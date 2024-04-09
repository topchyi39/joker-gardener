using Level.Flowers.Cards;
using UnityEngine;

namespace Level.Abilities
{
    public interface IAbilityReferences
    {
        CardsManager Cards { get; }
        Level Level { get; }
        
    }
    
    public abstract class Ability : ScriptableObject
    {
        public abstract void Cast(IAbilityReferences abilityReferences);
    }
}