using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject YES;



    [SerializeField] GameObject GameMenu;

    [SerializeField] bool IsGame = false;
    [SerializeField] bool IsDieMenu = false;


    void Start()
    {
        Credits.SetActive(false);
        YES.SetActive(false);
        GameMenu.SetActive(false);
    }


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
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

    public void ReturnToGame()
    {
        GameMenu.SetActive(!GameMenu.activeSelf);
        if (GameMenu.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void Update()
    {
        if (IsGame && Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToGame();
        }
            

        if (IsDieMenu && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
