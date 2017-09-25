﻿
namespace Okuma.Scout.TestApp.net40
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    public class BindableRichTextBox : RichTextBox
    { 
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(FlowDocument),
            typeof(BindableRichTextBox), new FrameworkPropertyMetadata
            (null, new PropertyChangedCallback(OnDocumentChanged)));

        public new FlowDocument Document
        {
            get { return (FlowDocument)this.GetValue(DocumentProperty); }
            set { this.SetValue(DocumentProperty, value); }
        }

        public static void OnDocumentChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue == null)
                return;

            RichTextBox rtb = (RichTextBox)obj;
            rtb.Document = (FlowDocument)args.NewValue;
        }
    }
}