using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRents.Application.Interfaces
{
    public interface IEmailSender
    {
        public void Send(SendEmailDto dto);
    }

    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
