using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMvvmSample.UI.View;

namespace WpfMvvmSample.UI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            treeNodeList = new ObservableCollection<TreeNodeModel>(GetData());
            //ViewModel = new MenuViewModel();
            ViewModel = new ClassRoomsView();
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

        public ObservableCollection<TreeNodeModel> treeNodeList { get; set; } = new ObservableCollection<TreeNodeModel>();

        private List<TreeNodeModel> GetData()
        {
            List<TreeNodeModel> typeTrees = new List<TreeNodeModel>()
            {
                new TreeNodeModel()
                {
                    Id=1,
                    Name="控件示例",
                    ChildNode = new ObservableCollection<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Id=11,Name="DataGrid"},
                        new TreeNodeModel(){Id=12,Name="Expander",ViewModelName="SampleExpanderViewModel"},
                        new TreeNodeModel(){Id=13,Name="ListView"},
                        new TreeNodeModel(){Id=14,Name="TreeView"}
                    }
                },
                new TreeNodeModel()
                {
                    Id=2,
                    Name="功能示例",
                    ChildNode = new ObservableCollection<TreeNodeModel>()
                    {
                        new TreeNodeModel(){Id=21,Name="ListBox、ItemsControl 内嵌 UserControl 的交互",ViewModelName="MenuViewModel"},
                        new TreeNodeModel(){Id=22,Name="ListBox、ItemsControl 互嵌绑定树状结构数据的交互",ViewModelName="ClassRoomsViewModel"}
                    }
                },
            };
            return typeTrees;
        }

        public ICommand SelectItemChangeCommand
        {
            get
            {
                return new DelegateCommand((param) =>
                {
                    if (param != null)
                    {
                        var node = (TreeNodeModel)param;
                        if (!string.IsNullOrEmpty(node.ViewModelName))
                        {
                            switch (node.ViewModelName)
                            {
                                case "MenuViewModel":
                                    ViewModel = new MenuView();
                                    break;

                                case "ClassRoomsViewModel":
                                    ViewModel = new ClassRoomsView();
                                    break;

                                case "SampleExpanderViewModel":
                                    ViewModel = new SampleExpanderView();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                });
            }
        }
    }

    public class TreeNodeModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ViewModelName { get; set; }
        public ObservableCollection<TreeNodeModel> ChildNode { get; set; } = new ObservableCollection<TreeNodeModel>();
    }
}