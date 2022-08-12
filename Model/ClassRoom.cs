using System.Collections.Generic;

namespace WpfMvvmSample.Model
{
    internal class ClassRoom
    {
        public ClassRoom()
        {
            this.Students = new List<Student>();
        }

        public ClassRoom(int Id, string RoomName, string Grade)
        {
            this.Id = Id;
            this.RoomName = RoomName;
            this.Grade = Grade;
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Grade { get; set; }
        public List<Student> Students { get; set; }
    }
}