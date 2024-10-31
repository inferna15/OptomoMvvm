using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class VolumeProperty : IVolumeProperty
    {
        private vtkVolumeProperty property;

        public void Create() => property = new vtkVolumeProperty();

        public vtkVolumeProperty GetProperty() => property;

        public void SetColor(vtkColorTransferFunction Color) => property.SetColor(Color);

        public void SetInterpolationType(INTERPOLATION Value) => property.SetInterpolationType((int)Value);

        public void SetOpacity(vtkPiecewiseFunction Opacity) => property.SetScalarOpacity(Opacity);

        public void SetOpacityDistance(double Distance) => property.SetScalarOpacityUnitDistance(Distance);

        public void SetShade(bool Value) => property.SetShade(Value ? 1 : 0);

        public void SetAmbient(double Value) => property.SetAmbient(Value);

        public void SetDiffuse(double Value) => property.SetDiffuse(Value);

        public void SetSpecular(double Value) => property.SetSpecular(Value);

        public void SetSpecularPower(double Value) => property.SetSpecularPower(Value);

        public void SetScatteringAnisotropy(float Value) => property.SetScatteringAnisotropy(Value);
    }
}
