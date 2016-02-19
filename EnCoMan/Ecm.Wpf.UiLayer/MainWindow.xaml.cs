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
using Ecm.BlLayer;
using Ecm.Common.Dto;


namespace Ecm.Wpf.UiLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Reset database
            ConfigurationLogic.ResetDatabaseData();
            
            // Get all
            var allConfigurations = ConfigurationLogic.GetConfigurationList();

            

            // Create
            var newConf = ConfigurationLogic.CreateConfiguration(new ConfigurationDto()
                                   {
                                       EnergyType = new EnergyTypeDto() { Id = 1},
                                       Periodicity = new PeriodicityDto() { Id = 1},
                                       Name = "Mová konfigurace 1",
                                       Order = (short)(allConfigurations.Max(c => c.Order) + 1),
                                       User = new UserDto() { Id = 1}
                                   });

            // Get one configuration
            var firstConfiguration = ConfigurationLogic.GetConfiguration(1);

            // update
            firstConfiguration.Name = "Aktualizovaná Konfigurace: " + DateTime.Now.ToShortTimeString();
            ConfigurationLogic.UpdateConfiguration(firstConfiguration);

            // delete
            ConfigurationLogic.DeleteConfiguration(2);
        }
    }
}
