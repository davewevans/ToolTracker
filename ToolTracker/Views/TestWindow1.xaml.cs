﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for TestWindow1.xaml
    /// </summary>
    public partial class TestWindow1 : Window
    {
        public TestWindow1()
        {
            InitializeComponent();

            // Define the animation
            DoubleAnimation a = new DoubleAnimation();
            a.From = 50;
            a.To = 100;
            // Start animating
            b.BeginAnimation(Button.WidthProperty, a);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
