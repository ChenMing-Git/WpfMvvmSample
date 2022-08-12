using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMvvmSample.UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion INotifyPropertyChanged
    }
}