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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationSettings_Сабитов.Properties;
using Microsoft.Win32;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace ApplicationSettings_Сабитов.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        MainWindow MainWindow;
        public static Settings settings;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        ColorDialog colorDialog = new ColorDialog();
        FontDialog fontDialog = new FontDialog();
        public Settings(MainWindow _mainWindow)
        {
            InitializeComponent();
            settings = this;
            MainWindow = _mainWindow;
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Access files (*.accdb)|*.accdb|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = false;

            fontDialog.ShowHelp = false;
            fontDialog.ShowColor = false;
            fontDialog.ShowEffects = true;

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "config files (*.conf)|*.conf|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
        }

        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_database.Text = openFileDialog.FileName;
            }
        }

        private void SelectColorAplication(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                gr_header.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                gr_appliacation.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectColorText(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                var text = new[]
                {
                    textColor2,
                    textColor3,
                    textColor4,
                    textColor5,
                    textColor6,
                    textColor7,
                    textStyle,
                };
                var button = new[]
                {
                    textColor8,
                    textColor9,
                    textColor10,
                    textColor11,
                };
                for (int i = 0; i < text.Length; i++)
                {
                    text[i].Foreground = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                }
                for (int i = 0; i < button.Length; i++)
                {
                    button[i].Foreground = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                }
                gr_Text.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectFonts(object sender, RoutedEventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                var font = fontDialog.Font;
                var text = new[]
                {
                    textColor2,
                    textColor3,
                    textColor4,
                    textColor5,
                    textColor6,
                    textColor7,
                    textStyle,
                };
                var button = new[]
                {
                    textColor8,
                    textColor9,
                    textColor10,
                    textColor11,
                };
                for (int i = 0; i < text.Length; i++)
                {
                    text[i].FontFamily = new FontFamily(font.FontFamily.Name);
                }
                for (int i = 0; i < button.Length; i++)
                {
                    button[i].FontFamily = new FontFamily(font.FontFamily.Name); ;
                }
                textStyle.Content = font.FontFamily.Name;
            }
        }
        string name;
        private void SelectScreenResolution(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboBox = sender as System.Windows.Controls.ComboBox;
            TextBlock textBlock = comboBox.SelectedValue as TextBlock;
            string resoluton = textBlock.Text;
            name = resoluton;
            string[] separator = new string[1] { " x " };
            MainWindow.Width = int.Parse(resoluton.Split(separator, StringSplitOptions.None)[0]);
            MainWindow.Height = int.Parse(resoluton.Split(separator, StringSplitOptions.None)[1]);
        }

        private void Safe(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string contentText = "";
                contentText += "База данных:" + "\n";
                contentText += openFileDialog.FileName + "\n";
                contentText += "Разрешение:" + "\n";
                contentText += name + "\n";
                contentText += "Цвет шапки:" + "\n";
                contentText += $"{gr_header.Background}" + "\n";
                contentText += "Цвет текста:" + "\n";
                contentText += $"{textColor2.Foreground}" + "\n";
                contentText += "Стиль текста:" + "\n";
                contentText += $"{textStyle.FontFamily}" + "\n";
                File.WriteAllText(saveFileDialog.FileName, contentText);
            }
        }
    }
}
