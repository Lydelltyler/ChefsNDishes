using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Add if your using Relationships
using System;

namespace ChefNDish.Models {
    public class Dish {
        [Key]
        public int DishId { get; set; }

        [Required (ErrorMessage = "Dish name is required")]
        public string DishName { get; set; }

        [Required (ErrorMessage = "Calories is required")]
        [Range (0, Int32.MaxValue, ErrorMessage = "No such thing as negative calories silly")]
        public string Calories { get; set; }

        [Required (ErrorMessage = "Taste is required")]

        public int Taste { get; set; }

        [Required (ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public int ChefId { get; set; }

        public Chef Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}