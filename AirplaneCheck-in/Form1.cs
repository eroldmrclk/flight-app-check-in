using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirplaneCheck_in.Entity;
namespace AirplaneCheck_in
{
    public partial class Form1 : Form
    {
        long ID;
        string PNR;
        public Form1()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            if(textBox1.Text !="")
                ID = long.Parse(textBox1.Text);
            PNR = textBox2.Text;
            var queryCheckIn = from q in context.Passenger
                               join p in context.Person on q.PersonID equals p.PersonID 
                               where q.PNR == PNR && p.ID == ID
                               select new
                               {
                                   Passenger = q,
                                   Person = p
                               };
            //textBox3.Text = queryCheckIn.FirstOrDefault().Passenger.SeatNumber.ToString();
            if (queryCheckIn.FirstOrDefault() != null)
            {
                if (queryCheckIn.First().Passenger.SeatNumber != 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Form5 form5 = new Form5();
                    form5.ShowDialog();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Form3 form3 = new Form3(queryCheckIn.First().Passenger.PassengerID, queryCheckIn.First().Person.PersonID);
                    form3.ShowDialog();
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
