using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class Medication // Препарат
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public int RegistrationNumber { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Medicine Medicine { get; set; }
        public List<Package> Packaging { get; set; }
        public Waybill Waybill { get; set; }
    }
}
