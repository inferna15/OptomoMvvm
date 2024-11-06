using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IActor2D
    {
        /// <summary>
        /// Mapper ile bir vtkActor2D oluşturur.
        /// </summary>
        /// <param name="Mapper"></param>
        void SetMapper(vtkImageMapper Mapper);

        /// <summary>
        /// Actor'ü döndürür.
        /// </summary>
        /// <returns>vtkActor2D</returns>
        vtkActor2D GetActor2D();
    }
}
