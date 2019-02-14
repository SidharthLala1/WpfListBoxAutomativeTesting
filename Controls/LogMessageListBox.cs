using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Controls
{
    public class LogMessageListBox : Control
    {
        ListBox ListBoxLog;

        static LogMessageListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LogMessageListBox), new FrameworkPropertyMetadata(typeof(LogMessageListBox)));
        }

        public override void OnApplyTemplate()
        {
            ListBoxLog = (ListBox)GetTemplateChild("ListBoxLog");

            ListBoxLog.Loaded += ListBoxLog_Loaded;

            ((INotifyCollectionChanged)ListBoxLog.Items).CollectionChanged += LogMessageListBox_CollectionChanged;

            base.OnApplyTemplate();
        }

        private void ListBoxLog_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollDown();
        }

        private void LogMessageListBox_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ScrollDown();
        }

        private void ScrollDown()
        {
            ListBoxLog.Items.MoveCurrentToLast();
            ListBoxLog.ScrollIntoView(ListBoxLog.Items.CurrentItem);
        }

        public ObservableCollection<DataItem> LogMessages
        {
            get { return (ObservableCollection<DataItem>)GetValue(LogMessagesProperty); }
            set { SetValue(LogMessagesProperty, value); }
        }

        public static readonly DependencyProperty LogMessagesProperty =
            DependencyProperty.Register("LogMessages", typeof(ObservableCollection<DataItem>), typeof(LogMessageListBox), new PropertyMetadata(null));
    }
}
