public class PublicRoot
{
    public class PublicNested
    {
        public string WhoAmI() => $"{this.GetType().Name}";

        public string BreakEncapsulation() => $"{PublicRoot.Secrets}";

        public string ReallyBreakEncapsulation() => $"{new PublicRoot().InstanceSecrets}";
    }

    private static string Secrets = "Public Root, Static Secrets";

    private string InstanceSecrets = "Public Root, Instance Secrets";

}

public static class PublicStaticRoot
{
    public class PublicNested
    {
        public string WhoAmI() => $"{this.GetType().Name}";
        public virtual string BreakEncapsulation() => $"{PublicStaticRoot.Secrets}";
    }
    protected class ProtectedNested
    {
        public string WhoAmI() => $"{this.GetType().Name}";
        public virtual string BreakEncapsulation() => $"{PublicStaticRoot.Secrets}";
    }
    private static string Secrets = "Public Static Root, Static Secrets";

}

public class Derived : PublicStaticRoot.PublicNested
{
    public override string BreakEncapsulation() => $"{base.BreakEncapsulation()}";

}

public class AnotherDerived : PublicRoot.PublicNested
{

}