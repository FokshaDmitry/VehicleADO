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
    public partial class WindowDB : Window
    {
        Model.VehicleContext context;
        public WindowDB()
        {
            context = new Model.VehicleContext();
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InfoVehicle.Text = $"Vehicles: {context.Vehicles.Count()}";
            InfoModel.Text = $"Models: {context.Models.Count()}";
            foreach (var item in context.Vehicles.GroupBy(v => v._NameVehicle).OrderBy(v => v.Key))
            {
                VehicleBox.Items.Add(item.Key); ;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoDB.Items.Clear();
            foreach (var item in context.Vehicles)
            {
                InfoDB.Items.Add(item);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InfoDB.Items.Clear();
            foreach (var item in context.Models)
            {
                InfoDB.Items.Add(item);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfoDB.Items.Clear();
            switch (Comand.Text.ToUpper().Replace(" ", ""))
            {
                case "NAMEVEHICLE":
                    foreach (var item in context.Vehicles.Select(v => v._NameVehicle))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "MAXSPEED":
                    foreach (var item in context.Vehicles.Select(v => v._MaxSpeed))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "MAXPASANGERS":
                    foreach (var item in context.Vehicles.Select(v => v._MaxPassengers))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "MAXLOADCAPACITY":
                    foreach (var item in context.Vehicles.Select(v => v._MaxLoadCapacity))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "NAMEMODEL":
                    foreach (var item in context.Models.Select(v => v._ModelName))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "WEIGHT":
                    foreach (var item in context.Models.Select(v => v._Weight))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "COLOR":
                    foreach (var item in context.Models.Select(v => v._Color))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "RELESEDATE":
                    foreach (var item in context.Models.Select(v => v._DateOfMan))
                    {
                        InfoDB.Items.Add(item);
                    }
                    break;
                case "NAMEVEHICLE+NAMEMODEL":
                    foreach (var item in context.Vehicles.Join(context.Models, v => v.Id, m => m.Id_vehicle, (v, m) => new { Vehicle = v, Model = m }))
                    {
                        InfoDB.Items.Add(item.Vehicle._NameVehicle + " " + item.Model._ModelName);
                    }
                    break;
                case "NAMEMODEL+MAXSPEED":
                    foreach (var item in context.Vehicles.Join(context.Models, v => v.Id, m => m.Id_vehicle, (v, m) => new { Vehicle = v, Model = m }))
                    {
                        InfoDB.Items.Add(item.Model._ModelName + " " + item.Vehicle._MaxSpeed + "km/h");
                    }
                    break;
                case "NAMEMODEL+MAXLOADCAPACITY":
                    foreach (var item in context.Vehicles.Join(context.Models, v => v.Id, m => m.Id_vehicle, (v, m) => new { Vehicle = v, Model = m }))
                    {
                        InfoDB.Items.Add(item.Model._ModelName + " " + item.Vehicle._MaxLoadCapacity + "kg");
                    }
                    break;
                case "NAMEMODEL+MAXPASANGER":
                    foreach (var item in context.Vehicles.Join(context.Models, v => v.Id, m => m.Id_vehicle, (v, m) => new { Vehicle = v, Model = m }))
                    {
                        InfoDB.Items.Add(item.Model._ModelName + " " + item.Vehicle._MaxPassengers);
                    }
                    break;
                case "VEHICLE":
                    foreach (var item in context.Vehicles.GroupBy(v => v._NameVehicle).OrderBy(v => v.Key))
                    {
                        InfoDB.Items.Add(item.Key + " " + item.Count());
                    }
                    break;
                case "NAMEMODEL+COLOR":
                    foreach (var item in context.Models.Select(v => v))
                    {
                        InfoDB.Items.Add(item._ModelName + " " + item._Color);
                    }
                    break;
            }
        }

        private void VehicleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoDB.Items.Clear();
            var tmp = VehicleBox.SelectedItem;
            foreach (var item in context.Vehicles.Join(context.Models, v => v.Id, m => m.Id_vehicle, (v, m) => new { Vehicle = v, Model = m }))
            {
                if (item.Vehicle._NameVehicle == tmp.ToString())
                {
                    InfoDB.Items.Add($"Name: {item.Model._ModelName}\n" +
                        $"Color: {item.Model._Color}\n" +
                        $"Date: {item.Model._DateOfMan}\n" +
                        $"-----------------");
                }
            }
        }

        private void InfoDB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            int selectedIndex = InfoDB.SelectedIndex;
            if (selectedIndex == -1) return;
            if(InfoDB.SelectedItem is Model.Model)
            {
                Model.Model model = InfoDB.SelectedItem as Model.Model;
                IdName.Text = model.ID.ToString();
            }
            if (InfoDB.SelectedItem is Model.Vehicle)
            {
                Model.Vehicle vehicle = InfoDB.SelectedItem as Model.Vehicle;
                IdName.Text = vehicle.Id.ToString();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(InfoDB.SelectedItem is Model.Model)
            {
                new Edit() { EditModel = InfoDB.SelectedItem}.Show();
            }
            else if (InfoDB.SelectedItem is Model.Vehicle)
            {
                new EditVehicle() { EditVeh = InfoDB.SelectedItem }.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Choose Position");
            }
            IdName.Clear();
        }
    }
}
