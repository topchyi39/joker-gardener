using UnityEngine;

using Fader = UI.Fader.Fader;

namespace UI.Screen
{
    public interface IUIScreen
    {
        void Init(UIManager uiManager);
        void Show();
        void Hide();
    }
    
    public abstract class Screen : MonoBehaviour, IUIScreen
    {
        [SerializeField] protected Fader.Fader fader;

        protected UIManager _uiManager;
        
        public void Init(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Show()
        {
            fader.FadeIn();
        }

        public void Hide()
        {
            fader.FadeOut();
        }

        protected void HideImmediately()
        {
            fader.Fade(false, true);
        }
        
        protected virtual void OnShowed() {}
        protected virtual void OnHided() {}
        
    }
}