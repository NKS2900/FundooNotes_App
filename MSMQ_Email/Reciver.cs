// -----------------------------------------------------------------------------------------------------
// <copyright file="Reciver.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace MSMQ_Email
{
    using Experimental.System.Messaging;
    public class Reciver
    {
        /// <summary>
        /// Reciving Massage from MSMQ
        /// </summary>
        /// <returns></returns>
        public string MailReciver()
        {
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToSend = recieving.Body.ToString();
            return linkToSend;
        }
    }
}
