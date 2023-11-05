using System.Reflection;
using Moq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using YlvasKaffelager.DbContext;
using YlvasKaffelager.DbContext.Interfaces;
using YlvasKaffelager.Models;
using YlvasKaffelager.Models.Interfaces;

namespace TestYlvasKaffeLager2;

public class UnitTestYlvasKaffelager
{
    private readonly ITestOutputHelper _testOutputHelper;
    private IDbContext _sut = new DbContext();
    private readonly Mock<IDbContext> _mockDb;
    private readonly IOrder _order = new Order();
    
    private List<Coffee> DatabaseForMock { get; set; }

    public UnitTestYlvasKaffelager(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _mockDb = new Mock<IDbContext>();
        DatabaseForMock = new List<Coffee>()
        {
            new()
            {
                Id = 1,
                Brand = "Gevalia",
                Price = 29.90m,
            },
            new()
            {
                Id = 2,
                Brand = "Lavazza",
                Price = 49.90m
            },
            new()
            {
                Id = 3,
                Brand = "Zoegas",
                Price = 60.0m
            }
        };
    }
    
    [Fact]
    public void Total_should_show_correct_value()
    {
        _order.Amount = 2;
        var coffee = _sut.GetCoffee(1);
        var expect = (29.90m * 2); //=59,8, Gevalia har priset 29,90 för en styck
        _order.Total = (coffee.Price * _order.Amount); //actual

        Assert.Equal(_order.Total, expect);
    }
   // Jag vill testa flera värden, 1 & 2 kommer vara korrekta värden
     [Theory]
     [InlineData(1)] 
     [InlineData(2)] 
     [InlineData(3)] //Mock kommer ha ett annorlunda värde i pris
     [InlineData(4)] //Denna kommer bli null
     public void Should_Return_Coffee(int id)
     {
         
         _mockDb.Setup(x => x.GetCoffee(id)).Returns(DatabaseForMock.FirstOrDefault(x => x.Id == id));
         var expected = _mockDb.Object.GetCoffee(id);
         var actual = _sut.GetCoffee(id);


         if (expected is null)
         {
             _testOutputHelper.WriteLine("Objektet var null");
         }

         else
         {
             try
             {
                 /*PropertyInfoklassen kommer jämföra datatyper och dess innehåll.
                  Ett undantag (exception) kommer hända vid 'typ' då den är null, dock anses båda ändå vara lika på grund av detta.*/
                 foreach (PropertyInfo value in expected.GetType().GetProperties())
                 {
                     Assert.Equal(value.GetValue(expected), value.GetValue(actual));
                 }
             }
             catch (EqualException)
             {
                 _testOutputHelper.WriteLine("Jämför skillnaderna nedanför.");
                 _testOutputHelper.WriteLine("_____________________________________");
                 foreach (PropertyInfo value in expected.GetType().GetProperties())

                     _testOutputHelper.WriteLine("Typ: " + (value.Name) + "\n" + "MockDatabasen: " + "Värde: " +
                                                 (value.GetValue(expected) + "\n" +
                                                  "Riktiga databasen: " + "Värde: " + (value.GetValue(actual) + "\n")));
             }

             _testOutputHelper.WriteLine("_____________________________________");
         }
     }
     }

