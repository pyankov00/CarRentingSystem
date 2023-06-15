using System;

namespace CarRentingSystem.Data.Models.Abstract
{
    public class BaseEntity : IBaseEntity
    {
        public DateTime? CreatedAt_19118072 { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt_19118072 { get; set; }
    }
}
