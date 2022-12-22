using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Medications;

public partial class EditMedicationWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Medication Medication { get; set; }
    public List<Manufacturer> Manufacturers { get; set; }
    public List<Medicine> Medicines { get; set; }
    public List<PackageType> PackageTypes { get; set; }
    public List<Package> MedicationPackage { get; set; }
    
    
    public EditMedicationWindow(PharmaceuticalWarehousingDbContext dbContext, User user, Medication medication)
    {
        InitializeComponent();
        this.dbContext = dbContext;
        this.user = user;
        DataContext = this;
        Medication = medication;

        Manufacturers = dbContext.Manufacturers.ToList();
        Medicines = dbContext.Medicines.ToList();
        PackageTypes = dbContext.PackageTypes.ToList();
        PackageTypeColumn.ItemsSource = PackageTypes;

        MedicationPackage = medication.Packaging;
        PackageGrid.ItemsSource = MedicationPackage;
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
        if ((PackageTypeColumn.ItemsSource ) == null)
        {
            MessageBox.Show("Укажите упаковку");
            return;
        }
        
        try
        {
            var all = Medication.Packaging.Select(x => x.PackageType);

            if (all.Distinct().Count() != all.Count())
            {
                MessageBox.Show("Обнаружены дубликаты типов упаковок");
            }
            else
            {
                dbContext.SaveChanges();
                Close();
            }
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}