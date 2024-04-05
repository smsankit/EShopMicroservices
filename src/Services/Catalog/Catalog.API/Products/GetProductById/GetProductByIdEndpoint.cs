
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById;

public record GetProductsByIdRequest();
public record GetProductsByIdResponse(Product Product);



public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}",async  (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProductsByIdResponse>();
            return Results.Ok(response);
        })
            .WithName("GetProductByCategory")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
    }
}
