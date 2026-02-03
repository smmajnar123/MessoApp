using MessoApp.Db.Models;
using MessoApp.DTO.RequestModels;
using MessoApp.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessoApp.Mapper
{
    public static class MessMapper
    {
        public static Mess ToEntity(MessRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new Mess
            {
                AdminId = model.AdminId,
                MessName = model.MessName.Trim(),
                MessAddress = model.MessAddress?.Trim(),
                MessMobile = model.MessMobile?.Trim(),
                MessEmail = model.MessEmail?.Trim(),
                IsActive = model.IsActive
            };
        }

        public static MessResponse ToResponse(Mess entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new MessResponse
            {
                MessId = entity.MessId,
                MessName = entity.MessName,
                MessAddress = entity.MessAddress,
                MessMobile = entity.MessMobile,
                MessEmail = entity.MessEmail,
                IsActive = entity.IsActive
            };
        }

        public static void UpdateEntity(Mess entity, MessRequestModel model)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            entity.AdminId = model.AdminId;
            entity.MessName = model.MessName.Trim();
            entity.MessAddress = model.MessAddress?.Trim();
            entity.MessMobile = model.MessMobile?.Trim();
            entity.MessEmail = model.MessEmail?.Trim();
            entity.IsActive = model.IsActive;
        }

    }
}
