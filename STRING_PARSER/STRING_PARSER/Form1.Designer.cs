﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label_e = new System.Windows.Forms.Label();
            this.Label_M = new System.Windows.Forms.Label();
            this.e_Field = new System.Windows.Forms.TextBox();
            this.M_Field = new System.Windows.Forms.TextBox();
            this.bige_Field = new System.Windows.Forms.TextBox();
            this.Label_bige = new System.Windows.Forms.Label();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Log_Box = new System.Windows.Forms.TextBox();
            this.note1 = new System.Windows.Forms.Label();
            this.note2 = new System.Windows.Forms.Label();
            this.Label_th = new System.Windows.Forms.Label();
            this.th_Field = new System.Windows.Forms.TextBox();
            this.Label_Port = new System.Windows.Forms.Label();
            this.Label_BR = new System.Windows.Forms.Label();
            this.Get_Port = new System.Windows.Forms.ComboBox();
            this.Get_BR = new System.Windows.Forms.ComboBox();
            this.Health_Box = new System.Windows.Forms.TextBox();
            this.Health_Button = new System.Windows.Forms.Button();
            this.Time_Field = new System.Windows.Forms.TextBox();
            this.Last_Update = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.flushbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_e
            // 
            this.Label_e.AutoSize = true;
            this.Label_e.Location = new System.Drawing.Point(51, 66);
            this.Label_e.Name = "Label_e";
            this.Label_e.Size = new System.Drawing.Size(13, 13);
            this.Label_e.TabIndex = 0;
            this.Label_e.Text = "e";
            // 
            // Label_M
            // 
            this.Label_M.AutoSize = true;
            this.Label_M.Location = new System.Drawing.Point(51, 105);
            this.Label_M.Name = "Label_M";
            this.Label_M.Size = new System.Drawing.Size(16, 13);
            this.Label_M.TabIndex = 1;
            this.Label_M.Text = "M";
            // 
            // e_Field
            // 
            this.e_Field.Location = new System.Drawing.Point(12, 82);
            this.e_Field.MaxLength = 5;
            this.e_Field.Name = "e_Field";
            this.e_Field.Size = new System.Drawing.Size(100, 20);
            this.e_Field.TabIndex = 2;
            this.e_Field.TextChanged += new System.EventHandler(this.A_Field_TextChanged);
            // 
            // M_Field
            // 
            this.M_Field.Location = new System.Drawing.Point(12, 121);
            this.M_Field.MaxLength = 5;
            this.M_Field.Name = "M_Field";
            this.M_Field.Size = new System.Drawing.Size(100, 20);
            this.M_Field.TabIndex = 3;
            // 
            // bige_Field
            // 
            this.bige_Field.Location = new System.Drawing.Point(172, 124);
            this.bige_Field.MaxLength = 32;
            this.bige_Field.Multiline = true;
            this.bige_Field.Name = "bige_Field";
            this.bige_Field.ReadOnly = true;
            this.bige_Field.Size = new System.Drawing.Size(100, 20);
            this.bige_Field.TabIndex = 4;
            // 
            // Label_bige
            // 
            this.Label_bige.AutoSize = true;
            this.Label_bige.Location = new System.Drawing.Point(219, 108);
            this.Label_bige.Name = "Label_bige";
            this.Label_bige.Size = new System.Drawing.Size(14, 13);
            this.Label_bige.TabIndex = 5;
            this.Label_bige.Text = "E";
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(25, 163);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(75, 23);
            this.Send_Button.TabIndex = 6;
            this.Send_Button.Text = "SEND";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // Log_Box
            // 
            this.Log_Box.Location = new System.Drawing.Point(12, 331);
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.ReadOnly = true;
            this.Log_Box.Size = new System.Drawing.Size(260, 20);
            this.Log_Box.TabIndex = 7;
            // 
            // note1
            // 
            this.note1.AutoSize = true;
            this.note1.Location = new System.Drawing.Point(118, 85);
            this.note1.Name = "note1";
            this.note1.Size = new System.Drawing.Size(37, 13);
            this.note1.TabIndex = 9;
            this.note1.Text = "0<e<1";
            // 
            // note2
            // 
            this.note2.AutoSize = true;
            this.note2.Location = new System.Drawing.Point(118, 124);
            this.note2.Name = "note2";
            this.note2.Size = new System.Drawing.Size(40, 13);
            this.note2.TabIndex = 10;
            this.note2.Text = "0<M<1";
            // 
            // Label_th
            // 
            this.Label_th.AutoSize = true;
            this.Label_th.Location = new System.Drawing.Point(219, 69);
            this.Label_th.Name = "Label_th";
            this.Label_th.Size = new System.Drawing.Size(13, 13);
            this.Label_th.TabIndex = 11;
            this.Label_th.Text = "θ";
            // 
            // th_Field
            // 
            this.th_Field.Location = new System.Drawing.Point(172, 85);
            this.th_Field.MaxLength = 32;
            this.th_Field.Multiline = true;
            this.th_Field.Name = "th_Field";
            this.th_Field.ReadOnly = true;
            this.th_Field.Size = new System.Drawing.Size(100, 20);
            this.th_Field.TabIndex = 12;
            this.th_Field.TextChanged += new System.EventHandler(this.th_Field_TextChanged);
            // 
            // Label_Port
            // 
            this.Label_Port.AutoSize = true;
            this.Label_Port.Location = new System.Drawing.Point(41, 20);
            this.Label_Port.Name = "Label_Port";
            this.Label_Port.Size = new System.Drawing.Size(37, 13);
            this.Label_Port.TabIndex = 13;
            this.Label_Port.Text = "PORT";
            // 
            // Label_BR
            // 
            this.Label_BR.AutoSize = true;
            this.Label_BR.Location = new System.Drawing.Point(114, 21);
            this.Label_BR.Name = "Label_BR";
            this.Label_BR.Size = new System.Drawing.Size(69, 13);
            this.Label_BR.TabIndex = 14;
            this.Label_BR.Text = "BAUD RATE";
            // 
            // Get_Port
            // 
            this.Get_Port.FormattingEnabled = true;
            this.Get_Port.Location = new System.Drawing.Point(25, 36);
            this.Get_Port.Name = "Get_Port";
            this.Get_Port.Size = new System.Drawing.Size(67, 21);
            this.Get_Port.TabIndex = 15;
            this.Get_Port.SelectedIndexChanged += new System.EventHandler(this.Get_Port_SelectedIndexChanged);
            // 
            // Get_BR
            // 
            this.Get_BR.FormattingEnabled = true;
            this.Get_BR.Items.AddRange(new object[] {
            "4800",
            "9600",
            "115200"});
            this.Get_BR.Location = new System.Drawing.Point(118, 36);
            this.Get_BR.Name = "Get_BR";
            this.Get_BR.Size = new System.Drawing.Size(61, 21);
            this.Get_BR.TabIndex = 16;
            this.Get_BR.SelectedIndexChanged += new System.EventHandler(this.Get_BR_SelectedIndexChanged);
            // 
            // Health_Box
            // 
            this.Health_Box.Location = new System.Drawing.Point(12, 216);
            this.Health_Box.Multiline = true;
            this.Health_Box.Name = "Health_Box";
            this.Health_Box.Size = new System.Drawing.Size(179, 80);
            this.Health_Box.TabIndex = 17;
            // 
            // Health_Button
            // 
            this.Health_Button.Location = new System.Drawing.Point(197, 216);
            this.Health_Button.Name = "Health_Button";
            this.Health_Button.Size = new System.Drawing.Size(75, 80);
            this.Health_Button.TabIndex = 18;
            this.Health_Button.Text = "GET HEALTH";
            this.Health_Button.UseVisualStyleBackColor = true;
            this.Health_Button.Click += new System.EventHandler(this.Health_Button_Click);
            // 
            // Time_Field
            // 
            this.Time_Field.Location = new System.Drawing.Point(114, 302);
            this.Time_Field.Name = "Time_Field";
            this.Time_Field.ReadOnly = true;
            this.Time_Field.Size = new System.Drawing.Size(77, 20);
            this.Time_Field.TabIndex = 19;
            // 
            // Last_Update
            // 
            this.Last_Update.AutoSize = true;
            this.Last_Update.Location = new System.Drawing.Point(13, 305);
            this.Last_Update.Name = "Last_Update";
            this.Last_Update.Size = new System.Drawing.Size(95, 13);
            this.Last_Update.TabIndex = 20;
            this.Last_Update.Text = "LAST UPDATED :";
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(197, 36);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 23);
            this.connect_button.TabIndex = 21;
            this.connect_button.Text = "CONNECT";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click_1);
            // 
            // flushbutton
            // 
            this.flushbutton.Location = new System.Drawing.Point(197, 163);
            this.flushbutton.Name = "flushbutton";
            this.flushbutton.Size = new System.Drawing.Size(75, 23);
            this.flushbutton.TabIndex = 22;
            this.flushbutton.Text = "FLUSH";
            this.flushbutton.UseVisualStyleBackColor = true;
            this.flushbutton.Click += new System.EventHandler(this.flushbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 366);
            this.Controls.Add(this.flushbutton);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.Last_Update);
            this.Controls.Add(this.Time_Field);
            this.Controls.Add(this.Health_Button);
            this.Controls.Add(this.Health_Box);
            this.Controls.Add(this.Get_BR);
            this.Controls.Add(this.Get_Port);
            this.Controls.Add(this.Label_BR);
            this.Controls.Add(this.Label_Port);
            this.Controls.Add(this.th_Field);
            this.Controls.Add(this.Label_th);
            this.Controls.Add(this.note2);
            this.Controls.Add(this.note1);
            this.Controls.Add(this.Log_Box);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.Label_bige);
            this.Controls.Add(this.bige_Field);
            this.Controls.Add(this.M_Field);
            this.Controls.Add(this.e_Field);
            this.Controls.Add(this.Label_M);
            this.Controls.Add(this.Label_e);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "S P C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_e;
        private System.Windows.Forms.Label Label_M;
        private System.Windows.Forms.TextBox e_Field;
        private System.Windows.Forms.TextBox M_Field;
        private System.Windows.Forms.TextBox bige_Field;
        private System.Windows.Forms.Label Label_bige;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.TextBox Log_Box;
        private System.Windows.Forms.Label note1;
        private System.Windows.Forms.Label note2;
        private System.Windows.Forms.Label Label_th;
        private System.Windows.Forms.TextBox th_Field;
        private System.Windows.Forms.Label Label_Port;
        private System.Windows.Forms.Label Label_BR;
        private System.Windows.Forms.ComboBox Get_Port;
        private System.Windows.Forms.ComboBox Get_BR;
        private System.Windows.Forms.TextBox Health_Box;
        private System.Windows.Forms.Button Health_Button;
        private System.Windows.Forms.TextBox Time_Field;
        private System.Windows.Forms.Label Last_Update;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button flushbutton;
    }
}

