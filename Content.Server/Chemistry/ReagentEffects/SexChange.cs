using Content.Shared.Chemistry.Reagent;
using Content.Shared.Humanoid;
using Robust.Shared.Prototypes;

namespace Content.Server.Chemistry.ReagentEffects
{
    public sealed partial class SexChange : ReagentEffect
    {
        private const Sex DefaultSex = Sex.Female;

        [DataField("sex")]
        public Sex NewSex { get; set; } = DefaultSex;

        public override void Effect(ReagentEffectArgs args)
        {
            var uid = args.SolutionEntity;
            EntitySystem.Get<SharedHumanoidAppearanceSystem>().SetSex(uid, NewSex, true);
        }

        protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
            => Loc.GetString("reagent-effect-guidebook-ignite", ("chance", Probability));
    }
}
