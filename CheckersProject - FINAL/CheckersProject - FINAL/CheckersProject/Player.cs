using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace CheckersProject
{
    partial class Player
    {
        public Player(string firstName, string lastName, string cellNumber, string city, string street, string house, string email)
            : this()
        {
            this.player_FirstName = firstName;
            this.player_LastName = lastName;
            this.player_Reg_Date = DateTime.Now;
            this.player_Wins = 0;
            if(cellNumber != "")
                this.player_CellNumber = cellNumber;
            if (city != "")
                this.player_City = city;
            else
                this.player_City = " ";
            if (street != "")
                this.player_Street = street;
            if (house != "")
                this.player_HouseNumber = Convert.ToInt32(house);
            if (email != "")
                this.player_Email = email;
        }

    }
}
