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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Task timer;
        private int proValue;
        private int balls = 0;
        private int vo = 1;
        int numberq = 0;
        string[] v = { "1. Что такое массив? ", "2. Что такое int? ", "3. Какие значения может принимать тип данных bool?", "4. О чем говорит слово void?", "5. Как называется функция вызывающая саму себя?", "6. Как называется один цикл в цикле фор?", "7. Сколько есть циклов?", "8. Что такое полиморфизм? ","9. С помощью чего обращаются к элементам массива?","10. Как обозначается массив?" };
        string[] a1 = { "Набор однотипных данных ", "Строковый тип данных", "1,2,3,4,5,6,7,8,9,0", "о логическом типе данных", "рекурсивная", "Проход", "2", "Один класс наследуется от другого класса", "По индексу", "{}" };
        string[] a2 = { "Строковая переменная ", "Целочисленный тип данных", "Дробные", "о функции", "целочисленная", "Итерация", "3", "Сокрытие внутренностей класса", "по названию", "[]" };
        string[] a3 = { "Метод ", "Логический тип данных", "true/false", "о процедуре", "скрытая", "Круг", "4", "Использование 1 интерфейса для разных классов", "по номеру", "()" };
        public MainWindow()
        {
            InitializeComponent();
            restart.Visibility = Visibility.Hidden;
            perv.Visibility = Visibility.Hidden;
            vtoroy.Visibility = Visibility.Hidden;
            treti.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Hidden;
            pr.Visibility = Visibility.Hidden;
        }
        
        private async Task FillPrBarAsync()
        {
            pr.Value = 0;
            for (int i = 0; i <= 6000000; i++)
            {
                pr.Value = i;
                await Task.Delay(500);
            }
        }

        private void pr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var tr = TimeSpan.FromSeconds(pr.Value);
            timertekst.Text = string.Format("{0}:{1}:{2}", tr.Hours,tr.Minutes, tr.Seconds);
        }


        private async void start_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Hidden;
            title.Visibility = Visibility.Hidden;
            perv.Visibility = Visibility.Visible;
            vtoroy.Visibility = Visibility.Visible;
            treti.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
            pr.Visibility = Visibility.Visible;
            ball.Text = Convert.ToString(balls) + "/ 15 баллов";
            
            voprosy.Text= Convert.ToString(vo) + "/ 10 вопросов";
            question.Text = v[0];
            pervtext.Text = a1[0];
            vtoroytext.Text = a2[0];
            tretiitext.Text = a3[0];
            start.IsEnabled = false;
            await FillPrBarAsync();
            start.IsEnabled = true;
            
        }
        
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)perv.IsChecked || (bool)vtoroy.IsChecked || (bool)treti.IsChecked)
            {
                switch (numberq)
                {
                    case 0:
                        if ((bool)perv.IsChecked)
                        {
                            balls+=2;
                        }

                        break;
                    case 1:
                        if ((bool)vtoroy.IsChecked)
                        {
                            balls++;
                        }
                        break;

                    case 2:
                        if ((bool)treti.IsChecked)
                        {
                            balls+=2;
                        }
                        break;
                    case 3:
                        if ((bool)treti.IsChecked)
                        {
                            balls++;
                        }
                        break;
                    case 4:
                        if ((bool)perv.IsChecked)
                        {
                            balls++;
                        }
                        break;
                    case 5:
                        if ((bool)vtoroy.IsChecked)
                        {
                            balls+=2;
                        }
                        break;
                    case 6:
                        if ((bool)treti.IsChecked)
                        {
                            balls++;
                        }
                        break;
                    case 7:
                        if ((bool)treti.IsChecked)
                        {
                            balls+=2;
                        }
                        break;
                    case 8:
                        if ((bool)perv.IsChecked)
                        {
                            balls+=2;
                        }
                        break;
                    case 9:
                        if ((bool)vtoroy.IsChecked)
                        {
                            balls++;
                        }
                        break;

                    default:

                        break;


                }

                ball.Text = Convert.ToString(balls) + "/ 15 баллов";
                voprosy.Text= Convert.ToString(vo) + "/ 10 вопросов";
                if (numberq == 9)
                {
                    string h = timertekst.Text;
                    pr.Visibility = Visibility.Hidden;
                    restart.Visibility = Visibility.Visible;
                    perv.Visibility = Visibility.Hidden;
                    vtoroy.Visibility = Visibility.Hidden;
                    treti.Visibility = Visibility.Hidden;
                    save.Visibility = Visibility.Hidden;
                    pr.Visibility = Visibility.Hidden;
                    timertekst.Visibility = Visibility.Hidden;
                    ball.Visibility = Visibility.Hidden;
                    question.Visibility = Visibility.Hidden;
                    pervtext.Visibility = Visibility.Hidden;
                    vtoroytext.Visibility = Visibility.Hidden;
                    tretiitext.Visibility = Visibility.Hidden;
                    voprosy.Visibility = Visibility.Hidden;
                    title.Visibility = Visibility.Visible;
                    title.Text = "Ваш результат: " + balls + "/ 15\n Ваше время: " + h;
                }
                else
                {
                    vo++;
                    voprosy.Text = Convert.ToString(vo) + "/ 10 вопросов";
                    numberq++;
                    perv.IsChecked = false;
                    vtoroy.IsChecked = false;
                    treti.IsChecked = false;
                    question.Text = v[numberq];
                    pervtext.Text = a1[numberq];
                    vtoroytext.Text = a2[numberq];
                    tretiitext.Text = a3[numberq];
                }
            }
            else
            {
                MessageBox.Show("Нужно выбрать один из вариантов!");
            }
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);//запуск заново
            Application.Current.Shutdown();
        }
    }
}
