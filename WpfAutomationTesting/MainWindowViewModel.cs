using Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAutomationTesting
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataItem> Items { get; private set; }

        public ICommand AddCommand { get; private set; }

        int Num = 4;

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<DataItem>()
            {
                new DataItem() {Text = "1", Text2 = "a" },
                new DataItem() {Text = "2", Text2 = "b" },
                new DataItem() {Text = "3", Text2 = "c" }
            };

            AddCommand = new DelegateCommand(() =>
            {
                Items.Add(new DataItem() { Text = Num.ToString() });
                Num++;
            });
        }
    }
}
