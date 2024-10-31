using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class DicomReader : IDicomReader
    {
        private vtkDICOMImageReader reader;

        public void SetDirectoryName(string Path)
        {
            reader = new vtkDICOMImageReader();
            reader.SetDirectoryName(Path);
            reader.Update();
        }

        public vtkAlgorithmOutput GetOutput() => reader.GetOutputPort();

        public int[] GetExtent() => reader.GetDataExtent();

        public double[] GetSpacing() => reader.GetDataSpacing();

        public double[] GetOrigin() => reader.GetDataOrigin();

        public double[] GetColorRange() => reader.GetOutput().GetScalarRange();
    }
}
