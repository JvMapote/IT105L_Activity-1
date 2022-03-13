using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Activity1_Problem2
{
    /* 
     * FullName: Jayvee N. Mapote
     * Section: C11
     * Course: IT105L
     * Laboratory Activity 1 : Problem 2
     */
    public partial class Problem_2 : Form
    {
        //Initialized variables
        String name, Firstname, Middlename, Lastname, Birthmonth, Yearlevel;
        int UnitsTaken,Unit, xUnit, bm, bd, x;
        
        //Show the Full Name with and without the middle initial
        private void Btn1_Click(object sender, EventArgs e)
        {
            Firstname = (String)FNbox.Text;
            Middlename = (String)MNbox.Text;
            Lastname = (String)LNbox.Text;

            Result1.Text = ($"{Firstname} {Middlename} {Lastname}");
            Result2.Text = ($"{Firstname} {Lastname}");
        }

        //Show the Birthdate in the format: Month Date, Year
        //Show the Age as of the current date
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Birthmonth = CultureInfo.CurrentCulture.
                DateTimeFormat.GetMonthName
                (Convert.ToInt32(BMbox.Text));
                Result3.Text = ($"{Birthmonth} {BDbox.Text} {BYbox.Text}");
                DateTime bday = Convert.ToDateTime(Result3.Text);
                DateTime today = DateTime.Today;
                int age = today.Year - Convert.ToInt32(BYbox.Text);
                if (bday > today.AddYears(-age)) age--;
                Result4.Text = ($"{age}");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input", "Error");     //Error message, if they left a textbox empty
            }
        }

        //Show the Current year level using the following conditions
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Unit = 250;
                UnitsTaken = Convert.ToInt32(UnitBox.Text);
                xUnit = Unit - UnitsTaken;

                if (xUnit > 200 && xUnit <= 250)
                {
                    Yearlevel = "First Year:";
                }
                else if (xUnit > 150 && xUnit <= 200)
                {
                    Yearlevel = "Second Year:";
                }
                else if (xUnit > 100 && xUnit <= 150)
                {
                    Yearlevel = "Third Year:";
                }
                else if (xUnit > 50 && xUnit <= 100)
                {
                    Yearlevel = "Fourth Year:";
                }
                else if (xUnit <= 50)
                {
                    Yearlevel = "Fifth Year:";
                }
                Result5.Text = ($"{Yearlevel} {ProgramBox.Text}");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input:", "Error");     //Error message, if they left a textbox empty
            }
        }

        //Auto set minimum (1) and maximum (250) value on textbox
        private void UnitBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(UnitBox.Text);
            }
            catch (Exception)
            {
                UnitBox.Text = null;
            }

            if (x > 250)
            {
                UnitBox.Text = null;
            }
            else if (x == 0)
            {
                UnitBox.Text = null;
            }
        }

        //Will only receive numbers
        private void BYbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int by = Convert.ToInt32(BYbox.Text);
            }
            catch (Exception)
            {
                BYbox.Text = null;
            }
        }

        //Auto set minimum (1) and maximum (31) value on textbox
        private void BDbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bd = Convert.ToInt32(BDbox.Text);
            }
            catch (Exception)
            {
                BDbox.Text = null;
            }

            if (bd > 31)
            {
                BDbox.Text = null;
            }
            else if (bd == 0)
            {
                BDbox.Text = null;
            }
        }

        //Auto set minimum (1) and maximum (12) value on textbox
        private void BMbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bm = Convert.ToInt32(BMbox.Text);
            }
            catch (Exception)
            {
                BMbox.Text = null;
            }

            if (bm > 12)
            {
                BMbox.Text = null;
            }
            else if (bm == 0)
            {
                BMbox.Text = null;
            }
        }

        //Clear Button
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            FNbox.Focus();
            FNbox.Clear();
            MNbox.Clear();
            LNbox.Clear();
            BMbox.Clear();
            BDbox.Clear();
            BYbox.Clear();
            ProgramBox.Clear();
            UnitBox.Clear();
        }

        //Exit
        private void FNbox_TextChanged(object sender, EventArgs e)
        {
            name = (String)FNbox.Text;
            if (name == "exit" || name == "Exit" || name == "EXIT")
            {
                Application.Exit();
            }
        }

        //To set Firstname textbox as the focus when the program was open
        private void Problem_2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = FNbox;
        }

        public Problem_2()
        {
            InitializeComponent();
        }
    }
}
