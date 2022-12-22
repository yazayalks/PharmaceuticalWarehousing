using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Waybills;

public partial class AddWaybillWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Waybill Waybills { get; set; } = new();
    public List<Counterparty> Counterpartys { get; set; }
    public List<Medication> Medications { get; set; }
    public Medication SelectMedication { get; set; }
    public AddWaybillWindow(PharmaceuticalWarehousingDbContext dbContext, User user)
    {
        InitializeComponent();
        DataContext = this;
        this.dbContext = dbContext;
        this.user = user;
        Counterpartys = dbContext.Counterparties.ToList();
        Medications = this.dbContext.Medications.ToList();
        
        Waybills.Medications = new List<Medication>();
        MedicationGrid.ItemsSource = Waybills.Medications;
    }

    private void SaveButton(object sender, RoutedEventArgs e)
    {
        try
        {
            dbContext.Waybills.Add(Waybills);
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            dbContext.Waybills.Remove(Waybills);
            MessageBox.Show(exception.Message);
        }
    }

    private void AddMedicationButton(object sender, RoutedEventArgs e)
    {
        if (SelectMedication == null)
        {
            return;
        }
        if (Waybills.Medications.Any(x => x.Id == SelectMedication.Id))
        {
            MessageBox.Show("Данный препарат уже добавлен");
            return;
        }
        
        Waybills.Medications.Add(SelectMedication);
        MedicationGrid.ItemsSource = Waybills.Medications;
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
                    Waybills.Medications.Remove(medication);
                }
            }
        }
        
        MedicationGrid.ItemsSource = Waybills.Medications;
        MedicationGrid.Items.Refresh();
    }
}