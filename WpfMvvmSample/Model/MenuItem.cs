﻿namespace WpfMvvmSample.Model
{
    internal class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}