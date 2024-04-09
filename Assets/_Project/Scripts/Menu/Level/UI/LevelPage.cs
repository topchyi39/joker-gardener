using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Level.UI
{
    public class LevelPage : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayout;
        
        public List<LevelSelectingButton> LevelButtons = new ();

        public void CreatePage(LevelSelectingButton buttonPrefab, int startIndex, int amount)
        {
            Debug.Log($"Start Index {startIndex} Amount: {amount}");
            for (var i = 0; i < amount; i++)
            {
                var button = Instantiate(buttonPrefab, transform);
                button.SetLevel(startIndex + i);
                LevelButtons.Add(button);
            }
        }
        
        
    }
}