using SimpleCQRS.Example.Events;
using SimpleCQRS.Example.ReadModel.Dtos;

namespace SimpleCQRS.Example.ReadModel.Handlers
{
    public class InventoryListView : 
        IHandles<InventoryItemCreated>, 
        IHandles<InventoryItemRenamed>, 
        IHandles<InventoryItemDeactivated>
    {
        public void Handle(InventoryItemCreated message)
        {
            MemoryReadDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
        }

        public void Handle(InventoryItemRenamed message)
        {
            var item = MemoryReadDatabase.list.Find(x => x.Id == message.Id);
            item.Name = message.NewName;
        }

        public void Handle(InventoryItemDeactivated message)
        {
            MemoryReadDatabase.list.RemoveAll(x => x.Id == message.Id);
        }
    }
}