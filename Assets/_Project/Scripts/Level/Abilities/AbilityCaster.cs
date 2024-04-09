using Level.Flowers.Cards;
using UnityEngine;

namespace Level.Abilities
{
    public class AbilityCaster : MonoBehaviour, IAbilityReferences
    {
        [field: SerializeField] public CardsManager Cards { get; private set; }
        [field: SerializeField] public Level Level { get; private set; }
        
        public void Cast(Ability ability)
        {
            ability.Cast(this);
        }

    }
}