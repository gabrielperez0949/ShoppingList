using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShoppingList.Data.Entity;
using ShoppingList.Exceptions;
using ShoppingList.Rest.ViewModel;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private IProductService Service { get; }

    private IMapper Mapper { get; }

    public ProductController(ILogger<ProductController> logger, IProductService service, IMapper mapper)
    {
        _logger = logger;
        Service = service;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<IStatusCodeActionResult> ListAsync()
    {
        IEnumerable<ProductViewModel> viewModels = new List<ProductViewModel>();
        try
        {
            var products = await Service.ListAsync();
            viewModels = products.Select(p => Mapper.MapToView<ProductViewModel, Product>(p)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable to list products due to unknown server error", ex);
            return BadRequest();
        }

        return new JsonResult(viewModels);
    }

    [HttpGet("{id}")]
    public async Task<IStatusCodeActionResult> GetbyIdAsync([FromRoute] string id)
    {
        ProductViewModel viewModel;
        try
        {
            viewModel = Mapper.MapToView<ProductViewModel, Product> (await Service.GetByIdAsync(id));
        }
        catch (ItemNotFoundException)
        {
            _logger.LogDebug($"Cannot find product with id {id}, because it does not exist.");
            return NotFound();

        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable to find product with id {id} due to unknown server error", ex);
            return BadRequest();
        }

        return new JsonResult(viewModel);
    }
}
