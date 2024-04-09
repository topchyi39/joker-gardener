using UnityEngine;

namespace UI
{
    public class SubUI : MonoBehaviour
    {
        [SerializeField] private Fader.Fader fader;

        public void Enter()
        {
            fader.Fade(true, true);
        }

        public void Exit()
        {
            
            fader.Fade(false, true);
        }
    }
}