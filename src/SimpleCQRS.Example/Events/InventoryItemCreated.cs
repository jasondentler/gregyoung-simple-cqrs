using System;
using SimpleCQRS.Eventing;

namespace SimpleCQRS.Example.Events
{
    public class InventoryItemCreated : Event
    {
        public readonly Guid Id;
        public readonly string Name;
        public InventoryItemCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}