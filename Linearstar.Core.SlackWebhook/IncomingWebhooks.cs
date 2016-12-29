using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Linearstar.Core.Slack
{
	public static class IncomingWebhooks
	{
		public static async Task PostAsync(string endpoint, WebhookMessage message)
		{
			using (var hc = new HttpClient())
			using (var ms = new MemoryStream())
			{
				var serializer = new DataContractJsonSerializer(typeof(WebhookMessage));

				serializer.WriteObject(ms, message);
				ms.Seek(0, SeekOrigin.Begin);

				await hc.PostAsync(endpoint, new StreamContent(ms)
				{
					Headers =
					{
						ContentType = new MediaTypeHeaderValue("application/json"),
					},
				});
			}
		}
	}
}
