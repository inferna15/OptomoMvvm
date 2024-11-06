using Kitware.VTK;
using OptomoMvvm.Group;
using OptomoMvvm.Interface;
using System.Windows;

namespace OptomoMvvm.Model
{
    public enum Panel
    {
        Axial,
        Sagittal,
        Frontal,
        View3D
    }

    public class VtkModel
    {
        #region Servisler
        private readonly IDicomReader Reader;
        private readonly AxialGroup Axial;
        private readonly SagittalGroup Sagittal;
        private readonly FrontalGroup Frontal;
        private readonly View3DGroup View3D;
        private readonly IAspectText AspectText;
        private readonly ILines2D Lines2D;
        private readonly ILines3D Lines3D;
        #endregion

        #region Dicom Bilgileri
        public string Path { get; set; } = "C:\\Users\\fatil\\Documents\\Dicoms\\beyin";
        public int[] Extent { get; set; } = new int[6];
        public double[] Spacing { get; set; } = new double[3];
        public double[] Origin { get; set; } = new double[3];
        public double[] Center { get; set; } = new double[3];
        public double[] ColorRange { get; set; } = new double[2];
        #endregion

        #region Özellikler
        public Dictionary<double, double[]> Colors { get; set; }
        public Dictionary<double, double> Opacitys { get; set; }
        public INTERPOLATION InterpolationType { get; set; }
        public double OpacityDistance { get; set; }
        public bool IsShadeOn { get; set; }
        public double Ambient { get; set; }
        public double Diffuse { get; set; }
        public double Specular { get; set; }
        public double SpecularPower { get; set; }
        public float ScatteringAnisotropy { get; set; }
        public RenderMode RenderMode { get; set; }
        public int MaxMemoryBytes { get; set; }
        public float GPURatio { get; set; }
        public double FPS { get; set; }
        public bool IsUseJittering { get; set; }
        public bool IsInterAdjustSampleDistance { get; set; }
        public bool IsAutoAdjustSampleDistance { get; set; }
        public float GlobalIll { get; set; }
        public float VolumetricScatBlend { get; set; }
        #endregion

