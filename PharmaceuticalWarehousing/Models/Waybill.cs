using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    
    public class Waybill // Накладная ведомость
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ReceiptDate { get; set; }
        public List<Medication> Medications { get; set; }

        public Counterparty Provider { get; set; }
    }
}
