using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDiaryAPI.Repositories
{
    public interface IEmailRepo
    {
        public Task<IList <Student>> ViewEmailList(EmailDTO emailDTO);
        public Task<Email> SendEmail(String messageText, String messageSubject, EmailDTO emailDTO);
    }
}
