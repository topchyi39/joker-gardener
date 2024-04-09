using System;
using Level;
using Reactivity;
using UI.Binding;
using UnityEngine;
using Screen = UI.Screen.Screen;

namespace Menu.Level.UI
{
    public class LevelSelectingScreen : Screen, IView<LevelSelecting>
    {

        public Type ModelType => typeof(LevelSelecting);

        [SerializeField] private LevelSelectingContainer buttonContainer;

        private readonly ReactProperty<int> _indexSelected = new (-1);
        
        private void Start()
        {
            var buttons = buttonContainer.Buttons;
            foreach (var button in buttons)
            {
                button.LevelSelected += OnLevelSelected;
            }
        }
        
        public void Bind(LevelSelecting model)
        {
            _indexSelected.ValueChanged += model.SelectLevel;
        }

        private void OnLevelSelected(int levelIndex)
        {
            _indexSelected.Value = levelIndex;
        }

    }
}