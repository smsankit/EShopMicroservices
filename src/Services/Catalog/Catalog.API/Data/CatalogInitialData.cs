using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreConfiguratedProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreConfiguratedProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("018e60b1-4a8e-4eb2-a577-0812e1c04434"),
            Name = "IPhone X",
            Description = "Description",
            ImageFile = "iphone.png",
            Price = 45000,
            Category = new List<string>{"Smart Phone"}
        },

        new Product()
        {
            Id = new Guid("018e60b1-4a8e-4eb2-a577-0812e1c04445"),
            Name = "Samsung M31",
            Description = "Description",
            ImageFile = "samsung.png",
            Price = 15000,
            Category = new List<string>{"Smart Phone"}
        }

    };
}
