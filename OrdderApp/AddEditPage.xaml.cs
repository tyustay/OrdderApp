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

namespace OrdderApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private order _currentorder = new order();
        public AddEditPage(order selectedorder)
        {
            InitializeComponent();
            if (selectedorder != null)
                _currentorder = selectedorder;
            
            DataContext = _currentorder;
            ComboPrice.ItemsSource = OrderBaseEntities.GetContext().prices.ToList();
            ComboPriceps.ItemsSource = OrderBaseEntities.GetContext().pricePCs.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;

            }
            if (_currentorder.id == 0)
                OrderBaseEntities.GetContext().orders.Add(_currentorder);
            try
            {
                OrderBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Иныормация сохранена!");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
