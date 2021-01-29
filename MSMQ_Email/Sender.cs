// -----------------------------------------------------------------------------------------------------
// <copyright file="Sender.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace MSMQ_Email
{
    using Experimental.System.Messaging;
    public class Sender
    {
        /// <summary>
        /// adding massage in MSMQ
        /// </summary>
        public void MailSender()
        {
            var forgoturl = "Reset password link for FundooNotes App: https://localhost:44379/swagger/index.html";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }
            Message message = new Message
            {
                Formatter = new BinaryMessageFormatter(),
                Body = forgoturl
            };
            msmqQueue.Label = "E-mails";
            msmqQueue.Send(message);
        }
    }
}
