namespace CarRentingSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using CarRentingSystem.Data.Models.Abstract;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants.User;

    public class User : IdentityUser, IBaseEntity
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
        public DateTime? CreatedAt_19118072 { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt_19118072 { get; set; }
    }
}
