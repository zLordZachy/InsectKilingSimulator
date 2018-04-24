using InsectMurderSimulator.ViewModel;

namespace InsectMurderSimulator.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel(Canvas);
        }
    }
}
