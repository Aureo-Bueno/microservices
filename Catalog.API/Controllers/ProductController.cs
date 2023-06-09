﻿using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducRepository _producRepository;
        public ProductController(IProducRepository producRepository)
        {
            _producRepository = producRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Product> result = await _producRepository.GetProducts();
            return Ok(result);
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> Get([FromBody] Guid id)
        {
            Product result = await _producRepository.GetProduct(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Product product)
        {
            await _producRepository.CreateProduct(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            await _producRepository.UpdateProduct(product);
            return Ok();
        }

        [HttpPost("{category}")]
        public async Task<IActionResult> SearchNameCategory([FromBody] string category)
        {
            IEnumerable<Product> result = await _producRepository.GetProductByCategory(category);

            if (result is null)
                return NotFound(category);

            return Ok(result);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> SearchName([FromBody] string name)
        {
            IEnumerable<Product> result = await _producRepository.GetProductsByName(name);

            if (result is null)
                return NotFound(name);

            return Ok(result);
        }
    }
}
