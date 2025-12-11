namespace WinFormsAppTasks
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
            txtSearch = new TextBox();
            label1 = new Label();
            button1 = new Button();
            listView1 = new ListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderFileSize = new ColumnHeader();
            columnHeaderLastModified = new ColumnHeader();
            btnStop = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(131, 31);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(241, 27);
            txtSearch.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 34);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 1;
            label1.Text = "Search:";
            // 
            // button1
            // 
            button1.Location = new Point(390, 34);
            button1.Name = "button1";
            button1.Size = new Size(91, 25);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderFileSize, columnHeaderLastModified });
            listView1.Location = new Point(45, 117);
            listView1.Name = "listView1";
            listView1.Size = new Size(913, 427);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "FileName";
            columnHeaderFileName.Width = 240;
            // 
            // columnHeaderFileSize
            // 
            columnHeaderFileSize.Text = "File size";
            columnHeaderFileSize.Width = 240;
            // 
            // columnHeaderLastModified
            // 
            columnHeaderLastModified.Text = "Last Modified";
            columnHeaderLastModified.Width = 240;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(506, 34);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(91, 25);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 566);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1005, 26);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(151, 20);
            lblStatus.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 592);
            Controls.Add(statusStrip1);
            Controls.Add(btnStop);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            DoubleBuffered = true;
            Name = "Form1";
            FormClosing += Form1_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Label label1;
        private Button button1;
        private ListView listView1;
        private ColumnHeader columnHeaderFileName;
        private ColumnHeader columnHeaderFileSize;
        private ColumnHeader columnHeaderLastModified;
        private Button btnStop;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
