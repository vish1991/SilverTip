using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public class LeafCollection
    {
        public LeafCollection()
        {
            LeafReconciliations = new HashSet<LeafReconciliation>();
        }
        [Key]
        public int Id { get; set; }
        public DateTime CollectedDate { get; set; }
        public double FieldGrossWeight { get; set; }
        public double FieldNetWeight { get; set; }
        public double FactoryGrossWeight { get; set; }
        public double FactoryNetWeight { get; set; }
        public int CollectionOfficerRouteId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        [ForeignKey("CollectionOfficerRouteId")]
        public virtual CollectionOfficerRoute CollectionOfficerRoute { get; set; }
        public virtual ICollection<LeafReconciliation> LeafReconciliations { get; set; }

    }
}
