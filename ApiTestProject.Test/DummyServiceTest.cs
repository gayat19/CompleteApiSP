using employeeapp.Api;

namespace ApiTestProject.Test;

public class Tests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddSuccessTest()
    {
        //Arrange
        DummyServiceForTest obj = new DummyServiceForTest();
        int n1 = 20, n2 = 10;
        //Action
        var result = obj.Sum(n1, n2);
        //Assert
        Assert.That(result, Is.EqualTo(20));

    }
}
