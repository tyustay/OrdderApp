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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            //DGridOrder.ItemsSource = OrderBaseEntities.GetContext().orders.ToList(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as order));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var OrderForRemoving = DGridOrder.SelectedItems.Cast<order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {OrderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    OrderBaseEntities.GetContext().orders.RemoveRange(OrderForRemoving);
                    OrderBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridOrder.ItemsSource = OrderBaseEntities.GetContext().orders.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                OrderBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridOrder.ItemsSource = OrderBaseEntities.GetContext().orders.ToList();
            }
        }
    }
}
