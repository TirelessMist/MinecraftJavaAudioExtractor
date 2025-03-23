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
    public partial class Form1 : Form
    {
        public struct AudioFile
        {
            public string path;
            public string hash;
            public string size;
            public AudioFile(string hash, string path, string size)
            {
                this.hash = hash;
                this.path = path;
                this.size = size;
            }
        }
        AudioFile[] audioFiles;
        string indexFilePath;
        string saveToPath;
        public Form1()
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
            Console.WriteLine("Index file path is set to: " + indexFilePath);
            LoadIndexFile(indexFilePath);
        }

        private void LoadIndexFile(string indexFilePath)
        {
            string contents = File.ReadAllText(indexFilePath).Replace(" ", ""); // entire file as string
            contents = contents.Remove(0, contents.IndexOf("sounds.json")); // removes everything before "sounds.json" because they are references to languages, built-in packs, etc.
            string[] entries = contents.Split(new string[] { "}," }, StringSplitOptions.None); // split by "}," to get each audio file AudioFile data structure
            audioFiles = new AudioFile[entries.Length];

            string[] tempPaths = new string[entries.Length];
            string[] tempHashes = new string[entries.Length];
            string[] tempSizes = new string[entries.Length];
            for (int i = 0; i < entries.Length; i++)
            {
                tempPaths[i] = entries[i].Split(new string[] { "\"" }, StringSplitOptions.None)[1]; // get text after first '"' to get path (which is index 1)

                tempHashes[i] = entries[i].Split(new string[] { "\"hash\":\"", "\"" }, StringSplitOptions.None)[3]; // get text after first '"hash":"' to get hash (which is index 3)
                tempSizes[i] = entries[i].Split(new string[] { "\"size\":", "}" }, StringSplitOptions.None)[1]; // get text after first '"size":' to get size (which is index 1)
            }
            for (int i = 0; i < entries.Length; i++)
            {
                audioFiles[i] = new AudioFile(tempHashes[i], tempPaths[i], tempSizes[i]);
            }

            // Testing
            Console.WriteLine(audioFiles[1].path);
            Console.WriteLine(audioFiles[1].hash);
            Console.WriteLine(audioFiles[1].size);

            ExtractAudioFiles();
        }

        private void ExtractAudioFiles()
        {
            string objectsPath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\assets\\objects";
            string outputPath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\.minecraft\\assets\\audio_files";
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            for (int i = 1; i < audioFiles.Length; i++)
            {
                string hash = audioFiles[i].hash;
                string path = audioFiles[i].path;
                string size = audioFiles[i].size;
                string firstTwoChars = hash.Substring(0, 2);
                string lastChars = hash.Substring(2);
                string objectPath = objectsPath + "\\" + firstTwoChars + "\\" + hash;
                string outputPathFile = outputPath + "\\" + path;
                if (!Directory.Exists(outputPath + "\\" + path.Substring(0, path.LastIndexOf("\\"))))
                {
                    Directory.CreateDirectory(outputPath + "\\" + path.Substring(0, path.LastIndexOf("\\")));
                }
                File.Copy(objectPath, outputPathFile);
            }
        }

        private void saveToFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                saveToPath = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
