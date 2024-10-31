using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    internal interface IActor2D
    {
        /// <summary>
        /// Mapper ile bir vtkActor2D oluşturur.
        /// </summary>
        /// <param name="Mapper"></param>
        void Create(vtkImageMapper Mapper);

        /// <summary>
        /// Actor'ü döndürür.
        /// </summary>
        /// <returns>vtkActor2D</returns>
        vtkActor2D GetActor2D();
    }
}
