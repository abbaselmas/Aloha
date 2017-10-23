using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aloha
{
    public partial class Form1 : Form
    {
        public const long a = 1000000;
        public static Random r = new Random();
        public ArrayList randomNumberList = new ArrayList();
        public double N, G, p;
        int transferCount = 0;
        double idleSlotCount = 0;
        double succededTransfer = 0;
        double collusion = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void calc_Click(object sender, EventArgs e)
        {
            N = Convert.ToDouble(n.Text);
            G = Convert.ToDouble(g.Text);
            p = G / N;

            for (int b = 0; b < a; b++)
            {
                for (int i = 0; i < N; i++)
                {
                    randomNumberList.Add(r.NextDouble());
                }

                for (int y = 0; y < N; y++)
                {
                    if (Convert.ToDouble(randomNumberList[y]) < p)
                    {
                        transferCount++;
                    }
                }

                if (transferCount == 0)
                {
                    idleSlotCount++;
                }
                else if (transferCount == 1)
                {
                    succededTransfer++;
                }
                else
                {
                    collusion++;
                }

                randomNumberList.Clear();
                transferCount = 0;

            }
            idleSlotCount /= a;
            succededTransfer /= a;
            collusion /= a;

            idleResult.Text = idleSlotCount.ToString();
            throughput.Text = succededTransfer.ToString();
            collusionResult.Text = collusion.ToString();
        }
    }
}
