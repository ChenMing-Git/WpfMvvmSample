using System;
using System.Windows;
using System.Windows.Controls;
using WpfMvvmSample.UI.ViewModel;

namespace WpfMvvmSample.UI.View
{
    /// <summary>
    /// MenuItemView.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuItemView : UserControl
    {
        private MenuItemViewModel VM
        {
            get
            {
                return this.DataContext as MenuItemViewModel;
            }
        }

        public MenuItemView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.VM != null)
                {
                    this.VM.view = this;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}