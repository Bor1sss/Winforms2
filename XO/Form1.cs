using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form, View
    {
        public List<Button> buttons;
        public Form1()
        {
    
            InitializeComponent();
            
            cords = new int[2];
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        
        public void ShowText(string s)
        {
            this.Text = s;
        }
        public bool isPlayer { get; set; }
        public int[] cords { get; set; }

        public event EventHandler<EventArgs> Changes;

        public void ShowLoseMessage()
        {
            MessageBox.Show("Draw");
            this.Close();
        }

        public void ShowWinMessage()
        {
            if (isPlayer)
            {
                MessageBox.Show($"Win Player2");
            }
            else
            {
                MessageBox.Show($"Win Player1");
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isPlayer)
            {
                button1.Text = "X";
            }
            else
            {
                button1.Text = "0";
            }
            cords[0] = 0;
            cords[1] = 0;
            Changes?.Invoke(this, EventArgs.Empty);
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button2.Text = "X";
            }
            else
            {
                button2.Text = "0";
            }
            cords[0] = 0;
            cords[1] = 1;
            Changes?.Invoke(this, EventArgs.Empty);
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button3.Text = "X";
            }
            else
            {
                button3.Text = "0";
            }
            cords[0] = 0;
            cords[1] = 2;
            Changes?.Invoke(this, EventArgs.Empty);
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button4.Text = "X";
            }
            else
            {
                button4.Text = "0";
            }
            cords[0] = 1;
            cords[1] = 0;
            Changes?.Invoke(this, EventArgs.Empty);
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button5.Text = "X";
            }
            else
            {
                button5.Text = "0";
            }
            cords[0] = 1;
            cords[1] = 1;
            Changes?.Invoke(this, EventArgs.Empty);
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button6.Text = "X";
            }
            else
            {
                button6.Text = "0";
            }
            cords[0] = 1;
            cords[1] = 2;
            Changes?.Invoke(this, EventArgs.Empty);
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button7.Text = "X";
            }
            else
            {
                button7.Text = "0";
            }
            cords[0] = 2;
            cords[1] = 0;
            Changes?.Invoke(this, EventArgs.Empty);
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button8.Text = "X";
            }
            else
            {
                button8.Text = "0";
            }
            cords[0] = 2;
            cords[1] = 1;
            Changes?.Invoke(this, EventArgs.Empty);
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isPlayer)
            {
                button9.Text = "X";
            }
            else
            {
                button9.Text = "0";
            }
            cords[0] = 2;
            cords[1] = 2;
            Changes?.Invoke(this, EventArgs.Empty);
            button9.Enabled = false;
        }
        public void EmulateButtonClick(int x,int y)
        {
           
          
            if (x == 0 && y == 0)
            {
                if (isPlayer)
                {
                   button1.Text = "X";
                }
                else
                {
                    button1.Text = "0";
                }
                button1.Enabled = false;
            }
            else if(x == 0 && y == 1)
            {
                if (isPlayer)
                {
                    button2.Text = "X";
                }
                else
                {
                    button2.Text = "0";
                }
                button2.Enabled = false;
            }
            else if(x == 0 && y == 2)
            {
                if (isPlayer)
                {
                    button3.Text = "X";
                }
                else
                {
                    button3.Text = "0";
                }
                button3.Enabled = false;
            }
            else if(x==1&& y == 0)
            {
                if (isPlayer)
                {
                    button4.Text = "X";
                }
                else
                {
                    button4.Text = "0";
                }
                button4.Enabled = false;
            }
            else if(x==1&& y == 1)
            {
                if (isPlayer)
                {
                    button5.Text = "X";
                }
                else
                {
                    button5.Text = "0";
                }
                button5.Enabled = false;
            }
            else if(x==1 && y == 2)
            {
                if (isPlayer)
                {
                    button6.Text = "X";
                }
                else
                {
                    button6.Text = "0";
                }

                button6.Enabled = false;
            }
            else if (x == 2 && y == 0)
            {
                if (isPlayer)
                {
                    button7.Text = "X";
                }
                else
                {
                    button7.Text = "0";
                }
                button7.Enabled = false;
            }
            else if(x==2 && y == 1)
            {
                if (isPlayer)
                {
                    button8.Text = "X";
                }
                else
                {
                    button8.Text = "0";
                }
                button8.Enabled = false;
            }
            else if(x==2&& y == 2)
            {
                if (isPlayer)
                {
                    button9.Text = "X";
                }
                else
                {
                    button9.Text = "0";
                }
                button9.Enabled = false;
            }






            cords[0] = x;
            cords[1] = y;
           
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            button10.Enabled = false;
            Changes?.Invoke(this, new EventArgs());
        }
    }
}
