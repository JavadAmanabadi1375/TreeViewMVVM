using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        
        public MainWindow()
        {
            InitializeComponent();


            this.DataContext = new DirectoryStructureViewModel();
            #region Sample

            // Initial Sample for understanding the road map of the project
            var d = new DirectoryStructureViewModel();
            var item1 = d.Items[0];
            d.Items[0].ExpandICommand.Execute(null);
            #endregion


        }

        #endregion

    }
}
