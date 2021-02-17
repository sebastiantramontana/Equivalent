using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class ConversionToConversionDto : OwnedEntityToOwnedDtoBase<Conversion, ConversionDto>
   {
      protected override void ContinueWithOwnedDto(IMappingExpression<ConversionDto, Conversion> mappingExpression)
      {
         mappingExpression
            .ForMember(e => e.Name, c => c.MapFrom(d => d.Name))
            .ForMember(e => e.Equivalences, c => c.MapFrom(d => d.Equivalences));
      }

      protected override void ContinueWithOwnedEntity(IMappingExpression<Conversion, ConversionDto> mappingExpression)
      {
         mappingExpression
            .ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
            .ForMember(d => d.Equivalences, c => c.MapFrom(e => e.Equivalences));
      }
   }
}
