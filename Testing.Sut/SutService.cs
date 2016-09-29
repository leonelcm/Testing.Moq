using System;
using System.CodeDom;
using Testing.Sut.Interfaces;

namespace Testing.Sut
{
    public class SutService : ISutService
    {
        public SutService(IPrimaryDependency primaryDependency)
        {
            PrimaryDependency = primaryDependency;
        }

        public IPrimaryDependency PrimaryDependency
        {
            get;
            private set;
        }

        public int PrimaryDependencyDependantCall(int value)
        {
            // uncomment to fail
            // return 1;

            int result = PrimaryDependency.CalculatePrimary(value);

            if (result < 0)
            {
                throw new InvalidOperationException(
                    "Value coming from PrimaryDependency.Callcualte() must be non-negative.");
            }

            return result/10;
        }

        public int SecondaryDependencyDependantCall(int value)
        {
            if (SecondaryDependency == null)
            {
                throw new InvalidOperationException();
            }
            //return 15;

            int result = SecondaryDependency.CalculateSecondary(value);
            return result - 1;
        }

        public virtual ISecondaryDependency SecondaryDependency { get; set; }
    }
}
