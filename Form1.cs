using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using Microsoft.WindowsAPICodePack.Dialogs;
using NationalInstruments.VisaNS;


delegate void delegatecall(string text); //Allows you to change text without a threading error well reading serial in

namespace SInclair_Loader
{
    public partial class Form1 : Form
    {
        string serialtext = "";
        int textlinecount = 0;
        string Forward_file = "none";
        string Reverse_file = "none";
        Boolean runSensor = false;
        Boolean runupdateSlabels = true;

        uint[] Mac_current = new uint[6];
        uint[] Mac_new = new uint[6];

        int Serial = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] resources = ResourceManager.GetLocalManager().FindResources("?*");
            foreach (string s in resources)
            {
                Debug.WriteLine(s);
               // availableResourcesListBox.Items.Add(s);
            }

        }



        private void textchange(string text)
        {
            //Creates a delegate object if threading is required to avoid error (invoke)
            if (this.textBox1.InvokeRequired)
            {
                delegatecall d = new delegatecall(textchange);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (text.Length > 0)
                {
                    //textlinecount++;
                    //if (textlinecount > 42)
                    //{
                    //    textBox1.Text = "";
                    //    textlinecount = 0;
                    //}
                    textBox1.Text += text + Constants.vbCrLf;
                }
                else
                {
                    textBox1.Text = "";
                    textlinecount = 0;
                }
            }

            serialtext = "";

        }

        private void F_select_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\PMS_CAL",
                Title = "Browse Calibration Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "s2p",
                Filter = "s2p files (*.s2p)|*.s2p",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Forward_file = openFileDialog1.FileName;
                Forward_name.Text = Forward_file;
                this.textchange("");
            }
        }

        private void R_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\PMS_CAL",
                Title = "Browse Calibration Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "s2p",
                Filter = "s2p files (*.s2p)|*.s2p",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Reverse_file = openFileDialog1.FileName;
                Reverse_name.Text = Reverse_file;
            }
        }


        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            //
            if (runSensor)
            {
                timer1.Enabled = false;

                run_Sensor_Parse();
                Sensor_make.Enabled = true;
                runSensor = false;

                timer1.Enabled = true;
            }

            //
            if (runupdateSlabels)
            {
                timer1.Enabled = false;

                updateSlabels();
                runupdateSlabels = false;

                timer1.Enabled = true;
            }
        }

        private void Sensor_make_Click(object sender, EventArgs e)
        {
            Sensor_make.BackColor = Color.Red;
            runSensor = true;
            Sensor_make.Enabled = false;
            Sensor_make.Focus();
        }

        private void run_Sensor_Parse()
        {
            //
            // this.textchange("");
            this.textchange("Working on Sensor File");

            DateTime localDate = DateTime.Now;
            string targetDir = string.Format(@"C:\PMS_CAL\Output");
            string targetusedDir = string.Format(@"C:\PMS_CAL\Used");

            Forward_file = Forward_name.Text;
            Reverse_file = Reverse_name.Text;

            string Forward_used = Forward_file.Insert(11, @"Used\");
            string Reverse_used = Reverse_file.Insert(11, @"Used\");


            //Check source files 
            if (!Directory.Exists(targetDir)) // Check drive
            {
                this.textchange("Target Directory " + targetDir + " does not exist");
                this.textchange(targetDir);
                System.Threading.Thread.Sleep(200);
                return;
            }

            //Forwards
            if (!File.Exists(Forward_file))
            {
                this.textchange("Forward Cal file " + Forward_file + " does not exist");
                System.Threading.Thread.Sleep(200);
                return;
            }

            if (File.Exists(Forward_used))
            {
                string message = "Forward File has been used, Overwrite ?";
                string title = "Already Used";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.No)
                {
                    return;
                }
            }


            //Reverses
            if (!File.Exists(Reverse_file))
            {
                this.textchange("Reverse Cal file " + Reverse_file + " does not exist");
                System.Threading.Thread.Sleep(200);
                return;
            }
            if (File.Exists(Reverse_used))
            {
                string message = "Reverse File has been used, Overwrite ?";
                string title = "Already Used";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            //Wriite Sensor file
            string makefile = string.Format(@"C:\PMS_CAL\Output\") + Sensor_serial.Text + ".cal";

            if (!File.Exists(makefile))
            {
                //this.textchange("Making to Sensor File");

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(makefile))
                {
                    sw.WriteLine("Started  " + localDate.ToString("G"));
                    sw.Close();
                }

                this.textchange("Dan makes work easy :)");
                System.Threading.Thread.Sleep(200);
                Sensor_make.BackColor = Color.LawnGreen;
            }
            else
            {
                this.textchange("Target File already exists !");
                System.Threading.Thread.Sleep(200);
                return;
            }


            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(Forward_file))
                using (StreamReader sr2 = new StreamReader(Reverse_file))
                using (StreamWriter sw = new StreamWriter(makefile))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = "";

                    line = sr.ReadLine();
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                    sw.WriteLine(line);


                    //First
                    while ((line = sr.ReadLine()) != null)
                    {
                        char test = line[0];
                        if (Char.IsDigit(test))
                        {
                            break;
                        }
                    }
                    string[] line_t = line.Split(null); //Or myStr.Split()

                    while ((line = sr2.ReadLine()) != null)
                    {
                        char test = line[0];
                        if (Char.IsDigit(test))
                        {
                            break;
                        }
                    }
                    string[] line_t2 = line.Split(null); //Or myStr.Split()

                    float forward_val = Makefloat(line_t[3]);
                    float reverse_val = Makefloat(line_t2[3]);

                    line = line_t[0] + "," + forward_val.ToString("0.000") + "," + reverse_val.ToString("0.000");
                    sw.WriteLine(line);

                    //The rest
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] line_split = line.Split(null);
                        line = sr2.ReadLine();
                        string[] line_split2 = line.Split(null);

                        forward_val = Makefloat(line_split[3]);
                        reverse_val = Makefloat(line_split2[3]);

                        line = line_split[0] + "," + forward_val.ToString("0.000") + "," + reverse_val.ToString("0.000") + ",";
                        sw.WriteLine(line);
                    }

                    sr.Close();
                    sr2.Close();
                    sw.Close();

                    File.Delete(Forward_used);
                    File.Move(Forward_file, Forward_used);

                    File.Delete(Reverse_used);
                    File.Move(Reverse_file, Reverse_used);

                }
            }
            catch (IOException e)
            {
                this.textchange("Sensor File failed !");
                System.Threading.Thread.Sleep(200);
                return;
                //  Console.WriteLine(e.Message);
            }


            this.textchange("Sensor File " + makefile + " Completed");
        }



        private float Makefloat(String test)
        {
            float value = 0;
            int expon = 0;
            string[] Test_S = test.Split('e');

            if (Test_S[1] != null)
            {
                string exponent = "";
                string test2 = Test_S[1];

                if (test2[0] == '+')
                {
                    exponent = test2.Substring(1);
                    expon = int.Parse(exponent);

                    value = float.Parse(Test_S[0]);
                    value = value * (-10 * expon);
                }
                else if (test2[0] == '-')
                {
                    exponent = test2.Substring(1);
                    expon = int.Parse(exponent);

                    value = float.Parse(Test_S[0]);
                    value = value / (-10 * expon);
                }
                else
                {
                    value = float.Parse(Test_S[0]) * -1;
                }

            }

            // Debug.WriteLine(value);
            return value;
        }

        private void updateSlabels()
        {
            string makefile = string.Format(@"C:\PMS_CAL\Serials\lastused.csv");

            try
            {
                using (StreamReader sr = new StreamReader(makefile))
                {

                    String line = "";
                    line = sr.ReadLine();

                    //Split
                    string[] Test = line.Split(',');
                    Last_serial.Text = Test[0];
                    last_mac.Text = Test[1] + "-" + Test[2] + "-" + Test[3] + "-" + Test[4] + "-" + Test[5] + "-" + Test[6];

                    string[] Test2 = Test[0].Split('_');

                    Serial = int.Parse(Test2[1]);
                    Debug.WriteLine(Serial.ToString("D6"));

                    sr.Close();

                    for (int i = 0; i < 6; i++)
                    {
                        Mac_current[i] = byte.Parse(Test[i + 1], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (IOException e)
            {
                this.textchange("Last Used File failed !");
                System.Threading.Thread.Sleep(200);
            }
        }

        private void MakeSerial_Click(object sender, EventArgs e)
        {
            Mac_current[5] += 2;
            if (Mac_current[5] > 255)
            {
                Mac_current[5] = Mac_current[5] - 255;
                Mac_current[4] += 1;

                if (Mac_current[4] > 255)
                {
                    Mac_current[4] = Mac_current[4] - 255;
                    Mac_current[3] += 1;

                    if (Mac_current[3] > 255)
                    {
                        Mac_current[3] = Mac_current[3] - 255;
                        Mac_current[2] += 1;
                    }
                }
            }

            string makefile = string.Format(@"C:\PMS_CAL\Serials\lastused.csv");

            using (StreamWriter sw = new StreamWriter(makefile))
            {
                String line = "";
                Serial += 1;
                line = "ITS110_" + Serial.ToString("D6") + "," + Mac_current[0].ToString("X2") + "," + Mac_current[1].ToString("X2") + "," + Mac_current[2].ToString("X2") + "," + Mac_current[3].ToString("X2") + "," + Mac_current[4].ToString("X2") + "," + Mac_current[5].ToString("X2") + ",";

                sw.WriteLine(line); ;

                sw.Close();
            }

            runupdateSlabels = true;

        }

        private void WEB_PKG_Click(object sender, EventArgs e)
        {
            WEB_PKG.BackColor = Color.Red;

            string version = Microsoft.VisualBasic.Interaction.InputBox("Version ?", "Input Version", "1_01");

            if (version == "")
            {
                return;
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "D:\\Documents\\Sinclair";
            dialog.IsFolderPicker = true;
            dialog.Title = "Select WEB package files directory";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                this.textchange("");
                string makefile = dialog.FileName + "\\WEB_PACK_V" + version + ".wpo";
                // this.textchange(makefile);

                FileStream sw = new FileStream(makefile, FileMode.Create, FileAccess.Write);

                //SinclairPMS
                byte[] FileCheck = new byte[] { 0x53, 0x69, 0x6e, 0x63, 0x6c, 0x61, 0x69, 0x72, 0x50, 0x4d, 0x53 };
                sw.Write(FileCheck, 0, 11);


                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(dialog.FileName);
                foreach (string fileName in fileEntries)
                {
                    var info = new System.IO.FileInfo(fileName);

                    if (info.Name.Contains("WEB_PACK"))
                    {
                        // this.textchange("makefile name");
                    }
                    else
                    {
                        this.textchange(info.Name + "   " + info.Length.ToString());

                        long F_lenght = info.Length;
                        string F_Name ="/" + info.Name;
                        byte F_N_lenght = (byte)F_Name.Length;
                        byte data = 0;

                        sw.WriteByte(F_N_lenght);

                        data = (byte)(F_lenght >> 16);
                        sw.WriteByte(data);

                        data = (byte)(F_lenght >> 8);
                        sw.WriteByte(data);

                        data = (byte)F_lenght;
                        sw.WriteByte(data);

                        for (int x = 0; x < F_N_lenght; x++)
                        {
                            sw.WriteByte((byte)F_Name[x]);
                        }

                        FileStream sr = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        sr.CopyTo(sw);
                        sr.Close();
                    }
                }
                sw.Close();



                //Encrypt file                                                                     **********************  NOTE THIS IS CFB 8, block, key, and IV size still 128 - BLAME MS !!! ******************
                //SinclairPMS2023!
                byte[] Key = new byte[] { 0x53, 0x69, 0x6e, 0x63, 0x6c, 0x61, 0x69, 0x72, 0x50, 0x4d, 0x53, 0x32, 0x30, 0x32, 0x33, 0x21 };

                //AVTCanadaDNeault
                byte[] IV = new byte[] { 0x41, 0x56, 0x54, 0x43, 0x61, 0x6e, 0x61, 0x64, 0x61, 0x44, 0x4e, 0x65, 0x61, 0x75, 0x6c, 0x74 };

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = Key;
                aes.IV = IV;
                aes.Mode = CipherMode.CFB;
                aes.Padding = PaddingMode.None;

                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

                string outFile = dialog.FileName + "\\WEB_PACK_V" + version + ".wpx";

                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    using (var outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        int count = 0;

                        int blockSizeBytes = 512;
                        byte[] dataIO = new byte[blockSizeBytes];

                        using (var inFs = new FileStream(makefile, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(dataIO, 0, blockSizeBytes);
                                outStreamEncrypted.Write(dataIO, 0, count);
                            } while (count > 0);
                        }
                        outStreamEncrypted.FlushFinalBlock();
                    }
                }

                File.Delete(makefile);

                ////Decrypt Test !!
                //byte[] KeyD = new byte[] { 0x53, 0x69, 0x6e, 0x63, 0x6c, 0x61, 0x69, 0x72, 0x50, 0x4d, 0x53, 0x32, 0x30, 0x32, 0x33, 0x21 };
                //byte[] IVD = new byte[] { 0x41, 0x56, 0x54, 0x43, 0x61, 0x6e, 0x61, 0x64, 0x61, 0x44, 0x4e, 0x65, 0x61, 0x75, 0x6c, 0x74 };

                //// Aes aesD = Aes.Create();

                //AesCryptoServiceProvider aesD = new AesCryptoServiceProvider();
                //aesD.Key = KeyD;
                //aesD.IV = IVD;
                // aesD.Mode = CipherMode.CFB;
                //aesD.Padding = PaddingMode.None;

                //ICryptoTransform transformD = aesD.CreateDecryptor(aesD.Key, aesD.IV);

                //string outFileD = dialog.FileName + "\\WEB_PACK_V" + version + ".wpd";

                //using (var inFs = new FileStream(outFile, FileMode.Open))
                //{
                //    using (var outFs = new FileStream(outFileD, FileMode.Create))
                //    {
                //        int count = 0;

                //        // blockSizeBytes can be any arbitrary size.
                //        int blockSizeBytesD = 512;
                //        byte[] dataD = new byte[blockSizeBytesD];

                //        using (var outStreamDecrypted = new CryptoStream(outFs, transformD, CryptoStreamMode.Write))
                //        {
                //            do
                //            {
                //                count = inFs.Read(dataD, 0, blockSizeBytesD);
                //                outStreamDecrypted.Write(dataD, 0, count);
                //            } while (count > 0);

                //            outStreamDecrypted.FlushFinalBlock();
                //        }
                //    }
                //}

                this.textchange("Package completed:");
                this.textchange(outFile);
                WEB_PKG.BackColor = Color.LawnGreen;
            }

            //END
        }

        private void FIRM_PKG_Click(object sender, EventArgs e)
        {
            FIRM_PKG.BackColor = Color.Red;

            string version = Microsoft.VisualBasic.Interaction.InputBox("Version ?", "Input Version", "2_01");

            if (version == "")
            {
                return;
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "D:\\Documents\\Sinclair";
            dialog.IsFolderPicker = true;
            dialog.Title = "Select FIRMWARE package file directory";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                this.textchange("");

                string makefile = dialog.FileName + "\\FIRM_PACK_V" + version + ".fpo";
                // this.textchange(makefile);

                FileStream sw = new FileStream(makefile, FileMode.Create, FileAccess.Write);

                //SinclairPMS write at start
                byte[] FileCheck = new byte[] { 0x53, 0x69, 0x6e, 0x63, 0x6c, 0x61, 0x69, 0x72, 0x50, 0x4d, 0x53 };
                sw.Write(FileCheck, 0, 11);

                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(dialog.FileName);
                foreach (string fileName in fileEntries)
                {
                    var info = new System.IO.FileInfo(fileName);

                    if (info.Name.Contains("FIRM_PACK"))
                    {
                        // this.textchange("makefile name");
                    }
                    else
                    {
                        this.textchange(info.Name + "   " + info.Length.ToString());

                        long F_lenght = info.Length;
                        string F_Name = "/" + info.Name;
                        byte F_N_lenght = (byte)F_Name.Length;
                        byte data = 0;

                        sw.WriteByte(F_N_lenght);

                        data = (byte)(F_lenght >> 16);
                        sw.WriteByte(data);

                        data = (byte)(F_lenght >> 8);
                        sw.WriteByte(data);

                        data = (byte)F_lenght;
                        sw.WriteByte(data);

                        for (int x = 0; x < F_N_lenght; x++)
                        {
                            sw.WriteByte((byte)F_Name[x]);
                        }

                        FileStream sr = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        sr.CopyTo(sw);
                        sr.Close();
                    }
                }
                sw.Close();



                //Encrypt file                                                                     **********************  NOTE THIS IS CFB 8, block, key, and IV size still 128 - BLAME MS !!! ******************
                //SinclairPMS2023!
                byte[] Key = new byte[] { 0x53, 0x69, 0x6e, 0x63, 0x6c, 0x61, 0x69, 0x72, 0x50, 0x4d, 0x53, 0x32, 0x30, 0x32, 0x33, 0x21 };

                //AVTCanadaDNeault
                byte[] IV = new byte[] { 0x41, 0x56, 0x54, 0x43, 0x61, 0x6e, 0x61, 0x64, 0x61, 0x44, 0x4e, 0x65, 0x61, 0x75, 0x6c, 0x74 };

                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = Key;
                aes.IV = IV;
                aes.Mode = CipherMode.CFB;
                aes.Padding = PaddingMode.None;

                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

                string outFile = dialog.FileName + "\\FIRM_PACK_V" + version + ".fpx";

                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    using (var outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        int count = 0;

                        int blockSizeBytes = 512;
                        byte[] dataIO = new byte[blockSizeBytes];

                        using (var inFs = new FileStream(makefile, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(dataIO, 0, blockSizeBytes);
                                outStreamEncrypted.Write(dataIO, 0, count);
                            } while (count > 0);
                        }
                        outStreamEncrypted.FlushFinalBlock();
                    }
                }

                File.Delete(makefile);

                this.textchange("Package completed:");
                this.textchange(outFile);
                FIRM_PKG.BackColor = Color.LawnGreen;
            }
        }
    }
}
