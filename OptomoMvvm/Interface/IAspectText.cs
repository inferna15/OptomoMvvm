using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IAspectText
    {
        void Create();
        void Add(vtkRenderer axialRenderer, vtkRenderer sagittalRenderer, vtkRenderer frontalRenderer);
    }
}
