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
            this.openIndexDialog = new System.Windows.Forms.Button();
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openSaveDialog = new System.Windows.Forms.Button();
            this.saveFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.copyToFolderButton = new System.Windows.Forms.Button();
            this.indexFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Open File";
            // 
            // openIndexDialog
            // 
            this.openIndexDialog.Location = new System.Drawing.Point(467, 12);
            this.openIndexDialog.Name = "openIndexDialog";
            this.openIndexDialog.Size = new System.Drawing.Size(145, 23);
            this.openIndexDialog.TabIndex = 0;
            this.openIndexDialog.Text = "Choose Index File...";
            this.openIndexDialog.UseVisualStyleBackColor = true;
            this.openIndexDialog.Click += new System.EventHandler(this.chooseIndexFileButton_Click);
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.assetsTreeView.CausesValidation = false;
            this.assetsTreeView.CheckBoxes = true;
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.Size = new System.Drawing.Size(657, 305);
            this.assetsTreeView.TabIndex = 1;
            this.assetsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.assetsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choose Save Folder";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // openSaveDialog
            // 
            this.openSaveDialog.Location = new System.Drawing.Point(535, 415);
            this.openSaveDialog.Name = "openSaveDialog";
            this.openSaveDialog.Size = new System.Drawing.Size(114, 23);
            this.openSaveDialog.TabIndex = 0;
            this.openSaveDialog.Text = "Choose Folder...";
            this.openSaveDialog.UseVisualStyleBackColor = true;
            this.openSaveDialog.Click += new System.EventHandler(this.saveToFolderButton_Click);
            // 
            // saveFilePathTextBox
            // 
            this.saveFilePathTextBox.Location = new System.Drawing.Point(283, 418);
            this.saveFilePathTextBox.Name = "saveFilePathTextBox";
            this.saveFilePathTextBox.Size = new System.Drawing.Size(246, 20);
            this.saveFilePathTextBox.TabIndex = 2;
            this.saveFilePathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateFilePath);
            this.saveFilePathTextBox.Validated += new System.EventHandler(this.saveFilePathTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Save To Folder";
            // 
            // copyToFolderButton
            // 
            this.copyToFolderButton.Location = new System.Drawing.Point(655, 415);
            this.copyToFolderButton.Name = "copyToFolderButton";
            this.copyToFolderButton.Size = new System.Drawing.Size(119, 23);
            this.copyToFolderButton.TabIndex = 4;
            this.copyToFolderButton.Text = "Copy To Folder";
            this.copyToFolderButton.UseVisualStyleBackColor = true;
            this.copyToFolderButton.Click += new System.EventHandler(this.copyToFolderButton_Click);
            // 
            // indexFilePathTextBox
            // 
            this.indexFilePathTextBox.Location = new System.Drawing.Point(215, 15);
            this.indexFilePathTextBox.Name = "indexFilePathTextBox";
            this.indexFilePathTextBox.Size = new System.Drawing.Size(246, 20);
            this.indexFilePathTextBox.TabIndex = 2;
            this.indexFilePathTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateFilePath);
            this.indexFilePathTextBox.Validated += new System.EventHandler(this.indexFilePathTextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Index File";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.selectAllCheckBox);
            this.panel1.Controls.Add(this.assetsTreeView);
            this.panel1.Location = new System.Drawing.Point(75, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 328);
            this.panel1.TabIndex = 5;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.selectAllCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectAllCheckBox.Location = new System.Drawing.Point(0, 311);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(657, 17);
            this.selectAllCheckBox.TabIndex = 2;
            this.selectAllCheckBox.Text = "Select All";
            this.selectAllCheckBox.UseVisualStyleBackColor = false;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.copyToFolderButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indexFilePathTextBox);
            this.Controls.Add(this.saveFilePathTextBox);
            this.Controls.Add(this.openSaveDialog);
            this.Controls.Add(this.openIndexDialog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openIndexDialog;
        private System.Windows.Forms.TreeView assetsTreeView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button openSaveDialog;
        private System.Windows.Forms.TextBox saveFilePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copyToFolderButton;
        private System.Windows.Forms.TextBox indexFilePathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
    }
}

