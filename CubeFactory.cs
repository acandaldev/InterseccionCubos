using InterseccionCubos.Models.Cube;

namespace InterseccionCubos
{
    public class CubeFactory
    {
        private Point center;
        private double edgeLength;
        public static CubeFactory Cube()
        {
            return new CubeFactory();
        }
        public CubeFactory CenteredAt(double x, double y, double z)
        {
            center = new Point(x, y, z);
            return this;
        }
        public CubeFactory WithEdgeLength(double length)
        {
            edgeLength = length;
            return this;
        }
        public Cube Build()
        {
            return new Cube(center, edgeLength);
        }
    }
}
