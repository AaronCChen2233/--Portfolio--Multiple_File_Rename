using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Multiple_File_Rename.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        }

        private void OnBrowseClicked()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                FilesnameList = new List<string>(dlg.FileNames);
            }
        }
    }
}