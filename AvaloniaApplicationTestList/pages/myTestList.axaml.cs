using Avalonia;
using Avalonia.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls.Presenters;
// using Avalonia.Themes.Neumorphism.Colors;
using System.Collections.Generic;
using System;
using Avalonia.Interactivity;
using System.IO;
using Avalonia.Controls.Shapes;

namespace AvaloniaApplicationTestList.pages
{
    public partial class myTestList : UserControl
    {

        public class TraceItem
        {
            public string? OutPut { get; set; }
            public string? ForeColor { get; set; }
            public string? BackgroundColor { get; set; }
        }

        public static StyledProperty<ObservableCollection<TraceItem>> ItemsTraceListProperty =
            AvaloniaProperty.Register<myTestList, ObservableCollection<TraceItem>>(nameof(ItemsTraceList));

        public ObservableCollection<TraceItem> ItemsTraceList
        {
            get => GetValue(ItemsTraceListProperty);
            set => SetValue(ItemsTraceListProperty, value);
        }


        private int lineNumber = 0;

        //private ObservableCollection<TraceItem> _itemsTraceList;
        //public ObservableCollection<TraceItem> ItemsTraceList
        //{
        //    get { return _itemsTraceList; }
        //    set { _itemsTraceList = value; }
        //}

        public myTestList()
        {
            InitializeComponent();
            //foreach (Avalonia.Themes.Neumorphism.Colors.PrimaryColor color in Enum.GetValues(typeof(Avalonia.Themes.Neumorphism.Colors.PrimaryColor)))
            //{
            //    AddInDisplay(color.ToString(), color.ToString());
            //}

            AddInDisplay("Dog", "Red");

            //TraceListBox.ItemsSource = new ObservableCollection<TraceItem>();
        }



        public void ResetLogs(object sender, RoutedEventArgs e)
        {
            ResetLogs();
        }


        public void ResetLogs()
        {
            if (ItemsTraceList != null)
            {
                ItemsTraceList.Clear();
            }
        }


        static int nbLinesMax = 1000;
        int maxLines = nbLinesMax;


        public void PopulateFull(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("..\\..\\..\\..\\dataForTest\\UniteGui_2024_03_21_10_49_46.txt"))
            {
                string line;
                // read file line by line
                while ((line = sr.ReadLine()) != null)
                {
                    AddInDisplay(line);
                    lineNumber++;
                }
            }

        }

        public void Populate(object sender, RoutedEventArgs e)
        {
            // open file with a StreamReader
            using (StreamReader sr = new StreamReader("..\\..\\..\\..\\dataForTest\\UniteGui_2024_03_21_10_49_46.txt"))
            {
                string line;

                for (int i = 1; i < lineNumber; i++) // loop until last number line
                {
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        return;
                    }
                }

                    // read file line by line
                while ((line = sr.ReadLine()) != null && lineNumber < (maxLines + 1))
                {
                    AddInDisplay(line);
                    lineNumber++;
                }
                lineNumber++;
                maxLines += nbLinesMax;
            }
        }


        private void AddInDisplay(string message, string foreColor = "Black")
        {

            TraceItem consoleItem = new TraceItem()
            {
                OutPut = message,
                ForeColor = foreColor,
                BackgroundColor = "Transparent"
            };

            if (ItemsTraceList != null)
            {
                ItemsTraceList.Add(consoleItem);
                
            }
            else
            {
                ItemsTraceList = new()
                {
                    consoleItem
                };
                // TraceListBox.ItemsSource = ItemsTraceList;
            }

            if (ItemsTraceList.Count > 0)
            {
                TraceListBox.SelectedIndex = ItemsTraceList.Count - 1;
            }
        }
    }
}
