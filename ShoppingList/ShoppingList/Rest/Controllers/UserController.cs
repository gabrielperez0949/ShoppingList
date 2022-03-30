using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShoppingList.Data.Entity;
using ShoppingList.Exceptions;
using ShoppingList.Rest.ViewModel;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private IUserService Service { get; }

    private IMapper Mapper { get; }

    public UserController(ILogger<UserController> logger, IUserService service, IMapper mapper)
    {
        _logger = logger;
        Service = service;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<IStatusCodeActionResult> ListAsync()
    {
        ICollection<UserViewModel> viewModels;
        try
        {
            var entities = await Service.ListAsync();
            viewModels = entities.Select(e => Mapper.MapToView<UserViewModel, User>(e)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable find users due to unknown server error", ex);
            return BadRequest();
        }

        return new JsonResult(viewModels);
    }

    [HttpGet("{id}")]
    public async Task<IStatusCodeActionResult> GetbyIdAsync([FromRoute] string id)
    {
        UserViewModel viewModel;
        try
        {
            viewModel = Mapper.MapToView<UserViewModel, User>(await Service.GetByIdAsync(id));
        }
        catch (ItemNotFoundException)
        {
            _logger.LogDebug($"Cannot find user with id {id}, because they do not exist.");
            return NotFound();

        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable find user with id {id} due to unknown server error", ex);
            return BadRequest();
        }

        return new JsonResult(viewModel);
    }
}