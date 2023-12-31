﻿using CQRSMediatr.Commands;
using CQRSMediatr.Model;
using CQRSMediatr.Notifications;
using CQRSMediatr.PostgresEFCore;
using CQRSMediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CQRSMediatr.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender,IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }

        /// <summary>
        /// Add or Edit Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SaveProduct(ProductModel product)
        {
            var returnedProduct = await _sender.Send(new SaveProductCommand(product));

            await _publisher.Publish(new ProductAddedNotification(returnedProduct));
            return CreatedAtRoute("GetProductById", new { id = returnedProduct.ProductId }, returnedProduct);
        }
    }
}
