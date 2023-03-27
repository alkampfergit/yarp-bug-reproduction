using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace TestNet48.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/download
		[HttpGet]
		[Route("api/download")]
		public HttpResponseMessage Download()
		{
			var ms = new MemoryStream(new byte[] { 67,68,69 });

			return CreateStreamContentHttpResponseMessage(ms, "This is N°1 file.txt");
		}

		protected HttpResponseMessage CreateStreamContentHttpResponseMessage(Stream fileStream, string filename)
		{
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage
			{
				Content = new StreamContent(fileStream)
			};

			httpResponseMessage.Content.Headers.Add("x-filename", filename);
			httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
			httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
			{
				FileName = filename
			};
			httpResponseMessage.Content.Headers.ContentLength = fileStream.Length;
			httpResponseMessage.StatusCode = HttpStatusCode.OK;
			return httpResponseMessage;
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
