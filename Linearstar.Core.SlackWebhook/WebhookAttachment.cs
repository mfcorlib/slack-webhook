using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Linearstar.Core.Slack
{
	[DataContract]
	public class WebhookAttachment
	{
		[DataMember(Name = "fallback")]
		public string FallbackText { get; set; }
		[DataMember(Name = "color", EmitDefaultValue = false)]
		public string Color { get; set; }
		[DataMember(Name = "pretext", EmitDefaultValue = false)]
		public string Pretext { get; set; }
		[DataMember(Name = "author_name", EmitDefaultValue = false)]
		public string AuthorName { get; set; }
		[DataMember(Name = "author_link", EmitDefaultValue = false)]
		public string AuthorLink { get; set; }
		[DataMember(Name = "author_icon", EmitDefaultValue = false)]
		public string AuthorIconUrl { get; set; }
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string Title { get; set; }
		[DataMember(Name = "title_link", EmitDefaultValue = false)]
		public string TitleLinkUrl { get; set; }
		[DataMember(Name = "text", EmitDefaultValue = false)]
		public string Text { get; set; }
		[DataMember(Name = "fields", EmitDefaultValue = false)]
		public WebhookAttachmentField[] Fields { get; set; }
		[DataMember(Name = "image_url", EmitDefaultValue = false)]
		public string ImageUrl { get; set; }
		[DataMember(Name = "thumb_url", EmitDefaultValue = false)]
		public string ThumbnailUrl { get; set; }
		[DataMember(Name = "footer", EmitDefaultValue = false)]
		public string Footer { get; set; }
		[DataMember(Name = "footer_icon", EmitDefaultValue = false)]
		public string FooterIconUrl { get; set; }
		[DataMember(Name = "ts", EmitDefaultValue = false)]
		long TimestampValue { get; set; }
		public DateTimeOffset Timestamp
		{
			get => new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero).AddSeconds(TimestampValue);
			set => TimestampValue = (long)(value - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds;
		}
		[DataMember(Name = "mrkdwn_in", EmitDefaultValue = false)]
		string[] MrkdwnInValue { get; set; }
		public WebhookAttachmentMrkdwnTargets MrkdwnIn
		{
			get => MrkdwnInValue?.Select(i => Enum.TryParse<WebhookAttachmentMrkdwnTargets>(i, out var rt) ? rt : 0).Aggregate((x, y) => x | y) ?? 0;
			set
			{
				MrkdwnInValue = value == 0 ? null : new[]
				{
					(value & WebhookAttachmentMrkdwnTargets.Text) != 0 ? "text" : null,
					(value & WebhookAttachmentMrkdwnTargets.Pretext) != 0 ? "pretext" : null,
					(value & WebhookAttachmentMrkdwnTargets.Fields) != 0 ? "fields" : null,
				}.Where(i => i != null).ToArray();
			}
		}

		public WebhookAttachment(string fallbackText) =>
			FallbackText = fallbackText;
	}
}