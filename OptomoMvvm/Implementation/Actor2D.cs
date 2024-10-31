using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    internal class Actor2D : IActor2D
    {
        private vtkActor2D actor;

        public void Create(vtkImageMapper Mapper)
        {
            actor = new vtkActor2D();
            actor.SetMapper(Mapper);
        }

        public vtkActor2D GetActor2D() => actor;
    }
}
