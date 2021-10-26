﻿using System;

namespace GoodCompanyMVC.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirebaseUserId { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
    }
}
