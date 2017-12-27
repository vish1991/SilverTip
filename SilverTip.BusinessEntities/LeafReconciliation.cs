using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public class LeafReconciliation
    {
        [Key]
        public int Id { get; set; }
        public bool IsBox { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal Boxweight { get; set; }
        public decimal BoilWeight { get; set; }
        public decimal MassWeight { get; set; }
        public decimal RouteDeduction { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetWeight { get; set; }
        public int LeafCollectionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("LeafCollectionId")]
        public virtual LeafCollection LeafCollection { get; set; }
    }
}
