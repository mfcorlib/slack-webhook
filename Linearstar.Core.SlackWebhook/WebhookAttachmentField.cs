using System.Runtime.Serialization;

namespace Linearstar.Core.Slack
{
	[DataContract]
	public class WebhookAttachmentField
	{
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string Title { get; set; }
		[DataMember(Name = "value", EmitDefaultValue = false)]
		public string Value { get; set; }
		[DataMember(Name = "short", EmitDefaultValue = false)]
		public bool IsShort { get; set; }
	}
}