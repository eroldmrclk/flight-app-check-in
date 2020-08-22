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
    public partial class Form3 : Form
    {
        int PersonID;
        int PassengerID;
        public Form3(int PassengerID, int PersonID)
        {
            InitializeComponent();
            this.PassengerID = PassengerID;
            this.PersonID = PersonID;
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            Context context = new Context();
            var queryCheckIn = from q in context.Passenger
                               join p in context.Person on q.PersonID equals p.PersonID
                               where q.PassengerID == PassengerID && p.PersonID == PersonID
                               select new
                               {
                                   Passenger = q,
                                   Person = p
                               };
            textBox1.Text = queryCheckIn.First().Passenger.FlightID.ToString();
            textBox2.Text = queryCheckIn.First().Person.ID.ToString();
            textBox3.Text = queryCheckIn.First().Person.Name;
            textBox4.Text = queryCheckIn.First().Person.Surname;
            textBox5.Text = queryCheckIn.First().Person.Gender;


            var queryForSeat = from p in context.Passenger
                               join f in context.Flight on p.FlightID equals f.FlightID
                               join a in context.Airplane on f.AirplaneID equals a.AirplaneID
                               where p.PassengerID == PassengerID
                               select new
                               {
                                   Passenger = p,
                                   Flight = f,
                                   Airplane = a
                               };
            int Capacacity = queryForSeat.First().Airplane.Capacity;
            int FlightID = queryForSeat.First().Flight.FlightID;
            for (var i=1; i <= Capacacity; i++)
            {
                var queryFlight = from f in context.Passenger
                                  where f.FlightID == FlightID && f.SeatNumber == i
                                  select f;
                                   
                if(queryFlight.FirstOrDefault() != null)
                {
                    
                }
                else
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            var queryDoneSeat = from p in context.Passenger
                                where p.PassengerID == PassengerID
                                select p;
            if(comboBox1.Text != null)
            {
                queryDoneSeat.First().SeatNumber = Int32.Parse(comboBox1.Text);
                context.SaveChanges();
                Close();
                Form4 form4 = new Form4();
                form4.ShowDialog();
            }

        }
    }
}
