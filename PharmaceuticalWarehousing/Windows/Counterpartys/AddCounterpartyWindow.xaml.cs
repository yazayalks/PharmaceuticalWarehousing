using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Counterpartys;

public partial class AddCounterpartyWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Counterparty Counterparty { get; set; } = new();
    public List<PaymentAccount> PaymentAccounts { get; set; }
    public AddCounterpartyWindow(PharmaceuticalWarehousingDbContext dbContext, User user)
    {
        InitializeComponent();
        DataContext = this;
        this.dbContext = dbContext;
        this.user = user;
        PaymentAccounts = dbContext.PaymentAccounts.ToList();
    }

    private void SaveButton(object sender, RoutedEventArgs e)
    {
        var regexITN = new Regex("^[0-9]+$");
        
        if (string.IsNullOrWhiteSpace(Counterparty.Title))
        {
            MessageBox.Show("Введите название контрагента");
            return;
        }
        if (Counterparty.Title.Length < 5)
        {
            MessageBox.Show("Название контрагента не может быть меньше 5 символов");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Counterparty.Flat))
        {
            MessageBox.Show("Введите номер квартиры или офиса");
            return;
        }
        if (string.IsNullOrWhiteSpace(Counterparty.Street))
        {
            MessageBox.Show("Введите улицу");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Counterparty.House))
        {
            MessageBox.Show("Введите номер дома или корпуса");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Counterparty.Phone))
        {
            MessageBox.Show("Введите номер телефона");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Counterparty.ITN))
        {
            MessageBox.Show("Введите ИНН");
            return;
        }
        
        if (!regexITN.IsMatch(Counterparty.ITN))
        { 
            MessageBox.Show("ИНН содержит только цифры");
            return;
        }
        if ((Counterparty.PaymentAccount) == null)
        {
            MessageBox.Show("Выберите расчётный счёт");
            return;
        }
        
        
        try
        {
            dbContext.Counterparties.Add(Counterparty);
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            dbContext.Counterparties.Remove(Counterparty);
            MessageBox.Show(exception.Message);
        }
    }
}