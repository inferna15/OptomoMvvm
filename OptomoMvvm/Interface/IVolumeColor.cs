using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    internal interface IVolumeColor
    {
        void Create();
        void AddColor(double Value, double[] RGB);
        void RemoveColor(double Value);
        void RemoveAllColor();
        vtkColorTransferFunction GetColor();
    }
}
