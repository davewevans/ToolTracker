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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace ToolTracker.Views
{
    /// <summary>
    /// Interaction logic for TestLoadAnimationWindow.xaml
    /// </summary>
    public partial class TestLoadAnimationWindow : Window
    {
        BusyIndicator _busyIndicator;

        public TestLoadAnimationWindow()
        {
            InitializeComponent();
        }
    }
}
