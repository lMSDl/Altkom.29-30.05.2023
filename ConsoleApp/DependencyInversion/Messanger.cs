using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DependencyInversion
{
    internal class Messanger
    {
       /* public SmsSender SmsSender { get; set; }
        public MmsSender MmsSender { get; set; }
        public MailSender MailSender { get; set; }*/

        //wstrzykiwanie przez właściwość
        public IEnumerable<IMessage> Messages { get; set; }

        //wstrzykiwanie przez konstruktor
        public Messanger(IEnumerable<IMessage> messages)
        {
            Messages = messages;
        }

        //wstrzykiwanie przez metodę
        public void Send(IEnumerable<IMessage> messages)
        {
            Messages = messages;
            Send();
        }


        public void Send()
        {
            foreach (var message in Messages)
            {
                message.Send();
            }

            /*SmsSender?.SendSms();
            MmsSender?.SendMms();
            MailSender?.SendMail();*/
        }
    }
}
