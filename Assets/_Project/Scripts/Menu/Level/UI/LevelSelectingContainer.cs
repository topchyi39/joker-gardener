using System;
using System.Collections.Generic;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Level.UI
{
    public class LevelSelectingContainer : MonoBehaviour
    {
        public IReadOnlyCollection<LevelSelectingButton> Buttons => _buttonArray;
        public int LevelsPerPage => _levelsPerPage;
        [SerializeField] private LevelSelectingButton prefab;
        [SerializeField] private RectTransform parent;
        [SerializeField] private GridLayoutGroup layoutGroup;
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float spacing;
        [SerializeField] private float cellSize;
        
        private int _levelsPerPage;
        private LevelSelectingButton[] _buttonArray;

        private void Awake()
        {
            BuildLevelsButton();
        }

        private void BuildLevelsButton()
        {
            _levelsPerPage = rows * columns;
            _buttonArray = new LevelSelectingButton[_levelsPerPage];
            parent.sizeDelta = new Vector2((cellSize + spacing * 2f) * columns, (cellSize + spacing * 2f) * rows);
            layoutGroup.cellSize = Vector2.one * cellSize;
            layoutGroup.spacing = Vector2.one * spacing;
            
            for (var i = 0; i < _levelsPerPage; i++)
            { 
                var button = Instantiate(prefab, parent);
                button.SetLevel(i);
                _buttonArray[i] = button;
            }
        }

        public void ChangePage(int page)
        {
            // currentPage = Mathf.Clamp(page, 0, totalPages - 1); // Убедимся, что мы не выходим за границы страниц
            //
            // int startIndex = currentPage * levelsPerPage;
            // int endIndex = Mathf.Min(startIndex + levelsPerPage, levelCount);
            // float cellWidth = parent.rect.width / columns;
            // float cellHeight = parent.rect.height / rows;
            // // Перемещаем кнопки с края экрана к центру с плавной анимацией
            // Vector2 targetPosition = Vector2.zero;
            // for (int i = startIndex; i < endIndex; i++)
            // {
            //     
            //     int row = i / columns;
            //     int col = i % columns;
            //     Vector2 buttonPosition = new Vector2((col + 0.5f) * cellWidth, -(row + 0.5f) * cellHeight);
            //     RectTransform buttonTransform = parent.GetChild(i).GetComponent<RectTransform>();
            //     buttonTransform.gameObject.SetActive(true);
            //     Vector2 startPos = buttonTransform.anchoredPosition;
            //     StartCoroutine(MoveButtonCoroutine(buttonTransform, startPos, buttonPosition, animationSpeed * (i - startIndex)));
            // }
        }

        // Корутина для анимированного перемещения кнопки
        private System.Collections.IEnumerator MoveButtonCoroutine(RectTransform buttonTransform, Vector2 startPos, Vector2 targetPos, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                buttonTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
                yield return null;
            }
            buttonTransform.anchoredPosition = targetPos;
        }

        public void PreviousPage()
        {
            // ChangePage(currentPage - 1);
        }

        public void NextPage()
        {
            // ChangePage(currentPage + 1);
        }
    }
}