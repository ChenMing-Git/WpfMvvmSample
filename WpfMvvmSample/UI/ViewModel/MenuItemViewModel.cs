using System;
using System.Windows.Input;
using WpfMvvmSample.Model;
using WpfMvvmSample.UI.View;

namespace WpfMvvmSample.UI.ViewModel
{
    internal class MenuItemViewModel : ViewModelBase
    {
        public MenuItemViewModel()
        { }

        public MenuViewModel menuViewModel { get; set; }
        public MenuItem menuItem { get; set; }

        private WeakReference _viewHolder = null;

        public MenuItemView view
        {
            get
            {
                if (_viewHolder == null || _viewHolder.IsAlive == false)
                    return null;
                return _viewHolder.Target as MenuItemView;
            }
            set
            {
                if (value == null)
                {
                    _viewHolder = null;
                    return;
                }
                _viewHolder = new WeakReference(value);
            }
        }

        //private WeakReference _menuViewHolder = null;
        //public MenuView menuView
        //{
        //    get
        //    {
        //        if (_menuViewHolder == null || _menuViewHolder.IsAlive == false)
        //            return null;
        //        return _menuViewHolder.Target as MenuView;
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            _menuViewHolder = null;
        //            return;
        //        }
        //        _menuViewHolder = new WeakReference(value);
        //    }
        //}

        public ICommand DeleteCommand
        {
            get
            {
                try
                {
                    return this.menuViewModel.DeleteCommand;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}