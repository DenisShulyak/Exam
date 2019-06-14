using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExamWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[] array = new int[0];
        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = int.Parse(numberTextBox.Text) + 1;
                Array.Resize(ref array, count);

                var threads = new Thread[array.Length];
                RecordArray recordArray = new RecordArray();
                recordArray.Array = array;

                for (int i = 0; i < threads.Length; i++)
                {
                    Thread.Sleep(100);
                    var thread = new Thread(recordArray.WriteToArray);
                    thread.Start();
                    array = recordArray.Array;
                }

            }
            catch
            {
                MessageBox.Show("Введите натуральное число!");
            }

        }

        
        

        public Task LoadToDatabase()
        {
            return Task.Run(() => {
                try
                {
                    using (var context = new ProductsContext())
                    {
                        string categoryTextBoxText = null;
                        Dispatcher.Invoke(() => categoryTextBoxText = categoryTextBox.Text);
                        Category category = new Category();
                        category.Name = categoryTextBoxText;

                        context.Categories.Add(category);

                        CountryOrigin country = new CountryOrigin();
                        string countryOriginTextBoxText = null;
                        Dispatcher.Invoke(() => countryOriginTextBoxText = countryOriginTextBox.Text);
                        country.Name = countryOriginTextBoxText;

                        context.CountryOrigins.Add(country);

                        string priceTextBoxText = null;
                        Dispatcher.Invoke(() => priceTextBoxText = priceTextBox.Text);
                        int price = int.Parse(priceTextBoxText);

                        int year = 0;
                        int month = 0;
                        int day = 0;
                        Dispatcher.Invoke(() =>
                        {
                            year = datePicker.SelectedDate.Value.Date.Year;
                            month = datePicker.SelectedDate.Value.Date.Month;
                            day = datePicker.SelectedDate.Value.Date.Day;
                        });


                        DateTime dateTime = new DateTime(year, month, day);
                        string nameProduct = null;
                        Dispatcher.Invoke(() => nameProduct = nameProductTextBox.Text);
                        Product product = new Product
                        {
                            Name = nameProduct,
                            DateOfIssue = dateTime,
                            Price = price,
                            CategoryId = category.Id,
                            CountryOriginId = country.Id
                        };


                        context.Products.Add(product);


                        context.SaveChanges();
                        MessageBox.Show("Данные загружены!");
                    }
                }
                catch
                {
                    MessageBox.Show("Некоректные данные");
                }
            
            });



        }

        private async void LoadToDataBaseButtonClick(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Дата выпуска не может быть больше текущей!");
            }
            else
            {
            await LoadToDatabase();
            }

        }
    }
}
