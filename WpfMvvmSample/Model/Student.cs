namespace WpfMvvmSample.Model
{
    internal class Student
    {
        public Student()
        {
        }

        public Student(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}