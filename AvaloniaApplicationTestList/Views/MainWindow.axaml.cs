using Avalonia.Controls;

namespace AvaloniaApplicationTestList.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LayoutUpdated += OnLayoutUpdated;


    }

    private void OnLayoutUpdated(object? sender, System.EventArgs e)
    {
        //this.Main.testList.BorderListBox.Height = this.Height - 150;
        this.Main.testList.TraceListBox.Height = this.Height - 150;
        this.Main.testList.TraceListBox.Width = this.Width;
        this.Main.TabControlMain.Height = this.Height - 50;
    }



}
