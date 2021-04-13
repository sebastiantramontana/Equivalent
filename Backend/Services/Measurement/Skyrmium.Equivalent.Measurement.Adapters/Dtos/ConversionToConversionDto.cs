using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class ConversionToConversionDto : OwnedEntityToDtoBase<Conversion, ConversionDto>
   {
      protected override void ContinueDtoToEntity(IMappingExpression<ConversionDto, Conversion> mappingExpression)
      {
      }

      protected override void ContinueEntityToDto(IMappingExpression<Conversion, ConversionDto> mappingExpression)
      {
      }
   }
}
