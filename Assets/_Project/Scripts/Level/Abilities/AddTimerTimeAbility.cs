using UnityEngine;

namespace Level.Abilities
{
    [CreateAssetMenu(fileName = "AddTimerTimeAbility", menuName = "Project/Abilities/AddTimerTime", order = 0)]
    public class AddTimerTimeAbility : Ability
    {
        [SerializeField] private int seconds;
        
        public override void Cast(IAbilityReferences abilityReferences)
        {
            abilityReferences.Level.AddTime(seconds);
        }
    }
}