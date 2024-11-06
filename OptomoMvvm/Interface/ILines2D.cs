using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface ILines2D
    {
        void Create(vtkRenderer axialRenderer, vtkRenderer sagittalRenderer, vtkRenderer frontalRenderer);
        void SetAxialLines();
        void SetSagittalLines();
        void SetFrontalLines();
        void SetAxialLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height);
        void SetSagittalLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height);
        void SetFrontalLinesPos(int Layer, int[] Motion, double[] Ratio, int[] Offset, double[] Zoom, double width, double height);
    }
}
