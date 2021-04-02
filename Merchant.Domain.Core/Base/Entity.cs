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
      

    }
}
