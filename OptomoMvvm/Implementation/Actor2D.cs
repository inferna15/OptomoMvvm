using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class Actor2D : IActor2D
    {
        private readonly vtkActor2D actor;

        public Actor2D() => actor = new vtkActor2D();

        public void SetMapper(vtkImageMapper Mapper) => actor.SetMapper(Mapper);

        public vtkActor2D GetActor2D() => actor;
    }
}
