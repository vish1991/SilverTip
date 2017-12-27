using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public class SupplierCollection
    {
        [Key]
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public int CollectionOfficerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("CollectionOfficerId")]
        public virtual CollectionOfficer CollectionOfficer { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
