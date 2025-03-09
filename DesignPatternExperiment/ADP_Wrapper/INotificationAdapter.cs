using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExperiment.ADP_Wrapper
{

    public class User 
    {
        public bool AllowEmailNotifications { get; set;}
        public string EmailAddres { get; set;}

    }
    public class Message { }
    public class EmailSettings 
    { 
        public string DefaultFromAddress { get; set;}
    }


    public interface IEmailSender 
    { 
       
       public bool SendEmail(string fromUser, string toUser, string emailBody);
       public bool SendEmail(string fromUser, string[] toUsers, string[] ccUsers, string emailBody);
       public bool SendEmail(string fromUser, string[] toUsers, string[] ccUsers, string[] bccUsers, string emailBody);
       public bool SendEmail(string fromUser, string[] toUsers, string[] ccUsers, string[] bccUsers, string emailBody, bool sendCopyToMe = false);

    }

    public interface INotificationAdapter
    {
        void Notify(User user, Message message);

    }

    public class EmailNotificationAdapter : INotificationAdapter
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailSettings _settings;

        public EmailNotificationAdapter(IEmailSender emailSender,
            EmailSettings settings)
        {
            _emailSender = emailSender;
            _settings = settings;
        }

        public void Notify(User user, Message message)
        {
            if (!user.AllowEmailNotifications) return;

            string fromEmail = _settings.DefaultFromAddress;

            _emailSender.SendEmail(user.EmailAddress, fromEmail, message.Title, message.Details);
        }
    }
}


//--https://deviq.com/design-patterns/adapter-design-pattern
//--https://github.com/dotnet/training-tutorials/blob/master/content/csharp/getting-started/patterns-antipatterns.md
//--https://github.com/ffisk/books/blob/master/microservices-antipatterns-and-pitfalls.pdf