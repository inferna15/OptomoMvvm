using OptomoMvvm.Interface;

namespace OptomoMvvm.Model
{
    internal class PropertyModel
    {
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

        public PropertyModel()
        {
            Colors = new Dictionary<double, double[]>();
            Opacitys = new Dictionary<double, double>();
            InterpolationType = INTERPOLATION.VTK_NEAREST_INTERPOLATION;
            OpacityDistance = 5.0;
            IsShadeOn = true;
            Ambient = 0.5;
            Diffuse = 0.5;
            Specular  = 0.5;
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
    }
}
