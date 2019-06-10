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
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gptButton = new System.Windows.Forms.Button();
            this.gptList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 627);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(776, 145);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1000, 749);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gptButton
            // 
            this.gptButton.Location = new System.Drawing.Point(919, 749);
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
            this.gptList.Location = new System.Drawing.Point(809, 627);
            this.gptList.Name = "gptList";
            this.gptList.Size = new System.Drawing.Size(266, 108);
            this.gptList.TabIndex = 3;
            this.gptList.SelectedIndexChanged += new System.EventHandler(this.GptList_SelectedIndexChanged);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 784);
            this.Controls.Add(this.gptList);
            this.Controls.Add(this.gptButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.Name = "DebugForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gptButton;
        public System.Windows.Forms.ListBox gptList;
    }
}