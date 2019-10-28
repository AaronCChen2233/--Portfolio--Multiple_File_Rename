using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Multiple_File_Rename.Model
{
    public class FileRename
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public FlowDocument FileNameDocument { get; set; }
        public string NewFullPath { get; set; }
        public string NewFileName { get; set; }
        public FlowDocument NewFileNameDocument { get; set; }
        public string DirectoryName { get; set; }

        public FileRename(string _fullPath, string _directoryName, string _fileName)
        {
            FullPath = _fullPath;
            DirectoryName = _directoryName;
            FileName = _fileName;
        }

        public FileRename(string _fullPath, string _fileName, string _newFullPath, string _newFileName, string _directoryName)
        {
            FullPath = _fullPath;
            FileName = _fileName;
            FileNameDocument = StringToFlowDocument(_fileName);
            NewFullPath = _newFullPath;
            NewFileName = _newFileName;
            DirectoryName = _directoryName;
            NewFileNameDocument = StringToFlowDocument(_newFileName);
        }

        public void AfterMove()
        {
            FullPath = NewFullPath;
            FileName = NewFileName;
            FileNameDocument = NewFileNameDocument;
        }

        public static FlowDocument StringToFlowDocument(string filename)
        {
            return new FlowDocument(new Paragraph(new Run(filename)));
        }
    }
}
