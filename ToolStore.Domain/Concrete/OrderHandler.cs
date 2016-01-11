﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Entities;
using System.Net.Mail;

namespace ToolStore.Domain.Concrete
{
    public class OrderHandler : IOrderHandler
    {
        private EmailCredential _credential;

        public OrderHandler(EmailCredential credential)
        {
            _credential = credential;
        }

        public void Handle(Product product, ShippingCredentials shippingCredentials) //Change product to cart (wrap it)
        {
            StringBuilder mailToClientSubject = new StringBuilder();
            mailToClientSubject.AppendFormat("Hello, {0}! Thanks for you order! (do-not-reply)", 
                shippingCredentials.FirstName);

            StringBuilder mailToClientBody = new StringBuilder();
            mailToClientBody.AppendLine("You have ordered a product "
                                + product.Name + " at ToolStore. <br/>")
                .AppendLine("Order details: <br/>")
                .AppendFormat("Product: {0} <br/>About it: {1} <br/>Price: {2:C} <br/>",
                    product.Name, product.Description, product.Price)
                .AppendLine("Your shipping credentials:  <br/>")
                .AppendFormat("Address: {0} <br/>Phone: {1}", shippingCredentials.Address, shippingCredentials.Phone);

            StringBuilder mailToStoreBody = new StringBuilder();
            mailToStoreBody.AppendFormat("New order by {0} {1}\n",
                shippingCredentials.FirstName, shippingCredentials.SecondName)
                .AppendLine("-------------Product---------------")
                .AppendFormat("Name: {0}\nDescription: {1}\nPrice: {2}\n",
                    product.Name, product.Description, product.Price)
                .AppendLine("-----------Coordinates-------------")
                .AppendFormat("First name: {0}\nSecond name: {1}\nEmail: {2}\nPhone: {3}\nAddress: {4}",
                    shippingCredentials.FirstName, shippingCredentials.SecondName, shippingCredentials.Email,
                    shippingCredentials.Phone, shippingCredentials.Address);

            MailMessage mailToClient = new MailMessage(_credential.Email, shippingCredentials.Email)
            {
                Body = mailToClientBody.ToString(),
                Subject = mailToClientSubject.ToString()
            };
            MailMessage mailToStore = new MailMessage(_credential.Email, _credential.Email)
            {
                Body = mailToStoreBody.ToString()
            };

            try
            {
                using (SmtpClient client = new SmtpClient(_credential.Host, _credential.Port)) //
                {
                    string password = _credential.Password;
                    client.EnableSsl = _credential.UseSsl;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.ServicePoint.MaxIdleTime = 1;
                    client.Credentials = new NetworkCredential(_credential.Username, password);
                    mailToClient.IsBodyHtml = true;

                    client.Send(mailToClient);
                    client.Send(mailToStore);
                }
            }
            catch (SmtpException exc)
            {
                throw new Exception("Could not connect to smtp server");
            }
        }
    }
}
