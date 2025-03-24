using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// Using a index file (selected by user) in the .minecraft > assets > indexes folder, this
// program extracts all the audio files from the
// .minecraft > assets > objects folder and saves them in a new folder.

namespace MinecraftJavaAudioExtractor
{
    public partial class MinecraftJavaAssetsExtractor : Form
    {
        public struct AssetFile
        {
            public string path;
            public string hash;
            public AssetFile(string hash, string path)
            {
                this.hash = hash;
                this.path = path;
            }
        }
        AssetFile[] assetFiles;
        string indexFilePath;
        string saveFilePath;

        bool isProgramClosing = false;
        public MinecraftJavaAssetsExtractor()
        {
            if (Directory.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\assets\indexes"))
            {
                indexFilePath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\assets\\indexes";
            }
            else
            {
                Console.WriteLine("Warning: could not find default \".minecraft\" folder.");
            }
            InitializeComponent();
        }

        private void chooseIndexFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Index files (*.json)|*.json";
            openFileDialog1.InitialDirectory = indexFilePath;
            openFileDialog1.ShowDialog();
            indexFilePath = openFileDialog1.FileName; // FileName returns entire path, not just the file name
            if (indexFilePath != "")
            {
                indexFilePathTextBox.Text = indexFilePath;
                LoadIndexFile(indexFilePath);
                Console.WriteLine("Index file path is set to: " + indexFilePath);
                LoadIndexFile(indexFilePath);
            }
        }

        private void LoadIndexFile(string indexFilePath)
        {
            string contents = File.ReadAllText(indexFilePath).Replace(" ", ""); // entire file as string
            string[] entries = contents.Split(new string[] { "}," }, StringSplitOptions.None); // split by "}," to get each audio file AudioFile data structure
            assetFiles = new AssetFile[entries.Length];

            string[] tempPaths = new string[entries.Length];
            string[] tempHashes = new string[entries.Length];
            for (int i = 0; i < entries.Length; i++)
            {
                tempPaths[i] = entries[i].Split(new string[] { "\"" }, StringSplitOptions.None)[1]; // get text after first '"' to get path (which is index 1)

                tempHashes[i] = entries[i].Split(new string[] { "\"hash\":\"", "\"" }, StringSplitOptions.None)[3]; // get text after first '"hash":"' to get hash (which is index 3)
            }
            for (int i = 1; i < entries.Length; i++)
            {
                assetFiles[i] = new AssetFile(tempHashes[i], tempPaths[i]);
            }

            UpdateTreeView();

            // Testing
            Console.WriteLine(assetFiles[1].path);
            Console.WriteLine(assetFiles[1].hash);

        }

        private void UpdateTreeView()
        {
            TreeNodeCollection nodes = assetsTreeView.Nodes;
            assetsTreeView.Nodes.Clear();
            for (int i = 1; i < assetFiles.Length; i++)
            {
                string[] path = assetFiles[i].path.Split('/');
                for (int j = 0; j < path.Length; j++)
                {
                    if (j == 0)
                    {
                        nodes = assetsTreeView.Nodes;
                    }
                    else
                    {
                        nodes = nodes[nodes.Count - 1].Nodes;
                    }
                    if (nodes.Find(path[j], false).Length == 0)
                    {
                        nodes.Add(path[j], path[j]);
                    }
                }
            }
        }

        private void SaveAudioFiles()
        {
            Console.WriteLine("Saving audio files...");
            try
            {
                for (int i = 1; i < assetFiles.Length; i++)
                {
                    string tempString = saveFilePath + "\\" + assetFiles[i].path.Remove(assetFiles[i].path.LastIndexOf('/'), assetFiles[i].path.Length - assetFiles[i].path.LastIndexOf('/'));
                    if (!Directory.Exists(tempString))
                    {
                        Directory.CreateDirectory(tempString);
                    }


                    File.Copy(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\assets\objects\" + assetFiles[i].hash.Substring(0, 2) + "\\" + assetFiles[i].hash, saveFilePath + "\\" + assetFiles[i].path, true);
                }
                Console.WriteLine("Completed");
                Console.WriteLine("\nCopied Files: " + assetFiles.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void saveToFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                saveFilePath = folderBrowserDialog1.SelectedPath;
                saveFilePathTextBox.Text = saveFilePath;
            }
        }


        private void copyToFolderButton_Click(object sender, EventArgs e)
        {
            if (indexFilePath == null || saveFilePath == null)
            {
                MessageBox.Show("Please select an index file and a save folder.");
                return;
            }
            if (assetFiles == null)
            {
                MessageBox.Show("Please load an index file.");
                return;
            }
            try
            {
                SaveAudioFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ValidateFilePath(object sender, CancelEventArgs e) // generic function to validate file paths
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Equals("") || !Directory.Exists(Directory.GetParent(textBox.Text).ToString()))
            {
                MessageBox.Show("Invalid path.");
                e.Cancel = true;
            }
        }

        private void indexFilePathTextBox_Validated(object sender, EventArgs e)
        {
            indexFilePath = indexFilePathTextBox.Text;
        }

        private void saveFilePathTextBox_Validated(object sender, EventArgs e)
        {
            saveFilePath = saveFilePathTextBox.Text;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = DragDropEffects.Copy;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                indexFilePath = files[0];
                LoadIndexFile(indexFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Checked)
            {
                selectAllCheckBox.Checked = false;
            }
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked)
            {
                foreach (TreeNode node in assetsTreeView.Nodes)
                {
                    node.Checked = true;
                }
            }
        }
    }
}
