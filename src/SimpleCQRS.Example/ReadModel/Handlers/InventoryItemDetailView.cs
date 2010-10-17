using SimpleCQRS.Example.Events;
using SimpleCQRS.Example.ReadModel.Dtos;
using SimpleCQRS.ReadModel;

namespace SimpleCQRS.Example.ReadModel.Handlers
{
    public class InventoryItemDetailView : 
		IView<InventoryItemDetailsDto>,
		IHandles<InventoryItemCreated>, 
        IHandles<InventoryItemDeactivated>, 
        IHandles<InventoryItemRenamed>, 
        IHandles<ItemsRemovedFromInventory>, 
        IHandles<ItemsCheckedInToInventory>
    {

    	private readonly IHandlerHelper<InventoryItemDetailsDto> _handlerHelper;

    	public InventoryItemDetailView(
			IHandlerHelper<InventoryItemDetailsDto> handlerHelper)
		{
			_handlerHelper = handlerHelper;
		}

    	public void Handle(InventoryItemCreated message)
    	{
    		_handlerHelper.InsertDto(
    			new InventoryItemDetailsDto(
    				message.Id, message.Name, 0, message.Version));

    	}

        public void Handle(InventoryItemRenamed message)
        {
        	_handlerHelper.UpdateDto(
        		message.Id,
        		dto => dto.Name = message.NewName);
        }

        public void Handle(ItemsRemovedFromInventory message)
        {
        	_handlerHelper.UpdateDto(
        		message.Id,
        		dto => dto.CurrentCount -= message.Count);
        }

        public void Handle(ItemsCheckedInToInventory message)
        {
        	_handlerHelper.UpdateDto(
        		message.Id,
        		dto => dto.CurrentCount += message.Count);
        }

        public void Handle(InventoryItemDeactivated message)
        {
        	_handlerHelper.DeleteDto(message.Id);
        }

    }
}