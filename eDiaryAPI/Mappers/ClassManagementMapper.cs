using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public class ClassManagementMapper : IClassManagementMapper
    {
   
        public ClassDTO MappClassAdd(SchoolClass schoolClass)
        {
            var classDTO = new ClassDTO();

            classDTO.ClassName = schoolClass.ClassName;
            classDTO.SchoolYear = schoolClass.SchoolYear;

            return classDTO;
        }
    }
}
