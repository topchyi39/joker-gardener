using System;
using Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Level.UI
{
    public class LevelSelectingButton : MonoBehaviour
    {
        public event Action<int> LevelSelected; 
        
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text levelTMP;

        private int _levelIndex;
        
        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            LevelSelected?.Invoke(_levelIndex);
        }

        public void SetLevel(int level)
        {
            _levelIndex = level;
            levelTMP.text = (_levelIndex + 1).ToString();
        }
    }
}