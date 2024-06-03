using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using api.Data;
using api.Mappers;
using Microsoft.VisualBasic;
using api.Dtos.Stock;
using api.Interfaces;

namespace api.Controllers;


[Route("api/stock")]
[ApiController]
public class StockController: ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepo;

    public StockController(ApplicationDbContext context, IStockRepository stockRepo)
    {
        _context = context;
        _stockRepo = stockRepo;
    }


    [HttpGet("getStocks")]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await _stockRepo.GetAllAsync();
        var stockDto = stocks.Select(item => item.ToStockDto());

        return Ok(stockDto);
    }


    [HttpGet("getStockById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _stockRepo.GetByIdAsync(id);
        if(stock == null) return NotFound();

        return Ok(stock);
    }


    [HttpPost("createStock")]
    public async Task<IActionResult> CreateStock([FromBody] CrateStockRquestDto createDto)
    {
        var stockModel = createDto.ToStockCreateDto();

        await _stockRepo.CreateAsync(stockModel);
        
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id}, stockModel.ToStockDto());
    }


    [HttpPut("updateStock/{id}")]
    public async Task<IActionResult> UpdateStock([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
        if(stockModel == null) return NotFound();

        return Ok(stockModel.ToStockDto());
    }


    [HttpDelete("deleteStock/{id}")]
    public async Task<IActionResult> DeleteStock([FromRoute] int id)
    {
        var stockModel = await _stockRepo.DeleteAsync(id);
        if(stockModel == null) return NotFound();

        return NoContent();
    }


    
    [HttpPost("getdata")]
    public  string Get()
    {
        // var search_text = new OracleParameter("p_search_text", dto.search_text);
        // var page = new OracleParameter("p_page", dto.page);
        // var per_page = new OracleParameter("p_per_page", dto.per_page);
        // var start_date = new OracleParameter("p_start_date", dto.start_date);
        // var end_date = new OracleParameter("p_end_date", dto.end_date);


        // var json = JsonConvert.SerializeObject(dto);

        // Console.WriteLine(json);
        


        // var cursor = new OracleParameter
        // {
        //     ParameterName = "p_cursor",
        //     OracleDbType = OracleDbType.RefCursor,
        //     Direction = System.Data.ParameterDirection.Output
        // };

        // var emps = await _dataContext.Emps
        //     .FromSqlRaw("BEGIN store_sel_emp_pagination(:p_cursor, :p_search_text, :p_page, :p_per_page, :p_start_date, :p_end_date); END;",
        //                 cursor, search_text, page, per_page, start_date, end_date)
        //     .ToListAsync();

        return "hello";
    }

}