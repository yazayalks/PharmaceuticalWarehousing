using System.Collections.Generic;
using System.Linq;
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