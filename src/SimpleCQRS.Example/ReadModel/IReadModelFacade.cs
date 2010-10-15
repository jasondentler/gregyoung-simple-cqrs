using System;
using System.Collections.Generic;
using SimpleCQRS.Example.ReadModel.Dtos;

namespace SimpleCQRS.Example.ReadModel
{
    public interface IReadModelFacade
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();
        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
    }
}