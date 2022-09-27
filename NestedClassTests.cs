using FluentAssertions;

public class NestedClassTests
{

    [Fact]
    public void Can_We_Agree_This_Is_Not_A_Good_Idea()
    {
        var instance = new AnotherDerived();

        instance.ReallyBreakEncapsulation().Should().Be("Public Root, Instance Secrets");
    }

    [Fact]
    public void Can_Really_BreakEncapsulation()
    {
        var instance = new PublicRoot.PublicNested();

        instance.ReallyBreakEncapsulation().Should().Be("Public Root, Instance Secrets");
    }

    [Fact]
    public void Can_Get_Public_Static_Secrets()
    {
        var instance = new PublicRoot.PublicNested();

        instance.BreakEncapsulation().Should().Be("Public Root, Static Secrets");
    }

    [Fact]
    public void Can_Create_Nested_Instance()
    {
        var nestedInstance = new PublicRoot.PublicNested();

        nestedInstance.Should().BeOfType<PublicRoot.PublicNested>();
        nestedInstance.WhoAmI().Should().Be("PublicNested");
    }

    [Fact]
    public void Can_Create_Nested_Instance_In_Static()
    {
        var nestedInstance = new PublicStaticRoot.PublicNested();

        nestedInstance.Should().BeOfType<PublicStaticRoot.PublicNested>();
        nestedInstance.WhoAmI().Should().Be("PublicNested");
    }

    [Fact]
    public void Can_Create_Nested_Derived_In_Static()
    {
        var nestedInstance = new Derived();

        nestedInstance.Should().BeOfType<Derived>();
        nestedInstance.WhoAmI().Should().Be("Derived");
    }

    [Fact]
    public void Can_Get_StaticSecrets()
    {
        var instance = new Derived();

        instance.BreakEncapsulation().Should().Be("Public Static Root, Static Secrets");
    }
}