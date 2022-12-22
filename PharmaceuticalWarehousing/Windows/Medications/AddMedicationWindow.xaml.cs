using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Medications;

public partial class AddMedicationWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Medication Medication { get; set; } = new();
    public List<Manufacturer> Manufacturers { get; set; }
    public List<Medicine> Medicines { get; set; }
    
    
    public AddMedicationWindow(PharmaceuticalWarehousingDbContext dbContext, User user)
    {
        InitializeComponent();
        this.dbContext = dbContext;
        this.user = user;
        DataContext = this;

        Manufacturers = dbContext.Manufacturers.ToList();
        Medicines = dbContext.Medicines.ToList();
    }

    private void SaveButton(object sender, RoutedEventArgs e)
    {
        try
        {
            dbContext.Medications.Add(Medication);
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}