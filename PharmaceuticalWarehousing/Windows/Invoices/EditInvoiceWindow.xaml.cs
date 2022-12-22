using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Invoices;

public partial class EditInvoiceWindow : Window
{
   private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Invoice Invoice { get; set; }
    public List<Salesman> Salesmens { get; set; }
    public List<Counterparty> Counterpartys { get; set; }
    public List<Medication> Medications { get; set; }
    public Medication SelectMedication { get; set; }
    public EditInvoiceWindow(PharmaceuticalWarehousingDbContext dbContext, User user, Invoice invoice)
    {
        InitializeComponent();
        DataContext = this;
        Invoice = invoice;
        this.dbContext = dbContext;
        this.user = user;
        Salesmens = dbContext.Salesmans.ToList();
        Counterpartys = dbContext.Counterparties.ToList();
        Medications = this.dbContext.Medications.ToList();
        
        MedicationGrid.ItemsSource = Invoice.Medications;
    }

    private void SaveButton(object sender, RoutedEventArgs e)
    {
        try
        {
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void AddMedicationButton(object sender, RoutedEventArgs e)
    {
        if (Invoice.Medications.Any(x => x.Id == SelectMedication.Id))
        {
            MessageBox.Show("Данный препарат уже добавлен");
            return;
        }
        
        Invoice.Medications.Add(SelectMedication);
        MedicationGrid.ItemsSource = Invoice.Medications;
        MedicationGrid.Items.Refresh();
    }

    private void DeleteMedicationButton(object sender, RoutedEventArgs e)
    {
        if (MedicationGrid.SelectedItems.Count > 0)
        {
            for (int i = 0; i < MedicationGrid.SelectedItems.Count; i++)
            {
                if (MedicationGrid.SelectedItems[i] is Medication medication)
                {
                    Invoice.Medications.Remove(medication);
                }
            }
        }
        
        MedicationGrid.ItemsSource = Invoice.Medications;
        MedicationGrid.Items.Refresh();
    }
}