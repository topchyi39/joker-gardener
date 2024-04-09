using Menu.Level.UI;
using Menu.UI;
using SceneManagement;
using UI;
using UnityEngine;

namespace Menu
{
    public class MenuEntryPoint : EntryPoint
    {
        [SerializeField] private UIManager uiManager;
        
        protected override SceneType SceneType => SceneType.Menu;

        protected override void Enter()
        {
            base.Enter();
            uiManager.Show<MainMenuScreen>();
        }

        protected override void Exit()
        {
            base.Exit();
            uiManager.Hide<LevelSelectingScreen>();
        }
    }
}