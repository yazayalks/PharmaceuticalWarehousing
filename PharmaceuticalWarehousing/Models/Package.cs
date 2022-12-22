using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class Package // Упаковка
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public PackageType PackageType { get; set; }
        public Medication Medications { get; set; }
    }
}
