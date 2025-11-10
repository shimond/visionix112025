namespace AsyncAndMore
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
            textBoxStam = new TextBox();
            listBoxLogs = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxStam
            // 
            textBoxStam.Location = new Point(31, 377);
            textBoxStam.Name = "textBoxStam";
            textBoxStam.Size = new Size(734, 27);
            textBoxStam.TabIndex = 0;
            // 
            // listBoxLogs
            // 
            listBoxLogs.FormattingEnabled = true;
            listBoxLogs.Location = new Point(31, 65);
            listBoxLogs.Name = "listBoxLogs";
            listBoxLogs.Size = new Size(734, 264);
            listBoxLogs.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(620, 30);
            button1.Name = "button1";
            button1.Size = new Size(145, 29);
            button1.TabIndex = 2;
            button1.Text = "Start download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listBoxLogs);
            Controls.Add(textBoxStam);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxStam;
        private ListBox listBoxLogs;
        private Button button1;
    }
}
