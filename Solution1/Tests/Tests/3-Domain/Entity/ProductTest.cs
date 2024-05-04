using Sistema.Vendas.Domain.Exceptions;
using DomainContext = Sistema.Vendas.Domain.ProductContext;

namespace Tests._3_Domain.Entity;

public class ProductTest
{
    [Fact(DisplayName = nameof(Instantiate))]
    [Trait("Domain", "Product - Aggregate")]
    public void Instantiate()
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = 1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        var datetimeBefore = DateTime.Now;

        var product = new DomainContext.ProductContext(validData.Name, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var datetimeAfter = DateTime.Now;

        Assert.NotNull(product);
        Assert.Equal(validData.Name, product.Name);
        Assert.Equal(validData.Description, product.Description);
        Assert.Equal(validData.Quantity, product.Quantity);
        Assert.Equal(validData.Price, product.Price);
        Assert.Equal(validData.LinkPhoto, product.LinkPhoto);
        Assert.NotEqual(default(Guid), product.Id);
        Assert.True(product.CreatedAt > datetimeBefore);
        Assert.True(product.CreatedAt < datetimeAfter);
    }

    [Theory(DisplayName = nameof(InstantiateErrorWhenNameIsNull))]
    [Trait("Domain", "Product - Aggregate")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void InstantiateErrorWhenNameIsNull(string? name)
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = 1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(name!, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var exception = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Name should not be empty or null", exception.Message);
    }

    [Theory(DisplayName = nameof(InstantiateErrorWhenDescriptionIsNull))]
    [Trait("Domain", "Product - Aggregate")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void InstantiateErrorWhenDescriptionIsNull(string? description)
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = 1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(validData.Name, description!, validData.Quantity, validData.Price, validData.LinkPhoto);

        var exception = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Description should not be empty or null", exception.Message);
    }

    [Fact(DisplayName = nameof(InstantiateErrorWhenQuantityLessThanZero))]
    [Trait("Domain", "Product - Aggregate")]
    public void InstantiateErrorWhenQuantityLessThanZero()
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = -1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(validData.Name, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var exception = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Quantity should not be less to 0", exception.Message);
    }

    [Fact(DisplayName = nameof(InstantiateErrorWhenPriceLessThanZero))]
    [Trait("Domain", "Product - Aggregate")]
    public void InstantiateErrorWhenPriceLessThanZero()
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = 2,
            Price = -1,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(validData.Name, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var exception = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Price should not be less to 0.00", exception.Message);
    }

    [Theory(DisplayName = nameof(InstantiateErrorWhenPriceLessThanZero))]
    [Trait("Domain", "Product - Aggregate")]
    [InlineData("a")]
    [InlineData("ab")]
    public void InstantiateErrorWhenNameIsLessThan3Characters(string name)
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = -1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(name!, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var exception = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Name should be at leats 3 caracters long", exception.Message);
    }

    [Fact(DisplayName = nameof(InstantiateErrorWhenNameIsGreaterThan255Characters))]
    [Trait("Domain", "Product - Aggregate")]
    public void InstantiateErrorWhenNameIsGreaterThan255Characters()
    {
        var nameInvalid = String.Join(null,Enumerable.Range(1, 256).Select(_ => "a").ToArray());
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = -1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(nameInvalid!, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var expection = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Name should be less or equals 255 caracters long", expection.Message);
    }

    [Fact(DisplayName = nameof(InstantiateErrorWhenDescriptionIsGreaterThan255Characters))]
    [Trait("Domain", "Product - Aggregate")]
    public void InstantiateErrorWhenDescriptionIsGreaterThan255Characters()
    {
        var descriptionInvalid = String.Join(null,Enumerable.Range(1, 256).Select(_ => "a").ToArray());
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = -1,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        Action action =
            () => new DomainContext.ProductContext(validData.Name, descriptionInvalid, validData.Quantity, validData.Price, validData.LinkPhoto);

        var expection = Assert.Throws<EntityValidationException>(action);
        Assert.Equal("Description should be less or equals 255 caracters long", expection.Message);
    }

    [Fact(DisplayName = nameof(Update))]
    [Trait("Domain", "Product - Aggregate")]
    public void Update()
    {
        var validData = new
        {
            Name = "Test",
            Description = "Test",
            Quantity = 2,
            Price = 10_87,
            LinkPhoto = "link_to_photo"
        };

        var product = new DomainContext.ProductContext(validData.Name, validData.Description, validData.Quantity, validData.Price, validData.LinkPhoto);

        var updatePoduct = new
        {
            Name = "Test updated",
            Description = "Test updated",
            Quantity = 12,
            Price = 23_99,
            LinkPhoto = "link_to_photo_updated"
        };

        product.Update(updatePoduct.Name, updatePoduct.Description,updatePoduct.Quantity,updatePoduct.Price,updatePoduct.LinkPhoto);

        Assert.Equal(updatePoduct.Name, product.Name);
        Assert.Equal(updatePoduct.Description, product.Description);
        Assert.Equal(updatePoduct.Quantity, product.Quantity);
        Assert.Equal(updatePoduct.Price, product.Price);
        Assert.Equal(updatePoduct.LinkPhoto, product.LinkPhoto);
    }
}
