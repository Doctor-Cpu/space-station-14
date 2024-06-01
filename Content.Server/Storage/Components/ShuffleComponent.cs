using Content.Server.Storage.EntitySystems;

namespace Content.Server.Storage.Components;

/// <summary>
/// Adds a verb to shuffle the contents of a bin
/// </summary>
[RegisterComponent]
[Access(typeof(ShuffleSystem))]
public sealed partial class ShuffleComponent : Component
{
}
