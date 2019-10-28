using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Multiple_File_Rename.Tools
{
    public sealed class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(FlowDocument), typeof(BindableRichTextBox),
            new PropertyMetadata(OnSourceChanged));

        public FlowDocument Source
        {
            get => GetValue(SourceProperty) as FlowDocument;
            set => SetValue(SourceProperty, value);
        }

        private static void OnSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is BindableRichTextBox rtf && rtf.Source != null)
            {
                ((System.Windows.Controls.RichTextBox)obj).Document = rtf.Source;
            }
        }
    }
}
