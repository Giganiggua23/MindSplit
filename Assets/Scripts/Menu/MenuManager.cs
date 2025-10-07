using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject YES;



    [SerializeField] GameObject Settings;

    bool IsGame = false;


    void Start()
    {
        Credits.SetActive(false);
        YES.SetActive(false);
    }


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }


    public void ButtonCredits()
    {
        Credits.SetActive(!Credits.activeSelf);
    }

    public void ButtonExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonExit()
    {
        YES.SetActive(!YES.activeSelf);
    }

    public void ButtonYes()
    {
        Application.Quit();
    }

    void Update()
    {
        if (IsGame && Input.GetKeyDown(KeyCode.Escape))
        {
            Settings.SetActive(!Settings.activeSelf);
        }
    }
}
