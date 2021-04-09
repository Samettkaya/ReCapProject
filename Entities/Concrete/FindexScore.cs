using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FindexScore : IEntity
    {
        public int FindexScoreId { get; set; }
        public int CustomerId { get; set; }
        public int Score { get; set; }
    }
}