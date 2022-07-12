using Meter_API.Utils;

namespace UnitTests.Utils;

public class UtilsTest
{
    [Fact]
    public void ShouldCallIsEmptyMethodAndReturnTrueWhenPassedStringIsNull()
    {
        string req = null;

        var res = ApiUtils.IsEmpty(req);

        Assert.True(res);
    }


    [Fact]
    public void ShouldCallIsEmptyMethodAndReturnTrueWhenPassedStringIsEmpty()
    {
        const string req = "";

        var res = ApiUtils.IsEmpty(req);

        Assert.True(res);
    }

    [Fact]
    public void ShouldCallIsEmptyMethodAndReturnFalseWhenPassedStringIsNotNull()
    {
        const string req = "data";

        var res = ApiUtils.IsEmpty(req);

        Assert.False(res);
    }
}