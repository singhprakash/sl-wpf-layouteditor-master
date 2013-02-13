using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Layout;
using LayoutEditor.LayoutEditorControl.Helpers;
using LayoutEditor.LayoutEditorControl.Models;
using LayoutEditor.Models;
using Microsoft.Practices.Prism.Commands;

namespace LayoutEditor.LayoutEditorControl
{
    public partial class LayoutEditorControl : UserControl
    {
        #region Properties

        public SelectionCommand SelectionCommand
        {
            get { return (SelectionCommand)GetValue(SelectionCommandProperty); }
            set { SetValue(SelectionCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectionCommandProperty =
            DependencyProperty.Register("SelectionCommand", typeof(SelectionCommand), typeof(LayoutEditorControl), new PropertyMetadata((sender, e) =>
            {
                var layoutEditorControl = sender as LayoutEditorControl;
                if (layoutEditorControl == null)
                    throw new InvalidCastException();
                var helper = layoutEditorControl.Tag as WorkAreaHelper[];
                helper[0].ApplySelectionCommand((SelectionCommand)e.NewValue);
                //helper[1].ApplySelectionCommand((SelectionCommand)e.NewValue);
                if ((SelectionCommand)e.NewValue == SelectionCommand.Fill)
                    layoutEditorControl.btnFillSettings.Visibility = Visibility.Visible;
                else
                    layoutEditorControl.btnFillSettings.Visibility = Visibility.Collapsed;
            }));

        public LayoutEditorPopulation LayoutContent
        {
            get { return (LayoutEditorPopulation)GetValue(LayoutContentProperty); }
            set { SetValue(LayoutContentProperty, value); }
        }
        public static readonly DependencyProperty LayoutContentProperty =
            DependencyProperty.Register("LayoutContent", typeof(LayoutEditorPopulation), typeof(LayoutEditorControl), new PropertyMetadata((sender, e) =>
            {
                var layoutEditorControl = sender as LayoutEditorControl;
                if (layoutEditorControl == null)
                    throw new InvalidCastException();
                var helper = layoutEditorControl.Tag as WorkAreaHelper[];

                helper[0].InitializePlateControl(e.NewValue as LayoutEditorPopulation);
                helper[1].InitializePlateControl(e.NewValue as LayoutEditorPopulation);
                layoutEditorControl.UpdateLeftMenuWidth();

            }));

        public UserSettingsModel UserSettings
        {
            get { return (UserSettingsModel)GetValue(UserSettingsProperty); }
            set { SetValue(UserSettingsProperty, value); }
        }
        public static readonly DependencyProperty UserSettingsProperty =
            DependencyProperty.Register("UserSettings", typeof(UserSettingsModel), typeof(LayoutEditorControl), new PropertyMetadata((sender, e) =>
            {
                var layoutEditorControl = sender as LayoutEditorControl;
                if (layoutEditorControl == null)
                    throw new InvalidCastException();
                var helper = layoutEditorControl.Tag as WorkAreaHelper[];
                var userSettings = e.NewValue as UserSettingsModel;
                helper[0].ApplyUserSettings(userSettings);
                helper[1].ApplyUserSettings(userSettings);
                layoutEditorControl.UpdateLeftMenuWidth();
            }));

        public UpdateUserLayoutModel UpdatedUserLayout
        {
            get { return (UpdateUserLayoutModel)GetValue(UpdatedUserLayoutProperty); }
            set { SetValue(UpdatedUserLayoutProperty, value); }
        }
        public static readonly DependencyProperty UpdatedUserLayoutProperty =
            DependencyProperty.Register("UpdatedUserLayout", typeof(UpdateUserLayoutModel), typeof(LayoutEditorControl), new PropertyMetadata(null, (sender, e) =>
            {
                var layoutEditorControl = sender as LayoutEditorControl;
                if (layoutEditorControl == null)
                    throw new InvalidCastException();
                var helper = layoutEditorControl.Tag as WorkAreaHelper[];
                var updatedLayout = e.NewValue as UpdateUserLayoutModel;
                helper[0].OnUpdateUserLayout(updatedLayout.UserLayout, updatedLayout.FlaggedPositions);
                helper[1].OnUpdateUserLayout(updatedLayout.UserLayout, updatedLayout.FlaggedPositions);
            }));

        #region Commands
        public DelegateCommand<LoadUserLayoutModel> LoadUserLayoutCommand
        {
            get { return (DelegateCommand<LoadUserLayoutModel>)GetValue(LoadUserLayoutCommandProperty); }
            set { SetValue(LoadUserLayoutCommandProperty, value); }
        }
        public static readonly DependencyProperty LoadUserLayoutCommandProperty =
            DependencyProperty.Register("LoadUserLayoutCommand", typeof(DelegateCommand<LoadUserLayoutModel>), typeof(LayoutEditorControl), new PropertyMetadata(null));

        public DelegateCommand<SingleLayoutEditor> CurrentStateChangeCommand
        {
            get { return (DelegateCommand<SingleLayoutEditor>)GetValue(CurrentStateChangeCommandProperty); }
            set { SetValue(CurrentStateChangeCommandProperty, value); }
        }
        public static readonly DependencyProperty CurrentStateChangeCommandProperty =
            DependencyProperty.Register("CurrentStateChangeCommand", typeof(DelegateCommand<SingleLayoutEditor>), typeof(LayoutEditorControl), new PropertyMetadata(null));

        public DelegateCommand<SingleLayoutEditor> SaveCommand
        {
            get { return (DelegateCommand<SingleLayoutEditor>)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }
        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(DelegateCommand<SingleLayoutEditor>), typeof(LayoutEditorControl), new PropertyMetadata(null));

        #endregion
        public string Message { get; set; }
        private ObservableCollection<LeftMenuModel> LeftMenuContent { get; set; }
        private ControlSettingsModel _controlSettings;
       
        #endregion
      
        #region Constructors
        public LayoutEditorControl()
        {
            InitializeComponent();
            IsLoad = true;
            LeftMenuContent = new ObservableCollection<LeftMenuModel>();
            leftMenu.ItemsSource = LeftMenuContent;

            plateControl.PosMouseCursor = Cursors.Arrow;
          var  context = new WorkAreaHelper(plateControl);
          var  contextHidden = new WorkAreaHelper(plateControlhidden);
            context.LoadUserLayoutEvent += context_LoadUserLayoutEvent;
            context.ShowTipMessageEvent += context_ShowTipMessageEvent;
            context.UpdateControlSettingsEvent += context_UpdateControlSettingsEvent;
            context.UpdateFillSettingsEvent += context_UpdateFillSettingsEvent;
            contextHidden.LoadUserLayoutEvent += context_LoadUserLayoutEvent;
            contextHidden.ShowTipMessageEvent += context_ShowTipMessageEvent;
          //  contextHidden.UpdateControlSettingsEvent += context_UpdateControlSettingsEvent;
            contextHidden.UpdateFillSettingsEvent += context_UpdateFillSettingsEvent;

            this.Tag = new WorkAreaHelper[] { context, contextHidden };
            //this.Tag = contextHidden;
            plateControl.DataContext = this;
         
            //plateControl.DataContext = this;

            //plateControlhidden.DataContext = this;



            this.SizeChanged += LayoutEditorControl_SizeChanged;

            btnFillSettings.Visibility = System.Windows.Visibility.Collapsed;
            spGroupNumEditor.Visibility = System.Windows.Visibility.Collapsed;
            btnAdd.Visibility = System.Windows.Visibility.Collapsed;
            btnDuplicate.Visibility = System.Windows.Visibility.Collapsed;
            btnRemove.Visibility = System.Windows.Visibility.Collapsed;
        }

        void contexthidden_UpdateFillSettingsEvent(FillSettingsModel fillSettings)
        {
            lbSampleTypes.DataContext = fillSettings;
            spGroupNumEditor.DataContext = fillSettings;
            if (_controlSettings != null)
            {
                lbSampleTypes.IsEnabled = _controlSettings.AllowFillMode;
                spGroupNumEditor.Visibility = _controlSettings.AllowFillMode ?
                    Visibility.Visible : Visibility.Collapsed;
            }
        }

        void contexthidden_UpdateControlSettingsEvent(ControlSettingsModel controlSettings)
        {
            _controlSettings = controlSettings;
           
            #region Update thumbnail
            if (leftMenu != null)
            {
                if (leftMenu.Items.Count > 0)
                {
                    leftMenu.SelectedIndex = 0;
                    if (leftMenu.SelectedItem != null)
                    {
                        var image = new System.Windows.Media.Imaging.BitmapImage();
                        image.SetSource(plateControl.SaveAsImage());
                        ((LeftMenuModel)leftMenu.SelectedItem).Image = image;

                        leftMenu.ItemsSource = null;
                        leftMenu.ItemsSource = LeftMenuContent;
                    }

                }

            }
            #endregion


            btnSaveClose.IsEnabled = controlSettings.IsSaveAvailable;
            btnUndo.IsEnabled = controlSettings.IsUndoAvailable;
            btnRedo.IsEnabled = controlSettings.IsRedoAvailable;

            btnClear.IsEnabled = controlSettings.IsClearAvailable;
            btnClear.Visibility = controlSettings.IsClearAvailable ? Visibility.Visible : Visibility.Collapsed;

            btnErase.Visibility = controlSettings.AllowFillMode ? Visibility.Visible : Visibility.Collapsed;
            btnFill.Visibility = controlSettings.AllowFillMode ? Visibility.Visible : Visibility.Collapsed;
            btnFillSettings.Visibility = controlSettings.SelectionCommand == Models.SelectionCommand.Fill ?
                Visibility.Visible : Visibility.Collapsed;

            spGroupNumEditor.Visibility = controlSettings.AllowFillMode ?
                Visibility.Visible : Visibility.Collapsed;
            lbSampleTypes.IsEnabled = controlSettings.AllowFillMode;

            SelectionCommand = controlSettings.SelectionCommand;
            if (CurrentStateChangeCommand != null && CurrentStateChangeCommand.CanExecute(controlSettings.CurrentState))
                CurrentStateChangeCommand.Execute(controlSettings.CurrentState);
        }

        void contexthidden_LoadUserLayoutEvent(LoadUserLayoutModel loadUserLayoutModel)
        {
            if (LoadUserLayoutCommand != null && LoadUserLayoutCommand.CanExecute(loadUserLayoutModel))
                LoadUserLayoutCommand.Execute(loadUserLayoutModel);
        }
        #endregion

        #region Methods
        void context_UpdateFillSettingsEvent(FillSettingsModel fillSettings)
        {
            lbSampleTypes.DataContext = fillSettings;
            spGroupNumEditor.DataContext = fillSettings;
            if (_controlSettings != null)
            {
                lbSampleTypes.IsEnabled = _controlSettings.AllowFillMode;
                spGroupNumEditor.Visibility = _controlSettings.AllowFillMode ?
                    Visibility.Visible : Visibility.Collapsed;
            }
        }

        void context_UpdateControlSettingsEvent(ControlSettingsModel controlSettings)
        {
           
            _controlSettings = controlSettings;
          
                plateControlhidden.PointData = plateControl.PointData;
            
           
         
            #region Update thumbnail
            if (leftMenu != null)
            {
                if (leftMenu.Items.Count > 0)
                {
                    leftMenu.SelectedIndex = 0;
                    if (leftMenu.SelectedItem != null)
                    {
                        var image = new System.Windows.Media.Imaging.BitmapImage();
                        image.SetSource(plateControl.SaveAsImage());
                        ((LeftMenuModel)leftMenu.SelectedItem).Image = image;

                        leftMenu.ItemsSource = null;
                        leftMenu.ItemsSource = LeftMenuContent;
                    }

                }

            }
            #endregion


            btnSaveClose.IsEnabled = controlSettings.IsSaveAvailable;
            btnUndo.IsEnabled = controlSettings.IsUndoAvailable;
            btnRedo.IsEnabled = controlSettings.IsRedoAvailable;

            btnClear.IsEnabled = controlSettings.IsClearAvailable;
            btnClear.Visibility = controlSettings.IsClearAvailable ? Visibility.Visible : Visibility.Collapsed;

            btnErase.Visibility = controlSettings.AllowFillMode ? Visibility.Visible : Visibility.Collapsed;
            btnFill.Visibility = controlSettings.AllowFillMode ? Visibility.Visible : Visibility.Collapsed;
            btnFillSettings.Visibility = controlSettings.SelectionCommand == Models.SelectionCommand.Fill ?
                Visibility.Visible : Visibility.Collapsed;

            spGroupNumEditor.Visibility = controlSettings.AllowFillMode ?
                Visibility.Visible : Visibility.Collapsed;
            lbSampleTypes.IsEnabled = controlSettings.AllowFillMode;

            SelectionCommand = controlSettings.SelectionCommand;
            if (CurrentStateChangeCommand != null && CurrentStateChangeCommand.CanExecute(controlSettings.CurrentState))
                CurrentStateChangeCommand.Execute(controlSettings.CurrentState);
        }

        void LayoutEditorControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLeftMenuWidth();
        }

        void context_LoadUserLayoutEvent(LoadUserLayoutModel loadUserLayoutModel)
        {
            if (LoadUserLayoutCommand != null && LoadUserLayoutCommand.CanExecute(loadUserLayoutModel))
                LoadUserLayoutCommand.Execute(loadUserLayoutModel);
        }

        void context_ShowTipMessageEvent(string message)
        {
            Message = message;
        }

        public MemoryStream SaveAsImage()
        {
            var result = new MemoryStream();
            var stream = plateControl.SaveAsImage();
            if (stream != null)
                stream.CopyTo(result);
            else
                return null;
            return result;
        }

        private void UpdateLeftMenuWidth()
        {
            if (UserSettings != null && UserSettings.IsMultiple)
            {
                var width = LayoutRoot.ActualWidth;
                leftMenu.Width = width / 4;
            }
            else
            {
                leftMenu.Width = 0;
            }
            UpdateLeftMenuContent();
        }

        private void leftMenu_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLeftMenuContent();
        }

        private void UpdateLeftMenuContent()
        {
            if (UserSettings != null && UserSettings.IsMultiple)
            {
                if (UserSettings.IsMultiple)
                {
                    btnAdd.Visibility = Visibility.Visible;
                    btnAdd.Content = UserSettings.ContainerName;

                    btnRemove.Visibility = Visibility.Visible;
                    btnRemove.Content = UserSettings.ContainerName;

                    btnDuplicate.Visibility = Visibility.Visible;
                    btnDuplicate.Content = UserSettings.ContainerName;
                }
                else
                {
                    btnAdd.Visibility = Visibility.Collapsed;
                    btnRemove.Visibility = Visibility.Collapsed;
                    btnDuplicate.Visibility = Visibility.Collapsed;
                }

                var stream = SaveAsImage();
                LeftMenuContent.Clear();
                //TODO: To place the business logic of filling the left menu here
                //      add a logic of parsing the MultipleLayout
                if (stream != null)
                {
                    var leftMenuItem = new LeftMenuModel();
                    var image = new System.Windows.Media.Imaging.BitmapImage();
                    image.SetSource(stream);
                    var scale = Math.Max(plateControl.ActualWidth, plateControl.ActualHeight) / (leftMenu.Width - 100);
                    leftMenuItem.Width = plateControl.ActualWidth / scale;
                    leftMenuItem.Height = plateControl.ActualHeight / scale;
                    leftMenuItem.Image = image;
                    leftMenuItem.Key = LeftMenuContent.Count;
                    leftMenuItem.DiagramModel = LayoutContent;
                    LeftMenuContent.Add(leftMenuItem);
                    leftMenu.SelectedItem = leftMenuItem;
                }

            }
            else
                LeftMenuContent.Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           
            ((WorkAreaHelper)Tag).Clear();
        }

        private void btnFillSettings_Click(object sender, RoutedEventArgs e)
        {
            ((WorkAreaHelper)Tag).UpdateFillSettings();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            ((WorkAreaHelper)Tag).Undo();
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            ((WorkAreaHelper)Tag).Redo();
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            SelectionCommand = Models.SelectionCommand.Erase;
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            SelectionCommand = Models.SelectionCommand.Fill;
        }

        #region ToolTip Management
        bool showPlateControlToolTip = true;
        // Code to only display the tool top the first time the user moves the mouse into the control
        private void plateControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.showPlateControlToolTip = false;
        }

        private void ToolTipPlateControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.showPlateControlToolTip)
                (sender as ToolTip).IsOpen = false;
        }
        #endregion

        private void btnSaveClose_Click(object sender, RoutedEventArgs e)
        {
            if (SaveCommand != null && SaveCommand.CanExecute(_controlSettings.CurrentState))
                SaveCommand.Execute(_controlSettings.CurrentState);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Is not imlemented yet");
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Is not imlemented yet");
        }

        private void btnDuplicate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Is not imlemented yet");
        }

        private void leftMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var listBox = sender as ListBox;
            //var selectedItem = listBox.SelectedItem as LeftMenuModel;
            //if (selectedItem != null)
            //    MessageBox.Show(string.Format("Item #{0} is selected", selectedItem.Key));


        }
        #endregion
    }
}