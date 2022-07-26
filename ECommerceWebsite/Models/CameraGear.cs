﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    /// <summary>
    /// Represents a single piece of Camera Gear for purchase
    /// </summary>
    public class CameraGear
    {
        /// <summary>
        /// primary key for each camera gear product
        /// </summary>
        [Key]
        public int CameraGearId { get; set; }

        /// <summary>
        /// The title of the product
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sale price of the product
        /// </summary>
        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }

        // Todo: Add rating
    }

    /// <summary>
    /// A single piece of gear that has been added to the users
    /// shopping cart cookie
    /// </summary>
    public class CartGearViewModel
    {
        public int CartGearId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }

}
