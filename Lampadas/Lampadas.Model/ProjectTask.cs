﻿using System.ComponentModel.DataAnnotations;

namespace Lampadas.Model
{
    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
