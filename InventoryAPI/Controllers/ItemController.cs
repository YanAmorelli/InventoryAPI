using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Data.ItemRepo;
using InventoryAPI.Models;

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

        [HttpGet("GetAllItems/{inventoryId}")]
        public async Task<IActionResult> GetAllItems(int inventoryId)
        {
            try
            {
                return Ok(await _itemRepository.GetItemsFromInventory(inventoryId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItemById/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                return Ok(await _itemRepository.GetItemFromInventoryById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> CreateItem(Item model)
        {
            try
            {
                _itemRepository.Add(model);
                if(await _itemRepository.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }

            return BadRequest();
        }

        [HttpPut("EditItem/{id}")]
        public async Task<IActionResult> EditItem(Item model, int id)
        {
            try
            {
                var item = _itemRepository.GetItemFromInventoryById(id);
                if (item == null) return NotFound("Item not found");
                
                _itemRepository.Update(model);
                if (await _itemRepository.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }
    }
}
