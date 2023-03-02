using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Project> Projects { get; }
    }
}
