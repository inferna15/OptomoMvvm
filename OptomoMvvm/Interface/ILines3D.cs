using Kitware.VTK;

namespace OptomoMvvm.Interface
{
    public interface ILines3D
    {
        void Create(vtkRenderer view3DRenderer);
        void SetAxialLinesPos(int Layer, int[] Extent, double[] Spacing);
        void SetSagittalLinesPos(int Layer, int[] Extent, double[] Spacing);
        void SetFrontalLinesPos(int Layer, int[] Extent, double[] Spacing);
        void SetConstPointsPos(int[] Extent, double[] Spacing);
        void SetAxialLines();
        void SetSagittalLines();
        void SetFrontalLines();
        void SetInitPoints();
    }
}
