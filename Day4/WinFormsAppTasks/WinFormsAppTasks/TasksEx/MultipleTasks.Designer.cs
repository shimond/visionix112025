namespace WinFormsAppTasks.TasksEx
{
    partial class MultipleTasks
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
            btnTests = new Button();
            btnTest = new Button();
            SuspendLayout();
            // 
            // btnTests
            // 
            btnTests.Location = new Point(43, 30);
            btnTests.Name = "btnTests";
            btnTests.Size = new Size(94, 29);
            btnTests.TabIndex = 0;
            btnTests.Text = "Tasks";
            btnTests.UseVisualStyleBackColor = true;
            btnTests.Click += btnTests_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(167, 30);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(94, 29);
            btnTest.TabIndex = 1;
            btnTest.Text = "Parallel";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // MultipleTasks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTest);
            Controls.Add(btnTests);
            Name = "MultipleTasks";
            Text = "MultipleTasks";
            Load += MultipleTasks_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnTests;
        private Button btnTest;
    }
}