using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLGUI.EventsLib;

namespace XMLGUI.Forms
{
    public partial class SetTime : Form
    {
        public event EventHandler<SetTimerEventArgs> SetTimeChangeEvent;
        public SetTime()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            EventHandler<SetTimerEventArgs> handler = SetTimeChangeEvent;
            handler?.Invoke(this, new SetTimerEventArgs(this.paramTxtBox.Text));
            this.Close();

        }

        private void SetTime_Load(object sender, EventArgs e)
        {

        }
    }
}
