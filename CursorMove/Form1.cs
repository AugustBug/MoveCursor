using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorMove
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private bool direction = false;
        private int[] periods = new int[] { 5, 30, 60, 300, 600};

        public Form1()
        {
            InitializeComponent();

            cmbPeriods.Items.Clear();
            foreach(int period in periods)
            {
                if(period < 60)
                {
                    cmbPeriods.Items.Add(period + " second" + (period > 1 ? "s" : ""));
                } else
                {
                    cmbPeriods.Items.Add((int)(period/60) + " minute" + (period/60 > 1 ? "s" : ""));
                }
            }

            timer = new Timer();
            timer.Interval = 1000 * periods[2];
            timer.Tick += (sender, args) => {
                direction = !direction;
                int k = direction ? 3 : -3;
                Cursor.Position = new Point(Cursor.Position.X + k, Cursor.Position.Y + k);
            };
            timer.Start();

            cmbPeriods.SelectedIndex = 2;
        }
        
        private void btnSet_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000 * periods[cmbPeriods.SelectedIndex];
        }
    }
}
