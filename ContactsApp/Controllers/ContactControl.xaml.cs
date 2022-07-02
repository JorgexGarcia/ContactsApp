using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp.Controllers
{
    /// <summary>
    /// Lógica de interacción para ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact Contact
        {
            get { return (Contact)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact()
            {
                Name = "Name LastName",
                Email = "example@gmail.com",
                Phone = "961494949"
            }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = (ContactControl)d;

            if(contactControl != null)
            {
                contactControl.nameTextBox.Text = (e.NewValue as Contact).Name;
                contactControl.emailTextBox.Text = (e.NewValue as Contact).Email;
                contactControl.phoneTextBox.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();


        }
    }
}
