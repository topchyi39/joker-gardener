using Menu.Level.UI;
using UnityEngine;
using UnityEngine.UI;
using Screen = UI.Screen.Screen;

namespace Menu.UI
{
    public class MainMenuScreen : Screen
    {
        [SerializeField] private Button play;

        private void Awake()
        {
            play.onClick.AddListener(ToLevelSelecting);
        }

        private void ToLevelSelecting()
        {
            _uiManager.Hide(this);
            _uiManager.Show<LevelSelectingScreen>();
        }
    }
}