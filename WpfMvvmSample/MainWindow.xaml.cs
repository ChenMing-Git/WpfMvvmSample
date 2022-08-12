using System.Windows;
using WpfMvvmSample.UI.ViewModel;

namespace WpfMvvmSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var menuViewModel = new MenuViewModel();
            //this.DataContext = menuViewModel;

            var classRoomsViewModel = new ClassRoomsViewModel();
            this.DataContext = classRoomsViewModel;
        }
    }
}