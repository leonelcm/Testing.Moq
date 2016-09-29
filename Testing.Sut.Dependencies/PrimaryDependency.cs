using Testing.Sut.Interfaces;

namespace Testing.Sut.Dependencies
{
    public class PrimaryDependency: IPrimaryDependency
    {
        public int CalculatePrimary(int value)
        {
            return value*10;
        }
    }
}
