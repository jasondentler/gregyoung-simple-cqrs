using System;
using SimpleCQRS.ReadModel;

namespace SimpleCQRS.Example.ReadModel.Dtos
{
    public class InventoryItemListDto : IDto 
    {
		public Guid Id { get; set; }
        public string Name;

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

		private InventoryItemListDto()
		{
		}
    }
}