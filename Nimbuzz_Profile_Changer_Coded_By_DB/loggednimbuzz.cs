using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agsXMPP;
using System.Diagnostics;
using agsXMPP.Exceptions;
using agsXMPP.Collections;
using agsXMPP.Util;
using agsXMPP.protocol.client;
using agsXMPP.Xml.Dom;

namespace Nimbuzz_Profile_Changer_Coded_By_DB
{
    public partial class loggednimbuzz : Form
    {
        private agsXMPP.XmppClientConnection dbcon;

        //      public loggednimbuzz()
        //      {
        //          InitializeComponent();
        //      }

        //  passing 'dbcon' defined in previous Form

        public loggednimbuzz(agsXMPP.XmppClientConnection dbcon)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.dbcon = dbcon;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbcon.Send("<iq from='" + dbcon.Username.Replace("&", "&amp;").Replace(">", "&gt;").Replace("'", "&apos;") + "@nimbuzz.com' type='set' to='uprofile.nimbuzz.com' id='dbhere'><profile xmlns='http://jabber.org/protocol/profile'><x xmlns='jabber:x:data' type='submit'><field type='hidden' var='FORM_TYPE'><value>http://jabber.org/protocol/profile</value></field><field var='nickname'><value>" + textBox1.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + " </value></field><field var='status'><value>" + textBox2.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + "</value></field><field var='gender'><value>" + gender + "</value></field><field var='birth_dayofmonth'><value>" + numericUpDown1.Value + "</value></field><field var='birth_month'><value>" + numericUpDown2.Value + "</value></field><field var='birth_year'><value>" + numericUpDown3.Value + "</value></field><field var='country'><value>" + textBox3.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + "</value></field><field var='locality'><value>" + textBox4.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + "</value></field><field var='region'><value>" + textBox5.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + "</value></field><field var='street'><value>" + textBox6.Text.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("'", "&apos;") + "</value></field></x></profile></iq> ");
                MessageBox.Show("Your Nimbuzz Profile has been updated!");
                
            }
            catch
            {

            }
        }


        string gender;      // as we have defined radiobutton to make an Either selection of genders (male, female) lets define the string

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                gender = "male";

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {

                gender = "female";

            }
        }

        private void loggednimbuzz_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.dbh4ck.blogspot.in");
        }
    }
}
