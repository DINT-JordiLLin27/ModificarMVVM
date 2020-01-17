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

namespace WpfApp4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowVM();
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string nombreCliente = (this.DataContext as MainWindowVM).GetClienteNombreCompleto();

            MessageBoxResult boxResult = MessageBox.Show("¿Actualizar cliente actual a " + nombreCliente + "?", "Actualizar Dato", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (boxResult == MessageBoxResult.OK)
            {
                (this.DataContext as MainWindowVM).Modificar();
                MessageBox.Show("Actualizado correctamente", "Actualizar Dato", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("No se ha actualizado " + nombreCliente, "Actualizar Dato", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (this.DataContext as MainWindowVM).canExecute();
        }
    }
}
