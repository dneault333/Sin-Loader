﻿
namespace SInclair_Loader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Forward_name = new System.Windows.Forms.TextBox();
            this.Reverse_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.F_select = new System.Windows.Forms.Button();
            this.R_select = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Sensor_serial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Sensor_make = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Last_serial = new System.Windows.Forms.Label();
            this.last_mac = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MakeSerial = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.WEB_PKG = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.FIRM_PKG = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(821, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(488, 627);
            this.textBox1.TabIndex = 0;
            // 
            // Forward_name
            // 
            this.Forward_name.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Forward_name.Location = new System.Drawing.Point(12, 145);
            this.Forward_name.Name = "Forward_name";
            this.Forward_name.Size = new System.Drawing.Size(624, 29);
            this.Forward_name.TabIndex = 1;
            this.Forward_name.Text = "Forward_file.s2p";
            // 
            // Reverse_name
            // 
            this.Reverse_name.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Reverse_name.Location = new System.Drawing.Point(12, 232);
            this.Reverse_name.Name = "Reverse_name";
            this.Reverse_name.Size = new System.Drawing.Size(624, 29);
            this.Reverse_name.TabIndex = 1;
            this.Reverse_name.Text = "Reverse_file.s2p";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Forward Calibration File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reverse Calibration File";
            // 
            // F_select
            // 
            this.F_select.BackColor = System.Drawing.Color.SteelBlue;
            this.F_select.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.F_select.ForeColor = System.Drawing.Color.White;
            this.F_select.Location = new System.Drawing.Point(642, 140);
            this.F_select.Name = "F_select";
            this.F_select.Size = new System.Drawing.Size(151, 39);
            this.F_select.TabIndex = 3;
            this.F_select.Text = "SELECT";
            this.F_select.UseVisualStyleBackColor = false;
            this.F_select.Click += new System.EventHandler(this.F_select_Click);
            // 
            // R_select
            // 
            this.R_select.BackColor = System.Drawing.Color.SteelBlue;
            this.R_select.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_select.ForeColor = System.Drawing.Color.White;
            this.R_select.Location = new System.Drawing.Point(642, 227);
            this.R_select.Name = "R_select";
            this.R_select.Size = new System.Drawing.Size(151, 39);
            this.R_select.TabIndex = 3;
            this.R_select.Text = "SELECT";
            this.R_select.UseVisualStyleBackColor = false;
            this.R_select.Click += new System.EventHandler(this.R_select_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sensor_serial
            // 
            this.Sensor_serial.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sensor_serial.Location = new System.Drawing.Point(169, 316);
            this.Sensor_serial.Name = "Sensor_serial";
            this.Sensor_serial.Size = new System.Drawing.Size(624, 29);
            this.Sensor_serial.TabIndex = 1;
            this.Sensor_serial.Text = "CC######";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(169, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "SENSOR SERIAL NUMBER";
            // 
            // Sensor_make
            // 
            this.Sensor_make.BackColor = System.Drawing.Color.LawnGreen;
            this.Sensor_make.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Sensor_make.ForeColor = System.Drawing.Color.Black;
            this.Sensor_make.Location = new System.Drawing.Point(12, 294);
            this.Sensor_make.Name = "Sensor_make";
            this.Sensor_make.Size = new System.Drawing.Size(121, 74);
            this.Sensor_make.TabIndex = 4;
            this.Sensor_make.Text = "MAKE\r\nSENSOR\r\nFILE";
            this.Sensor_make.UseVisualStyleBackColor = false;
            this.Sensor_make.Click += new System.EventHandler(this.Sensor_make_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(-3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(823, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "=================================================================================" +
    "=======================================================";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "PMS Last Used Serial #";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(352, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "MAC Address";
            // 
            // Last_serial
            // 
            this.Last_serial.AutoSize = true;
            this.Last_serial.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Last_serial.ForeColor = System.Drawing.Color.Red;
            this.Last_serial.Location = new System.Drawing.Point(12, 45);
            this.Last_serial.Name = "Last_serial";
            this.Last_serial.Size = new System.Drawing.Size(168, 26);
            this.Last_serial.TabIndex = 7;
            this.Last_serial.Text = "ITS110_000000";
            // 
            // last_mac
            // 
            this.last_mac.AutoSize = true;
            this.last_mac.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.last_mac.ForeColor = System.Drawing.Color.Red;
            this.last_mac.Location = new System.Drawing.Point(352, 45);
            this.last_mac.Name = "last_mac";
            this.last_mac.Size = new System.Drawing.Size(196, 26);
            this.last_mac.TabIndex = 8;
            this.last_mac.Text = "54-08-3b-e0-00-00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(-3, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(823, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "=================================================================================" +
    "=======================================================";
            // 
            // MakeSerial
            // 
            this.MakeSerial.BackColor = System.Drawing.Color.LawnGreen;
            this.MakeSerial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MakeSerial.ForeColor = System.Drawing.Color.Black;
            this.MakeSerial.Location = new System.Drawing.Point(657, 9);
            this.MakeSerial.Name = "MakeSerial";
            this.MakeSerial.Size = new System.Drawing.Size(89, 74);
            this.MakeSerial.TabIndex = 10;
            this.MakeSerial.Text = "New Serial";
            this.MakeSerial.UseVisualStyleBackColor = false;
            this.MakeSerial.Click += new System.EventHandler(this.MakeSerial_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(-3, 486);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(823, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "=================================================================================" +
    "=======================================================";
            // 
            // WEB_PKG
            // 
            this.WEB_PKG.BackColor = System.Drawing.Color.LawnGreen;
            this.WEB_PKG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WEB_PKG.ForeColor = System.Drawing.Color.Black;
            this.WEB_PKG.Location = new System.Drawing.Point(12, 424);
            this.WEB_PKG.Name = "WEB_PKG";
            this.WEB_PKG.Size = new System.Drawing.Size(105, 59);
            this.WEB_PKG.TabIndex = 12;
            this.WEB_PKG.Text = "MAKE WEB PACKAGE";
            this.WEB_PKG.UseVisualStyleBackColor = false;
            this.WEB_PKG.Click += new System.EventHandler(this.WEB_PKG_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "UPDATE PACKAGES";
            // 
            // FIRM_PKG
            // 
            this.FIRM_PKG.BackColor = System.Drawing.Color.LawnGreen;
            this.FIRM_PKG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FIRM_PKG.ForeColor = System.Drawing.Color.Black;
            this.FIRM_PKG.Location = new System.Drawing.Point(169, 424);
            this.FIRM_PKG.Name = "FIRM_PKG";
            this.FIRM_PKG.Size = new System.Drawing.Size(105, 59);
            this.FIRM_PKG.TabIndex = 12;
            this.FIRM_PKG.Text = "MAKE FIRMWARE PACKAGE";
            this.FIRM_PKG.UseVisualStyleBackColor = false;
            this.FIRM_PKG.Click += new System.EventHandler(this.FIRM_PKG_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 741);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FIRM_PKG);
            this.Controls.Add(this.WEB_PKG);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MakeSerial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.last_mac);
            this.Controls.Add(this.Last_serial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Sensor_make);
            this.Controls.Add(this.R_select);
            this.Controls.Add(this.F_select);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sensor_serial);
            this.Controls.Add(this.Reverse_name);
            this.Controls.Add(this.Forward_name);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Sinclair Intelli Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Forward_name;
        private System.Windows.Forms.TextBox Reverse_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button F_select;
        private System.Windows.Forms.Button R_select;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Sensor_serial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Sensor_make;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Last_serial;
        private System.Windows.Forms.Label last_mac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button MakeSerial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button WEB_PKG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button FIRM_PKG;
    }
}
