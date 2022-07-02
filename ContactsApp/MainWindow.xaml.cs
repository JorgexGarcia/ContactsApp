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

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDataBase();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindows = new NewContactWindow();
            newContactWindows.ShowDialog();

            ReadDataBase();
        }

        public void ReadDataBase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if(contacts != null)
            {
                contactListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            var textFilter = contacts.Where(c => c.Name.ToLower().Contains(textBox.Text.ToLower())).ToList();

            contactListView.ItemsSource = textFilter;
        }

        private void SelectedContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = contactListView.SelectedItem as Contact;

            if(contact != null)
            {
                ContactDetailWindow contactDetailWindow = new ContactDetailWindow(contact);
                contactDetailWindow.ShowDialog();
            }

            ReadDataBase();
        }
    }
}
