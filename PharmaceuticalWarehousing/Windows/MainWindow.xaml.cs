using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

using PharmaceuticalWarehousing.Models;
using PharmaceuticalWarehousing.Utilities;
using PharmaceuticalWarehousing.Windows.Counterpartys;
using PharmaceuticalWarehousing.Windows.Invoices;
using PharmaceuticalWarehousing.Windows.Medications;
using PharmaceuticalWarehousing.Windows.Waybills;

namespace PharmaceuticalWarehousing.Windows;

public partial class MainWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public List<Category> Categoryes { get; set; }
    public List<PackageType> PackageTypes { get; set; }
    public List<Bank> Banks { get; set; }
    public List<User> Users { get; set; }
    public List<UserType> UserTypes { get; set; }
    public List<AccessRight> AccessRights { get; set; }
    public List<Salesman> Salesmans { get; set; }
    public List<PaymentAccount> PaymentAccounts { get; set; }
    public List<Counterparty> Counterparties { get; set; }

    public List<Manufacturer> Manufacturers { get; set; }

    public MainWindow(PharmaceuticalWarehousingDbContext dbContext, User user)
    {
        InitializeComponent();

        this.dbContext = dbContext;
        this.user = user;
        DataContext = this;

        if (user.UserType != UserType.admin)
        {
            AdminTabItem.Visibility = Visibility.Hidden;
        }

        var medicationAccessRight = user.AccessRights.Single(x => x.Form == FormType.MedicationForm);
        AccessRightForm(medicationAccessRight, MedicationTabItem, MedicationGridItem, addMedicationButton, editMedicationButton, deleteMedicationButton); 
        var wybillAccessRight = user.AccessRights.Single(x => x.Form == FormType.WaybillForm);
        AccessRightForm(wybillAccessRight, WaybillTabItem, WaybillGridItem, addWaybillButton, editWaybillButton, deleteWaybillButton);
        var counterpartyAccessRight = user.AccessRights.Single(x => x.Form == FormType.CounterpartyForm);
        AccessRightForm(counterpartyAccessRight, CounterpartyTabItem, CounterpartyGridItem, addCounterpartyButton, editCounterpartyButton, deleteCounterpartyButton);
        var invoiceAccessRight = user.AccessRights.Single(x => x.Form == FormType.InvoiceForm);
        AccessRightForm(invoiceAccessRight, InvoiceTabItem, InvoiceGridItem, addInvoiceButton, editInvoiceButton, deleteInvoiceButton);
        
        var paymentAccountAccessRight = user.AccessRights.Single(x => x.Form == FormType.PaymentAccountForm);
        AccessRightGrid(paymentAccountAccessRight, PaymentAccountTabItem, PaymentAccountGrid);
        var bankAccountAccessRight = user.AccessRights.Single(x => x.Form == FormType.BankForm);
        AccessRightGrid(bankAccountAccessRight, BankTabItem, BankGrid);
        var packageTypeAccessRight = user.AccessRights.Single(x => x.Form == FormType.PackageTypeForm);
        AccessRightGrid(packageTypeAccessRight, PackageTypeTabItem, PackageTypeGrid);
        var manufacturerAccessRight = user.AccessRights.Single(x => x.Form == FormType.ManufacturerForm);
        AccessRightGrid(manufacturerAccessRight, ManufacturerTabItem, ManufacturerGrid);
        var categoryAccessRight = user.AccessRights.Single(x => x.Form == FormType.CategoryForm);
        AccessRightGrid(categoryAccessRight, CategoryTabItem, CategoryGrid);
        var medicineAccessRight = user.AccessRights.Single(x => x.Form == FormType.MedicineForm);
        AccessRightGrid(medicineAccessRight, MedicineTabItem, MedicineGrid);
        var salesmanAccessRight = user.AccessRights.Single(x => x.Form == FormType.SalesmanForm);
        AccessRightGrid(salesmanAccessRight, SalesmanTabItem, SalesmanGrid);

        RefreshUserGrid();
        RefreshCategoryGrid();
        RefreshMedicationGrid();
        RefreshMedicineGrid();
        RefreshPackageTypeGrid();
        RefreshBankGrid();
        RefreshSalesmanGrid();
        RefreshPaymentAccountGrid();
        RefreshManufacturerGrid();
        RefreshCounterpartyGrid();
        RefreshInvoiceGrid();
        RefreshWaybillGrid();


        this.Closing += MainWindow_Closing;
    }

    private void AccessRightForm(AccessRight accessRight, TabItem tabItem, Grid grid, Button addButton, Button editButton, Button deleteButton)
    {
        if (!accessRight.Read) {
            tabItem.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Hidden;
        }
        addButton.IsEnabled = accessRight.Write;
        editButton.IsEnabled = accessRight.Edit;
        deleteButton.IsEnabled = accessRight.Delete;
    }

    private void AccessRightGrid(AccessRight accessRight, TabItem tabItem, DataGrid grid)
    {
        if (!accessRight.Read) {
            tabItem.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Hidden;
        }
        grid.IsReadOnly = !accessRight.Edit;
        grid.CanUserAddRows = accessRight.Write;
        grid.CanUserDeleteRows = accessRight.Delete;
    }

    private void RefreshWaybillGrid()
    {
        WaybillGrid.ItemsSource = dbContext.Waybills.Include(x => x.Medications).ToList();
        WaybillGrid.Items.Refresh();
    }

    private void RefreshUserGrid()
    {
        // var a =        Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList().Select(x=>x.ToString());
        var userTypes = Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();

        UserTypesColumn.ItemsSource = userTypes;
        UserGrid.ItemsSource = dbContext.Users.Include(x => x.AccessRights).ToList();
        UserGrid.Items.Refresh();
    }

    private void RefreshInvoiceGrid()
    {
        InvoiceGrid.ItemsSource = dbContext.Invoices.Include(x => x.Medications).ToList();
        CounterpartyGrid.Items.Refresh();
    }


    private void RefreshCounterpartyGrid()
    {
        Counterparties = dbContext.Counterparties.ToList();
        CounterpartyGrid.ItemsSource = Counterparties;

        CounterpartyGrid.Items.Refresh();
    }

    private void RefreshCategoryGrid()
    {
        Categoryes = dbContext.Categorys.ToList();
        CategoryColumn.ItemsSource = Categoryes;
        CategoryGrid.ItemsSource = Categoryes;

        CategoryGrid.Items.Refresh();
    }

    private void RefreshMedicineGrid()
    {
        MedicineGrid.ItemsSource = dbContext.Medicines
            .Include(x => x.Category)
            .ToList();

        MedicineGrid.Items.Refresh();
    }

    private void RefreshPackageTypeGrid()
    {
        PackageTypes = dbContext.PackageTypes.ToList();
        PackageTypeGrid.ItemsSource = PackageTypes;

        PackageTypeGrid.Items.Refresh();
    }

    private void RefreshManufacturerGrid()
    {
        Manufacturers = dbContext.Manufacturers.ToList();
        ManufacturerGrid.ItemsSource = Manufacturers;
        ManufacturerGrid.Items.Refresh();
    }

    private void RefreshBankGrid()
    {
        Banks = dbContext.Banks.ToList();
        BankGrid.ItemsSource = Banks;
        BankGrid.Items.Refresh();
    }

    private void RefreshSalesmanGrid()
    {
        Salesmans = dbContext.Salesmans.ToList();
        SalesmanGrid.ItemsSource = Salesmans;
        SalesmanGrid.Items.Refresh();
    }

    private void RefreshPaymentAccountGrid()
    {
        PaymentAccounts = dbContext.PaymentAccounts.ToList();
        PaymentAccountGrid.ItemsSource = PaymentAccounts;
        PaymentAccountGrid.Items.Refresh();

        BankColumn.ItemsSource = Banks;
    }

    private void RefreshMedicationGrid()
    {
        var search = searchTextBox.Text.ToLower();
        MedicationGrid.ItemsSource = dbContext.Medications
            .AsSplitQuery()
            .Include(x => x.Manufacturer)
            .Include(x => x.Medicine)
            .Include(x => x.Packaging)
            .Where(x => x.Medicine.Name.ToLower().Contains(search)
                        || x.Manufacturer.Name.ToLower().Contains(search)
                        || x.RegistrationNumber.ToString().Contains(search))
            .ToList();
    
        MedicationGrid.Items.Refresh();
    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var authWindow = new AuthWindow();
        authWindow.Show();
    }

    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        try
        {
            dbContext.PackageTypes.AddRange(PackageTypes.Except(dbContext.PackageTypes.ToList()));
            dbContext.Banks.AddRange(Banks.Except(dbContext.Banks.ToList()));
            dbContext.Salesmans.AddRange(Salesmans.Except(dbContext.Salesmans.ToList()));
            dbContext.PaymentAccounts.AddRange(PaymentAccounts.Except(dbContext.PaymentAccounts.ToList()));
            dbContext.Manufacturers.AddRange(Manufacturers.Except(dbContext.Manufacturers.ToList()));
            dbContext.Counterparties.AddRange(Counterparties.Except(dbContext.Counterparties.ToList()));
            dbContext.SaveChanges();
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void SearchMedicationButtonClick(object sender, RoutedEventArgs e)
    {
        RefreshMedicationGrid();
    }

    private void DeleteMedicationButtonClick(object sender, RoutedEventArgs e)
    {
        if (MedicationGrid.SelectedItems.Count > 0)
        {
            for (int i = 0; i < MedicationGrid.SelectedItems.Count; i++)
            {
                if (MedicationGrid.SelectedItems[i] is Medication medication)
                {
                    dbContext.Medications.Remove(medication);
                }
            }
        }


        dbContext.SaveChanges();
        RefreshMedicationGrid();
    }

    private void AddMedicationButtonClick(object sender, RoutedEventArgs e)
    {
        var addMedicationWindow = new AddMedicationWindow(dbContext, user);
        addMedicationWindow.ShowDialog();
        RefreshMedicationGrid();
    }

    private void EditMedicationButtonClick(object sender, RoutedEventArgs e)
    {
        if (MedicationGrid.SelectedItems.Count == 1)
        {
            var editMedicationWindow =
                new EditMedicationWindow(dbContext, user, (Medication)MedicationGrid.SelectedItems[0]!);
            editMedicationWindow.ShowDialog();
            RefreshMedicationGrid();
        }
    }

    private void DeleteCounterpartyButtonClick(object sender, RoutedEventArgs e)
    {
        if (CounterpartyGrid.SelectedItems.Count > 0)
        {
            for (int i = 0; i < CounterpartyGrid.SelectedItems.Count; i++)
            {
                if (CounterpartyGrid.SelectedItems[i] is Counterparty counterparty)
                {
                    dbContext.Counterparties.Remove(counterparty);
                }
            }
        }

        dbContext.SaveChanges();
        RefreshCounterpartyGrid();
    }

    private void AddCounterpartyButtonClick(object sender, RoutedEventArgs e)
    {
        var addCounterpartyWindow = new AddCounterpartyWindow(dbContext, user);
        addCounterpartyWindow.ShowDialog();
        RefreshCounterpartyGrid();
    }

    private void EditCounterpartyButtonClick(object sender, RoutedEventArgs e)
    {
        if (CounterpartyGrid.SelectedItems.Count == 0) return;
        var editCounterpartyWindow =
            new EditCounterpartyWindow(dbContext, user, (Counterparty)CounterpartyGrid.SelectedItems[0]!);
        editCounterpartyWindow.ShowDialog();
        RefreshCounterpartyGrid();
    }

    private void AddInvoiceButtonClick(object sender, RoutedEventArgs e)
    {
        var addInvoiceWindow = new AddInvoiceWindow(dbContext, user);
        addInvoiceWindow.ShowDialog();
        RefreshInvoiceGrid();
    }

    private void EditInvoiceButtonClick(object sender, RoutedEventArgs e)
    {
        if (InvoiceGrid.SelectedItems.Count > 0)
        {
            var editInvoiceWindow = new EditInvoiceWindow(dbContext, user, (Invoice)InvoiceGrid.SelectedItems[0]!);
            editInvoiceWindow.ShowDialog();
            RefreshInvoiceGrid();
        }
    }

    private void DeleteInvoiceButtonClick(object sender, RoutedEventArgs e)
    {
        if (InvoiceGrid.SelectedItems.Count > 0)
        {
            for (int i = 0; i < InvoiceGrid.SelectedItems.Count; i++)
            {
                if (InvoiceGrid.SelectedItems[i] is Invoice invoice)
                {
                    dbContext.Invoices.Remove(invoice);
                }
            }
        }

        dbContext.SaveChanges();
        RefreshInvoiceGrid();
    }

    private void DeleteWaybillButtonClick(object sender, RoutedEventArgs e)
    {
        if (WaybillGrid.SelectedItems.Count > 0)
        {
            for (int i = 0; i < WaybillGrid.SelectedItems.Count; i++)
            {
                if (WaybillGrid.SelectedItems[i] is Waybill waybill)
                {
                    dbContext.Waybills.Remove(waybill);
                }
            }
        }

        dbContext.SaveChanges();
        RefreshWaybillGrid();
    }

    private void EditWaybillButtonClick(object sender, RoutedEventArgs e)
    {
        if (WaybillGrid.SelectedItems.Count > 0)
        {
            var editWaybillWindow = new EditWaybillWindow(user, ((Waybill)WaybillGrid.SelectedItems[0]!).Id);
            editWaybillWindow.ShowDialog();
            RefreshWaybillGrid();
        }
    }

    private void AddWaybillButtonClick(object sender, RoutedEventArgs e)
    {
        var addWaybillWindow = new AddWaybillWindow(dbContext, user);
        addWaybillWindow.ShowDialog();
        RefreshWaybillGrid();
    }

    private void EditUserButton_Click(object sender, RoutedEventArgs e)
    {
        if (UserGrid.SelectedItems.Count > 0)
        {
            var editAccessRightWindow = new EditAccessRightWindow(dbContext, ((User)UserGrid.SelectedItems[0]!));
            editAccessRightWindow.ShowDialog();
            RefreshWaybillGrid();
        }
    }
    private void RecoverPasswordButton_OnClick(object sender, RoutedEventArgs e)
    {
        var oldPassword = OldPasswordTexBox.Password;
        var newPassword = NewPasswordTexBox.Password;
        var confirmPassword = ConfirmPasswordTexBox.Password;
        
        if (oldPassword == String.Empty)
        {
            MessageBox.Show("Старый может быть пустым");
            return;
        }
        if (newPassword == String.Empty)
        {
            MessageBox.Show("Новый пароль не может быть пустым");
            return;
        }
        if (confirmPassword == String.Empty)
        {
            MessageBox.Show("Подтвержение пароля не может быть пустым");
            return;
        }
        if (newPassword.Length < 5)
        {
            MessageBox.Show("Новый пароль не может быть меньше 5 символов");
            return;
        }
        if (confirmPassword.Length < 5)
        {
            MessageBox.Show("Подтвержение пароля не может быть меньше 5 символов");
            return;
        }
        
        if (user.Password == PasswordEncrypter.GetHash(oldPassword))
        {
            if(newPassword == confirmPassword)
            {
                var PasswordHash = PasswordEncrypter.GetHash(newPassword);
                user.Password = PasswordHash;
                dbContext.SaveChanges();
                OldPasswordTexBox.Password = string.Empty;
                NewPasswordTexBox.Password = string.Empty;
                ConfirmPasswordTexBox.Password = string.Empty;
                MessageBox.Show("Пароль успешно изменён!");

            } else
            {
                MessageBox.Show("Новые пароли не совпадают");
            }

        } else
        {
            MessageBox.Show("Старый пароль неправильный");
        }

    }
}