using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmSample.UI.ViewModel
{
    internal class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItemViewModel> menuItemViewModel { get; set; }

        public MenuViewModel()
        {
            LoadMenu();
        }

        //private WeakReference _viewHolder = null;
        //public MenuView view
        //{
        //    get
        //    {
        //        if (_viewHolder == null || _viewHolder.IsAlive == false)
        //            return null;
        //        return _viewHolder.Target as MenuView;
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            _viewHolder = null;
        //            return;
        //        }
        //        _viewHolder = new WeakReference(value);
        //    }
        //}

        public void LoadMenu()
        {
            menuItemViewModel = new ObservableCollection<MenuItemViewModel>();
            menuItemViewModel.Add(SetVM(1, "菜单项一"));
            menuItemViewModel.Add(SetVM(2, "菜单项二"));
            menuItemViewModel.Add(SetVM(3, "菜单项三"));
            menuItemViewModel.Add(SetVM(4, "菜单项四"));
        }

        public MenuItemViewModel SetVM(int Id, string Title)
        {
            var vm = new MenuItemViewModel();
            //vm.menuView = this.view;
            vm.menuViewModel = this;
            vm.menuItem = new Model.MenuItem(Id, Title);
            return vm;
        }

        private DelegateCommand _Command;

        public ICommand DeleteCommand
        {
            get
            {
                _Command = new DelegateCommand(param => this.Delete(param), null);
                return _Command;
            }
        }

        public void Delete(object param)
        {
            MessageBox.Show(param.ToString());
        }
    }
}