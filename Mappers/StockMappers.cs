using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock model)
    {
        return new StockDto
        {
            Id = model.Id,
            Symbol = model.Symbol,
            CompanyName = model.CompanyName,
            Purchase = model.Purchase,
            LastDiv = model.LastDiv,
            Industry = model.Industry,
            MarketCap = model.MarketCap,
        };
    }

    public static Stock ToStockCreateDto(this CrateStockRquestDto dto)
    {
        return new Stock
        {
            Symbol = dto.Symbol,
            CompanyName = dto.CompanyName,
            Purchase = dto.Purchase,
            LastDiv = dto.LastDiv,
            Industry = dto.Industry,
            MarketCap = dto.MarketCap,
        };
    }
}