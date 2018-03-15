using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AutoMapper;
using Inventory.Data;
using Inventory.Data.Sqlite;
using Inventory.Data.Sqlite.Model;
using Inventory.ViewModels;
using Inventory.ViewModels.Customers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Inventory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var container = new Grace.DependencyInjection.DependencyInjectionContainer();
            container.Configure(x => x.Export<DataService>().As<IDataService>());
            container.Configure(x => x.Export<CustomersViewModel>());

            Mapper.Initialize(x => x.AddProfiles(typeof(CustomerDto), typeof(Customer), typeof(CustomerItemViewModel)));
            this.DataContext = container.Locate<MainViewModel>();
        }
    }
}
