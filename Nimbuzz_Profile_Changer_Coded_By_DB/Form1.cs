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
using agsXMPP.Xml;
using agsXMPP.protocol.client;
using agsXMPP.Exceptions;
using agsXMPP.Collections;
using agsXMPP.Util;
using agsXMPP.Xml.Dom;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.vcard;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.ObjectModel;
using System.Web;
using System.Threading;

namespace Nimbuzz_Profile_Changer_Coded_By_DB
{
    public partial class Form1 : Form
    {

        //  Create XMPP CONNECTION named as 'dbcon'

        XmppClientConnection dbcon = new XmppClientConnection();

        //  To generate digits randomly (Later we use this in defining Resource of this app)

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            dbcon.OnLogin += new ObjectHandler(dbcon_onlogin);
            dbcon.OnAuthError += new XmppElementHandler(dbcon_onerror);
            // dbcon.OnPresence += new agsXMPP.protocol.client.PresenceHandler(dbcon_onpresence);
            // dbcon.OnMessage += new agsXMPP.protocol.client.MessageHandler(dcon_onmsg);
            // dbcon.OnReadXml += new XmlHandler(dbcon_OnReadXml);
            // dbcon.OnWriteXml += new XmlHandler(XmppCon_OnWriteXml);
            //   dbcon.OnRosterItem += new XmppClientConnection.RosterHandler(dbcon_OnRosterItem);
            //    dbcon.OnRosterStart += new ObjectHandler(dbcon_OnRosterStart);
            //    dbcon.OnRosterEnd += new ObjectHandler(dbcon_OnRosterEnd);
            
            dbcon.OnIq += new IqHandler(dbcon_oniq);

        }

        private void dbcon_onlogin(object sender)
        {
            //   throw new NotImplementedException();

            if (InvokeRequired)
            {
                BeginInvoke(new ObjectHandler(dbcon_onlogin), new object[] { sender });
                return;
            }

            textBox1.BackColor = Color.Green;
            textBox2.BackColor = Color.Green;

            this.Hide();             //  After Successfull Login we don't require this form anymore so lets hide it
            var loggednimbuzz = new loggednimbuzz(dbcon);                //  let's pass this CONNECTION 'dbcon' to Another Form
            loggednimbuzz.ShowDialog();                  //  let's make another form Visible

        }

        //  on Successfull Login
        
        //  When someone checks our client details through requesting iq
        private void dbcon_oniq(object sender, IQ iq)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IqHandler(dbcon_oniq), new object[] { sender, iq });
                return;
            }

            if (iq.Query != null)
            {
                if (iq.Query.GetType() == typeof(agsXMPP.protocol.iq.version.Version))
                {
                    agsXMPP.protocol.iq.version.Version vers = (agsXMPP.protocol.iq.version.Version)iq.Query;
                    if (iq.Type == agsXMPP.protocol.client.IqType.get)
                    {
                        iq.SwitchDirection();
                        iq.Type = agsXMPP.protocol.client.IqType.result;
                        vers.Name = "Nimbuzz Profile Changer Coded by db~@NC";
                        vers.Ver = "1.0.1";
                        vers.Os = "Coded By db~@NC\nFor More Visit: http://dbh4ck.blogspot.in";
                        ((XmppClientConnection)sender).Send(iq);
                    }
                }
            }

        }

        //  If the provide user credentials are wrong, then show an Error Message Box
        private void dbcon_onerror(object sender, Element e)
        {
         //   throw new NotImplementedException();

            if (InvokeRequired)
            {
                BeginInvoke(new XmppElementHandler(dbcon_onerror), new object[] { sender, e });
                return;
            }

            MessageBox.Show("Yu have entered a wrong username or password", "Attention!");
            textBox1.BackColor = Color.Red;
            textBox2.BackColor = Color.Red;
        }

        //  Handle the Click Event For Logging with Nimbuzz 
        private void button1_Click(object sender, EventArgs e)
        {
            dbcon.Server = "nimbuzz.com";
            dbcon.ConnectServer = "o.nimbuzz.com";
            dbcon.Open(textBox1.Text, textBox2.Text, "ProfileChangerByDB" + (object)this.random.Next(100, 999));
            dbcon.Username = textBox1.Text;
            dbcon.Password = textBox2.Text;
            // dbcon.Resource = xxxx (we already defined this while Opening dbcon)
            dbcon.Priority = 10;
            dbcon.Status = "Online via Nimbuzz Profile Changer Coded By DB~@NC :)";
            dbcon.Port = 5222;
            dbcon.AutoAgents = false;
            dbcon.AutoResolveConnectServer = true;
            dbcon.UseCompression = false;
        }

        
    }
}
