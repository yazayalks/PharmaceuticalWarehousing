using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows.Counterpartys;

public partial class EditCounterpartyWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    private readonly User user;
    public Counterparty Counterparty { get; set; }
    public List<PaymentAccount> PaymentAccounts { get; set; }
    public EditCounterpartyWindow(PharmaceuticalWarehousingDbContext dbContext, User user, Counterparty counterparty)
    {
        InitializeComponent();
        this.dbContext = dbContext;
        this.user = user;
        this.Counterparty = counterparty;
        DataContext = this;
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
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}