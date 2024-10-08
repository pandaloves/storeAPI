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

public class CategoryControllerTests
{
    private readonly Mock<ICategoryRepository> _mockCategoryRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CategoryController _categoryController;

    public CategoryControllerTests()
    {
        _mockCategoryRepo = new Mock<ICategoryRepository>();
        _mockMapper = new Mock<IMapper>();
        _categoryController = new CategoryController(_mockCategoryRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetCategories_ReturnsOkResult_WithCategoryDTOs()
    {
        var categories = new List<Category> { new Category { Id = 1, Name = "Test Category" } };
        var categoryDTOs = new List<CategoryDTO> { new CategoryDTO { Id = 1, Name = "Test Category" } };

        _mockCategoryRepo.Setup(repo => repo.GetCategories()).ReturnsAsync(categories);
        _mockMapper.Setup(mapper => mapper.Map<List<CategoryDTO>>(categories)).Returns(categoryDTOs);

        var result = await _categoryController.GetCategories();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnCategories = Assert.IsType<List<CategoryDTO>>(okResult.Value);
        Assert.Single(returnCategories);
    }

    [Fact]
    public async Task GetCategory_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        int categoryId = 1;
        _mockCategoryRepo.Setup(repo => repo.GetCategory(categoryId)).ReturnsAsync((Category)null);

        var result = await _categoryController.GetCategory(categoryId);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AddCategory_ReturnsCreatedAtAction_WithCategoryDTO()
    {
        var categoryDTO = new CategoryDTO { Id = 1, Name = "New Category" };
        var category = new Category { Id = 1, Name = "New Category" };

        _mockMapper.Setup(mapper => mapper.Map<Category>(categoryDTO)).Returns(category);
        _mockCategoryRepo.Setup(repo => repo.AddCategory(category)).ReturnsAsync(category);
        _mockMapper.Setup(mapper => mapper.Map<CategoryDTO>(category)).Returns(categoryDTO);

        var result = await _categoryController.AddCategory(categoryDTO);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnCategoryDTO = Assert.IsType<CategoryDTO>(createdAtActionResult.Value);
        Assert.Equal(categoryDTO.Id, returnCategoryDTO.Id);
    }

    [Fact]
    public async Task UpdateCategory_ReturnsOkResult_WithUpdatedCategoryDTO()
    {
        // Arrange
        int categoryId = 1;
        var categoryDTO = new CategoryDTO { Id = categoryId, Name = "Updated Category" };
        var category = new Category { Id = categoryId, Name = "Updated Category" };

        _mockMapper.Setup(mapper => mapper.Map<Category>(categoryDTO)).Returns(category);
        _mockCategoryRepo.Setup(repo => repo.UpdateCategory(categoryId, category)).ReturnsAsync(category);
        _mockMapper.Setup(mapper => mapper.Map<CategoryDTO>(category)).Returns(categoryDTO);

        // Act
        var result = await _categoryController.UpdateCategory(categoryId, categoryDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnCategoryDTO = Assert.IsType<CategoryDTO>(okResult.Value);
        Assert.Equal(categoryDTO.Id, returnCategoryDTO.Id);
        Assert.Equal(categoryDTO.Name, returnCategoryDTO.Name);
    }

    [Fact]
    public async Task UpdateCategory_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        int categoryId = 1;
        var categoryDTO = new CategoryDTO { Id = categoryId, Name = "Nonexistent Category" };
        var category = new Category { Id = categoryId, Name = "Nonexistent Category" };

        _mockMapper.Setup(mapper => mapper.Map<Category>(categoryDTO)).Returns(category);
        _mockCategoryRepo.Setup(repo => repo.UpdateCategory(categoryId, category)).ReturnsAsync((Category)null);

        // Act
        var result = await _categoryController.UpdateCategory(categoryId, categoryDTO);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteCategory_ReturnsOkResult_WhenCategoryIsDeleted()
    {
        // Arrange
        int categoryId = 1;
        var category = new Category { Id = categoryId, Name = "Test Category" };

        _mockCategoryRepo.Setup(repo => repo.DeleteCategory(categoryId)).ReturnsAsync(category);

        // Act
        var result = await _categoryController.DeleteCategory(categoryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnMessage = okResult.Value as dynamic;
        Assert.Equal("Deleted the category successfully!", returnMessage.message);
    }

    [Fact]
    public async Task DeleteCategory_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        int categoryId = 1;

        _mockCategoryRepo.Setup(repo => repo.DeleteCategory(categoryId)).ReturnsAsync((Category)null);

        // Act
        var result = await _categoryController.DeleteCategory(categoryId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

}
