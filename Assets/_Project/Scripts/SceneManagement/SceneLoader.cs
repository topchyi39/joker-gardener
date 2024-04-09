using System;
using Reactivity;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public event Action<SceneType> SceneLoaded;
        public event Action<SceneType> SceneUnLoaded;
        public event Action<SceneType> ScenePrepare;
        
        public IReactProperty<bool> IsLoading => _isLoading;
        public IReactProperty<float> Progress => _progress;
        
        [SerializeField] private int menuIndex;
        [SerializeField] private int levelIndex;
        [Header("Fake Loading Settings")] 
        [SerializeField] private float minTimeLoading;
        [SerializeField] private float maxTimeLoading;

        private SceneType _currentEntryPoint;
        private int _minLoading;
        private int _maxLoading;
        private readonly ReactProperty<bool> _isLoading = new ();
        private readonly ReactProperty<float> _progress = new ();

        private void Awake()
        {
            _minLoading = (int)(minTimeLoading * 100);
            _maxLoading = (int)(maxTimeLoading * 100);
        }

        public void LoadMenu()
        {
            Debug.Log("MenuLoaded");
            FakeLoadScene(SceneType.Menu);
        }

        public void LoadLevel()
        {
            
            FakeLoadScene(SceneType.Level);
        }

        private void FakeLoadScene(SceneType scene)
        {
            StartCoroutine(FakeLoadSceneRoutine(scene));
        }

        private IEnumerator FakeLoadSceneRoutine(SceneType scene)
        {
            
            _isLoading.Value = true;
            _progress.Value = 0; 
            var random = new Random();
            var duration = random.Next(_minLoading, _maxLoading)/100f;
            var loadingTime = 0f;
            var prepared = false;
            while (loadingTime < duration)
            {
                _progress.Value = loadingTime / duration;
                yield return new WaitForEndOfFrame();
                loadingTime += Time.deltaTime;

                var next = random.Next(0, 50);
                if (next == 0)
                {
                    yield return new WaitForSeconds(0.2f);
                }
                
                if (_progress.Value < 0.5f || prepared) continue;
                
                SceneUnLoaded?.Invoke(_currentEntryPoint);
                ScenePrepare?.Invoke(scene);
                prepared = true;
            }

            yield return new WaitForSeconds(0.3f);
            
            _progress.Value = 1;
            _isLoading.Value = false;
            
            _currentEntryPoint = scene;
            SceneLoaded?.Invoke(_currentEntryPoint);
        }
    }
    
}