using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Task1_API.Services;
using Task1_API.ViewModels.Products;
using Task1_API.ViewModels.Store;

namespace Task1_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        //HTTP GET -> localhost:5555/api/Store/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<StoreViewModel>))]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var stores = await _storeService.GetStores();
                return Ok(stores);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // HTTP GET -> localhost:5555/api/Store/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(StoreViewModel))]
        public async Task<IActionResult> GetStore(int id)
        {
            try
            {
                var store = await _storeService.GetStoreById(id);
                return Ok(store);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // HTTP Post -> localhost:5555/api/Store/createStore
        [HttpPost("createStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(StoreViewModel))]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var storeRequest = await _storeService.CreateStore(request);
                return Ok(storeRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // HTTP Post -> localhost:5555/api/Store/updateStore/id
        [HttpPut("updateStore/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(StoreViewModel))]
        public async Task<IActionResult> UpdateStore(int? id, [FromBody] UpdateStoreRequest request)
        {
            if (id == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var storeRequest = await _storeService.UpdateStore((int)id, request);
                return Ok(storeRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // HTTP POST -> localhost:5555/api/Store/deleteStore/id
        [HttpDelete("deleteStore/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStore(int id)
        {
            try
            {
                await _storeService.DeleteStore(id);
                return Ok();
            }
            catch (Exception ex)
            {                
                return NotFound(ex.Message);
            }
        }
    }
}
