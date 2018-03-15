using SilverTip.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class CollectionOfficerRouteViewModels
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public int collectionOfficerId { get; set; }
        public int routeId { get; set; }
        [ForeignKey("CollectionOfficerId")]
        public virtual CollectionOfficer collectionOfficer { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route route { get; set; }
    }
}
