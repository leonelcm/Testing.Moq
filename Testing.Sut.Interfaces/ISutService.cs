namespace Testing.Sut.Interfaces
{
    public interface ISutService
    {
        int PrimaryDependencyDependantCall(int value);
        int SecondaryDependencyDependantCall(int value);

        ISecondaryDependency SecondaryDependency { get; set; }
    }
}
