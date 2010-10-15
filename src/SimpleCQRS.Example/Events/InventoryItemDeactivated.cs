using System;
using SimpleCQRS.Eventing;

namespace SimpleCQRS.Example.Events
{

    public class InventoryItemDeactivated : Event
    {
        public readonly Guid Id;

        public InventoryItemDeactivated(Guid id)
        {
            Id = id;
        }
    }
}
