using System.Collections.Generic;
using System.Linq;
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
        try
        {
            dbContext.Counterparties.Add(Counterparty);
            dbContext.SaveChanges();
            Close();
        }
        catch (DbUpdateException exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}