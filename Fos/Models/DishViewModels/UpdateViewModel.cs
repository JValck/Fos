﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.DishViewModels
{
    public class UpdateViewModel
    {
        public IList<Kitchen> Kitchens { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} moet minimaal 0 zijn")]
        [Display(Name = "Prijs")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Afbeelding")]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Keuken")]
        public int KitchenId { get; set; }
    }
}
