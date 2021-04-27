using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class PhotographsWithLocationsSpecification : BaseSpecification<Photograph>
    {
        public PhotographsWithLocationsSpecification(string sort)
        {
            AddInclude(p => p.PhotographLocation);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public PhotographsWithLocationsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.PhotographLocation);
        }
    }
}