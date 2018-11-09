using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DragDropAdornerPoC.Adorners
{
    public class CarretAdorner : Adorner
    {
        public CarretAdorner(UIElement adornedElement) 
            : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            var renderPen = new Pen(new SolidColorBrush(Colors.Black), 1.5);
            var renderBrush = new SolidColorBrush(Colors.Black);

            // draw line
            drawingContext.DrawLine(renderPen, adornedElementRect.TopLeft, adornedElementRect.TopRight);

            // draw left triangle
            drawingContext.DrawGeometry(renderBrush, renderPen, GetTriangle(new Point(0, -1.5), new Point(0, 1.5), new Point(3, 0)));

            // draw right triangle
            drawingContext.DrawGeometry(renderBrush, renderPen, GetTriangle(new Point(adornedElementRect.TopRight.X, -1.5),
                                                                            new Point(adornedElementRect.TopRight.X, 1.5),
                                                                            new Point(adornedElementRect.TopRight.X - 3, 0)));
        }

        private StreamGeometry GetTriangle(Point p1, Point p2, Point p3)
        {
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(p1, true, true);
                PointCollection points = new PointCollection { p2, p3 };
                geometryContext.PolyLineTo(points, true, true);
            }

            streamGeometry.Freeze();
            return streamGeometry;
        }
    }
}
