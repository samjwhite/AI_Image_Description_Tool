#pragma checksum "S:\OneDrive - NC\Desktop\College Resources\Term 4\PROG1442\Final Project\SRiazanov_ComputerVisionApp\SRiazanov_ComputerVisionApp\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1B30851B0BB27FFFBD75A7961EC63DD70787C30429C1D15226E8EFE89FA5F3A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRiazanov_ComputerVisionApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 20
                {
                    this.Headers = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 3: // MainPage.xaml line 27
                {
                    this.ImageArea = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 4: // MainPage.xaml line 38
                {
                    this.CommandButtons = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 5: // MainPage.xaml line 39
                {
                    this.btnUpload = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUpload).Click += this.btnUpload_Click;
                }
                break;
            case 6: // MainPage.xaml line 47
                {
                    this.btnAnalyze = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAnalyze).Click += this.btnAnalyze_Click;
                }
                break;
            case 7: // MainPage.xaml line 55
                {
                    this.btnClear = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnClear).Click += this.btnClear_Click;
                }
                break;
            case 8: // MainPage.xaml line 28
                {
                    this.imageGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9: // MainPage.xaml line 31
                {
                    this.lblDescription = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // MainPage.xaml line 33
                {
                    this.lblTags = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // MainPage.xaml line 34
                {
                    this.lbxTags = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.lbxTags).SelectionChanged += this.lbxTags_SelectionChanged;
                }
                break;
            case 12: // MainPage.xaml line 29
                {
                    this.imgPreview = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 13: // MainPage.xaml line 21
                {
                    this.lblTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // MainPage.xaml line 23
                {
                    this.lblSubheader = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

