using MvvmSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmSample.UI.ViewModel
{
    internal class ClassRoomsViewModel : ViewModelBase
    {

        private List<ClassRoomViewModel> _classRooms = new List<ClassRoomViewModel>();
        public List<ClassRoomViewModel> ClassRooms
        {
            get { return _classRooms; }
            set
            {
                _classRooms = value;
                RaisePropertyChanged("ClassRooms");
            }
        }

        public ClassRoomsViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            ClassRooms = new List<ClassRoomViewModel>();

            var Students1 = new List<StudentViewModel>();
            Students1.Add(new StudentViewModel(this, 111, "赵"));
            Students1.Add(new StudentViewModel(this, 112, "钱"));
            Students1.Add(new StudentViewModel(this, 113, "孙"));
            ClassRooms.Add(new ClassRoomViewModel(this, 1, "一年级（ 1 ）班", "一年级", Students1));

            var Students2 = new List<StudentViewModel>();
            Students2.Add(new StudentViewModel(this, 121, "李"));
            Students2.Add(new StudentViewModel(this, 122, "周"));
            Students2.Add(new StudentViewModel(this, 123, "吴"));
            ClassRooms.Add(new ClassRoomViewModel(this, 2, "一年级（ 2 ）班", "一年级", Students2));
        }

        private DelegateCommand _Command;

        public ICommand AddCommand
        {
            get
            {
                _Command = new DelegateCommand(param => this.Add(param), null);
                return _Command;
            }
        }

        public void Add(object param)
        {
            MessageBox.Show(param.ToString());
            var temp = ClassRooms;
            var f = temp.Find(x => x.Id == int.Parse(param.ToString()));
            if (f != null)
            {
                f.Students.Add(new StudentViewModel(this, 101, "新"));
                MessageBox.Show(f.Students.Count.ToString());
            }
            ClassRooms = new List<ClassRoomViewModel>();
            ClassRooms = temp;
        }

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
            var temp = ClassRooms;
            foreach (var ClassRoom in temp)
            {
                var f = ClassRoom.Students.Find(x => x.Id == int.Parse(param.ToString()));
                if (f != null)
                {
                    ClassRoom.Students.Remove(f);
                    MessageBox.Show(ClassRoom.Students.Count.ToString());
                }
            }
            ClassRooms = new List<ClassRoomViewModel>();
            ClassRooms = temp;
        }
    }

    internal class ClassRoomViewModel : ViewModelBase
    {

        public ClassRoomsViewModel classRoomsViewModel { get; set; }

        public ClassRoomViewModel()
        {
            this.Students = new List<StudentViewModel>();
        }

        public ClassRoomViewModel(ClassRoomsViewModel classRoomsViewModel, int Id, string RoomName, string Grade, List<StudentViewModel> Students)
        {
            this.classRoomsViewModel = classRoomsViewModel;
            this.Id = Id;
            this.RoomName = RoomName;
            this.Grade = Grade;
            this.Students = Students;
        }

        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string _roomName = string.Empty;
        public string RoomName
        {
            get { return _roomName; }
            set
            {
                _roomName = value;
                RaisePropertyChanged("RoomName");
            }
        }
        private string _grade = string.Empty;
        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                RaisePropertyChanged("Grade");
            }
        }
        private List<StudentViewModel> _students =  new List<StudentViewModel> ();
        public List<StudentViewModel> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                RaisePropertyChanged("Students");
            }
        }
        public ICommand AddCommand
        {
            get
            {
                try
                {
                    return this.classRoomsViewModel.AddCommand;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }

    internal class StudentViewModel : ViewModelBase
    {

        public StudentViewModel()
        {
        }

        public ClassRoomsViewModel classRoomsViewModel { get; set; }

        public StudentViewModel(ClassRoomsViewModel classRoomsViewModel, int Id, string Name)
        {
            this.classRoomsViewModel = classRoomsViewModel;
            this.Id = Id;
            this.Name = Name;
        }

        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                try
                {
                    return this.classRoomsViewModel.DeleteCommand;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}