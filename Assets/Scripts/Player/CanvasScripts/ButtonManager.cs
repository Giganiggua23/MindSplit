using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject ButtonE;
    [SerializeField] GameObject ButtonLMB;


    private bool IsActiveBottonM = false;
   // [SerializeField] GameObject ButtonM; // когда будет кнопка йоу
    [SerializeField] GameObject BookOBJ;


    void Start()
    {
        IsActiveBottonM = false;
        BookOBJ.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IsActiveBottonM = !IsActiveBottonM;
            BookOBJ.SetActive(!BookOBJ.activeSelf);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button_E"))
        {
            ButtonE.SetActive(true);
        }

        if (other.CompareTag("Button_LMB"))
        {
            ButtonLMB.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (ButtonE != null)
        {
            ButtonE.SetActive(false);
        }

        if (ButtonLMB != null)
        {
            ButtonLMB.SetActive(false);
        }

    }

    //targetObject.SetActive(!targetObject.activeSelf);    - обратное вкл
}
