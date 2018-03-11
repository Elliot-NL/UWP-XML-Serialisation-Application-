using System.Collections.Generic;
using System.Windows;
using System;


namespace Testing_File___Serialisation
{
    /// <summary>
    /// Open File Dialogue to select file and serialise raw XML
    /// Enter Data which gets deserialised to raw XML file 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Save to file, change values and overwrite:
            //People p2 = new People();
            //p2.id = new Guid();
            //p2.first_name = "Luke";
            //p2.last_name = "Schwartz";
            //p2.gender = "Male";
            //p2.Persist("Test.xml");

            //Load
            People p3 = People.LoadFromFile("Test.xml");
        }

        private void btn_SelectData_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();            
            dlg.ShowDialog();
            dlg.Filter = "XML Files (.xml)|* .xml|All Files (*.*)|*.*";
            //If user selects file, get path of that file

            dlg.FilterIndex = 1;
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.HasValue)
            {
                List<string> contents = new List<string>();
                string selectedFile = dlg.FileName;
                string[] arrAllFiles = dlg.FileNames;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(selectedFile))
                {
                    //Add contents to file:
                    textBox.Text = System.IO.File.ReadAllText(dlg.FileName);
                    textBox1.Text = System.IO.Path.GetFullPath(dlg.FileName);
                    reader.Close();
                }
            }


            //The read contents and serialise:

        }

        private void btn_AddData_Click(object sender, RoutedEventArgs e)
        {
            //AddData ad = new AddData();
            //ad.Show();
            //this.Close();

            //Write Data to file:
            string selectedFile = textBox1.Text;
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(selectedFile))
            {
                writer.WriteLine(textBox.Text);
            }

        }
    }
}
