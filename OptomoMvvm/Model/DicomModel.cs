using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Model
{
    internal class DicomModel
    {
        // Service
        private readonly IDicomReader Reader;

        // Field
        public string Path { get; set; } = "C:\\Users\\Admin\\Documents\\Documents\\Dicoms\\beyin";
        public int[] Extent { get; set; } = new int[6];
        public double[] Spacing { get; set; } = new double[3];
        public double[] Origin { get; set; } = new double[3];
        public double[] Center { get; set; } = new double[3];
        public double[] ColorRange { get; set; } = new double[2];
        public vtkAlgorithmOutput Output { get; set; }

        // Constuctor
        public DicomModel(IDicomReader reader)
        {
            Reader = reader;

            ReadDicom();
        }

        // Functions
        private void ReadDicom()
        {
            Reader.SetDirectoryName(Path);
            Extent = Reader.GetExtent();
            Spacing = Reader.GetSpacing();
            Origin = Reader.GetOrigin();
            ColorRange = Reader.GetColorRange();

            Center[0] = Origin[0] + ((Extent[1] - Extent[0]) * Spacing[0]) / 2.0;
            Center[1] = Origin[1] + ((Extent[3] - Extent[2]) * Spacing[1]) / 2.0;
            Center[2] = Origin[2] + ((Extent[5] - Extent[4]) * Spacing[2]) / 2.0;

            Output = Reader.GetOutput();
        }
    }
}
