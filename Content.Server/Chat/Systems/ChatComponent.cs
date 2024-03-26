using Robust.Shared.Prototypes;
using Content.Server.Chat.Systems;

namespace Content.Server.Chat.Systems;

public sealed partial class ChatComponent : Component
{
    [DataField]
    public string Language = string.Empty;
}
