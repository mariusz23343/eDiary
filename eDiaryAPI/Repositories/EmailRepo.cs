using eDiaryAPI.Models.DbModels;
using eDiaryAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace eDiaryAPI.Repositories
{
    public class EmailRepo : IEmailRepo
    {
        private readonly ApplicationDbContext _context;

        public EmailRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Email> SendEmail(String messageText, String messageSubject, EmailDTO emailDTO)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(emailDTO.TeacherName + " " + emailDTO.TeacherSurname,emailDTO.TeacherEmail);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Rodzic " + emailDTO.Name + " " +emailDTO.Surname,emailDTO.EmailParent);
            message.To.Add(to);

            message.Subject = messageSubject;

            BodyBuilder bodyBuilder = new BodyBuilder(); 
            bodyBuilder.TextBody = messageText;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate(emailDTO.TeacherEmail, emailDTO.Password);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return null;
        }

        public async Task<IList <Student>> ViewEmailList(EmailDTO emailDTO)
        {
            var mailList = await _context.Students.ToListAsync();

            return mailList;
        }
    }
}
