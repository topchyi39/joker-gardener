using UnityEngine;

namespace Level.Abilities
{
    [CreateAssetMenu(fileName = "FindAbility", menuName = "Project/Abilities/FindCard", order = 0)]

    public class FindCardAbility : Ability
    {
        public override void Cast(IAbilityReferences abilityReferences)
        {
            var cards = abilityReferences.Cards.AvailableCards;

            var randomIndex = Random.Range(0, cards.Count);
            var randomAvailableCard = cards[randomIndex];
            randomAvailableCard.Highlight();
        }
    }
}