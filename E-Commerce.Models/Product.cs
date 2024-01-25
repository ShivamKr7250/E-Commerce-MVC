﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MaaMobile.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ModelName { get; set; }

        public string Brand { get; set; }

        [Required]
        public string CompatiableModel { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display (Name = "List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }

    }
}
