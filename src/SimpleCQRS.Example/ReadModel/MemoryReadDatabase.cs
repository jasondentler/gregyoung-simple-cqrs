using System;
using System.Collections.Generic;
using SimpleCQRS.Example.ReadModel.Dtos;

namespace SimpleCQRS.Example.ReadModel
{
    public static class MemoryReadDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> details = new Dictionary<Guid, InventoryItemDetailsDto>();
        public static List<InventoryItemListDto> list = new List<InventoryItemListDto>();
    }
}