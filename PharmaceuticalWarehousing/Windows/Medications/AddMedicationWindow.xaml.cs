using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        if (Medication.RegistrationNumber.ToString() == null || Medication.RegistrationNumber.ToString() == "0")
        {
            MessageBox.Show("Введите регистрационный номер");
            return;
        }

        
        if ((Medication.DateOfManufacture) == null)
        {
            MessageBox.Show("Введите дату производства");
            return;
        }
        if ((Medication.BestBeforeDate) == null)
        {
            MessageBox.Show("Введите срок годности");
            return;
        }
        if ((Medication.Medicine) == null)
        {
            MessageBox.Show("Укажите лекарство ");
            return;
        }
        if ((Medication.Manufacturer) == null)
        {
            MessageBox.Show("Укажите проиводителя ");
            return;
        }
        

        try
        {
            dbContext.Medications.Add(Medication);
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            dbContext.Medications.Remove(Medication);
            MessageBox.Show(exception.Message);
        }
    }
}