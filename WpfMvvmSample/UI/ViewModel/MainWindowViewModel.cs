using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfMvvmSample.UI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            TypeList = new ObservableCollection<TypeTreeModel>(GetData());
            //ViewModel = new MenuViewModel();
            ViewModel = new ClassRoomsViewModel(); ;
        }

        private object _viewModel;

        public object ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value)
                {
                    return;
                }
                _viewModel = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<TypeTreeModel> TypeList { get; set; } = new ObservableCollection<TypeTreeModel>();
        
        private List<TypeTreeModel> GetData()
        {
            List<TypeTreeModel> typeTrees = new List<TypeTreeModel>()
            {
                new TypeTreeModel()
                {
                    Id = 1,
                    Name = "手机",
                    ChildList = new ObservableCollection<TypeTreeModel>()
                    {
                        new TypeTreeModel(){ Id=2,Name="苹果" },
                        new TypeTreeModel(){ Id=3,Name="华为",
                            ChildList = new ObservableCollection<TypeTreeModel>()
                            {
                                new TypeTreeModel(){Id=4,Name="荣耀" }
                            }},
                        new TypeTreeModel(){ Id=5,Name="小米",
                            ChildList = new ObservableCollection<TypeTreeModel>()
                            {
                                new TypeTreeModel(){Id=6,Name="红米" }
                            }}
                    }
                },
                new TypeTreeModel()
                {
                    Id=7,
                    Name="笔记本",
                    ChildList = new ObservableCollection<TypeTreeModel>()
                    {
                        new TypeTreeModel(){Id=8,Name="联想"}
                    }
                },
                new TypeTreeModel()
                {
                    Id=9,
                    Name="耳机"
                }
            };
            return typeTrees;
        }
        public ICommand SelectItemChangeCommand
        {
            get
            {
                return new DelegateCommand((param) =>
                {
                    if (param != null) { }
                });
            }
        }
    }

    public class TypeTreeModel : TypeModel
    {
        public ObservableCollection<TypeTreeModel> ChildList { get; set; } = new ObservableCollection<TypeTreeModel>();
    }
    public class TypeModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}