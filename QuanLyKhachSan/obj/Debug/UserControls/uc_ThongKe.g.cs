﻿#pragma checksum "..\..\..\UserControls\uc_ThongKe.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A81A3ACD1B3432249255A896A14D0319CCADE678FA51C2BC427109B820B75241"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI.UserControls;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GUI.UserControls {
    
    
    /// <summary>
    /// uc_ThongKe
    /// </summary>
    public partial class uc_ThongKe : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbDoanhThuPhong;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbDoanhThuDV;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbSoLuongPhongDat;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbThang;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.PieSeries psDoanhThuPhong;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.PieSeries psDoanhThuDV;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbNam;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.LineSeries lsDoanhThuPhong;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.LineSeries lsDoanhThuDV;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\UserControls\uc_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.LineSeries lsTongDoanhThu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;component/usercontrols/uc_thongke.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\uc_ThongKe.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\UserControls\uc_ThongKe.xaml"
            ((GUI.UserControls.uc_ThongKe)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbDoanhThuPhong = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txbDoanhThuDV = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txbSoLuongPhongDat = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.cbThang = ((System.Windows.Controls.ComboBox)(target));
            
            #line 98 "..\..\..\UserControls\uc_ThongKe.xaml"
            this.cbThang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.selectionChang_cbThang);
            
            #line default
            #line hidden
            return;
            case 6:
            this.psDoanhThuPhong = ((LiveCharts.Wpf.PieSeries)(target));
            return;
            case 7:
            this.psDoanhThuDV = ((LiveCharts.Wpf.PieSeries)(target));
            return;
            case 8:
            this.cbNam = ((System.Windows.Controls.ComboBox)(target));
            
            #line 118 "..\..\..\UserControls\uc_ThongKe.xaml"
            this.cbNam.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbNam_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lsDoanhThuPhong = ((LiveCharts.Wpf.LineSeries)(target));
            return;
            case 10:
            this.lsDoanhThuDV = ((LiveCharts.Wpf.LineSeries)(target));
            return;
            case 11:
            this.lsTongDoanhThu = ((LiveCharts.Wpf.LineSeries)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

