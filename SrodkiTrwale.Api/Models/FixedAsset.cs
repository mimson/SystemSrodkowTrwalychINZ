using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class FixedAsset
    {
        public FixedAsset()
        {
            AmortizationRows = new HashSet<AmortizationRow>();
            Raports = new HashSet<Raport>();
        }

        public int Id { get; set; }
        public int CategoriesId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCollections { get; set; }
        public int? AmortizationId { get; set; }
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public virtual Amortization Amortization { get; set; }
        [JsonIgnore]
        public virtual Category Categories { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<AmortizationRow> AmortizationRows { get; set; }
        [JsonIgnore]
        public virtual ICollection<Raport> Raports { get; set; }
    }
}
