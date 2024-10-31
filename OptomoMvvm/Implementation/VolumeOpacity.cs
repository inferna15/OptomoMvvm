using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class VolumeOpacity : IVolumeOpacity
    {
        private vtkPiecewiseFunction opacity;

        public void Create() => opacity = new vtkPiecewiseFunction();

        public void AddOpacity(double Value, double Opacity) => opacity.AddPoint(Value, Opacity);

        public void RemoveOpacity(double Value) => opacity.RemovePoint(Value);

        public void RemoveAllOpacity() => opacity.RemoveAllPoints();

        public vtkPiecewiseFunction GetOpacity() => opacity;
    }
}
