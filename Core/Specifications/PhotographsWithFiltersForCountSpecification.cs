using Core.Entities;

namespace Core.Specifications
{
    public class PhotographsWithFiltersForCountSpecification : BaseSpecification<Photograph>
    {
        public PhotographsWithFiltersForCountSpecification(PhotographSpecParams photographSpecParams)
              : base(x =>
                    (!photographSpecParams.PhotographLocationId.HasValue || x.PhotographLocationId == photographSpecParams.PhotographLocationId)
                 )
        {
            
        }
    }
}