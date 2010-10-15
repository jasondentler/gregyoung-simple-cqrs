using System;
using System.Collections.Generic;
using SimpleCQRS.Example.ReadModel.Dtos;

namespace SimpleCQRS.Example.ReadModel
{
    public class MemoryReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return MemoryReadDatabase.list;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return MemoryReadDatabase.details[id];
        }
    }
}