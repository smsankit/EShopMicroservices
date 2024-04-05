
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryRequest();
public record GetProductsByCategoryResponse(IEnumerable<Product> Products);



public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",async  (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(category));
            var response = result.Adapt<GetProductsByCategoryResponse>();
            return Results.Ok(response);
        })
            .WithName("GetProductById")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By ID");
    }
}
