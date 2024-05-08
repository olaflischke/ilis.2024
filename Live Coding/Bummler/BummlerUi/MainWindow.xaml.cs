using BummlerLibrary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace BummlerUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnBummeln_Click(object sender, RoutedEventArgs e)
        {
            lblBummeln.Content = "";
            //lblBummeln.Content = bummler.Bummeln();
            lblBummeln.Content = await bummler.BummelnAsync();
        }

        private async void btnTroedeln_Click(object sender, RoutedEventArgs e)
        {
            lblTroedeln.Content = "";
            //lblTroedeln.Content = bummler.Troedeln();
            lblTroedeln.Content = await bummler.TroedelnAsync();
        }
    }
}