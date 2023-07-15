﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalSeventeen.Data.Models
{
    public class UserRole
    {
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Key, Column(Order = 2)]
        public int RoleId { get; set; }

        //Navigation properties
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
