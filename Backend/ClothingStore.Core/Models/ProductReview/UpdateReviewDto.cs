using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Core.Models.ProductReview
{
    public class UpdateReviewDto
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }

}
