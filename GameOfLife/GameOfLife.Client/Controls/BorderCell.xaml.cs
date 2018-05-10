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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace GameOfLife.Client.Controls
{
    public sealed partial class BorderCell : UserControl
    {
        Models.Cell model;
        public BorderCell(Models.Cell cell)
        {
            model = cell;
            this.InitializeComponent();
            DataContext = model;
        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            model.live = !model.live;
        }
    }
}
