namespace MinecraftJavaAudioExtractor
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chooseIndexFileButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveToFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Open File";
            // 
            // chooseIndexFileButton
            // 
            this.chooseIndexFileButton.Location = new System.Drawing.Point(97, 12);
            this.chooseIndexFileButton.Name = "chooseIndexFileButton";
            this.chooseIndexFileButton.Size = new System.Drawing.Size(200, 23);
            this.chooseIndexFileButton.TabIndex = 0;
            this.chooseIndexFileButton.Text = "Choose Index File...";
            this.chooseIndexFileButton.UseVisualStyleBackColor = true;
            this.chooseIndexFileButton.Click += new System.EventHandler(this.chooseIndexFileButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(97, 97);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(380, 190);
            this.treeView1.TabIndex = 1;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choose Save Folder";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // saveToFolderButton
            // 
            this.saveToFolderButton.Location = new System.Drawing.Point(97, 350);
            this.saveToFolderButton.Name = "saveToFolderButton";
            this.saveToFolderButton.Size = new System.Drawing.Size(114, 23);
            this.saveToFolderButton.TabIndex = 0;
            this.saveToFolderButton.Text = "Save To Folder...";
            this.saveToFolderButton.UseVisualStyleBackColor = true;
            this.saveToFolderButton.Click += new System.EventHandler(this.saveToFolderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.saveToFolderButton);
            this.Controls.Add(this.chooseIndexFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button chooseIndexFileButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button saveToFolderButton;
    }
}

