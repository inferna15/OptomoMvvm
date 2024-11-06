using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IRenderer
    {
        void Create(vtkActor2D Actor, double[] Position, double[] Background);
        void Create(vtkVolume Actor, double[] Position, double[] Background);
        vtkRenderer GetRenderer();
    }
}
