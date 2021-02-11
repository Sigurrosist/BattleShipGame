using System;
using System.Collections.Generic;
using System.Text;

namespace GameClasses
{
    public class User
    {
        string name;
        Board userBoard;

        public User()
        {
            this.Name = "";
            this.UserBoard = new Board();
        }

        public string Name { get => name; set => name = value; }
        public Board UserBoard { get => userBoard; set => userBoard = value; }
    }
}
