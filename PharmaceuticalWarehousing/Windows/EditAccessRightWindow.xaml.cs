using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;

namespace PharmaceuticalWarehousing.Windows;

public partial class EditAccessRightWindow : Window
{
    private readonly PharmaceuticalWarehousingDbContext dbContext;
    public List<AccessRight> AccessRights { get; set; }
    public List<FormType> FormTypeColumn { get; set; }
    public EditAccessRightWindow(PharmaceuticalWarehousingDbContext dbContext,
        User selectedUser)
    {
        InitializeComponent();
        this.dbContext = dbContext;
        DataContext = this;
        FormTypeColumn = Enum.GetValues(typeof(FormType)).Cast<FormType>().ToList();
        
        AccessRights = selectedUser.AccessRights.ToList();
        AccessRightGrid.ItemsSource = AccessRights;
    }
    
    private void SaveButton_Click(object sender, RoutedEventArgs e)
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