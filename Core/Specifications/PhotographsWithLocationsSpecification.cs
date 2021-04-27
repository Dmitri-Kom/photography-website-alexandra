using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class PhotographsWithLocationsSpecification : BaseSpecification<Photograph>
    {
        public PhotographsWithLocationsSpecification(PhotographSpecParams photographSpecParams) 
                : base(x =>
                    (string.IsNullOrEmpty(photographSpecParams.Search) || x.Name.ToLower().Contains(photographSpecParams.Search)) &&
                    (!photographSpecParams.PhotographLocationId.HasValue || x.PhotographLocationId == photographSpecParams.PhotographLocationId)
                )
        {
            AddInclude(p => p.PhotographLocation);
            AddOrderBy(x => x.Name);
            ApplyPaging(photographSpecParams.PageSize * (photographSpecParams.PageIndex - 1), photographSpecParams.PageSize); 

            if (!string.IsNullOrEmpty(photographSpecParams.Sort))
            {
                switch (photographSpecParams.Sort)
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