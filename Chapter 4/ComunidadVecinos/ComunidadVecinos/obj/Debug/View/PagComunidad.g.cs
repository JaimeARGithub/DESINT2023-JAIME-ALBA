﻿#pragma checksum "..\..\..\View\PagComunidad.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E07C18DA76501BABE95B0A8D96235232ABC0FC8A84053AB103EBEF780CB89A43"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ComunidadVecinos;
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


namespace ComunidadVecinos {
    
    
    /// <summary>
    /// PagComunidad
    /// </summary>
    public partial class PagComunidad : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSurface;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumDoor;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton btnYes;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton btnNo;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selDate;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\View\PagComunidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calCalendar;
        
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
            System.Uri resourceLocater = new System.Uri("/ComunidadVecinos;component/view/pagcomunidad.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PagComunidad.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtSurface = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNumDoor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnYes = ((System.Windows.Controls.RadioButton)(target));
            
            #line 89 "..\..\..\View\PagComunidad.xaml"
            this.btnYes.Checked += new System.Windows.RoutedEventHandler(this.btnYes_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnNo = ((System.Windows.Controls.RadioButton)(target));
            
            #line 91 "..\..\..\View\PagComunidad.xaml"
            this.btnNo.Checked += new System.Windows.RoutedEventHandler(this.btnNo_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.selDate = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.calCalendar = ((System.Windows.Controls.Calendar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

