﻿using System.ComponentModel.DataAnnotations;

namespace GraphqlSubscriptionImplement_HangfireJob.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Standard { get; set; }
        public string? City { get; set; }
       
    }
}
