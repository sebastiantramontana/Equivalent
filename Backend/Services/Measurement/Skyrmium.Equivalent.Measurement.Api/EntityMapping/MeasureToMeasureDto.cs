﻿using Skyrmium.Api.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Api.EntityMapping
{
   public class MeasureToMeasureDto : OwnedEntityToDtoBase<Measure, MeasureDto>
   {
      public override Measure Map(MeasureDto dto)
      {
         return new Measure(default, dto.DistributedId, dto.OwnedBy, dto.ShortName, dto.FullName);
      }

      protected override MeasureDto ContinueOwnedEntityToDto(Measure entity, MeasureDto dto)
      {
         dto.ShortName = entity.ShortName;
         dto.FullName = entity.FullName;

         return dto;
      }
   }
}