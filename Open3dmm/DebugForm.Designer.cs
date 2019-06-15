namespace Open3dmm
{
    partial class DebugForm
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
            this.components = new System.ComponentModel.Container();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gptButton = new System.Windows.Forms.Button();
            this.gptList = new System.Windows.Forms.ListBox();
            this.mbmpList = new System.Windows.Forms.ListBox();
            this.mbmpInfo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 665);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(776, 145);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1000, 787);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gptButton
            // 
            this.gptButton.Location = new System.Drawing.Point(203, 636);
            this.gptButton.Name = "gptButton";
            this.gptButton.Size = new System.Drawing.Size(75, 23);
            this.gptButton.TabIndex = 2;
            this.gptButton.Text = "GPT Info";
            this.gptButton.UseVisualStyleBackColor = true;
            this.gptButton.Click += new System.EventHandler(this.GptButton_Click);
            // 
            // gptList
            // 
            this.gptList.FormattingEnabled = true;
            this.gptList.Location = new System.Drawing.Point(12, 522);
            this.gptList.Name = "gptList";
            this.gptList.Size = new System.Drawing.Size(266, 108);
            this.gptList.TabIndex = 3;
            this.gptList.SelectedIndexChanged += new System.EventHandler(this.GptList_SelectedIndexChanged);
            // 
            // mbmpList
            // 
            this.mbmpList.FormattingEnabled = true;
            this.mbmpList.Location = new System.Drawing.Point(284, 522);
            this.mbmpList.Name = "mbmpList";
            this.mbmpList.Size = new System.Drawing.Size(266, 108);
            this.mbmpList.TabIndex = 4;
            // 
            // mbmpInfo
            // 
            this.mbmpInfo.Location = new System.Drawing.Point(475, 636);
            this.mbmpInfo.Name = "mbmpInfo";
            this.mbmpInfo.Size = new System.Drawing.Size(75, 23);
            this.mbmpInfo.TabIndex = 5;
            this.mbmpInfo.Text = "MBMP Info";
            this.mbmpInfo.UseVisualStyleBackColor = true;
            this.mbmpInfo.Click += new System.EventHandler(this.MbmpInfo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(556, 522);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(556, 548);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(556, 575);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Draw Selected GPT";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 822);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mbmpInfo);
            this.Controls.Add(this.mbmpList);
            this.Controls.Add(this.gptList);
            this.Controls.Add(this.gptButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.Name = "DebugForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gptButton;
        public System.Windows.Forms.ListBox gptList;
        public System.Windows.Forms.ListBox mbmpList;
        private System.Windows.Forms.Button mbmpInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}