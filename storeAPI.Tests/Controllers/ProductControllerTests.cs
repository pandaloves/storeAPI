using AutoMapper;
using Moq;
using storeAPI.Controllers;
using storeAPI.DTOs;
using storeAPI.Interfaces;
using storeAPI.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ProductControllerTests
{
    private readonly Mock<IProductRepository> _mockProductRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProductController _productController;

    public ProductControllerTests()
    {
        _mockProductRepo = new Mock<IProductRepository>();
        _mockMapper = new Mock<IMapper>();
        _productController = new ProductController(_mockProductRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetProducts_ReturnsOkResult_WithProductDTOs()
    {
        // Arrange
        var products = new List<Product> { new Product { Id = 1, Name = "Test Product" } };
        var productDTOs = new List<ProductDTO> { new ProductDTO { Id = 1, Name = "Test Product" } };

        _mockProductRepo.Setup(repo => repo.GetProducts()).ReturnsAsync(products);
        _mockMapper.Setup(mapper => mapper.Map<List<ProductDTO>>(products)).Returns(productDTOs);

        // Act
        var result = await _productController.GetProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnProducts = Assert.IsType<List<ProductDTO>>(okResult.Value);
        Assert.Single(returnProducts);
    }

    [Fact]
    public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        int productId = 1;
        _mockProductRepo.Setup(repo => repo.GetProduct(productId)).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.GetProduct(productId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AddProduct_ReturnsCreatedAtAction_WithProductDTO()
    {
        // Arrange
        var productDTO = new ProductDTO { Id = 1, Name = "New Product" };
        var product = new Product { Id = 1, Name = "New Product" };
        var files = new List<IFormFile>();

        _mockMapper.Setup(mapper => mapper.Map<Product>(productDTO)).Returns(product);
        _mockProductRepo.Setup(repo => repo.AddProduct(product, files)).ReturnsAsync(product);
        _mockMapper.Setup(mapper => mapper.Map<ProductDTO>(product)).Returns(productDTO);

        // Act
        var result = await _productController.AddProduct(productDTO, files);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnProductDTO = Assert.IsType<ProductDTO>(createdAtActionResult.Value);
        Assert.Equal(productDTO.Id, returnProductDTO.Id);
    }

    [Fact]
    public async Task UpdateProduct_ReturnsOkResult_WithUpdatedProductDTO()
    {
        // Arrange
        int productId = 1;
        var productDTO = new ProductDTO { Id = productId, Name = "Updated Product" };
        var product = new Product { Id = productId, Name = "Updated Product" };
        var files = new List<IFormFile>();

        _mockMapper.Setup(mapper => mapper.Map<Product>(productDTO)).Returns(product);
        _mockProductRepo.Setup(repo => repo.UpdateProduct(productId, product, files)).ReturnsAsync(product);
        _mockMapper.Setup(mapper => mapper.Map<ProductDTO>(product)).Returns(productDTO);

        // Act
        var result = await _productController.UpdateProduct(productId, productDTO, files);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnProductDTO = Assert.IsType<ProductDTO>(okResult.Value);
        Assert.Equal(productDTO.Id, returnProductDTO.Id);
        Assert.Equal(productDTO.Name, returnProductDTO.Name);
    }

    [Fact]
    public async Task UpdateProduct_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        int productId = 1;
        var productDTO = new ProductDTO { Id = productId, Name = "Nonexistent Product" };
        var product = new Product { Id = productId, Name = "Nonexistent Product" };
        var files = new List<IFormFile>();

        _mockMapper.Setup(mapper => mapper.Map<Product>(productDTO)).Returns(product);
        _mockProductRepo.Setup(repo => repo.UpdateProduct(productId, product, files)).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.UpdateProduct(productId, productDTO, files);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteProduct_ReturnsOkResult_WhenProductIsDeleted()
    {
        // Arrange
        int productId = 1;
        var product = new Product { Id = productId, Name = "Test Product" };

        _mockProductRepo.Setup(repo => repo.DeleteProduct(productId)).ReturnsAsync(product);

        // Act
        var result = await _productController.DeleteProduct(productId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnMessage = okResult.Value as dynamic;
        Assert.Equal("Deleted the product successfully!", returnMessage.message);
    }

    [Fact]
    public async Task DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        int productId = 1;

        _mockProductRepo.Setup(repo => repo.DeleteProduct(productId)).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.DeleteProduct(productId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

}
