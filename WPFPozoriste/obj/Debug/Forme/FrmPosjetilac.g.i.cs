﻿#pragma checksum "..\..\..\Forme\FrmPosjetilac.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83E187EFB96EDBE70AC6453495FA5F558CCBEBEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using WPFPozoriste.Forme;


namespace WPFPozoriste.Forme {
    
    
    /// <summary>
    /// FrmPosjetilac
    /// </summary>
    public partial class FrmPosjetilac : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImePosjetioca;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrezimePosjetioca;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGradPosjetioca;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdresaPosjetioca;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontaktPosjetioca;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Forme\FrmPosjetilac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFPozoriste;component/forme/frmposjetilac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forme\FrmPosjetilac.xaml"
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
            this.txtImePosjetioca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtPrezimePosjetioca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtGradPosjetioca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAdresaPosjetioca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtKontaktPosjetioca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Forme\FrmPosjetilac.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.BtnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Forme\FrmPosjetilac.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.BtnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

