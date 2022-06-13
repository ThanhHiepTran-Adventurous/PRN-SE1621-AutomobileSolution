using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }
        //----------------------------------------------------

        public ICarRepository CarRepositoty { get; set; }
        public bool InsertOrUpdate { get; set; } //False: Insert, True: Update
        public Car CarInfo { get; set; }
        //-------------------------------------------------------
        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true) // Update mode
            {
                //Show car to perform updating
                txtCarID.Text = CarInfo.CarID.ToString();
                txtCarName.Text = CarInfo.CarName;
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleaseYear.Text = CarInfo.ReleaseYear.ToString();
                cboManufacturer.Text = CarInfo.Manufacturer.Trim();
            }//end frmCarDetails_Load
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCarName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void txtCarID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
                if(InsertOrUpdate == false)
                {
                    CarRepositoty.InsertCar(car);
                }
                else
                {
                    CarRepositoty.UpdateCar(car);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,InsertOrUpdate==false?"Add a new car": "Update a car");

            }
        }//end btnSave_Click
        //----------------------------------------------------------

        private void btnCancel_Click(object sender, EventArgs e) => Close();

       
    }//end Form
}
