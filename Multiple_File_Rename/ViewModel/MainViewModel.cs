using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Multiple_File_Rename.Model;
using Multiple_File_Rename.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Multiple_File_Rename.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private bool _isShowReplace;

        public bool IsShowReplace
        {
            get
            {

                return _isShowReplace;
            }
            set
            {
                if (value != _isShowReplace)
                {
                    _isShowReplace = value;
                    RaisePropertyChanged("IsShowReplace");
                }
            }
        }

        private bool _isShowAdd;

        public bool IsShowAdd
        {
            get
            {

                return _isShowAdd;
            }
            set
            {
                if (value != _isShowAdd)
                {
                    _isShowAdd = value;
                    RaisePropertyChanged("IsShowAdd");
                }
            }
        }

        private bool _isShowInsert;

        public bool IsShowInsert
        {
            get
            {

                return _isShowInsert;
            }
            set
            {
                if (value != _isShowInsert)
                {
                    _isShowInsert = value;
                    RaisePropertyChanged("IsShowInsert");
                }
            }
        }

        public bool IsBrowsed
        {
            get
            {
                return FilesnameList != null;
            }
        }

        private string _findText;

        public string FindText
        {
            get
            {

                return _findText;
            }
            set
            {
                if (value != _findText)
                {
                    _findText = value;
                    RaisePropertyChanged("FindText");
                }
            }
        }

        private string _replaceText;

        public string ReplaceText
        {
            get
            {
                return _replaceText;
            }
            set
            {
                if (value != _replaceText)
                {
                    _replaceText = value;
                    RaisePropertyChanged("ReplaceText");
                }
            }
        }

        private string _addText;

        public string AddText
        {
            get
            {
                return _addText;
            }
            set
            {
                if (value != _addText)
                {
                    _addText = value;
                    RaisePropertyChanged("AddText");
                }
            }
        }

        private string _indexText;

        public string IndexText
        {
            get
            {
                return _indexText;
            }
            set
            {
                if (value != _indexText)
                {
                    _indexText = value;
                    RaisePropertyChanged("IndexText");
                }
            }
        }

        private string _insertText;

        public string InsertText
        {
            get
            {
                return _insertText;
            }
            set
            {
                if (value != _insertText)
                {
                    _insertText = value;
                    RaisePropertyChanged("InsertText");
                }
            }
        }


        private List<string> _filesnameList;

        public List<string> FilesnameList
        {
            get
            {
                return _filesnameList;
            }
            set
            {
                if (value != _filesnameList)
                {
                    _filesnameList = value;
                    RaisePropertyChanged("FilesnameList");
                }
            }
        }

        private List<string> _changedFilesnameList;

        public List<string> ChangedFilesnameList
        {
            get
            {

                return _changedFilesnameList;
            }
            set
            {
                if (value != _changedFilesnameList)
                {
                    _changedFilesnameList = value;
                    RaisePropertyChanged("ChangedFilesnameList");
                }
            }
        }

        private ICommand _functionTypeSelected;

        public ICommand FunctionTypeSelected
        {
            get
            {
                if (_functionTypeSelected == null)
                {
                    _functionTypeSelected = new RelayCommand<object>(OnFunctionTypeSelected);
                }

                return _functionTypeSelected;
            }
        }

        private ICommand _findTextKeyUp;

        public ICommand FindTextKeyUp
        {
            get
            {
                if (_findTextKeyUp == null)
                {
                    _findTextKeyUp = new RelayCommand<object>(OnFindTextKeyUp);
                }

                return _findTextKeyUp;
            }
        }


        private ICommand _replaceTextKeyUp;

        public ICommand ReplaceTextKeyUp
        {
            get
            {
                if (_replaceTextKeyUp == null)
                {
                    _replaceTextKeyUp = new RelayCommand<object>(OnReplaceTextKeyUp);
                }

                return _replaceTextKeyUp;
            }
        }


        private ICommand _browseCommand;

        public ICommand BrowseCommand
        {
            get
            {
                if (_browseCommand == null)
                {
                    _browseCommand = new RelayCommand(OnBrowseClicked);
                }

                return _browseCommand;
            }
        }

        private ICommand _confirmCommand;

        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(OnConfirmClicked);
                }

                return _confirmCommand;
            }
        }

        private List<FileRename> fileNameFullPaty;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            #region
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            #endregion
        }

        private void OnFunctionTypeSelected(object sender)
        {
            ChangeFunctionEnum selectItem = (ChangeFunctionEnum)((System.Windows.Controls.Primitives.Selector)((System.Windows.RoutedEventArgs)sender).Source).SelectedItem;
            IsShowReplace = selectItem == ChangeFunctionEnum.Replace;
            IsShowAdd = selectItem == ChangeFunctionEnum.Add;
            IsShowInsert = selectItem == ChangeFunctionEnum.Insert;
        }

        private void OnBrowseClicked()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename;
                string getDirectory;
                FilesnameList = new List<string>();
                ChangedFilesnameList = new List<string>();
                fileNameFullPaty = new List<FileRename>();
                foreach (string ofileName in dlg.FileNames)
                { 
                    filename = System.IO.Path.GetFileName(ofileName);
                    getDirectory = System.IO.Path.GetDirectoryName(ofileName);
                    fileNameFullPaty.Add(new FileRename(ofileName, getDirectory, filename));
                    FilesnameList.Add(filename);
                    ChangedFilesnameList.Add(filename);
                }
                
                RaisePropertyChanged("IsBrowsed");
            }
        }

        private void OnConfirmClicked()
        {
            string getDirectory;
            FilesnameList = new List<string>();
            foreach (FileRename rf in fileNameFullPaty)
            {
                System.IO.File.Move(rf.FullPath, rf.NewFullPath);
                FilesnameList.Add(rf.NewFileName);
                rf.AfterMove();
            }
            FindText = ReplaceText;

            //System.IO.File.Move("c:\1.txt", "c:\2.txt")
        }

        private void OnFindTextKeyUp(object obj)
        {
            /*get string from FindTextBox*/
            string findString = ((System.Windows.Controls.TextBox)((System.Windows.RoutedEventArgs)obj).OriginalSource).Text;
            ChangePreview(findString, ReplaceText);
        }

        private void OnReplaceTextKeyUp(object obj)
        {
            /*get string from replaceTextBox*/
            string repliceString = ((System.Windows.Controls.TextBox)((System.Windows.RoutedEventArgs)obj).OriginalSource).Text;
            ChangePreview(FindText, repliceString);
        }

        private void ChangePreview(string find, string replace)
        {
            if(!string.IsNullOrEmpty(replace) && !string.IsNullOrEmpty(find))
            {
                ChangedFilesnameList = new List<string>();
                string changedFilename;
                foreach (FileRename rf in fileNameFullPaty)
                {
                    changedFilename = Regex.Replace(rf.FileName, find, replace);
                    ChangedFilesnameList.Add(changedFilename);
                    rf.NewFileName = changedFilename;
                    rf.NewFullPath = rf.DirectoryName + "\\" + changedFilename;
                }
            }
        }
    }
}