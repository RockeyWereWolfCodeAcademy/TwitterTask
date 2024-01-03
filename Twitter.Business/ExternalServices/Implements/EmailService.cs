﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.ExternalServices.Interfaces;

namespace Twitter.Business.ExternalServices.Implements
{
	public class EmailService : IEmailService
	{
		IConfiguration _configuration { get; }

		public EmailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task SendEmail(string toMail, string subject, string content, bool isHtml = true)
		{
			SmtpClient smtpClient = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
			smtpClient.EnableSsl = true;
			smtpClient.Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]);

			MailAddress from = new MailAddress(_configuration["Email:Username"], "Twitter RockeySupport");
			MailAddress to = new MailAddress(toMail);

			MailMessage message = new MailMessage(from, to);
			message.Body = content;
			message.Subject = subject;
			message.IsBodyHtml = isHtml;

			smtpClient.SendAsync(message, null);
		}
	}
}
