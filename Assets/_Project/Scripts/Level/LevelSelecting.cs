using System;
using Menu.Level.UI;
using SceneManagement;
using UI;
using UI.Binding;
using UnityEngine;

namespace Level
{
    public class LevelSelecting : MonoBehaviour, IModel
    {
        public int SelectedLevel { get; private set; }
        
        [SerializeField] private UIManager uiManager;
        [SerializeField] private SceneLoader sceneLoader;
        
        private void Start()
        {
            uiManager.Bind<LevelSelecting, LevelSelectingScreen>(this);
        }

        public void SelectLevel(int level)
        {
            Debug.Log($"LEVEL {level}");
            SelectedLevel = level;
            sceneLoader.LoadLevel();
        }
    }
}