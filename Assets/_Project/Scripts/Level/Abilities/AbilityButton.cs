using UnityEngine;
using UnityEngine.UI;

namespace Level.Abilities
{
    public class AbilityButton : MonoBehaviour
    {
        [SerializeField] private Ability ability;
        [SerializeField] private AbilityCaster abilityCaster;
        
        [SerializeField] private Button button;
        
        private void Awake()
        {
            button.onClick.AddListener(CastAbility);
        }

        private void CastAbility()
        {
            abilityCaster.Cast(ability);
        }
    }
}