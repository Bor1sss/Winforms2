using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form2 : Form
    {
        public bool isPlayer;
        public Form2()
        {
            bool isPlayer = false; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IModel model;
            AiModel aiModel;
            model = new ModelXo();
            if (radioButton1.Checked)
            {
                aiModel = new AiXO(false);
            }
            else 
            {
                aiModel = new AiXO(true);
            }
            Form1 View = new Form1();
            Presenter presenter = new Presenter(model, View,aiModel);
            View.ShowDialog();
            
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
