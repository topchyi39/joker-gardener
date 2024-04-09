using System;
using System.Collections;
using Level.Flowers;
using Level.Flowers.Cards;
using Level.Flowers.Pots;
using Level.UI;
using SceneManagement;
using UI;
using UI.Binding;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    [Serializable]
    public struct LevelConfiguration
    {
        [field: SerializeField] public int PairCount { get; set; }
        [field: SerializeField] public int TimerSeconds { get; set; }
    }

    public class LevelTimer : IModel
    {
        public Reactivity.ReactProperty<float> Seconds { get; private set; } = new ();

        private bool _enabled;
        
        public LevelTimer() { }

        public void SetTime(float seconds)
        {
            Seconds.Value = seconds;
        }
        
        public void Update(float deltaTime)
        {
            
            Seconds.Value -= deltaTime;
        }
    }

    public class Level : MonoBehaviour, IModel
    {
        public Action<bool> LevelCompleted;
        
        [SerializeField] private LevelConfiguration baseConfiguration;
        [SerializeField] private int decreseSecondsPerlevel = 5;
        [SerializeField] private float increasePairCountPerLevel = .2f;
        
        [SerializeField] private PotsManager potsManager;
        [SerializeField] private CardsManager cardsManager;
        [SerializeField] private CardDragger dragger;
        
        [Header("Other references")] 
        [SerializeField] private UIManager uiManager;
        [SerializeField] private LevelSelecting levelSelecting;
        [SerializeField] private SceneLoader loader;
        
        private readonly LevelTimer _timer = new ();

        private const float LevelStartDelay = 2f;

        private void Awake()
        {
            potsManager.AllFlowerGrown += () => CompleteLevel(true);
        }

        private void Start()
        {
            uiManager.Bind<LevelTimer, LevelTimerUI>(_timer);
            uiManager.Bind<Level, LevelUI>(this);
        }

        public void Retry()
        {
            levelSelecting.SelectLevel(levelSelecting.SelectedLevel);
        }

        public void Next()
        {
            var nextLevel = levelSelecting.SelectedLevel + 1;
            levelSelecting.SelectLevel(nextLevel);
        }

        public void Exit()
        {
            loader.LoadMenu();
        }

        public void Prepare(int levelIndex)
        {
            var configuration = GetLevelConfiguration(levelIndex);
            Random.InitState(levelIndex);
            
            var flowers = GetFlowers(configuration.PairCount);
            
            potsManager.Prepare(flowers, configuration.PairCount);
            cardsManager.Prepare(flowers, configuration.PairCount);
            
            _timer.SetTime(configuration.TimerSeconds);
        }

        public void StartLevel()
        {
            StartCoroutine(LevelRoutine());
        }

        public void AddTime(int seconds)
        {
            _timer.Seconds.Value += seconds;
        }
        
        public void ClearLevel()
        {
            potsManager.Clear();
            cardsManager.Clear();
        }
        
        private LevelConfiguration GetLevelConfiguration(int levelIndex)
        {
            var configuration = baseConfiguration;
            configuration.TimerSeconds -= (levelIndex + 1) * decreseSecondsPerlevel;
            configuration.PairCount += (int)Mathf.Ceil((levelIndex + 1f) * increasePairCountPerLevel);
            return configuration;
        }

        private Flower[] GetFlowers(int amount)
        {
            var array = new Flower[amount];
            var flowerCount = Enum.GetNames(typeof(Flower)).Length;
            for (var i = 0; i < amount; i++)
            {
                array[i] = (Flower)Random.Range(1, flowerCount);
            }

            return array;
        }

        private IEnumerator LevelRoutine()
        {
            yield return new WaitForSeconds(LevelStartDelay);

            dragger.EnableDrag();
            cardsManager.ShowCards();
            potsManager.HideFlowers();
            
            while (_timer.Seconds.Value > 0)
            {
                yield return new WaitForEndOfFrame();
                _timer.Update(Time.deltaTime);
            }

            CompleteLevel(false);
        }

        private void CompleteLevel(bool result)
        {
            dragger.DisableGrab();
            LevelCompleted?.Invoke(result);
            StopAllCoroutines();
        }
    }
}