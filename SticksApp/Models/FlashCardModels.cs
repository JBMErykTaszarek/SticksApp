using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SticksApp.Models
{
    public class FlashCard
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Level { get; set; }
        public string Language { get; set; }

    }
}
