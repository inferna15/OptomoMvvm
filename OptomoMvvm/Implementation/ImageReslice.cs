using Kitware.VTK;
using OptomoMvvm.Interface;

namespace OptomoMvvm.Implementation
{
    public class ImageReslice : IImageReslice
    {
        private vtkImageReslice reslice;

        public void Create(vtkAlgorithmOutput Output, double[] Center, double[] Cosinus)
        {
            reslice = new vtkImageReslice();
            reslice.SetInputConnection(Output);
            reslice.SetResliceAxesDirectionCosines(Cosinus[0], Cosinus[1], Cosinus[2], Cosinus[3], Cosinus[4], Cosinus[5], Cosinus[6], Cosinus[7], Cosinus[8]);
            reslice.SetResliceAxesOrigin(Center[0], Center[1], Center[2]);
        }

        public vtkAlgorithmOutput GetOutput() => reslice.GetOutputPort();

        public void SetOutputExtent(int[] Values) => reslice.SetOutputExtent(Values[0], Values[1], Values[2], Values[3], Values[4], Values[5]);

        public void SetOutputSpacing(double[] Values) => reslice.SetOutputSpacing(Values[0], Values[1], Values[2]);
    }
}
