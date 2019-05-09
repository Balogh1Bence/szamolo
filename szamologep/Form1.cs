using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szamologep
{
    public partial class Form1 : Form
    {
        string szamitani = "3+3*3+3-4+4+23-64+234/4*3*435+345";
   
        public Form1()
        {
            InitializeComponent();
         
        }
        public void gomb(object sender, EventArgs e)
        { 
            int i = sender.ToString().Length;

            char c = sender.ToString()[i - 1];
            
            textBox1.Text += c;


        }
        public void darabolo(object sender, EventArgs e)
        {
            string sor = textBox1.Text;
            List<string> d = new List<string>();
            List<string> szorzasok = new List<string>();
            d= sor.Split('+', '-').ToList();
            foreach (string s in d)
            {
                if (s.Contains('*'))
                {
                    szorzasok.Add(s);
                }
            }
            List<double> szorzatok = new List<double>();
            foreach (string s in szorzasok)
            {
              
               
                int h = 0;
                string muveletek = "";
                muveletek = Regex.Replace(s, @"[\d-]", string.Empty);// / * *
                
                string [] a = s.Split('*','/', '\\');//234 4 3 435
                List<string> l = s.Split('*', '/', '\\').ToList(); 
                while (h < muveletek.Length)
                {
                   
                    if (muveletek[h] == '*')
                    {

                        try
                        {
                            double szorz = Convert.ToDouble(l[h]) * Convert.ToDouble(l[h + 1]);
                           
                            l.RemoveAt(h);
                            szorzatok.Add(szorz);
                        }
                        catch { break; }

                    }
                    if (muveletek[h] == '/')
                    {
                        try
                        {
                            double szorz = Convert.ToDouble(l[h]) / Convert.ToDouble(l[h + 1]);
                           
                            l.RemoveAt(h);
                            szorzatok.Add(szorz);
                        }
                        catch { break; }
                    }

                    h++;
                }
                
                

               
      

            }
            foreach (string s in szorzasok)
            {
               
               
              
                sor = sor.Replace(s, "x");

               
             }
            int i = 0;
            int b = 0;
            while (i < sor.Length)
            {
               
              
                StringBuilder sb = new StringBuilder(sor);
           
                if (sor[i] == 'x')
                {
            
                    sb.Remove(i,1);
                    sb.Insert(i, szorzatok[b]);
                    b++;
                }
                sor = sb.ToString();
                i++;

            }

            textBox1.Text = sor;
            
        }

    }
}
