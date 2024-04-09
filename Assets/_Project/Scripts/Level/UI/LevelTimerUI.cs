using System;
using TMPro;
using UI.Binding;
using UnityEngine;

namespace Level.UI
{
    public class LevelTimerUI : MonoBehaviour, IView<LevelTimer>
    {
        public Type ModelType => typeof(LevelTimer);
        
        [SerializeField] private TMP_Text timerTMP;

        private int _previousSeconds;
    
        public void Bind(LevelTimer model)
        {
            model.Seconds.ValueChanged += SecondsChanged;
        }

        private void SecondsChanged(float seconds)
        {
            var currentSeconds = (int)seconds;

            if (currentSeconds == _previousSeconds) return;
            var timeSpan = TimeSpan.FromSeconds(currentSeconds);
            timerTMP.text = $"{timeSpan.Minutes}:{timeSpan.Seconds}";
            _previousSeconds = currentSeconds;
        }
    }
}