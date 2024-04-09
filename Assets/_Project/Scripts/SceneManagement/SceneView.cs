using System;
using UI.Fader;
using UnityEngine;

namespace SceneManagement
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private SceneLoader loader;
        [SerializeField] private Fader fader;
        [SerializeField] private ProgressBar progressBar;
           
        private void Start()
        {
            loader.IsLoading.ValueChanged += SceneLoadChanged;
            loader.Progress.ValueChanged += SceneProgressChanged;
        }

        private void SceneProgressChanged(float value)
        {
            progressBar.SetValue(value);
        }

        private void SceneLoadChanged(bool value)
        {
            fader.Fade(value);
        }
    }
}