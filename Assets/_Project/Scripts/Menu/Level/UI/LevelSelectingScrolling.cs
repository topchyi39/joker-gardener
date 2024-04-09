using UnityEngine;
using UnityEngine.UI;

namespace Menu.Level.UI
{
    public class LevelSelectingScrolling : MonoBehaviour
    {
        [SerializeField] private LevelSelectingContainer buttonContainer;
        [SerializeField] private Button next;
        [SerializeField] private Button previous;

        private int _currentPage;
        
        private void Awake()
        {
            next.onClick.AddListener(NextPage);
            previous.onClick.AddListener(PreviousPage);
        }

        private void NextPage()
        {
            _currentPage++;
            UpdateLevelIndexes();
            if (!previous.gameObject.activeSelf) previous.gameObject.SetActive(true);
        }

        private void PreviousPage()
        {
            if (_currentPage == 0) return;
            
            _currentPage--;
            UpdateLevelIndexes();
            if (_currentPage == 0) previous.gameObject.SetActive(false);
        }

        private void UpdateLevelIndexes()
        {
            var buttons = buttonContainer.Buttons;
            var perPage = buttonContainer.LevelsPerPage;
            var index = _currentPage * perPage;
            foreach (var button in buttons)
            {
                button.SetLevel(index);
                index++;
            }
        }
    }
}