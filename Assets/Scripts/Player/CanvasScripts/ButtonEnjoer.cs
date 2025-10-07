using UnityEngine;

public class ButtonEnjoer : MonoBehaviour
{
    [SerializeField] GameObject ButtonE;

    void OnTriggerEnter(Collider button)
    {
        if (button.CompareTag("Buttons"))
        {
            ButtonE.SetActive(true);
        }
       
    }
    void OnTriggerExit(Collider button)
    {
       
            ButtonE.SetActive(false);
        
    }
}
//targetObject.SetActive(!targetObject.activeSelf);    - обратное вкл