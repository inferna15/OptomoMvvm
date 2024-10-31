using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class VolumeColor : IVolumeColor
    {
        private vtkColorTransferFunction color;

        public void Create() => color = new vtkColorTransferFunction();

        public void AddColor(double Value, double[] RGB) => color.AddRGBPoint(Value, RGB[0], RGB[1], RGB[2]);

        public void RemoveColor(double Value) => color.RemovePoint(Value);

        public void RemoveAllColor() => color.RemoveAllPoints();

        public vtkColorTransferFunction GetColor() => color;
    }
}
