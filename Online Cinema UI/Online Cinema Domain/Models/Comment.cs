﻿using Online_Cinema_Domain.Models.IdentityModels;
using System;

namespace Online_Cinema_Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }


        public bool IsRemoved { get; set; }
    }
}
