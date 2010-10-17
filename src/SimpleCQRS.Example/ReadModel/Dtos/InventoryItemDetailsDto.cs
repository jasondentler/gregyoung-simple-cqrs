using System;
using SimpleCQRS.ReadModel;

namespace SimpleCQRS.Example.ReadModel.Dtos
{
    public class InventoryItemDetailsDto : IDto 
    {
		public Guid Id { get; set; }
        public string Name;
        public int CurrentCount;
        public int Version;

        public InventoryItemDetailsDto(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }

		private InventoryItemDetailsDto()
		{
		}

    }
}
