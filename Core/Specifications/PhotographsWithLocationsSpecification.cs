using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class PhotographsWithLocationsSpecification : BaseSpecification<Photograph>
    {
        public PhotographsWithLocationsSpecification()
        {
            AddInclude(p => p.PhotographLocation);
        }

        public PhotographsWithLocationsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.PhotographLocation);
        }
    }
}