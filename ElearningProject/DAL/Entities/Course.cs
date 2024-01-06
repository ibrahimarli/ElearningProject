using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElearningProject.DAL.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public  int InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public List<CourseRegister> CourseRegisters { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }

        public string Description { get; set; } 
        public List<Process> Processs { get; set; }

    }
}