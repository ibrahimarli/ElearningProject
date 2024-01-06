﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningProject.DAL.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public int StudentID { get; set; } 
        public virtual Student Student { get; set; }
        public int ReviewScore { get; set; }    
    }
}