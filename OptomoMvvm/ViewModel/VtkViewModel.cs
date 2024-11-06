using Kitware.VTK;
using OptomoMvvm.Command;
using OptomoMvvm.Model;
using OptomoMvvm.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace OptomoMvvm.ViewModel
{
    public class VtkViewModel : ViewModelBase
    {
        public VtkModel Model;
        public RenderWindowControl RenderControl;
        public ICommand StartCommand { get; }
        public ICommand LayerCommand { get; }
        public ICommand PanelCommand { get; }
        public ICommand MotionCommand { get; }
        public ICommand ResetCommand { get; }

        public VtkViewModel(VtkModel model)
        {
            RenderControl = new RenderWindowControl();
            Model = model;
            StartCommand = new RelayCommand(_ => StartFunc());
            LayerCommand = new RelayCommand(ChangeLayer);
            PanelCommand = new RelayCommand(ChangePanel);
            MotionCommand = new RelayCommand(ChangeMotion);
            ResetCommand = new RelayCommand(_ => Reset());
        }

        // ViewModel'e bağlı olanlar
        public double DpiScale { get; set; }

        // Model'e bağlı olanlar
        public bool IsMax
        {
            get => Model.IsMax;
            set
            {
                Model.IsMax = value;
                OnPropertyChanged(nameof(IsMax));
            }
        }

        public Panel SelectedPanel 
        { 
            get => Model.SelectedPanel;
            set
            {
                Model.SelectedPanel = value;
                OnPropertyChanged(nameof(SelectedPanel));
            }
        }

        public double Width
        {
            get => Model.Width;
            set
            {
                Model.Width = value;
                SetPositions();
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get => Model.Height;
            set
            {
                Model.Height = value;
                SetPositions();
                OnPropertyChanged(nameof(Height));
            }
        }

        public int AxialLayer
        {
            get => Model.AxialLayer;
            set
            {
                Model.AxialLayer = value;
                OnPropertyChanged(nameof(AxialLayer));
            }
        }

        public int SagittalLayer
        {
            get => Model.SagittalLayer;
            set
            {
                Model.SagittalLayer = value;
                OnPropertyChanged(nameof(SagittalLayer));
            }
        }

        public int FrontalLayer
        {
            get => Model.FrontalLayer;
            set
            {
                Model.FrontalLayer = value;
                OnPropertyChanged(nameof(FrontalLayer));
            }
        }

        public int[] Motion
        {
            get => Model.Motion;
            set
            {
                Model.Motion = value;
                OnPropertyChanged(nameof(Motion));
            }
        }

        public double ZoomLevel
        {
            get
            {
                if (SelectedPanel == Panel.Axial)
                {
                    return Model.Zoom[1];
                }
                else if (SelectedPanel == Panel.Sagittal)
                {
                    return Model.Zoom[0];
                }
                else if (SelectedPanel == Panel.Frontal)
                {
                    return Model.Zoom[2];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (SelectedPanel == Panel.Axial)
                {
                    Model.Zoom[1] = value;
                }
                else if (SelectedPanel == Panel.Sagittal)
                {
                    Model.Zoom[0] = value;
                }
                else if (SelectedPanel == Panel.Frontal)
                {
                    Model.Zoom[2] = value;
                }
                SetPositions();
                OnPropertyChanged(nameof(ZoomLevel));
            }
        }

        // Fonksiyonlar
        private void StartFunc()
        {
            MessageBox.Show(DpiScale.ToString());
            Model.InsertRenderersToController(RenderControl.RenderWindow);
        }

        private void SetPositions()
        {
            if (IsMax)
            {
                Model.WidthDPI = Width * DpiScale;
                Model.HeightDPI = Height * DpiScale;
            }
            else
            {
                Model.WidthDPI = Width * DpiScale / 2;
                Model.HeightDPI = Height * DpiScale / 2;
                Model.SetPositionInAxial();
                Model.SetPositionInSagittal();
                Model.SetPositionInFrontal();
            }
            if (RenderControl.RenderWindow != null)
            {
                RenderControl.RenderWindow.Render();
            }
        }

        private void ChangePanel(object param)
        {
            if (param is Panel panel)
            {
                SelectedPanel = panel;
            }
        }

        private void ChangeLayer(object param)
        {
            if (param is string value)
            {
                switch (SelectedPanel)
                {
                    case Panel.Axial:
                        if (value == "1")
                        {
                            AxialLayer++;
                            Motion[1]--;
                        }
                        else if (value == "-1")
                        {
                            AxialLayer--;
                            Motion[1]++;
                        }
                        Model.ChangeMotionInAxial();
                        break;
                    case Panel.Sagittal:
                        if (value == "1")
                        {
                            SagittalLayer++;
                            Motion[0]--;
                        }
                        else if (value == "-1")
                        {
                            SagittalLayer--;
                            Motion[0]++;
                        }
                        Model.ChangeMotionInSagittal();
                        break;
                    case Panel.Frontal:
                        if (value == "1")
                        {
                            FrontalLayer++;
                            Motion[2]--;
                        }
                        else if (value == "-1")
                        {
                            FrontalLayer--;
                            Motion[2]++;
                        }
                        Model.ChangeMotionInFrontal();
                        break;
                    default:
                        MessageBox.Show("Lucky Day!");
                        break;
                }
            }
            RenderControl.RenderWindow.Render();
        }

        private void ChangeMotion(object param)
        {
            if (param is string direction)
            {
                switch (direction)
                {
                    case "1":
                        if (SelectedPanel == Panel.Axial)
                        {
                            FrontalLayer++;
                            Motion[2]--;
                            Model.ChangeMotionInFrontal();
                        }
                        else if (SelectedPanel == Panel.Sagittal)
                        {
                            FrontalLayer++;
                            Motion[2]--;
                            Model.ChangeMotionInFrontal();
                        }
                        else if (SelectedPanel == Panel.Frontal)
                        {
                            AxialLayer++;
                            Motion[1]--;
                            Model.ChangeMotionInAxial();
                        }
                        break;
                    case "2":
                        if (SelectedPanel == Panel.Axial)
                        {
                            FrontalLayer--;
                            Motion[2]++;
                            Model.ChangeMotionInFrontal();
                        }
                        else if (SelectedPanel == Panel.Sagittal)
                        {
                            FrontalLayer--;
                            Motion[2]++;
                            Model.ChangeMotionInFrontal();
                        }
                        else if (SelectedPanel == Panel.Frontal)
                        {
                            AxialLayer--;
                            Motion[1]++;
                            Model.ChangeMotionInAxial();
                        }
                        break;
                    case "3":
                        if (SelectedPanel == Panel.Axial)
                        {
                            SagittalLayer--;
                            Motion[0]++;
                            Model.ChangeMotionInSagittal();
                        }
                        else if (SelectedPanel == Panel.Sagittal)
                        {
                            AxialLayer--;
                            Motion[1]++;
                            Model.ChangeMotionInAxial();
                        }
                        else if (SelectedPanel == Panel.Frontal)
                        {
                            SagittalLayer--;
                            Motion[0]++;
                            Model.ChangeMotionInSagittal();
                        }
                        break;
                    case "4":
                        if (SelectedPanel == Panel.Axial)
                        {
                            SagittalLayer++;
                            Motion[0]--;
                            Model.ChangeMotionInSagittal();
                        }
                        else if (SelectedPanel == Panel.Sagittal)
                        {
                            AxialLayer++;
                            Motion[1]--;
                            Model.ChangeMotionInAxial();
                        }
                        else if (SelectedPanel == Panel.Frontal)
                        {
                            SagittalLayer++;
                            Motion[0]--;
                            Model.ChangeMotionInSagittal();
                        }
                        break;
                }
                RenderControl.RenderWindow.Render();
            }
        }

        private void Reset()
        {
            Model.Reset();
            RenderControl.RenderWindow.Render();
        }
    }
}
