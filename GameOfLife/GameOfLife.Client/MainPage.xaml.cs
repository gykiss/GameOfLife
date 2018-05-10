using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GameOfLife.Client.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameOfLife.Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModels.MainPageViewModel model;
        public MainPage()
        {
            model = new ViewModels.MainPageViewModel();
            model.timer.Tick += timer_Tick;
            model.Table = (new int[,] { 
                { 0, 0, 0, 0, 0 }, 
                { 0, 0, 1, 0, 0 }, 
                { 0, 0, 1, 0, 0 }, 
                { 0, 0, 1, 0, 0 }, 
                { 0, 0, 0, 0, 0 }
            }).ToCellArray();
            this.InitializeComponent();
            DataContext = model;
            Refresh();
        }

        public async void timer_Tick(object sender, object args)
        {
            int[,] table = await Services.Commands.GetNextGeneration(model.Table.ToIntArray());
            if (table != null)
            {
                model.Table = table.ToCellArray();
                Refresh();
            }
        }

        private void Refresh()
        {
            Content.Children?.Clear();
            Content.Children.Add(new Controls.GameGrid(model.Table));
            Content.Width = Content.ActualHeight / (model.Table.GetLength(1)) * (model.Table.GetLength(0));
        }

        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            model.isEdit = false;
            model.Auto = !model.Auto;
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            model.isEdit = false;
            await model.Next();
            Refresh();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            model.isEdit = !model.isEdit;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Content.Width = Content.ActualHeight / (model.Table.GetLength(1)) * (model.Table.GetLength(0));
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            model.Table = (new int[int.Parse(columns.Text), int.Parse(rows.Text)]).ToCellArray();
            Refresh();
        }
    }
}
