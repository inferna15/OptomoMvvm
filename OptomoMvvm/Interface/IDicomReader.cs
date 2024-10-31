using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface IDicomReader
    {
        /// <summary>
        /// vtkDICOMImageReader için klasör yerini belirler.
        /// </summary>
        /// <param name="Path">Klasör yolu.</param>
        void SetDirectoryName(string Path);

        /// <summary>
        /// Okunan verinin çıktısını verir.
        /// </summary>
        /// <returns>reader.GetOutputPort() çıktısı.</returns>
        vtkAlgorithmOutput GetOutput();

        /// <summary>
        /// Dicom görüntünün extent değerlerini döndürür.
        /// </summary>
        /// <returns>Extent değerleri.</returns>
        int[] GetExtent();

        /// <summary>
        /// Dicom görüntünün spacing değerlerini döndürür.
        /// </summary>
        /// <returns>Spacing değerleri.</returns>
        double[] GetSpacing();

        /// <summary>
        /// Dicom görüntünün origin değerlerini döndürür.
        /// </summary>
        /// <returns>Origin değerleri.</returns>
        double[] GetOrigin();

        double[] GetColorRange();
    }
}
