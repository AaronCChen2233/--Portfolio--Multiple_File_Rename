using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Multiple_File_Rename.Model;
using Multiple_File_Rename.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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

        private bool _isShowCut;

        public bool IsShowCut
        {
            get
            {
                return _isShowCut;
            }
            set
            {
                if (value != _isShowCut)
                {
                    _isShowCut = value;
                    RaisePropertyChanged("IsShowCut");
                }
            }
        }

        private bool _isConfirmEnable;

        public bool IsConfirmEnable
        {
            get
            {
                return _isConfirmEnable;
            }
            set
            {
                if (value != _isConfirmEnable)
                {
                    _isConfirmEnable = value;
                    RaisePropertyChanged("IsConfirmEnable");
                }
            }
        }

        public bool IsBrowsed
        {
            get
            {
                return FileNameFullPart != null;
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

        private string _keepSizeText;

        public string KeepSizeText
        {
            get
            {
                return _keepSizeText;
            }
            set
            {
                if (value != _keepSizeText)
                {
                    _keepSizeText = value;
                    RaisePropertyChanged("KeepSizeText");
                }
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    RaisePropertyChanged("ErrorMessage");
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

        private ICommand _keepSizeTextKeyUp;

        public ICommand KeepSizeTextKeyUp
        {
            get
            {
                if (_keepSizeTextKeyUp == null)
                {
                    _keepSizeTextKeyUp = new RelayCommand<object>(OnKeepSizeTextKeyUp);
                }

                return _keepSizeTextKeyUp;
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

        private List<FileRename> _fileNameFullPart;

        public List<FileRename> FileNameFullPart
        {
            get
            {
                return _fileNameFullPart;
            }
            set
            {
                if (value != _fileNameFullPart)
                {
                    _fileNameFullPart = value;
                    RaisePropertyChanged("FileNameFullPart");
                }
            }
        }

        private ChangeFunctionEnum nowFunction;

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
            FileNameFullPart = new List<FileRename>();
            ChangeFunctionEnum selectItem = (ChangeFunctionEnum)((System.Windows.Controls.Primitives.Selector)((System.Windows.RoutedEventArgs)sender).Source).SelectedItem;
            IsShowReplace = selectItem == ChangeFunctionEnum.Replace;
            IsShowAdd = selectItem == ChangeFunctionEnum.Add;
            IsShowInsert = selectItem == ChangeFunctionEnum.Insert;
            IsShowCut = selectItem == ChangeFunctionEnum.Cut;
            nowFunction = selectItem;
            /*without replace other function haven't finish so disable them*/
            switch (selectItem)
            {
                case ChangeFunctionEnum.Replace:
                    IsConfirmEnable = FindText != ReplaceText;
                    break;
                case ChangeFunctionEnum.Add:
                    IsConfirmEnable = false;
                    break;
                case ChangeFunctionEnum.Insert:
                    IsConfirmEnable = false;
                    break;
                case ChangeFunctionEnum.Cut:
                    IsConfirmEnable = !string.IsNullOrEmpty(KeepSizeText);
                    break;
                default:
                    break;
            }
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
                FileNameFullPart = new List<FileRename>();
                foreach (string ofileName in dlg.FileNames)
                {
                    filename = System.IO.Path.GetFileName(ofileName);
                    getDirectory = System.IO.Path.GetDirectoryName(ofileName);
                    FileNameFullPart.Add(new FileRename(ofileName, filename, ofileName, filename, getDirectory));
                }

                RaisePropertyChanged("IsBrowsed");
            }
        }

        private void OnConfirmClicked()
        {
            switch (nowFunction)
            {
                case ChangeFunctionEnum.Replace:

                    foreach (FileRename rf in FileNameFullPart)
                    {
                        System.IO.File.Move(rf.FullPath, rf.NewFullPath);
                        rf.AfterMove();
                    }
                    FindText = ReplaceText;
                    IsConfirmEnable = FindText != ReplaceText;
                    ReplaceChangePreview(FindText, ReplaceText);

                    break;
                case ChangeFunctionEnum.Add:
                    break;
                case ChangeFunctionEnum.Insert:
                    break;
                case ChangeFunctionEnum.Cut:
                    foreach (FileRename rf in FileNameFullPart)
                    {
                        System.IO.File.Move(rf.FullPath, rf.NewFullPath);
                        rf.AfterMove();
                    }
                    
                    IsConfirmEnable = false;
                    CutChangePreview(int.Parse(KeepSizeText));
                    break;
                default:
                    break;
            }
            
        }

        private void OnFindTextKeyUp(object obj)
        {
            /*get string from FindTextBox*/
            string findString = ((System.Windows.Controls.TextBox)((System.Windows.RoutedEventArgs)obj).OriginalSource).Text;
            ReplaceChangePreview(findString, ReplaceText);
            IsConfirmEnable = findString != ReplaceText;
        }

        private void OnReplaceTextKeyUp(object obj)
        {
            /*get string from replaceTextBox*/
            string repliceString = ((System.Windows.Controls.TextBox)((System.Windows.RoutedEventArgs)obj).OriginalSource).Text;
            ReplaceChangePreview(FindText, repliceString);
            IsConfirmEnable = FindText != repliceString;
        }

        private void OnKeepSizeTextKeyUp(object obj)
        {
            string keepSizeString = ((System.Windows.Controls.TextBox)((System.Windows.RoutedEventArgs)obj).OriginalSource).Text;
            IsConfirmEnable = !string.IsNullOrEmpty(keepSizeString);
            if (!string.IsNullOrEmpty(keepSizeString))
            {
                bool isRepeated = CutChangePreview(int.Parse(keepSizeString));
                IsConfirmEnable = !isRepeated;

                ErrorMessage = isRepeated ? "After cut there have somme files name are repeated So can't cut" : "";
            }
        }

        private void ReplaceChangePreview(string find, string replace)
        {
            if (replace != null && find != null)
            {
                List<FileRename> TempFileNameList = new List<FileRename>();
                string changedFilename = "";
                string[] findArray = { find };
                foreach (FileRename rf in FileNameFullPart)
                {
                    changedFilename = "";
                    string[] splitedString = rf.FileName.Split(findArray, StringSplitOptions.None);
                    Paragraph findTempFlowDocument = new Paragraph();
                    Paragraph replaceTempFlowDocument = new Paragraph();
                    for (int i = 0; i <= splitedString.Length - 1; i++)
                    {
                        findTempFlowDocument.Inlines.Add(new Run(splitedString[i]));
                        replaceTempFlowDocument.Inlines.Add(new Run(splitedString[i]));
                        changedFilename += splitedString[i];
                        if (i < splitedString.Length - 1)
                        {
                            findTempFlowDocument.Inlines.Add(new Run(find) { Background = Brushes.Red, Foreground = Brushes.White });
                            replaceTempFlowDocument.Inlines.Add(new Run(replace) { Background = Brushes.Red, Foreground = Brushes.White });
                            changedFilename += replace;
                        }
                    }

                    rf.FileNameDocument = new FlowDocument(findTempFlowDocument);
                    rf.NewFileNameDocument = new FlowDocument(replaceTempFlowDocument);
                    rf.NewFileName = changedFilename;
                    rf.NewFullPath = rf.DirectoryName + "\\" + changedFilename;
                    TempFileNameList.Add(rf);
                }

                FileNameFullPart = TempFileNameList;
            }
        }

        private bool CutChangePreview(int keepIndex)
        {
            bool isRepeated = false;
            List<FileRename> TempFileNameList = new List<FileRename>();
            string cutedFilename = "";
            string extension = "";
            int reKeepIndex = 0;
            
            foreach (FileRename rf in FileNameFullPart)
            {
                extension = Path.GetExtension(rf.FileName);
                cutedFilename = rf.FileName;
                cutedFilename.Replace(extension, "");
                reKeepIndex = keepIndex > cutedFilename.Length ? cutedFilename.Length : keepIndex;
                cutedFilename = cutedFilename.Substring(0, reKeepIndex);
                cutedFilename += extension;

                Paragraph cutedTempFlowDocument = new Paragraph();
                cutedTempFlowDocument.Inlines.Add(new Run(cutedFilename));

                Paragraph originalTempFlowDocument = new Paragraph();
                originalTempFlowDocument.Inlines.Add(new Run(rf.FileName));

                rf.FileNameDocument = new FlowDocument(originalTempFlowDocument);
                rf.NewFileNameDocument = new FlowDocument(cutedTempFlowDocument);
                rf.NewFileName = cutedFilename;
                rf.NewFullPath = rf.DirectoryName + "\\" + cutedFilename;
                TempFileNameList.Add(rf);
                
            }

            FileNameFullPart = TempFileNameList;
            foreach (FileRename rf in FileNameFullPart)
            {
                if (FileNameFullPart.Select(a=>a).Where(x => (x.NewFileName == rf.NewFileName)).Count() > 1)
                {
                    isRepeated = true;
                    break;
                }
            }
       
            return isRepeated;
        }
    }
}