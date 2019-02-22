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

namespace TestApp
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
            UiTests.Tests test = new UiTests.Tests();
            UiTests.Tests.ClassInitialize(null);

            string result = "Success";
            try
            {
                test.SuccessTest();
            }
            catch(Exception exc)
            {
                result = exc.Message;
            }

            tbResult.Text = result;

            test.ClassCleanup();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UiTests.Tests test = new UiTests.Tests();
            UiTests.Tests.ClassInitialize(null);

            string result = "Success";
            try
            {
                test.FailedTest();
            }
            catch (Exception exc)
            {
                result = exc.Message;
            }

            tbResult.Text = result;

            test.ClassCleanup();
        }
    }
}
