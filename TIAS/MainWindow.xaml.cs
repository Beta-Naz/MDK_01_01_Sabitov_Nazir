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
using TIAS.Core.Hex;
using TIAS.Pages;

namespace TIAS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public int CurrentLevel = 0;
        public List<HexMap> Maps = new List<HexMap>();

        //Вот это это потом уберю в отдельный класс, для логов, но щяс пускай тут будет
        private List<string> _errorMessages = new List<string>();
        public List<string> ErrorMessages
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                _errorMessages = value;
                MessageBox.Show($"Ошибка: {_errorMessages[_errorMessages.Count-1]}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        //
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            frame.Navigate(new MainMenu());
        }
    }
}
