using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Collections;

namespace ZeqkTools.ResourcesGenerator
{
    public partial class frmResxGenerator : Form
    {
        List<string> files = new List<string>();        

        public frmResxGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (chklstFiles.CheckedItems.Count == 0 ||
                txtCultureTag.Text == "" ||
                txtFrom.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("Must be define all settings");
            }
            else
            {
                foreach (var item in chklstFiles.CheckedItems)
                {
                    string file = item.ToString();
                    string resxFile = Path.GetFileNameWithoutExtension(item.ToString());
                    resxFile += "."+ txtCultureTag.Text + ".resx";

                    file = Path.Combine(txtSource.Text,file);
                    resxFile = Path.Combine(txtDestiny.Text,resxFile);

                    try
                    {
                        GenerateResx(file, resxFile, txtFrom.Text, txtTo.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }

                 
        }

        private void GenerateResx(string file, string resxFile, string fromStr, string toStr)
        {
            Dictionary<object, object> existingEntries = new Dictionary<object, object>();

            try
            {
                if (File.Exists(resxFile))
                    existingEntries = GetEntries(resxFile);


                using (StreamReader sr = new StreamReader(file))
                {
                    using (ResXResourceWriter rxrw = new ResXResourceWriter(resxFile))
                    {

                        foreach (var item in existingEntries)
                        {
                            rxrw.AddResource(new ResXDataNode(item.Key.ToString(), item.Value.ToString()));
                        }

                        string line = "";
                        int count = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string msg = ExtractString(line, fromStr, toStr);
                            if (msg != "")
                            {
                                if (!existingEntries.ContainsKey(msg))
                                {                                    
                                    rxrw.AddResource(new ResXDataNode(msg, msg));
                                    existingEntries.Add(msg, msg);
                                }
                                count++;
                                
                            }
                        }

                        rxrw.Close();
                    }
                }     
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.IO.FileNotFoundException))
                {
                    throw new Exception("Incorrect file.", ex);
                }
                else
                    throw ex;
            }
              
        }

        private Dictionary<object,object> GetEntries(string resxFile)
        {
            Dictionary<object, object> values = new Dictionary<object, object>();

            using (ResXResourceReader rxrr = new ResXResourceReader(resxFile))
            {                
                foreach (DictionaryEntry entry in rxrr)
                    values.Add(entry.Key, entry.Value);
            }

            return values;
        }

        private string ExtractString(string text, string from, string to)
        {
            string rv = "";

            int firstIndex = text.IndexOf(from);
            firstIndex = firstIndex + from.Length;
            int lastIndex = text.LastIndexOf(to);
            int lenght = lastIndex - firstIndex;
            if (lenght > 0)
                rv = text.Substring(firstIndex, lenght);
            return rv;
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            if (fbdDestiny.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = fbdDestiny.SelectedPath;
                txtDestiny.Text = fbdDestiny.SelectedPath;

                DirectoryInfo dir = new DirectoryInfo(txtSource.Text);
                FileInfo[] fileList = dir.GetFiles();
                foreach (FileInfo item in fileList)
                {
                    chklstFiles.Items.Add(item.Name);
                }
            }
        }

        private void btnSelectDestiny_Click(object sender, EventArgs e)
        {
            if(fbdDestiny.ShowDialog() == DialogResult.OK)
                txtDestiny.Text = fbdDestiny.SelectedPath;   
        }
    }
}
