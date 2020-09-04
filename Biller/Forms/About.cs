using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    //http://dineshbajajktn.blogspot.in/
    internal sealed partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = "About " + Global.AssemblyTitle;
            this.Icon = this.MdiParent.Icon;
            this.applicationTitleLabel.Text = Global.AssemblyTitle;
            this.versionLabel.Text = string.Format("Version {0}",
                Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void emailAddressLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = "mailto:aliabbasvohra@gmail.com";
            System.Diagnostics.Process.Start(text);
            emailAddressLinkLabel.LinkVisited = true;
        }

        private void blogURLLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(blogURLLinkLabel.Text);
            blogURLLinkLabel.LinkVisited = true;
        }
    }
}