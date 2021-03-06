﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Xml.Linq;
using HtmlAgilityPack;
using System.Threading;
using System.Net.Http.Headers;
using System.IO.Compression;

namespace BoardGameManager.Domain.Services
{
    public class BoardGameGeekInfoService : BoardGameManager.Domain.Services.IBoardGameGeekInfoService
    {
        public BoardGameGeekGameDetails GetBoardGameDetails(Uri boardGameGeekReviewUrl)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.MaxResponseContentBufferSize = 496000;
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
                httpClient.Timeout = TimeSpan.FromHours(1);

                var requestMessage = new HttpRequestMessage()
                {
                    RequestUri = boardGameGeekReviewUrl,
                    Method = HttpMethod.Get
                };
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                requestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

                    
                var httpResponse = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead).Result;

                httpResponse.EnsureSuccessStatusCode();
                var contentStream = httpResponse.Content.ReadAsStreamAsync().Result;


                StreamReader contentStreamReader;
                if (httpResponse.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    contentStreamReader = new StreamReader(new GZipStream(contentStream, CompressionMode.Decompress), Encoding.UTF8);
                }
                else
                {

                    contentStreamReader = new StreamReader(contentStream, Encoding.UTF8);
                }

                string responseHtmlAsString = contentStreamReader.ReadToEnd();
                contentStreamReader.Dispose();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(responseHtmlAsString);

                var boardGameGeekGameDetails = new BoardGameGeekGameDetails();

                PopulateBoardGameImageUrisFromHtml(htmlDocument, boardGameGeekGameDetails);
                PopulateBoardGameDescriptionFromHtml(htmlDocument, boardGameGeekGameDetails);

                return boardGameGeekGameDetails;
            }
        }

        private static void PopulateBoardGameDescriptionFromHtml(HtmlDocument htmlDocument, BoardGameGeekGameDetails boardGameGeekGameDetails)
        {
            var divContainingDescription = htmlDocument.DocumentNode.SelectNodes("//div[@id = \"editdesc\"]")[0];

            var hyperlinks = divContainingDescription.SelectNodes("//a");
            foreach (var hyperlink in hyperlinks)
            {
                hyperlink.SetAttributeValue("target", "_blank");
                var hyperlinkSourceAttribute = hyperlink.Attributes["href"];
                if (hyperlinkSourceAttribute != null && hyperlinkSourceAttribute.Value != null && hyperlinkSourceAttribute.Value.StartsWith("/"))
                {
                    hyperlinkSourceAttribute.Value = "http://www.boardgamegeek.com" + hyperlinkSourceAttribute.Value;
                }
            }

            boardGameGeekGameDetails.Description = divContainingDescription.InnerHtml;
        }


        private static void PopulateBoardGameImageUrisFromHtml(HtmlDocument htmlDocument, BoardGameGeekGameDetails boardGameGeekGameDetails)
        {
            var divContainingImage = htmlDocument.GetElementbyId("module_2");
            var imageElements = divContainingImage.SelectNodes(".//img");
            var boardGameImageElement = imageElements[0];
            var boardGameImageUrlAsString = boardGameImageElement.Attributes["src"].Value;

            boardGameGeekGameDetails.MediumBoardGameImage = new Uri(boardGameImageUrlAsString);
            boardGameGeekGameDetails.SmallBoardGameImage = new Uri(boardGameImageUrlAsString.Replace("_t.jpg", "_sq.jpg"));
        }

        static byte[] Decompress(MemoryStream gzipMemoryStream)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(gzipMemoryStream, CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

    }
}
