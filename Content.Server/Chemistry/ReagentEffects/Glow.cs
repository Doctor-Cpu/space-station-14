using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;
using Robust.Shared.Maths;

namespace Content.Server.Chemistry.ReagentEffects;

public sealed partial class Glow : ReagentEffect
{
    [DataField]
    public float Radius = 1.125f;

    [DataField(required: true)]
    public Color Color;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("reagent-effect-guidebook-glow", ("chance", Probability));

    public override void Effect(ReagentEffectArgs args)
    {
        var lightSys = args.EntityManager.EntitySysManager.GetEntitySystem<SharedPointLightSystem>();
        lightSys.SetEnabled(args.SolutionEntity, true);
        lightSys.SetColor(args.SolutionEntity, Color);
        lightSys.SetRadius(args.SolutionEntity, Radius);
    }
}
