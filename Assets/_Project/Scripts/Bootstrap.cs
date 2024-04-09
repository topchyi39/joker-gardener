using System.Collections;
using SceneManagement;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    private const float StartDelay = 0.1f;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(StartDelay);
        sceneLoader.LoadMenu();
    }
}