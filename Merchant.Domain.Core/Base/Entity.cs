using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Domain.Core.Base
{
    public abstract class Entity
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        private List<INotification> _events { get; set; }
        public IReadOnlyCollection<INotification> Events => _events?.AsReadOnly();
        public void AddEvent(INotification @event)
        {
            _events ??= new List<INotification>();
            _events.Add(@event);
        }
        public void RemoveEvent(INotification @event) => _events.Remove(@event);
        public void ClearEvents() => _events.Clear();

    }
}
