using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.BusinessEntities
{
    public class CollectionOfficerRoute
    {   [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CollectionOfficerId { get; set; }
        public int RouteId { get; set; }
        [ForeignKey("CollectionOfficerId")]
        public virtual CollectionOfficer CollectionOfficer { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
    }
}
