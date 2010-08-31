using System;

namespace SimpleCQRS
{
    public class RemoveItemsFromInventory : Command
    {
        public readonly int Count;
        public readonly int OriginalVersion;
        public Guid InventoryItemId;

        public RemoveItemsFromInventory(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}