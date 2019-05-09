namespace WindowsFormsApplication3
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
            this.fcfs = new System.Windows.Forms.RadioButton();
            this.priorty = new System.Windows.Forms.RadioButton();
            this.roundrobbin = new System.Windows.Forms.RadioButton();
            this.shortfirst = new System.Windows.Forms.RadioButton();
            this.method = new System.Windows.Forms.GroupBox();
            this.prem_priorty = new System.Windows.Forms.RadioButton();
            this.srtf = new System.Windows.Forms.RadioButton();
            this.tabcnt = new System.Windows.Forms.TabControl();
            this.config = new System.Windows.Forms.TabPage();
            this.quantum = new System.Windows.Forms.TextBox();
            this.priorty_list = new System.Windows.Forms.GroupBox();
            this.number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.GroupBox();
            this.arrival = new System.Windows.Forms.GroupBox();
            this.go = new System.Windows.Forms.Button();
            this.gantt = new System.Windows.Forms.TabPage();
            this.method.SuspendLayout();
            this.tabcnt.SuspendLayout();
            this.config.SuspendLayout();
            this.SuspendLayout();
            // 
            // fcfs
            // 
            this.fcfs.AutoSize = true;
            this.fcfs.Checked = true;
            this.fcfs.Location = new System.Drawing.Point(0, 31);
            this.fcfs.Margin = new System.Windows.Forms.Padding(2);
            this.fcfs.Name = "fcfs";
            this.fcfs.Size = new System.Drawing.Size(51, 17);
            this.fcfs.TabIndex = 0;
            this.fcfs.TabStop = true;
            this.fcfs.Text = "FCFS";
            this.fcfs.UseVisualStyleBackColor = true;
            this.fcfs.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // priorty
            // 
            this.priorty.AutoSize = true;
            this.priorty.Location = new System.Drawing.Point(1, 119);
            this.priorty.Margin = new System.Windows.Forms.Padding(2);
            this.priorty.Name = "priorty";
            this.priorty.Size = new System.Drawing.Size(54, 17);
            this.priorty.TabIndex = 1;
            this.priorty.Text = "Priorty";
            this.priorty.UseVisualStyleBackColor = true;
            this.priorty.CheckedChanged += new System.EventHandler(this.priorty_CheckedChanged);
            // 
            // roundrobbin
            // 
            this.roundrobbin.AutoSize = true;
            this.roundrobbin.Location = new System.Drawing.Point(0, 53);
            this.roundrobbin.Margin = new System.Windows.Forms.Padding(2);
            this.roundrobbin.Name = "roundrobbin";
            this.roundrobbin.Size = new System.Drawing.Size(94, 17);
            this.roundrobbin.TabIndex = 2;
            this.roundrobbin.Text = "Round Robbin";
            this.roundrobbin.UseVisualStyleBackColor = true;
            this.roundrobbin.CheckedChanged += new System.EventHandler(this.roundrobbin_CheckedChanged);
            // 
            // shortfirst
            // 
            this.shortfirst.AutoSize = true;
            this.shortfirst.Location = new System.Drawing.Point(0, 75);
            this.shortfirst.Margin = new System.Windows.Forms.Padding(2);
            this.shortfirst.Name = "shortfirst";
            this.shortfirst.Size = new System.Drawing.Size(43, 17);
            this.shortfirst.TabIndex = 3;
            this.shortfirst.Text = "SJF";
            this.shortfirst.UseVisualStyleBackColor = true;
            // 
            // method
            // 
            this.method.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.method.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.method.Controls.Add(this.prem_priorty);
            this.method.Controls.Add(this.srtf);
            this.method.Controls.Add(this.fcfs);
            this.method.Controls.Add(this.shortfirst);
            this.method.Controls.Add(this.priorty);
            this.method.Controls.Add(this.roundrobbin);
            this.method.Location = new System.Drawing.Point(6, 14);
            this.method.Margin = new System.Windows.Forms.Padding(2);
            this.method.Name = "method";
            this.method.Padding = new System.Windows.Forms.Padding(2);
            this.method.Size = new System.Drawing.Size(94, 166);
            this.method.TabIndex = 4;
            this.method.TabStop = false;
            this.method.Text = " Method";
            this.method.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // prem_priorty
            // 
            this.prem_priorty.AutoSize = true;
            this.prem_priorty.Location = new System.Drawing.Point(1, 141);
            this.prem_priorty.Margin = new System.Windows.Forms.Padding(2);
            this.prem_priorty.Name = "prem_priorty";
            this.prem_priorty.Size = new System.Drawing.Size(96, 17);
            this.prem_priorty.TabIndex = 5;
            this.prem_priorty.TabStop = true;
            this.prem_priorty.Text = "premtive priorty";
            this.prem_priorty.UseVisualStyleBackColor = true;
            this.prem_priorty.CheckedChanged += new System.EventHandler(this.prem_priorty_CheckedChanged);
            // 
            // srtf
            // 
            this.srtf.AutoSize = true;
            this.srtf.Location = new System.Drawing.Point(1, 98);
            this.srtf.Margin = new System.Windows.Forms.Padding(2);
            this.srtf.Name = "srtf";
            this.srtf.Size = new System.Drawing.Size(53, 17);
            this.srtf.TabIndex = 4;
            this.srtf.TabStop = true;
            this.srtf.Text = "SRTF";
            this.srtf.UseVisualStyleBackColor = true;
            // 
            // tabcnt
            // 
            this.tabcnt.Controls.Add(this.config);
            this.tabcnt.Controls.Add(this.gantt);
            this.tabcnt.Location = new System.Drawing.Point(0, 0);
            this.tabcnt.Margin = new System.Windows.Forms.Padding(2);
            this.tabcnt.Name = "tabcnt";
            this.tabcnt.SelectedIndex = 0;
            this.tabcnt.Size = new System.Drawing.Size(486, 401);
            this.tabcnt.TabIndex = 5;
            // 
            // config
            // 
            this.config.AutoScroll = true;
            this.config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.config.Controls.Add(this.quantum);
            this.config.Controls.Add(this.priorty_list);
            this.config.Controls.Add(this.number);
            this.config.Controls.Add(this.label1);
            this.config.Controls.Add(this.time);
            this.config.Controls.Add(this.arrival);
            this.config.Controls.Add(this.go);
            this.config.Controls.Add(this.method);
            this.config.Location = new System.Drawing.Point(4, 22);
            this.config.Margin = new System.Windows.Forms.Padding(2);
            this.config.Name = "config";
            this.config.Padding = new System.Windows.Forms.Padding(2);
            this.config.Size = new System.Drawing.Size(478, 375);
            this.config.TabIndex = 0;
            this.config.Text = "configuration";
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // quantum
            // 
            this.quantum.Location = new System.Drawing.Point(5, 185);
            this.quantum.Name = "quantum";
            this.quantum.Size = new System.Drawing.Size(65, 20);
            this.quantum.TabIndex = 12;
            // 
            // priorty_list
            // 
            this.priorty_list.AutoSize = true;
            this.priorty_list.Enabled = false;
            this.priorty_list.Location = new System.Drawing.Point(373, 14);
            this.priorty_list.Margin = new System.Windows.Forms.Padding(2);
            this.priorty_list.Name = "priorty_list";
            this.priorty_list.Padding = new System.Windows.Forms.Padding(2);
            this.priorty_list.Size = new System.Drawing.Size(83, 55);
            this.priorty_list.TabIndex = 11;
            this.priorty_list.TabStop = false;
            this.priorty_list.Text = "Priorty";
            this.priorty_list.Enter += new System.EventHandler(this.priort_list_Enter);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(7, 240);
            this.number.Margin = new System.Windows.Forms.Padding(2);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(76, 20);
            this.number.TabIndex = 10;
            this.number.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Number of Process :";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(238, 14);
            this.time.Margin = new System.Windows.Forms.Padding(2);
            this.time.Name = "time";
            this.time.Padding = new System.Windows.Forms.Padding(2);
            this.time.Size = new System.Drawing.Size(76, 55);
            this.time.TabIndex = 8;
            this.time.TabStop = false;
            this.time.Text = "CPU burst";
            this.time.Enter += new System.EventHandler(this.time_Enter);
            // 
            // arrival
            // 
            this.arrival.AutoSize = true;
            this.arrival.Location = new System.Drawing.Point(116, 14);
            this.arrival.Margin = new System.Windows.Forms.Padding(2);
            this.arrival.Name = "arrival";
            this.arrival.Padding = new System.Windows.Forms.Padding(2);
            this.arrival.Size = new System.Drawing.Size(78, 55);
            this.arrival.TabIndex = 7;
            this.arrival.TabStop = false;
            this.arrival.Text = "Arrival time";
            this.arrival.Enter += new System.EventHandler(this.arrival_Enter_1);
            // 
            // go
            // 
            this.go.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.go.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.go.Location = new System.Drawing.Point(1, 264);
            this.go.Margin = new System.Windows.Forms.Padding(2);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(107, 28);
            this.go.TabIndex = 5;
            this.go.Text = "Genrate Gantt";
            this.go.UseVisualStyleBackColor = false;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // gantt
            // 
            this.gantt.AutoScroll = true;
            this.gantt.BackColor = System.Drawing.SystemColors.Control;
            this.gantt.Location = new System.Drawing.Point(4, 22);
            this.gantt.Margin = new System.Windows.Forms.Padding(2);
            this.gantt.Name = "gantt";
            this.gantt.Padding = new System.Windows.Forms.Padding(2);
            this.gantt.Size = new System.Drawing.Size(1100, 375);
            this.gantt.TabIndex = 1;
            this.gantt.Text = "Gantt";
            this.gantt.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(489, 403);
            this.Controls.Add(this.tabcnt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.method.ResumeLayout(false);
            this.method.PerformLayout();
            this.tabcnt.ResumeLayout(false);
            this.config.ResumeLayout(false);
            this.config.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton fcfs;
        private System.Windows.Forms.RadioButton priorty;
        private System.Windows.Forms.RadioButton roundrobbin;
        private System.Windows.Forms.RadioButton shortfirst;
        private System.Windows.Forms.GroupBox method;
        private System.Windows.Forms.TabControl tabcnt;
        private System.Windows.Forms.TabPage config;
        private System.Windows.Forms.TabPage gantt;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.GroupBox time;
        private System.Windows.Forms.GroupBox arrival;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox priorty_list;
        private System.Windows.Forms.RadioButton srtf;
        private System.Windows.Forms.RadioButton prem_priorty;
        private System.Windows.Forms.TextBox quantum;
        

    }
}

