﻿using System;

namespace KillBillClient.Infrastructure.Exceptions
{
    public class KillBillClientException : Exception
    {
        public KillBillClientException()
        {
        }

        public KillBillClientException(string message)
            : base(message)
        {
        }

        public KillBillClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public KillBillClientException(string message, string httpStatusCode, string billingCode, string billingMessage)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            BillingMessage = billingMessage;
        }

        public KillBillClientException(string message, string httpStatusCode, string billingCode, string billingMessage,
            Exception innerException)
            : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            BillingMessage = billingMessage;
        }

        public string BillingCode { get; set; }

        public string BillingMessage { get; set; }

        public string HttpStatusCode { get; set; }
    }
}