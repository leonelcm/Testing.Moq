using Testing.Sut.Interfaces;

namespace Testing.Sut.Dependencies
{
    public class SecondaryDependency: ISecondaryDependency
    {
        public int CalculateSecondary(int value)
        {
            return value + 2;
        }
    }
}
