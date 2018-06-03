using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceVisitService.Database.Models {
    public class Visit {
        public int VisitId { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string ProfileRef { get; set; }

        public int? Count { get; set; }
    }
}
