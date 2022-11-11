using ShapeLib;

namespace ShapeLibTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateCircle()
        {
            Assert.IsInstanceOfType(new Circle(5),typeof(Circle));
            Assert.ThrowsException<ArgumentException>(()=>
            {
                Circle circle = new Circle(-5);
            });
        }
        [TestMethod]
        public void TestCalculateCircleArea()
        {
            Circle circle = new Circle(5);
            Assert.IsTrue(circle.Area() == Math.PI * 25d);
        }

        [TestMethod]
        public void TestCreateTriangle()
        {
            Assert.IsInstanceOfType(new Triangle(1, 1, 1), typeof(Triangle));
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Triangle circle = new Triangle(-5, 1, 1);
            });
        }

        [TestMethod]
        public void TestCalculateTriangleArea()
        {
            Triangle t = new Triangle(3, 4, 5);
            Assert.IsTrue(t.Area() == 6);
        }

        [TestMethod]
        public void Test90AngleTriangle()
        {
            Triangle t = new Triangle(3, 4, 5);
            Assert.IsTrue(t.Check90Angle());
        }

        [TestMethod]
        public void Test90AngleTriangle_Wrong()
        {
            Triangle t = new Triangle(1, 6, 6);
            Assert.IsFalse(t.Check90Angle());
        }
    }
}