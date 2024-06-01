using Content.Server.Storage.Components;
using Content.Shared.Database;
using Content.Shared.Storage.Components;
using Content.Shared.Verbs;
using Robust.Shared.Random;

namespace Content.Server.Storage.EntitySystems;

public sealed class ShuffleSystem : EntitySystem
{

    [Dependency] private readonly IRobustRandom _random = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ShuffleComponent, GetVerbsEvent<AlternativeVerb>>(OnGetAlternativeVerbs);
    }

    private void OnGetAlternativeVerbs(EntityUid uid, ShuffleComponent comp, GetVerbsEvent<AlternativeVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract || !TryComp<BinComponent>(uid, out var bin))
        {
            return;
        }

        bool enabled = false;

        if (bin.Items.Count < 1)
        {
            enabled = true;
        }

        args.Verbs.Add(new AlternativeVerb
        {
            Act = () =>
            {
                _random.Shuffle(bin.Items);
            },
            Impact = LogImpact.Low,
            Text = Loc.GetString("shuffle-verb"),
            Disabled = enabled
        });
    }

}
