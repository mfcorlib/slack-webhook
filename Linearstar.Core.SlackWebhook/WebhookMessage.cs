using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Linearstar.Core.Slack
{
	[DataContract]
	public class WebhookMessage
	{
		[DataMember(Name = "text")]
		public string Text { get; set; }
		[DataMember(Name = "channel", EmitDefaultValue = false)]
		public string Channel { get; set; }
		[DataMember(Name = "username", EmitDefaultValue = false)]
		public string UserName { get; set; }
		[DataMember(Name = "icon_url", EmitDefaultValue = false)]
		public string IconUrl { get; set; }
		[DataMember(Name = "icon_emoji", EmitDefaultValue = false)]
		public string IconEmoji { get; set; }
		[DataMember(Name = "link_names")]
		int LinkNamesValue { get; set; } = 1;
		[DataMember(Name = "attachments", EmitDefaultValue = false)]
		public WebhookAttachment[] Attachments { get; set; }

		public WebhookMessage()
		{
		}

		public WebhookMessage(string text) =>
			Text = text;

		public override string ToString()
		{
			using (var ms = new MemoryStream())
			{
				var serializer = new DataContractJsonSerializer(typeof(WebhookMessage));

				serializer.WriteObject(ms, this);

				return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
			}
		}
	}
}
