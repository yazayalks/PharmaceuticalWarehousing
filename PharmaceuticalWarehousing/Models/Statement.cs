using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class Statement // Ведомость
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<Medication?> Medications { get; set; }
        public Waybill? Waybill { get; set; }
    }
}
