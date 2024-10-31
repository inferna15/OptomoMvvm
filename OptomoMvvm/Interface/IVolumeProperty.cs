using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public enum INTERPOLATION
    {
        VTK_NEAREST_INTERPOLATION,
        VTK_LINEAR_INTERPOLATION,
        VTK_CUBIC_INTERPOLATION
    }

    internal interface IVolumeProperty
    {
        void Create();
        vtkVolumeProperty GetProperty();
        void SetColor(vtkColorTransferFunction Color);
        void SetOpacity(vtkPiecewiseFunction Opacity);
        void SetInterpolationType(INTERPOLATION Value);
        void SetOpacityDistance(double Distance);
        void SetShade(bool Value);
        void SetAmbient(double Value);
        void SetDiffuse(double Value);
        void SetSpecular(double Value);
        void SetSpecularPower(double Value);
        void SetScatteringAnisotropy(float Value);
    }
}
