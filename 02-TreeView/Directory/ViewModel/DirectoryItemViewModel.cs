
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfTreeView
{
    /// <summary>
    /// A view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        ///  The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of children contained indised this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if this item can be expanded
        /// </summary>
        public bool CanExpanded { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicade if the current item is expanded or not 
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f=>f !=null)> 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the UI tells us to close
                else
                    this.ClearChildren();
            }
        }

        #endregion

        #region Public Commands
        /// <summary>
        /// The Command to expand this item 
        /// </summary>
        
        public ICommand ExpandICommand { get; set; }
        #endregion

        #region Default constructor
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandICommand = new RelayCommand(Expand);

            //Set path and type
            this.FullPath = fullPath;
            this.Type = type;

            //Set up the children as needed
            this.ClearChildren();
        }
        #endregion


        #region Helper Method

        /// <summary>
        /// Removes all children from the list, adding the dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear item
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            //Show the expand arrow if we are not a file
            if (this.Type !=DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion

        /// <summary>
        /// Expand this directory and find all children
        /// </summary>
        private void Expand()
        {
            // we cannot expand a file
            if (this.Type == DirectoryItemType.File)
                return;
            // Find all children
            var children = DirectoryStructure.GetDirectoryContent(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
 
    }
}
