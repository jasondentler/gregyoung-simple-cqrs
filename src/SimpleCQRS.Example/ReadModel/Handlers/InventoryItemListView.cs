using SimpleCQRS.Example.Events;
using SimpleCQRS.Example.ReadModel.Dtos;
using SimpleCQRS.ReadModel;

namespace SimpleCQRS.Example.ReadModel.Handlers
{
    public class InventoryItemListView : 
		IView<InventoryItemListDto>, 
        IHandles<InventoryItemCreated>, 
        IHandles<InventoryItemRenamed>, 
        IHandles<InventoryItemDeactivated>
    {
    	private readonly IHandlerHelper<InventoryItemListDto> _handlerHelper;

    	public InventoryItemListView(
			IHandlerHelper<InventoryItemListDto> handlerHelper)
		{
			_handlerHelper = handlerHelper;
		}

    	public void Handle(InventoryItemCreated message)
    	{
    		_handlerHelper.InsertDto(
    			new InventoryItemListDto(message.Id, message.Name));
    	}

        public void Handle(InventoryItemRenamed message)
        {
        	_handlerHelper.UpdateDto(
        		message.Id,
        		dto => dto.Name = message.NewName);
        }

        public void Handle(InventoryItemDeactivated message)
        {
        	_handlerHelper.DeleteDto(message.Id);
        }

    }
}