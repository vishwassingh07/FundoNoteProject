﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class NotesPostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string colour { get; set; }
        public string Image { get; set; }
        public bool Archive { get; set; }
        public bool Pin { get; set; }
        public bool Trash { get; set; }
        public DateTime Reminder { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EditedTime { get; set; }
    }
}
