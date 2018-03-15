using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverTip.Common.ViewModels
{
    public class LeafCollectionViewModels
    {
        [Key]
        public int Id { get; set; }
        public DateTime collectedDate { get; set; }
        public double fieldGrossWeight { get; set; }
        public double fieldNetWeight { get; set; }
        public double factoryGrossWeight { get; set; }
        public double factoryNetWeight { get; set; }
        public int collectionOfficerRouteId { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
