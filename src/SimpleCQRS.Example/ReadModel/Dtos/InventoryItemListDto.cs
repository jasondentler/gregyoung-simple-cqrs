using System;

namespace SimpleCQRS.Example.ReadModel.Dtos
{
    public class InventoryItemListDto
    {
        public Guid Id;
        public string Name;

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}