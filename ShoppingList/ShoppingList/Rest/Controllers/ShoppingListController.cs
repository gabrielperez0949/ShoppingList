using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShoppingList.Data.Entity;
using ShoppingList.Exceptions;
using ShoppingList.Rest.ViewModel;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ILogger<ShoppingListController> _logger;

    private IListItemService ListService { get; }

    private IProductService ProductService { get; }

    private IUserService UserService { get; }

    private IMapper Mapper { get; }

    public ShoppingListController(ILogger<ShoppingListController> logger, IListItemService listService, IProductService productService, IUserService userService, IMapper mapper)
    {
        _logger = logger;
        ListService = listService;
        ProductService = productService;
        UserService = userService;
        Mapper = mapper;
    }

    [HttpGet("{userId}")]
    public  async Task<IStatusCodeActionResult> GetByIdAsync([FromRoute] string userId)
    {
        ICollection <ListItemViewModel> listItems;
        try
        {
            var items = await ListService.ListAsync(userId);
            listItems = items.Select(i => Mapper.MapToView<ListItemViewModel, ListItem>(i)).ToList();
        } catch (ItemNotFoundException)
        {
            _logger.LogDebug($"Cannot show shopping list for user with id {userId}, because list does not exist.");
            return NotFound();
        } catch (Exception ex)
        {
            _logger.LogDebug($"Cannot show shopping list for user with id {userId}, because unknown server error has occurred.", ex);
            return BadRequest();
        }

        return new JsonResult(listItems);
    }

    [HttpGet("item/{id}")]
    public async Task<IStatusCodeActionResult> GetListItemByIdAsync([FromRoute] string id)
    {
        ListItemViewModel item;
        try
        {
            item = Mapper.MapToView<ListItemViewModel, ListItem>(await ListService.GetByIdAsync(id));
        }
        catch (ItemNotFoundException)
        {
            _logger.LogDebug($"Cannot get list id with id {id}, because list does not exist.");
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Cannot get list item with id {id}, because unknown server error has occurred.", ex);
            return BadRequest();
        }

        return new JsonResult(item);
    }

    [HttpDelete("item/{id}")]
    public async Task<IStatusCodeActionResult> DeleteAsync([FromRoute] string id)
    {
        try
        {
            await ListService.DeleteAsync(id);
        }
        catch (ItemNotFoundException)
        {
            _logger.LogDebug($"Cannot delete shopping list item with id {id}, because item does not exist.");
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Cannot delete shopping list item with id {id}, because unknown server error has occurred.", ex);
            return BadRequest();
        }

        return Ok();
    }

    [HttpPost("{userId}/product/{productId}")]
    public async Task<IStatusCodeActionResult> AddProductToListAsync([FromRoute] string userId, [FromRoute] string productId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ListItem listItem;
        Guid id;

        try
        {
            id = Guid.NewGuid();
            listItem = new ListItem
            {
                Id = id.ToString(),
                ProductId = productId,
                UserId = userId
            };
            await ListService.CreateAsync(listItem);
        }
        catch (ItemNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Cannot add product with id {productId} to the shopping list, because unknown server error has occurred.", ex);
            return BadRequest();
        }

        return Ok();
    }

    private async Task<User> GetUserById(string userId)
    {
        User user;
        try
        {
            user = await UserService.GetByIdAsync(userId);
        }
        catch (ItemNotFoundException ex)
        {
            _logger.LogDebug($"Cannot find user with id {userId}, because they do not exist.", ex);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable find user with id {userId} due to unknown server error", ex);
            throw;
        }

        return user;
    }

    private async Task<Product> GetProductById(string id)
    {
        Product product;
        try
        {
            product = await ProductService.GetByIdAsync(id);
        }
        catch (ItemNotFoundException ex)
        {
            _logger.LogDebug($"Cannot find product with id {id}, because it does not exist.", ex);
            throw;

        }
        catch (Exception ex)
        {
            _logger.LogDebug($"Unable to find product with id {id} due to unknown server error", ex);
            throw;
        }

        return product;
    }
}
