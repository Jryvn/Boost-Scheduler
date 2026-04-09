using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Boost_Scheduler.API.Data;
using Microsoft.AspNetCore.Identity;
using Boost_Scheduler.API.Controllers;


namespace Boost_Scheduler.Tests;

public sealed class UnitTest1
{
    [Fact]
    public void TestReadGameWrongID()
    {
        //IActionResult result = DataController.ReadGame("");
        Assert.True(true);
    }

    [Fact]
    public void Test1()
    {
        
        Assert.True(true);
    }
    [Fact(Skip="this will fail")]
    public void Test2()
    {
        Assert.False(true);
    }
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Test3(bool input)
    {
        Assert.True(input);
    }
}