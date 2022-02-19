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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VehicleADO
{
    public partial class MainWindow : Window
    {
        private Guid idV;
        private Guid idM;
        private Model.VehicleContext context;
        Random random;
        public MainWindow()
        {
            
            InitializeComponent();
            idV = new Guid();
            idM = new Guid();
            context = new Model.VehicleContext();
            random = new Random();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name;
            double maxspeed = new double();
            int maxpas = new int();
            int maxloadc = new int();
            idV = Guid.NewGuid();
            do
            {
                name = Text_Name.Text.ToString();
                if (String.IsNullOrEmpty(name))
                {
                    System.Windows.Forms.MessageBox.Show("Enter Name");
                    return;
                }
            } while (String.IsNullOrEmpty(name));
            try
            {
                maxspeed = Convert.ToDouble(Text_MaxS.Text.ToString().Replace('.',','));
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Wrong! Enter Max Speed");
            }
            try
            {
                maxpas = Convert.ToInt32(Text_MaxP.Text.ToString());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Wrong! Enter Max Passenger");
            }
            try
            {
                maxloadc = Convert.ToInt32(Text_MaxLC.Text.ToString());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Wrong! Enter Max Load Capacity");
            }
            context.Vehicles.Add(new Model.Vehicle { Id = idV, _NameVehicle = name, _MaxSpeed = maxspeed, _MaxPassengers = maxpas, _MaxLoadCapacity = maxloadc });
            context.SaveChanges();
            Text_Name.Clear();
            Text_MaxS.Clear();
            Text_MaxP.Clear();
            Text_MaxLC.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tmpname;
            string color;
            DateTime date = new DateTime();
            int tmpweight = new int();
            idM = Guid.NewGuid();
            do
            {
                tmpname = Text_NameM.Text.ToString();
                if (String.IsNullOrEmpty(tmpname))
                {
                    System.Windows.Forms.MessageBox.Show("Enter Name");
                    return;
                }
            } while (String.IsNullOrEmpty(tmpname));
            do
            {
                color = Text_Color.Text.ToString();
                if (String.IsNullOrEmpty(color))
                {
                    System.Windows.Forms.MessageBox.Show("Enter Name");
                    return;
                }
            } while (String.IsNullOrEmpty(color));
            date = Enter_Data.DisplayDate;
            try
            {
                tmpweight = Convert.ToInt32(Text_WeightM.Text.ToString());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Wrong! Enter Max Load Capacity");
            }
            context.Models.Add(new Model.Model { ID = idM, Id_vehicle = idV, _DateOfMan = date, _ModelName = tmpname, _Weight = tmpweight, _Color = color });
            context.SaveChanges();
            Text_Color.Clear();
            Text_NameM.Clear();
            Text_WeightM.Clear();
            idV = Guid.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new WindowDB().Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int n = new int();
            List<string> vehicle = new List<string> { "Car", "Bus", "Bicycle", "Bike", "Truck" };
            List<string> vehicleCar = new List<string> { "BMW", "Mecedes", "Audy", "Toyota", "Honda", "Hundai", "Reno" };
            List<string> vehicleBike = new List<string> { "Honda", "Suzuki", "Yamaha", "Kawasaki", "BMW", "KTM" };
            List<string> vehicleBycycle = new List<string> { "GT", "Cannondale", "Trek", "Giant", "Colnago", "Salut" };
            List<string> Color = new List<string> { "Black", "Red", "Green", "Gray", "Pink", "Yellow", "Blue", "Brown" };
            try
            {
                 n = Convert.ToInt32(Num.Text);
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Enter number");
                throw;
            }
            while (n > 0)
            {
                idV = Guid.NewGuid();
                idM = Guid.NewGuid();
                switch (random.Next(0,4))
                {
                    case 0:
                        context.Vehicles.Add(new Model.Vehicle { Id = idV, _NameVehicle = vehicle[0], 
                            _MaxSpeed = random.Next(150, 350), 
                            _MaxPassengers = 4, _MaxLoadCapacity = 
                            random.Next(100, 500) });

                        context.Models.Add(new Model.Model { ID = idM, Id_vehicle = idV, 
                            _DateOfMan = DateTime.Parse($"1971-01-01").AddSeconds(random.Next(60 * 60 * 24 * 365 * 50)), 
                            _ModelName = vehicleCar.Skip(random.Next(vehicleCar.Count())).First(), 
                            _Weight = random.Next(500, 1000), 
                            _Color = Color.Skip(random.Next(Color.Count())).First() });
                        break;
                    case 1:
                        context.Vehicles.Add(new Model.Vehicle { Id = idV, _NameVehicle = vehicle[1], 
                            _MaxSpeed = random.Next(150, 250), 
                            _MaxPassengers = 30, 
                            _MaxLoadCapacity = random.Next(500, 1000) });
                        context.Models.Add(new Model.Model
                        {
                            ID = idM,
                            Id_vehicle = idV,
                            _DateOfMan = DateTime.Parse($"1971-01-01").AddSeconds(random.Next(60 * 60 * 24 * 365 * 50)),
                            _ModelName = vehicleCar.Skip(random.Next(vehicleCar.Count())).First(),
                            _Weight = random.Next(500, 1000),
                            _Color = Color.Skip(random.Next(Color.Count())).First()
                        });
                        break;
                    case 2:
                        context.Vehicles.Add(new Model.Vehicle
                        {
                            Id = idV,
                            _NameVehicle = vehicle[2],
                            _MaxSpeed = random.Next(30, 80),
                            _MaxPassengers = 2,
                            _MaxLoadCapacity = random.Next(20, 50)
                        });
                        context.Models.Add(new Model.Model
                        {
                            ID = idM,
                            Id_vehicle = idV,
                            _DateOfMan = DateTime.Parse($"1971-01-01").AddSeconds(random.Next(60 * 60 * 24 * 365 * 50)),
                            _ModelName = vehicleBycycle.Skip(random.Next(vehicleBycycle.Count())).First(),
                            _Weight = random.Next(10, 30),
                            _Color = Color.Skip(random.Next(Color.Count())).First()
                        });
                        break;
                    case 3:
                        context.Vehicles.Add(new Model.Vehicle
                        {
                            Id = idV,
                            _NameVehicle = vehicle[3],
                            _MaxSpeed = random.Next(250, 400),
                            _MaxPassengers = 2,
                            _MaxLoadCapacity = random.Next(50, 100)
                        });
                        context.Models.Add(new Model.Model
                        {
                            ID = idM,
                            Id_vehicle = idV,
                            _DateOfMan = DateTime.Parse($"1971-01-01").AddSeconds(random.Next(60 * 60 * 24 * 365 * 50)),
                            _ModelName = vehicleBike.Skip(random.Next(vehicleBike.Count())).First(),
                            _Weight = random.Next(350, 700),
                            _Color = Color.Skip(random.Next(Color.Count())).First()
                        });
                        break;
                    case 4:
                        context.Vehicles.Add(new Model.Vehicle
                        {
                            Id = idV,
                            _NameVehicle = vehicle[4],
                            _MaxSpeed = random.Next(150, 250),
                            _MaxPassengers = 30,
                            _MaxLoadCapacity = random.Next(2000, 10000)
                        });
                        context.Models.Add(new Model.Model
                        {
                            ID = idM,
                            Id_vehicle = idV,
                            _DateOfMan = DateTime.Parse($"1971-01-01").AddSeconds(random.Next(60 * 60 * 24 * 365 * 50)),
                            _ModelName = vehicleCar.Skip(random.Next(vehicleCar.Count())).First(),
                            _Weight = random.Next(2000, 5000),
                            _Color = Color.Skip(random.Next(Color.Count())).First()
                        });
                        break;
                }
                --n;
            }
            context.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Seve ok");
            Num.Clear();
        }
    }
}
