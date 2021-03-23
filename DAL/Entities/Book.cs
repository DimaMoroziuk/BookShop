﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(100), MinLength(5), Required]
        public string Name { get; set; }
        [StringLength(100), MinLength(5), Required]
        public string Language { get; set; }
        public int Count { get; set; }
        public bool IsExist { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}