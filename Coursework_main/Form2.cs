using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_main
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                Email = null;
                Close();
                return;
            }
            try 
            {
                Email = new MailAddress(textBox1.Text);
                    Close();
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный email");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Email = null;
            Close();
        }

        public static MailAddress getEmail()
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
            return form2.Email;
        }
    }
}
