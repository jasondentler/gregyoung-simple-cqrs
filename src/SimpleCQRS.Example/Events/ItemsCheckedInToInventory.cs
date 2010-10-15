using System;
using SimpleCQRS.Eventing;

namespace SimpleCQRS.Example.Events
{
    public class ItemsCheckedInToInventory : Event
    {
        public Guid Id;
        public readonly int Count;

        public ItemsCheckedInToInventory(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}