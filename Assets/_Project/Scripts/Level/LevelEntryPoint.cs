using SceneManagement;
using UnityEngine;

namespace Level
{
    public class LevelEntryPoint : EntryPoint
    {
        [SerializeField] private LevelSelecting levelSelecting;
        [SerializeField] private Level level;
                
        protected override SceneType SceneType => SceneType.Level;

        protected override void Prepare()
        {
            base.Prepare();
            var levelIndex = levelSelecting.SelectedLevel;
            level.Prepare(levelIndex);
        }

        protected override void Enter()
        {
            base.Enter();

            level.StartLevel();
        }

        protected override void Exit()
        {
            base.Exit();
            
            level.ClearLevel();
        }
    }
}