        public bool IsMax {  get; set; }
        public Panel SelectedPanel { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double WidthDPI { get; set; }
        public double HeightDPI { get; set; }
        public int[] Exts { get; set; } = new int[3];
        public int[] Offsets { get; set; } = new int[3];
        public int AxialLayer {  get; set; }
        public int SagittalLayer { get; set; }
        public int FrontalLayer { get; set; }
        public double[] Ratio { get; set; } = new double[3];
        public double[] Zoom { get; set; } = new double[3];
        public int[] Motion { get; set; } = new int[3];

        public VtkModel(IDicomReader reader, AxialGroup axial, SagittalGroup sagittal, 
            FrontalGroup frontal, View3DGroup view3D, IAspectText aspectText, ILines2D lines2D, ILines3D lines3D)
        {
            Reader = reader;
            Axial = axial;
            Sagittal = sagittal;
            Frontal = frontal;
            View3D = view3D;
            AspectText = aspectText;
            Lines2D = lines2D;
            Lines3D = lines3D;

            IsMax = false;
            SelectedPanel = Panel.Axial;
            Width = 1920;
            Height = 1080;

            Initialize();
        }

        #region Initialize kısmı
        public void Initialize()
        {
            ReadDicom();
            InitChangable();
            InitPropertyValues();
            InitAxial();
            InitSagittal();
            InitFrontal();
            Init3DView();
            InitAspectTexts();
            InitLines2D();
            InitLines3D();
        }

        private void InitChangable()
        {
            AxialLayer = Extent[3] / 2;
            SagittalLayer = Extent[1] / 2;
            FrontalLayer = Extent[5] / 2;
            Zoom[0] = 1; 
            Zoom[1] = 1; 
            Zoom[2] = 1;
        }

        private void InitPropertyValues()
        {
            Colors = new Dictionary<double, double[]>();
            Opacitys = new Dictionary<double, double>();
            InterpolationType = INTERPOLATION.VTK_NEAREST_INTERPOLATION;
            OpacityDistance = 5.0;
            IsShadeOn = true;
            Ambient = 0.5;
            Diffuse = 0.5;
            Specular = 0.5;
            SpecularPower = 0.5;
            ScatteringAnisotropy = 0.5f;
            RenderMode = RenderMode.GPURenderMode;
            MaxMemoryBytes = 1024 * 1024 * 1024; // 1GB
            GPURatio = 0.75f; // %75
            FPS = 30.0; // 30 fps
            IsUseJittering = true;
            IsInterAdjustSampleDistance = true;
            IsAutoAdjustSampleDistance = true;
            GlobalIll = 0.5f;
            VolumetricScatBlend = 0.5f;
        }

        private void ReadDicom()
        {
            Reader.SetDirectoryName(Path);
            Extent = Reader.GetExtent();
            Spacing = Reader.GetSpacing();
            Origin = Reader.GetOrigin();
            ColorRange = Reader.GetColorRange();

            Center[0] = Origin[0] + ((Extent[1] - Extent[0]) * Spacing[0]) / 2;
            Center[1] = Origin[1] + ((Extent[3] - Extent[2]) * Spacing[1]) / 2;
            Center[2] = Origin[2] + ((Extent[5] - Extent[4]) * Spacing[2]) / 2;
        }

        private void InitAxial()
        {
            double[] cosinuses = { 1, 0, 0, 0, 0, 1, 0, 1, 0 };
            double[] position = { 0.0, 0.5, 0.5, 1.0 };
            double[] background = { 0.0, 0.0, 0.0 };
            double window = 100; // ColorRange[1] - ColorRange[0];
            double level = window / 2.0;

            Axial.Slice.Create(Reader.GetOutput(), cosinuses);
            Axial.Slice.SetAxisOrigin(Center[0], Center[1], Center[2]);
            Axial.Mapper.Create(Axial.Slice.GetOutput());
            Axial.Mapper.SetColorWindow((int)window);
            Axial.Mapper.SetColorLevel((int)level);
            Axial.Actor.SetMapper(Axial.Mapper.GetMapper());
            Axial.Renderer.Create(Axial.Actor.GetActor2D(), position, background);
        }

        private void InitSagittal()
        {
            double[] cosinuses = { 0, 1, 0, 0, 0, 1, 1, 0, 0 };
            double[] position = { 0.5, 0.5, 1.0, 1.0 };
            double[] background = { 0.0, 0.0, 0.0 };
            double window = 100; // ColorRange[1] - ColorRange[0];
            double level = window / 2.0;

            Sagittal.Slice.Create(Reader.GetOutput(), cosinuses);
            Sagittal.Slice.SetAxisOrigin(Center[0], Center[1], Center[2]);
            Sagittal.Mapper.Create(Sagittal.Slice.GetOutput());
            Sagittal.Mapper.SetColorWindow((int)window);
            Sagittal.Mapper.SetColorLevel((int)level);
            Sagittal.Actor.SetMapper(Sagittal.Mapper.GetMapper());
            Sagittal.Renderer.Create(Sagittal.Actor.GetActor2D(), position, background);
        }

        private void InitFrontal()
        {
            double[] cosinuses = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            double[] position = { 0.0, 0.0, 0.5, 0.5 };
            double[] background = { 0.0, 0.0, 0.0 };
            double window = 100; // ColorRange[1] - ColorRange[0];
            double level = window / 2.0;

            Frontal.Slice.Create(Reader.GetOutput(), cosinuses);
            Frontal.Slice.SetAxisOrigin(Center[0], Center[1], Center[2]);
            Frontal.Mapper.Create(Frontal.Slice.GetOutput());
            Frontal.Mapper.SetColorWindow((int)window);
            Frontal.Mapper.SetColorLevel((int)level);
            Frontal.Actor.SetMapper(Frontal.Mapper.GetMapper());
            Frontal.Renderer.Create(Frontal.Actor.GetActor2D(), position, background);
        }

        private void Init3DView()
        {
            double[] position = { 0.5, 0.0, 1.0, 0.5 };
            double[] background = { 0.0, 0.0, 0.0 };

            View3D.Mapper.Create(Reader.GetOutput());

            View3D.Color.Create();
            Colors.Add(0, new double[] { 0, 0, 0 });
            Colors.Add(50, new double[] { 0.5, 0.1, 0 });
            Colors.Add(100, new double[] { 1, 1, 0 });
            foreach (var color in Colors)
            {
                View3D.Color.AddColor(color.Key, color.Value);
            }

            View3D.Opacity.Create();
            Opacitys.Add(0, 0);
            Opacitys.Add(50, 0.5);
            Opacitys.Add(100, 0.5);
            foreach (var opacity in Opacitys)
            {
                View3D.Opacity.AddOpacity(opacity.Key, opacity.Value);
            }

            View3D.Property.Create();
            View3D.Property.SetColor(View3D.Color.GetColor());
            View3D.Property.SetOpacity(View3D.Opacity.GetOpacity());

            View3D.Volume.Create();
            View3D.Volume.SetMapper(View3D.Mapper.GetMapper());
            View3D.Volume.SetProperty(View3D.Property.GetProperty());

            View3D.Renderer.Create(View3D.Volume.GetVolume(), position, background);
        }

        private void InitAspectTexts()
        {
            AspectText.Create();
            AspectText.Add(Axial.Renderer.GetRenderer(), Sagittal.Renderer.GetRenderer(), Frontal.Renderer.GetRenderer());
        }

        private void InitLines2D()
        {
            Lines2D.SetSagittalLinesPos(SagittalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetFrontalLinesPos(FrontalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetAxialLinesPos(AxialLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.Create(Axial.Renderer.GetRenderer(), Sagittal.Renderer.GetRenderer(), Frontal.Renderer.GetRenderer());
            Lines2D.SetAxialLines();
            Lines2D.SetSagittalLines();
            Lines2D.SetFrontalLines();
        }

        private void InitLines3D()
        {
            Lines3D.Create(View3D.Renderer.GetRenderer());
            Lines3D.SetAxialLinesPos(AxialLayer, Extent, Spacing);
            Lines3D.SetSagittalLinesPos(SagittalLayer, Extent, Spacing);
            Lines3D.SetFrontalLinesPos(FrontalLayer, Extent, Spacing);
            Lines3D.SetConstPointsPos(Extent, Spacing);
            Lines3D.SetInitPoints();
        }

        public void InsertRenderersToController(vtkRenderWindow Window)
        {
            Window.AddRenderer(View3D.Renderer.GetRenderer());
            Window.AddRenderer(Axial.Renderer.GetRenderer());
            Window.AddRenderer(Sagittal.Renderer.GetRenderer());
            Window.AddRenderer(Frontal.Renderer.GetRenderer());
            Window.Render();
        }
        #endregion

        #region Layer Değişim Fonksiyonları
        private void ChangeLayerInAxial() 
        { 
            Axial.Slice.SetAxisOrigin(Center[0], AxialLayer * Spacing[1], Center[2]);
            Lines2D.SetAxialLinesPos(AxialLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetAxialLines();
            Lines3D.SetAxialLinesPos(AxialLayer, Extent, Spacing);
            Lines3D.SetAxialLines();
        }

        private void ChangeLayerInSagittal()
        {
            Sagittal.Slice.SetAxisOrigin(SagittalLayer * Spacing[0], Center[1], Center[2]);
            Lines2D.SetSagittalLinesPos(SagittalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetSagittalLines();
            Lines3D.SetSagittalLinesPos(SagittalLayer, Extent, Spacing);
            Lines3D.SetSagittalLines();
        }

        private void ChangeLayerInFrontal()
        {
            Frontal.Slice.SetAxisOrigin(Center[0], Center[1], FrontalLayer * Spacing[2]);
            Lines2D.SetFrontalLinesPos(FrontalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetFrontalLines();
            Lines3D.SetFrontalLinesPos(FrontalLayer, Extent, Spacing);
            Lines3D.SetFrontalLines();
        }
        #endregion

        #region Pozisyonlama Fonksiyonları
        public void SetPositionInAxial()
        {
            Ratio[1] = HeightDPI / (double)Extent[5];
            Axial.Slice.SetOutputExtent(Motion[0], Motion[2], Zoom[1], Ratio[1], HeightDPI, WidthDPI);
            Axial.Slice.SetOutputSpacing(Spacing, Ratio[1], Zoom[1]);
            Exts[1] = Extent[1] * (int)HeightDPI / Extent[5];
            Offsets[1] = ((int)WidthDPI - Exts[1]) / 2;

            Lines2D.SetAxialLinesPos(AxialLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetAxialLines();
        }

        public void SetPositionInSagittal()
        {
            Ratio[0] = HeightDPI / (double)Extent[3];
            Sagittal.Slice.SetOutputExtent(Motion[1], Motion[2], Zoom[0], Ratio[0], HeightDPI, WidthDPI);
            Sagittal.Slice.SetOutputSpacing(Spacing, Ratio[0], Zoom[0]);
            Exts[0] = Extent[5] * (int)HeightDPI / Extent[3];
            Offsets[0] = ((int)WidthDPI - Exts[0]) / 2;

            Lines2D.SetSagittalLinesPos(SagittalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetSagittalLines();
        }

        public void SetPositionInFrontal()
        {
            Ratio[2] = HeightDPI / (double)Extent[3];
            Frontal.Slice.SetOutputExtent(Motion[0], Motion[1], Zoom[2], Ratio[2], HeightDPI, WidthDPI);
            Frontal.Slice.SetOutputSpacing(Spacing, Ratio[2], Zoom[2]);
            Exts[2] = Extent[1] * (int)HeightDPI / Extent[3];
            Offsets[2] = ((int)WidthDPI - Exts[2]) / 2;

            Lines2D.SetFrontalLinesPos(FrontalLayer, Motion, Ratio, Offsets, Zoom, WidthDPI, HeightDPI);
            Lines2D.SetFrontalLines();
        }
        #endregion

        #region Motion Fonksiyonları
        public void ChangeMotionInAxial()
        {
            ChangeLayerInAxial();
            ChangeLayerInSagittal();
            ChangeLayerInFrontal();
            //SetPositionInAxial();
            SetPositionInSagittal();
            SetPositionInFrontal();
        }

        public void ChangeMotionInSagittal()
        {
            ChangeLayerInAxial();
            ChangeLayerInSagittal();
            ChangeLayerInFrontal();
            SetPositionInAxial();
            //SetPositionInSagittal();
            SetPositionInFrontal();
        }

        public void ChangeMotionInFrontal()
        {
            ChangeLayerInAxial();
            ChangeLayerInSagittal();
            ChangeLayerInFrontal();
            SetPositionInAxial();
            SetPositionInSagittal();
            //SetPositionInFrontal();
        }
        #endregion

        public void Reset()
        {
            AxialLayer = Extent[3] / 2;
            SagittalLayer = Extent[1] / 2;
            FrontalLayer = Extent[5] / 2;
            Zoom[0] = 1;
            Zoom[1] = 1;
            Zoom[2] = 1;
            Motion[0] = 0; 
            Motion[1] = 0;
            Motion[2] = 0;
            SetPositionInAxial();
            SetPositionInSagittal();
            SetPositionInFrontal();
            ChangeLayerInAxial();
            ChangeLayerInSagittal();
            ChangeLayerInFrontal();
            SetPositionInAxial();
            SetPositionInSagittal();
            SetPositionInFrontal();
        }
    }
}
