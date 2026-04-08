using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TutorialManager _tutorialManager;

    [SerializeField] GameObject Settings;
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject YES;



    [SerializeField] GameObject GameMenu;

    [SerializeField] bool IsGame = false;
    [SerializeField] bool IsDieMenu = false;


    void Start()
    {
        if (IsGame && _tutorialManager == null)
            _tutorialManager = GameObject.Find("Book_Note").GetComponent<TutorialManager>();
        
        if (Settings != null)
            Settings.SetActive(false);

        if (Credits != null)
            Credits.SetActive(false);

        if (YES != null)
            YES.SetActive(false);

        if (GameMenu != null)
            GameMenu.SetActive(false);
    }

            /* === Play === */

    public void ButtonNewGamePlay()         // —цена с комиксом, после загрузка тыры пыры
    {
        _tutorialManager.ResetAllQuests();
        _tutorialManager.SaveAllQuests();

        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        

        //DataLoad

        
    }

    public void ButtonLastGamePlay()        // надо загружать сцену игры (скорей всего сцену загрузки котора€ уходит в игру)
    {
        //_tutorialManager.LoadAllQuest();
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
        

        //DataLoad

        
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }


            /* === Settings === */


    public void ButtonSettings()
    {
        Settings.SetActive(!Settings.activeSelf);
    }

    public void ButtonCredits()
    {
        Credits.SetActive(!Credits.activeSelf);
    }

            /* === Exit === */

    public void ButtonExitToMenu()
    {
        SceneManager.LoadScene(0);
        _tutorialManager.SaveAllQuests();
    }

    public void ButtonExit()
    {
        YES.SetActive(!YES.activeSelf);
    }

    public void ButtonYes()
    {
        Application.Quit();
    }

            /* === GameMenu === */

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

            /* === ALL === */


    void Update()
    {
        if (IsGame && Input.GetKeyDown(KeyCode.Escape))
        {
            _tutorialManager.SaveAllQuests();
            ReturnToGame();
        }
            

        if (IsDieMenu && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
