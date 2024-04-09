using System;
using UI;
using UnityEngine;

namespace SceneManagement
{
    public enum SceneType
    {
        Menu,
        Level,
        None
    }
    
    public abstract class EntryPoint : MonoBehaviour
    {
        [SerializeField] private SubUI subUI;
        [SerializeField] private SceneLoader loader;

        protected abstract SceneType SceneType { get; }
        private void Awake()
        {
            loader.SceneLoaded += OnSceneLoaded;
            loader.SceneUnLoaded += OnSceneUnLoaded;
            loader.ScenePrepare += OnScenePrepared;
        }

        private void OnScenePrepared(SceneType scene)
        {
            if (SceneType != scene) return;

            Prepare();
        }

        private void OnSceneUnLoaded(SceneType scene)
        {
            if (SceneType != scene) return;
    
            Exit();
        }

        private void OnSceneLoaded(SceneType scene)
        {
            if (SceneType != scene) return;
            
            Enter();
        }

        protected virtual void Enter()
        {
            subUI.Enter();
        }

        protected virtual void Exit()
        {
            subUI.Exit();
        }

        protected virtual void Prepare() { }
    }
}