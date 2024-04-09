using System;
using UI.Binding;
using UI.Fader;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Screen = UI.Screen.Screen;

namespace Level.UI
{
    public class LevelUI : Screen, IView<Level>
    {
        public Type ModelType => typeof(Level);

        [SerializeField] private Fader win;
        [SerializeField] private Fader lose;

        [SerializeField] private Button next;
        [SerializeField] private Button retry;
        [SerializeField] private Button toMenu;
        [SerializeField] private Button home;
        
        private Action _onNextClicked;
        private Action _onRetryClicked;
        private Action _onToMenuClicked;
        private Action _onPauseClicked;
        
        private void Awake()
        {
            fader.Fade(false, true);
            win.Fade(false, true);
            lose.Fade(false, true);
            
            next.onClick.AddListener(OnNextClicked);
            retry.onClick.AddListener(OnRetryClicked);
            toMenu.onClick.AddListener(OnToMenuClicked);
            home.onClick.AddListener(OnToHomeClicked);
        }

        private void OnPauseClicked()
        {
            _onPauseClicked?.Invoke();
        }

        private void OnToHomeClicked()
        {
            _onToMenuClicked?.Invoke();
        }

        public void Bind(Level model)
        {
            model.LevelCompleted += OnLevelCompleted;
            _onNextClicked = model.Next;
            _onRetryClicked = model.Retry;
            _onToMenuClicked = model.Exit;
        }
        
        private void OnLevelCompleted(bool value)
        {
            Show();
            var fader = value ? win : lose;
            fader.Fade(true);
        }

        private void OnNextClicked()
        {
            _onNextClicked?.Invoke();
            Hide();
        }

        private void OnRetryClicked()
        {
            _onRetryClicked?.Invoke();
            Hide();
        }

        private void OnToMenuClicked()
        {
            _onToMenuClicked?.Invoke();
            Hide();
        }
    }
}