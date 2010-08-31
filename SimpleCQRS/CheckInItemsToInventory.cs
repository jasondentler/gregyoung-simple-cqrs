using System;

namespace SimpleCQRS
{
    public class CheckInItemsToInventory : Command
    {
        public readonly int Count;
        public readonly int OriginalVersion;
        public Guid InventoryItemId;

        public CheckInItemsToInventory(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}