using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Client.Services
{
    public class SoapService
    {
        /// <summary>
        /// Execute a Soap WebService call
        /// </summary>
        public static string Execute(string startStation, string destinationStation, string date)
        {
            StringBuilder builder = new StringBuilder();
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            XmlDocument outputXml = new XmlDocument();

            string requestString = string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                 <GetDirections xmlns=""http://tempuri.org/"">
                      <startStationName>{0}</startStationName>
                      <finishStationName>{1}</finishStationName>
                      <arriveDate>{2}</arriveDate>
                    </GetDirections>
                  </soap:Body>
                </soap:Envelope>", startStation, destinationStation, date);

            soapEnvelopeXml.LoadXml(requestString);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        outputXml.LoadXml(soapResult);
                        builder.AppendLine(outputXml.InnerText);
                    }
                }
            }
            catch (Exception e)
            {
                builder.ToString();
            }
            return builder.ToString();
        }
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://localhost:54050/WebService1.asmx?op=GetDirections");
            webRequest.Host = "localhost";
            webRequest.Timeout = int.MaxValue;
            webRequest.Headers.Add("SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}