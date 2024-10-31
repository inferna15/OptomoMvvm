using OptomoMvvm.Group;

namespace OptomoMvvm.Model
{
    internal class VtkModel
    {
        // Services
        private readonly AxialGroup Axial;
        private readonly SagittalGroup Sagittal;
        private readonly FrontalGroup Frontal;
        private readonly View3DGroup View3D;

        // Models
        public readonly DicomModel DicomModel;
        public readonly PropertyModel PropertyModel;

        public VtkModel(AxialGroup axial, SagittalGroup sagittal, FrontalGroup frontal, View3DGroup view3D, DicomModel dicomModel, PropertyModel propertyModel)
        {
            Axial = axial;
            Sagittal = sagittal;
            Frontal = frontal;
            View3D = view3D;
            DicomModel = dicomModel;
            PropertyModel = propertyModel;

            Initialize();
        }

        private void Initialize()
        {
            // Axial Slice
            Axial.Slice.Create(DicomModel.Output, DicomModel.Center, new double[] { 1, 0, 0, 0, 0, 1, 0, 1, 0 });
            Axial.Mapper.Create(Axial.Slice.GetOutput());
            Axial.Mapper.SetColorWindow((int)(DicomModel.ColorRange[1] - DicomModel.ColorRange[0]));
            Axial.Mapper.SetColorLevel((int)((DicomModel.ColorRange[1] - DicomModel.ColorRange[0]) / 2.0));
            Axial.Actor.Create(Axial.Mapper.GetMapper());
            Axial.Renderer.Create(Axial.Actor.GetActor2D(), new double[] { 0.0, 0.5, 0.5, 1.0 }, new double[] { 0.0, 0.0, 0.0 });

            // Sagittal Slice
            Sagittal.Slice.Create(DicomModel.Output, DicomModel.Center, new double[] { 0, 1, 0, 0, 0, 1, 1, 0, 0 });
            Sagittal.Mapper.Create(Sagittal.Slice.GetOutput());
            Sagittal.Mapper.SetColorWindow((int)(DicomModel.ColorRange[1] - DicomModel.ColorRange[0]));
            Sagittal.Mapper.SetColorLevel((int)((DicomModel.ColorRange[1] - DicomModel.ColorRange[0]) / 2.0));
            Sagittal.Actor.Create(Sagittal.Mapper.GetMapper());
            Sagittal.Renderer.Create(Sagittal.Actor.GetActor2D(), new double[] { 0.5, 0.5, 1.0, 1.0 }, new double[] { 0.0, 0.0, 0.0 });

            // Frontal Slice
            Frontal.Slice.Create(DicomModel.Output, DicomModel.Center, new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 });
            Frontal.Mapper.Create(Sagittal.Slice.GetOutput());
            Frontal.Mapper.SetColorWindow((int)(DicomModel.ColorRange[1] - DicomModel.ColorRange[0]));
            Frontal.Mapper.SetColorLevel((int)((DicomModel.ColorRange[1] - DicomModel.ColorRange[0]) / 2.0));
            Frontal.Actor.Create(Frontal.Mapper.GetMapper());
            Frontal.Renderer.Create(Frontal.Actor.GetActor2D(), new double[] { 0.0, 0.0, 0.5, 0.5 }, new double[] { 0.0, 0.0, 0.0 });

            // 3D View
            View3D.Mapper.Create(DicomModel.Output);
            View3D.Mapper.SetRenderMode(PropertyModel.RenderMode);
            View3D.Mapper.SetInterpolitionType(PropertyModel.InterpolationType);
            View3D.Mapper.SetMaxMemoryInBytes(PropertyModel.MaxMemoryBytes);
            View3D.Mapper.SetMaxMemoryFraction(PropertyModel.GPURatio);
            View3D.Mapper.SetInteractiveUpdateRate(PropertyModel.FPS);
            View3D.Mapper.SetUseJittering(PropertyModel.IsUseJittering);
            View3D.Mapper.SetInteractiveAdjustSampleDistances(PropertyModel.IsInterAdjustSampleDistance);
            View3D.Mapper.SetAutoAdjustSampleDistances(PropertyModel.IsAutoAdjustSampleDistance);
            View3D.Mapper.SetGlobalIlluminationReach(PropertyModel.GlobalIll);
            View3D.Mapper.SetVolumetricScatteringBlending(PropertyModel.VolumetricScatBlend);

            View3D.Color.Create();
            PropertyModel.Colors.Add(DicomModel.ColorRange[0], new double[] { 0, 0, 0 });
            PropertyModel.Colors.Add((DicomModel.ColorRange[1] + DicomModel.ColorRange[0]) / 2.0, new double[] { 0.5, 0.1, 0 });
            PropertyModel.Colors.Add(DicomModel.ColorRange[1], new double[] { 1, 1, 0 });
            foreach (var color in PropertyModel.Colors)
            {
                View3D.Color.AddColor(color.Key, color.Value);
            }

            View3D.Opacity.Create();
            PropertyModel.Opacitys.Add(DicomModel.ColorRange[0], 0);
            PropertyModel.Opacitys.Add((DicomModel.ColorRange[1] + DicomModel.ColorRange[0]) / 2.0, 0.05);
            PropertyModel.Opacitys.Add(DicomModel.ColorRange[1], 0.5);
            foreach (var opacity in PropertyModel.Opacitys)
            {
                View3D.Opacity.AddOpacity(opacity.Key, opacity.Value);
            }

            View3D.Property.Create();
            View3D.Property.SetColor(View3D.Color.GetColor());
            View3D.Property.SetOpacity(View3D.Opacity.GetOpacity());
            View3D.Property.SetInterpolationType(PropertyModel.InterpolationType);
            View3D.Property.SetOpacityDistance(PropertyModel.OpacityDistance);
            View3D.Property.SetShade(PropertyModel.IsShadeOn);
            View3D.Property.SetAmbient(PropertyModel.Ambient);
            View3D.Property.SetDiffuse(PropertyModel.Diffuse);
            View3D.Property.SetSpecular(PropertyModel.Specular);
            View3D.Property.SetSpecularPower(PropertyModel.SpecularPower);
            View3D.Property.SetScatteringAnisotropy(PropertyModel.ScatteringAnisotropy);

            View3D.Volume.Create();
            View3D.Volume.SetMapper(View3D.Mapper.GetMapper());
            View3D.Volume.SetProperty(View3D.Property.GetProperty());

            View3D.Renderer.Create(View3D.Volume.GetVolume(), new double[] { 0.5, 0.0, 1.0, 0.5 }, new double[] { 0.0, 0.0, 0.0 });
        }
    }
}
