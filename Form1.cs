using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";           
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sfd.FileName, rtbDocument.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file at disk. Original error: " + ex.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            //ofd.OpenFile();
            String calosc = String.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream myStream;
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            byte[] bytes = new byte[myStream.Length];
                            int numBytesToRead = (int)myStream.Length;
                            int numBytesRead = 0;
                            StreamReader c = new StreamReader(myStream);
                            while (numBytesToRead > 0)
                            {                           

                               calosc = c.ReadToEnd();
                                // Read may return anything from 0 to numBytesToRead.
                                int n = myStream.Read(bytes, numBytesRead, numBytesToRead);
                                // Break when the end of the file is reached.
                                if (n == 0)
                                    break;

                                numBytesRead += n;
                                numBytesToRead -= n;
                            }
                            numBytesToRead = bytes.Length;                    
                        }
                    }
                    rtbDocument.Text = calosc;
                   
                }         
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
    }
}


/*
 DO ZROBIENIA ZA TYDZIEN
 1)  //rtbDocument.Find() - WYSZUKIWANIE W TEKSCIE JAKIEGOS WYRAZU --> TEXTBOX PO KLIKNIECIU NA ZNAJDZ - WPISUJEMY TEKST 
 2) ZMIANA CZCIONKI I ROZMAIRU ITP  
     */
