using Sistema.Vendas.Domain.Exceptions;

namespace Sistema.Vendas.Domain.Entity.Product;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public string LinkPhoto { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Product(string name, string description, int quantity, decimal price, string linkPhoto)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Quantity = quantity;
        Price = price;
        LinkPhoto = linkPhoto;
        CreatedAt = DateTime.Now;

        validate();
    }

    public void Update(string name, string description, int quantity, decimal price, string linkPhoto)
    {
        Name = name! ?? Name;
        Description = description! ?? Description;
        Quantity = (quantity != Quantity) ? quantity : Quantity;
        Price = (price != Price) ? price : Price;
        LinkPhoto = linkPhoto! ?? LinkPhoto;

        validate();
    }
    
    private void validate()
    {
        if (String.IsNullOrWhiteSpace(Name))
            throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

        if (Name.Length < 3)
            throw new EntityValidationException($"{nameof(Name)} should be at leats 3 caracters long");

        if (Name.Length > 255)
            throw new EntityValidationException($"{nameof(Name)} should be less or equals 255 caracters long");

        if (String.IsNullOrWhiteSpace(Description))
            throw new EntityValidationException($"{nameof(Description)} should not be empty or null");

        if (Description.Length > 255)
            throw new EntityValidationException($"{nameof(Description)} should be less or equals 255 caracters long");

        if (Quantity < 0)
            throw new EntityValidationException($"{nameof(Quantity)} should not be less to 0");

        if (Price < 0_00)
            throw new EntityValidationException($"{nameof(Price)} should not be less to 0.00");
    }
}
