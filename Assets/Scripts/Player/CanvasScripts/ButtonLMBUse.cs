using UnityEngine;

public class ButtonLMBUse : MonoBehaviour
{
    [SerializeField] GameObject ButtonLMB;

    void OnTriggerEnter(Collider button)
    {
        if (button.CompareTag("ButtonLMB"))
        {
            ButtonLMB.SetActive(true);
        }

    }
    void OnTriggerExit(Collider button)
    {

        ButtonLMB.SetActive(false);

    }
}
