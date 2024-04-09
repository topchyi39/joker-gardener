using System;
using System.Collections.Generic;
using System.Linq;
using UI.Binding;
using UI.Screen;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private Dictionary<Type, IUIScreen> _screensMap;
        private Dictionary<Type, IView> _viewsMap;

        private readonly List<IUIScreen> _openedScreens = new ();
        
        private void Awake()
        {
            _screensMap = GetComponentsInChildren<IUIScreen>().ToDictionary(screen => screen.GetType(), screen => screen);
            
            foreach (var screen in _screensMap.Values)
            {
                screen.Init(this);
            }
            
            _viewsMap = GetComponentsInChildren<IView>().ToDictionary(view => view.ModelType, screen => screen);
        }

        public T GetScreen<T>() where T : Screen.Screen
        {
            var type = typeof(T);
            if (_screensMap.TryGetValue(type, out var screen)) return screen as T;
            return null;
        }

        public void Bind<T, W>(T model) 
            where T : IModel 
            where W : class, IView<T> 
        {
            if (_viewsMap.TryGetValue(typeof(T), out var view))
            {
                var castedView = view as W;
                castedView.Bind(model);
            }
        }
        

        public void Show<T>() where T : IUIScreen
        {
            if (!_screensMap.TryGetValue(typeof(T), out var screen)) return;
            if (_openedScreens.Contains(screen)) return;
            
            screen.Show();
            _openedScreens.Add(screen);
        }

        public void Hide<T>() where T : IUIScreen
        {
            if (!_screensMap.TryGetValue(typeof(T), out var screen)) return;
            if (!_openedScreens.Contains(screen)) return;

            screen.Hide();
            _openedScreens.Remove(screen);
        }

        public void Hide<T>(T screen) where T : IUIScreen
        {
            if (!_screensMap.ContainsKey(typeof(T))) return;
            if (!_openedScreens.Contains(screen)) return;

            screen.Hide();
            _openedScreens.Remove(screen);
        }

        public void Back()
        {
            var screen = _openedScreens[^1];
            screen.Hide();
            
            _openedScreens.Remove(screen);
        }
        
    }
}