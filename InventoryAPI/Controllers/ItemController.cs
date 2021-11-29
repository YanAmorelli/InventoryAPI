using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Data.ItemRepo;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("GetAllItems/inventoryId")]
        public async Task<IActionResult> GetAllItems(int inventoryId)
        {
            try
            {
                var result = await _itemRepository.GetItemsFromInventory(inventoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItemById/id")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var result = await _itemRepository.GetItemFromInventoryById(id);
            return Ok(result);
        }
    }
}
