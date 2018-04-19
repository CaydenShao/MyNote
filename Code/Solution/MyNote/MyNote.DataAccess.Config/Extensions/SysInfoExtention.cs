using MyNote.Contracts.DataContracts.Config;
using MyNote.DataAccess.Config.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccess.Config.Extensions
{
    public static class SysInfoExtention
    {
        public static SysInfo ToModel(this SysInfoEntity entity)
        {
            return new SysInfo()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Detail = entity.Detail
            };
        }

        public static SysInfoEntity ToEntity(this SysInfo model)
        {
            return new SysInfoEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Detail = model.Detail
            };
        }
    }
}
