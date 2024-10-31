using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IImageReslice
    {
        /// <summary>
        /// Bir kesit oluşturur.
        /// </summary>
        /// <param name="Output">Alınan çıktı.</param>
        /// <param name="Center">Merkezin kordinatları double[3]</param>
        /// <param name="Cosinus">Kesitin kosinüs değerleri double[9]</param>
        void Create(vtkAlgorithmOutput Output, double[] Center, double[] Cosinus);

        /// <summary>
        /// Çıktı verir.
        /// </summary>
        /// <returns>Kesiti çıktısı.</returns>
        vtkAlgorithmOutput GetOutput();

        /// <summary>
        /// Extent değerlerini ayarlama.
        /// </summary>
        /// <param name="Values">Extent değerleri int[6]</param>
        void SetOutputExtent(int[] Values);

        /// <summary>
        /// Spacing değerlerini ayarlama.
        /// </summary>
        /// <param name="Values">Spacing değerleri double[3]</param>
        void SetOutputSpacing(double[] Values);
    }
}
