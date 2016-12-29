using System;

namespace Linearstar.Core.Slack
{
	[Flags]
	public enum WebhookAttachmentMrkdwnTargets
	{
		None,
		Text,
		Pretext,
		Fields = 4,
	}
}
