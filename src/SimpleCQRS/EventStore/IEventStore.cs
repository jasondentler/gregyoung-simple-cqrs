using System;
using System.Collections.Generic;
using SimpleCQRS.Eventing;

namespace SimpleCQRS.EventStore
{
  public interface IEventStore
  {
    void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
    List<Event> GetEventsForAggregate(Guid aggregateId);
  }
}