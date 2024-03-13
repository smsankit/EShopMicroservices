﻿using BuildingBlocks.CQRS;
using Catalog.API.Model;
using MediatR;
using System.Linq.Expressions;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Create Product entiey from command obj

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        //TODO: Save to DB

        //Return Result
        return new CreateProductResult(Guid.NewGuid());
    }
}

