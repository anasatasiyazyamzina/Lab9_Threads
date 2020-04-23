using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using XMLGUI.Forms;
using XMLGUI.EventsLib;
using System.Threading;

namespace XMLGUI
{
    public partial class ThreadConstr : Form
    {
        private delegate void SafeCallDelegate(string text);
       // private Thread thread2 = null;
        public ThreadConstr()
        {
            InitializeComponent();
        }
      
            static int sleeping = 0;
            static object locker = new object();
        
        public static string GetSent()
        {
            string sent="";
            Random r = new Random();
            int cnt = r.Next(1, 14);
            while(cnt>0)
            {
                sent += GetRandom();
                cnt = cnt - 1;
            }
            return sent;
        }

        //функция для получения рандомных слов
        public static string GetRandom()
        { 
            string[] randoms = new string[13];
            randoms[0] = "a";
            randoms[1] = "s";
            randoms[2] = "d";
            randoms[3] = "o";
            randoms[4] = "f";
            randoms[5] = "g";
            randoms[6] = "h";
            randoms[7] = "i";
            randoms[8] = "k";
            randoms[9] = "l";
            randoms[10] = "z";
            randoms[11] = "x";
            randoms[12] = "w";

            string[] rand = { ".", "?", "!" };
            
            string randsror = "";
            Random r = new Random();
            for (int i = 0; i < 13; i++)  randsror += randoms[r.Next(0, 13)]; 
            randsror += rand[r.Next(0, 3)]; 
            return randsror;
        }

        void main(int num, int time)
            {
                for (int i = 0; i < num; i++)
                {
                    Thread myThread = new Thread(Count);
                   // myThread.Name = "Поток " + i.ToString();
                    myThread.Start();
                    //myThread.Join(100);
                }
            }
            public void Count()
            {
            Random r = new Random();
                lock (locker)
                {
                   // x = 1;
                    for (int i = 1; i < 9; i++)
                    {
                    if (tableView.InvokeRequired)
                    {
                        var d = new SafeCallDelegate(WriteTextSafe);
                        tableView.Invoke(d, new object[] { Thread.CurrentThread.ManagedThreadId + GetSent() + Environment.NewLine});
                        tableView.ForeColor = Color.FromArgb(150, r.Next(0, 250), r.Next(0, Thread.CurrentThread.ManagedThreadId)); 
                        //tableView.Clear();
                        //tableView.Text += x;
                       // x++;
                    }
                    else
                    {
                        tableView.Text += Thread.CurrentThread.Name;
                    }
                   
                        Thread.CurrentThread.Join(sleeping);
                    }
                }
            }
        
        private void WriteTextSafe(string text)
        {
            //Random r = new Random();
            //tableView.ForeColor = Color.FromArgb(150, r.Next(0, 250), r.Next(0, Thread.CurrentThread.ManagedThreadId));
            this.tableView.Clear();
            if (tableView.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                tableView.Invoke(d, new object[] { text });
                
            }
            else
            {
                tableView.Text += text;
 
            }
        }

        private void SetText()
        {
            Color color = Color.FromArgb(15, 15, 15);
           // WriteTextSafe("This text was set safely."+ Thread.CurrentThread.ManagedThreadId, color);
            Thread.CurrentThread.Join(1000);
        }
        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuantityThreads setFilterForm = new QuantityThreads();
            setFilterForm.FilterChangeEvent += new EventHandler<FilterChangeEventArgs>(this.OnThreadChangeEvent);
            setFilterForm.Show();
            
            // Task SomTask1 = Task.Run(() => SomeWork(5));
        }
        public void OnThreadChangeEvent(object sender, FilterChangeEventArgs e)
        {

            main(Convert.ToInt32(e.Param),12);
        }

        private void setTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTime setTimerForm = new SetTime();
            setTimerForm.SetTimeChangeEvent += new EventHandler<SetTimerEventArgs>(this.SetTimeEvent);
            setTimerForm.Show();
        }
        public void SetTimeEvent(object sender, SetTimerEventArgs e)
        {
            sleeping = Convert.ToInt32(e.Param);
        }
    }
}