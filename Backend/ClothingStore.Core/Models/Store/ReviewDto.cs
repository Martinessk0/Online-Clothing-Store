using System;

namespace ClothingStore.Core.Models.Store
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class ReviewCreateDto
    {
        public int ProductId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }
    }
}
