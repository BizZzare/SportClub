﻿#pragma checksum "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99590F6DC003ADC395D3A1D7C2CFEE61C7C3650F51A2B66DE0D127905453CE48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SportClubDesktop.OtherWindows.Trainings;
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


namespace SportClubDesktop.OtherWindows.Trainings {
    
    
    /// <summary>
    /// AddNewTraining
    /// </summary>
    public partial class AddNewTraining : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtDate;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHours;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbMinutes;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstMembers;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstTrainers;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCost;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/SportClubDesktop;component/otherwindows/trainings/addnewtraining.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
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
            
            #line 9 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            ((SportClubDesktop.OtherWindows.Trainings.AddNewTraining)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 13 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.dtDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DtDate_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbHours = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.cbHours.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbHours_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbMinutes = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.cbMinutes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbHours_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lstMembers = ((System.Windows.Controls.ListBox)(target));
            
            #line 19 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.lstMembers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LstMembers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lstTrainers = ((System.Windows.Controls.ListBox)(target));
            
            #line 21 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.lstTrainers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LstMembers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtCost = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.txtCost.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtCost_TextChanged);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.txtCost.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\OtherWindows\Trainings\AddNewTraining.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

