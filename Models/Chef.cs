using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChefNDish.Validations;

namespace ChefNDish.Models {
    public class Chef {
        [Key]
        public int ChefId { get; set; }

        [Required (ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [DataType (DataType.Date)]
        [Eighteen]
        public DateTime Birthday { get; set; }

        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int Age () {
            return DateTime.Now.Year - Birthday.Year;
        }
    }
}