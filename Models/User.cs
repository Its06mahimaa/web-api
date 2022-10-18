﻿

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trainingproject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Hobbies { get; set; } = null!;

        public string Profile_pic { get; set; } = null;


       public int? RoleId { get; set; }
      public virtual Role? Role { get; set; }

    }
   

}
