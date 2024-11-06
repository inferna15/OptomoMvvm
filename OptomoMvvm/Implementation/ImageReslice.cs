using Kitware.VTK;
using OptomoMvvm.Interface;
using System.Windows;
using System.Windows.Media.Media3D;

namespace OptomoMvvm.Implementation
{
    public class ImageReslice : IImageReslice
    {
        private vtkImageReslice reslice;

        public ImageReslice() => reslice = new vtkImageReslice();

        public void Create(vtkAlgorithmOutput Output, double[] Cosinus)
        {
            reslice.SetInputConnection(Output);
            reslice.SetOutputDimensionality(2);
            reslice.SetResliceAxesDirectionCosines(Cosinus[0], Cosinus[1], Cosinus[2], Cosinus[3], Cosinus[4], Cosinus[5], Cosinus[6], Cosinus[7], Cosinus[8]);
        }

        public vtkAlgorithmOutput GetOutput() => reslice.GetOutputPort();

        public void SetAxisOrigin(double X, double Y, double Z) => reslice.SetResliceAxesOrigin(X, Y, Z);

        public void SetOutputExtent(int Motion1, int Motion2, double Zoom, double Ratio, double height, double width)
        {
            reslice.SetOutputExtent((int)(Motion1 * Ratio * Zoom) - (int)((Zoom - 1) * (width / 2)),
                (int)(width + Motion1 * Ratio * Zoom) + (int)((Zoom - 1) * (width / 2)),
                (int)(Motion2 * Ratio * Zoom) - (int)((Zoom - 1) * (height / 2)),
                (int)(height + Motion2 * Ratio * Zoom) + (int)((Zoom - 1) * (height / 2)), 0, 0);
        }

        public void SetOutputSpacing(double[] Spacing, double Ratio, double Zoom)
        {
            reslice.SetOutputSpacing(Spacing[0] / Ratio / Zoom, Spacing[1] / Ratio / Zoom, Spacing[2] / Ratio / Zoom);
        }
    }
}
