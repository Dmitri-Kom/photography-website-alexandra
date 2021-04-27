using Core.Entities;

namespace Core.Specifications
{
    public class PhotographsWithFiltersForCountSpecification : BaseSpecification<Photograph>
    {
        public PhotographsWithFiltersForCountSpecification(PhotographSpecParams photographSpecParams)
              : base(x =>
                    (string.IsNullOrEmpty(photographSpecParams.Search) || x.Name.ToLower().Contains(photographSpecParams.Search)) &&
                    (!photographSpecParams.PhotographLocationId.HasValue || x.PhotographLocationId == photographSpecParams.PhotographLocationId)
                 )
        {

        }
    }
}