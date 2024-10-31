using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    internal interface IVolumeOpacity
    {
        void Create();
        void AddOpacity(double Value, double Opacity);
        void RemoveOpacity(double Value);
        void RemoveAllOpacity();
        vtkPiecewiseFunction GetOpacity();
    }
}
