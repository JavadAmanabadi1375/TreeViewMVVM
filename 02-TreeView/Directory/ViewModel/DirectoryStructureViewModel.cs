using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// The view model for the application main Directory view
    /// </summary>
    public class DirectoryStructureViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all directory on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel>  Items { get; set; }

        #endregion

        #region Constructor

        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrive();
            this.Items = new ObservableCollection<DirectoryItemViewModel>( children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion
    }
}
