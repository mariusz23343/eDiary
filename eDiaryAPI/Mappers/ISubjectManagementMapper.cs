﻿using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Mappers
{
    public interface ISubjectManagementMapper
    {
        public SubjectDTO addSubject(Subject subject);
    }
}
