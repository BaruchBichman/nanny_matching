﻿#pragma checksum "..\..\MotherControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB90BE3FDA9EF4A24DF6A55511E49C5D4BFB68AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// MotherControl
    /// </summary>
    public partial class MotherControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\MotherControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddMother;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MotherControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteMother;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MotherControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateMother;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MotherControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Payment;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MotherControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindNanny;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/mothercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MotherControl.xaml"
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
            this.AddMother = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MotherControl.xaml"
            this.AddMother.Click += new System.Windows.RoutedEventHandler(this.AddMother_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DeleteMother = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\MotherControl.xaml"
            this.DeleteMother.Click += new System.Windows.RoutedEventHandler(this.DeleteMother_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UpdateMother = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MotherControl.xaml"
            this.UpdateMother.Click += new System.Windows.RoutedEventHandler(this.UpdateMother_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Payment = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MotherControl.xaml"
            this.Payment.Click += new System.Windows.RoutedEventHandler(this.Payment_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FindNanny = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MotherControl.xaml"
            this.FindNanny.Click += new System.Windows.RoutedEventHandler(this.FindNanny_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

