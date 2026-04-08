using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private float timerDuration = 3f; // Длительность таймера в секундах
   
    private void Start()
    {
        Invoke(nameof(LoadNextScene), timerDuration);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }
}
