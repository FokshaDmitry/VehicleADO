using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VehicleADO
{
    /// <summary>
    /// Interaction logic for EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle : Window
    {
        public Object EditVeh { get; set; }
        private Model.VehicleContext context { get; set; }
        private Model.Vehicle vehicle { get; set; }
        public EditVehicle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vehicle = EditVeh as Model.Vehicle;
            vehicle._NameVehicle = New_Text_Name.Text;
            try
            {
                vehicle._MaxSpeed = Convert.ToInt32(New_Text_Speed.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enter Speed!");
                throw;
            }
            try
            {
                vehicle._MaxPassengers = Convert.ToInt32(New_Text_Pas.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enter Passenger!");
                throw;
            }
            try
            {
                vehicle._MaxLoadCapacity = Convert.ToInt32(New_Text_Capacity.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Enter Capacity!");
                throw;
            }
            context.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Seve Ok!");
        }
    }
}
