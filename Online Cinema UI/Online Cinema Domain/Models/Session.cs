﻿using System;

namespace Online_Cinema_Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CinemaRoomId { get; set; }
        public CinemaRoom CinemaRoom { get; set; }

        public bool IsRemoved { get; set; }
    }
}