using Kitware.VTK;
using OptomoMvvm.Interface;
using System.Windows;

namespace OptomoMvvm.Implementation
{
    internal class AspectText : IAspectText
    {
        private vtkTextActor[] aspects;

        public void Create()
        {
            aspects = new vtkTextActor[12];
            for (int i = 0; i < 12; i++)
            {
                aspects[i] = new vtkTextActor();
                aspects[i].SetTextScaleModeToNone();
                aspects[i].GetPositionCoordinate().SetCoordinateSystemToNormalizedDisplay();
                aspects[i].GetTextProperty().SetFontFamilyToCourier(); ;
                aspects[i].GetTextProperty().SetFontSize(24);
                aspects[i].GetTextProperty().SetColor(1, 1, 1);
            }
        }

        public void Add(vtkRenderer axialRenderer, vtkRenderer sagittalRenderer, vtkRenderer frontalRenderer)
        {
            aspects[0].SetPosition(0.05, 0.93);
            aspects[0].SetInput("P");
            aspects[1].SetPosition(0.05, 0.83);
            aspects[1].SetInput("A");
            aspects[2].SetPosition(0.02, 0.88);
            aspects[2].SetInput("L");
            aspects[3].SetPosition(0.08, 0.88);
            aspects[3].SetInput("R");

            aspects[4].SetPosition(0.93, 0.93);
            aspects[4].SetInput("S");
            aspects[5].SetPosition(0.93, 0.83);
            aspects[5].SetInput("I");
            aspects[6].SetPosition(0.96, 0.88);
            aspects[6].SetInput("A");
            aspects[7].SetPosition(0.90, 0.88);
            aspects[7].SetInput("P");

            aspects[8].SetPosition(0.05, 0.43);
            aspects[8].SetInput("S");
            aspects[9].SetPosition(0.05, 0.33);
            aspects[9].SetInput("I");
            aspects[10].SetPosition(0.02, 0.38);
            aspects[10].SetInput("L");
            aspects[11].SetPosition(0.08, 0.38);
            aspects[11].SetInput("R");
            for (int i = 0; i < 12; i++)
            {
                if (i / 4 == 0)
                {
                    axialRenderer.AddActor(aspects[i]);
                }
                else if (i / 4 == 1)
                {
                    sagittalRenderer.AddActor(aspects[i]);
                }
                else if (i / 4 == 2)
                {
                    frontalRenderer.AddActor(aspects[i]);
                }
            }
        }
    }
}
