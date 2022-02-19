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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Object EditModel { get; set; }
        private Model.VehicleContext context { get; set; }
        private Model.Model model { get; set; }
        public Edit()
        {
            InitializeComponent();
            context = new Model.VehicleContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model = EditModel as Model.Model;
            model._ModelName = New_Text_Name.Text;
            model._Color = New_Text_Color.Text;
            model._DateOfMan = New_Text_Date.DisplayDate;
            try
            {
                model._Weight = Convert.ToInt32(New_Text_Weight.Text);
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Enter Weight!");
                throw;
            }
            context.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Seve Ok!");
        }
    }
}
