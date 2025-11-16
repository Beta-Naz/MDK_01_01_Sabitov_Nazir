using Pizza_Сабитов.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza_Сабитов.Layouts
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public List<Dish> dishes = new List<Dish>();
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        public void CreatePizza()
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                var bc = new BrushConverter();

                Grid global = new Grid()
                {
                    Height = 100,
                    Background = (Brush)bc.ConvertFrom("#FFECECEC"),
                };
                if (i > 0)
                {
                    global.Margin = new Thickness(0, 10, 0, 0);
                }
                Image logo = new Image()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 50,
                    Margin = new Thickness(10,10,0,-10),
                    Width = 50
                };
                if (File.Exists(mainWindow.localPath + @"\image\dish\" + dishes[i].img + ".png"))
                {
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\dish\" + dishes[i].img + ".png"));
                }
                else
                {
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\icon.png"));
                }
                global.Children.Add(logo);
                Label name = new Label()
                {
                    Content = dishes[i].name,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(65, 0, 0, 0),
                    FontWeight = FontWeights.Bold
                };
                global.Children.Add(name);
                Label description = new Label()
                {
                    Content = dishes[i].description,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(65, 20, 0, 0),
                };
                global.Children.Add(description);
                if (dishes[i].Ingredients.Count != 0)
                {
                    string str_ingredients = "";
                    for (int j = 0; j < dishes[i].Ingredients.Count; j++)
                    {
                        str_ingredients += dishes[i].Ingredients[j].name;
                        if(j != dishes[i].Ingredients.Count - 1)
                        {
                            str_ingredients += ", ";
                        }
                    }
                    Label ingredients = new Label()
                    { 
                        Content= "Состав: " + str_ingredients,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(65, 40, 0, 0),
                    };
                    global.Children.Add(ingredients);
                }
                Label price = new Label()
                {
                    Content = "Цена: " + dishes[i].sizes[0].price + " р.",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(65, 0, 0, 10),
                };
                global.Children.Add(price);
                Label wes = new Label()
                {
                    Content = "Вес: " + dishes[i].sizes[0].wes + " гр.",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(236, 0, 0, 10),
                };
                global.Children.Add(wes);
                Button button1 = new Button()
                {
                    Content = dishes[i].sizes[0].size + " см.",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 110, 0),
                    Width = 45,
                    Background = Brushes.White,
                    Foreground = (Brush)bc.ConvertFrom("#FFDD3333"),
                    Tag = i,
                };
                Button button2 = new Button()
                {
                    Content = dishes[i].sizes[1].size + " см.",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 60, 0),
                    Width = 45,
                    Tag = i,
                };
                Button button3 = new Button()
                {
                    Content = dishes[i].sizes[2].size + " см.",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 10, 10, 0),
                    Width = 45,
                    Tag = i,
                };
                TextBox count = new TextBox()
                {
                    Text = "0",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 10, 33.6f, 10),
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 65,
                    Height = 19,
                    Tag = i,
                };
                global.Children.Add(count);
                CheckBox order = new CheckBox()
                {
                    Content = "Выбрать",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 10, 128, 13),
                    Tag = i,
                };
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString());
                    dishes[id].sizes[dishes[id].activeSize].orders = (bool)order.IsChecked;
                };
                global.Children.Add(order);
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button1.Tag.ToString())].sizes[0].price + " р.";
                    wes.Content = "Вес: " + dishes[int.Parse(button1.Tag.ToString())].sizes[0].wes + " гр.";
                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button3.Foreground = Brushes.White;
                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 0;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[0].orders;
                };
                global.Children.Add(button1);
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button2.Tag.ToString())].sizes[1].price + " р.";
                    wes.Content = "Вес: " + dishes[int.Parse(button2.Tag.ToString())].sizes[1].wes + " гр.";
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button3.Foreground = Brushes.White;
                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 1;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[1].orders;
                };
                global.Children.Add(button2);
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishes[int.Parse(button3.Tag.ToString())].sizes[2].price + " р.";
                    wes.Content = "Вес: " + dishes[int.Parse(button3.Tag.ToString())].sizes[2].wes + " гр.";
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Foreground = Brushes.White;
                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Foreground = Brushes.White;
                    dishes[int.Parse(button1.Tag.ToString())].activeSize = 2;
                    count.Text = dishes[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString();
                    order.IsChecked = dishes[int.Parse(button1.Tag.ToString())].sizes[2].orders;
                };
                global.Children.Add(button3);
                Button minus = new Button()
                {
                    Content = "-",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 103.6f, 10),
                    Width = 19,
                    Tag = i,
                };
                minus.Click += delegate
                {
                    if(count.Text != "")
                    {
                        if(int.Parse(count.Text) > 0)
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString();
                            int id = int.Parse(minus.Tag.ToString());
                            dishes[id].sizes[dishes[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(minus);
                Button plus = new Button()
                {
                    Content = "+",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 9.6f, 10),
                    Width = 19,
                    Tag = i,
                };
                plus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) < 15)
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();
                            int id = int.Parse(plus.Tag.ToString());
                            dishes[id].sizes[dishes[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(plus);
                parrent.Children.Add(global);
            }
        }
    }
}
