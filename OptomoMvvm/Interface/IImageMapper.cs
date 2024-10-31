using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IImageMapper
    {
        /// <summary>
        /// vtkImageMapper nesnesini oluşturur.
        /// </summary>
        /// <param name="Output">Alınan çıktı.</param>
        void Create(vtkAlgorithmOutput Output);

        /// <summary>
        /// Mapper'ı verir.
        /// </summary>
        /// <returns>Mapper</returns>
        vtkImageMapper GetMapper();

        /// <summary>
        /// Görüntünün pencere renk seviyesini ayarlar.
        /// </summary>
        /// <param name="Value"></param>
        void SetColorWindow(int Value);

        /// <summary>
        /// Görüntünün ortalama renk seviyesini ayarlar.
        /// </summary>
        /// <param name="Value"></param>
        void SetColorLevel(int Value);
    }
}
