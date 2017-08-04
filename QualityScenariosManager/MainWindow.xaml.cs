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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QualityScenariosManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ContentPanel.Children.Add(new Home());
		}

		private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Close();
		}

		private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void Header_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}

		private void CreateTSButton_Click(object sender, RoutedEventArgs e)
		{
			if (ContentPanel.Children.Count > 0)
			{
				ContentPanel.Children.Clear();
			}
			ContentPanel.Children.Add(new TestSuiteCreation());
			TitleLabel.Content = "Test suite creation";
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			if (ContentPanel.Children.Count > 0)
			{
				ContentPanel.Children.Clear();
			}
			ContentPanel.Children.Add(new Home());
			TitleLabel.Content = "Home";
		}
	}
}
