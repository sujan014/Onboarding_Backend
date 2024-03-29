﻿using Microsoft.AspNetCore.Mvc;
using Task1_API.Services;
using Task1_API.ViewModels.Sales;
using Task1_API.ViewModels.Store;

namespace Task1_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<SalesViewModel>))]
        public async Task<IActionResult> GetSales()
        {
            try
            {
                var sales = await _salesService.GetSales();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(SalesViewModel))]
        public async Task<IActionResult> GetSales(int id)
        {
            try
            {
                var sales = await _salesService.GetSalesById(id);
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("createSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<SalesViewModel>))]
        public async Task<IActionResult> CreateSales([FromBody] CreateSalesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sales = await _salesService.CreateSales(request);
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("updateSales/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<SalesViewModel>))]
        public async Task<IActionResult> UpdateSales(int? id, [FromBody] UpdateSalesRequest request)
        {
            if (id == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sales = await _salesService.UpdateSales((int)id, request);
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("deleteSales/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSales(int id)
        {
            try
            {
                await _salesService.DeleteSales(id);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
