using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaceuticalWarehousing.Models
{
    public class Invoice // Счёт-фактура
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateOfDischarge { get; set; }
        public double AmountPayable { get; set; }
        public Salesman Salesman { get; set; }
        public Counterparty Buyer { get; set; }
        public List<Medication> Medications { get; set; }
    }
}
