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
using System.IO;

namespace type_struct
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

        List<obj> list = new List<obj>(); // Список с типом структуры
        string save_string = ""; // для сохранения в файл

        struct obj // Структура
        {
            public string firstName;
            public string lastName;
            public int age;
        }

        private async void writeFile(string info)
        {
            using (StreamWriter writer = new StreamWriter("info.txt", true)) // Путь
            {  
                await writer.WriteLineAsync(info); // Запись переменной в файл
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obj info; // Объект структуры

            info.firstName = textbox1.Text;
            info.lastName = textbox2.Text;
            info.age = Convert.ToInt32(textbox3.Text); // Заполнение строк структуры

            save_string = info.lastName + " " + info.firstName + " " + info.age; // склеивание переменных в одну строку

            list.Add(info); // Добавление в список

            listbox1.Items.Add(save_string); // Добавление в listbox
            writeFile(save_string); // Запись в файл info.txt
        }
    }
}
