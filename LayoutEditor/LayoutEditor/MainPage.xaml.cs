using System.Windows.Controls;
using LayoutEditor.Common.ViewModels;

namespace LayoutEditor
{
    public partial class MainPage : UserControl
    {
        public MainPage(MainPageViewModel context)
        {
            InitializeComponent();
            this.DataContext = context;
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((MainPageViewModel)DataContext).LoadData();
        }
    }
}