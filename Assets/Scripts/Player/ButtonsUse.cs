using UnityEngine;
using System.Collections.Generic;

public class ButtonsUse : MonoBehaviour
{
    [SerializeField] GameObject Stick;

    public List<GameObject> DominoPlits = new List<GameObject>();

    bool OnTrig;

    void Start()
    {

        SwitchKinematick(true);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           OnTrig = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTrig = false;
        }
    }



    void Update()
    {
        if (OnTrig && Input.GetKeyDown(KeyCode.E))
        {
            ButtonInput();
        }
    }


    




    private void ButtonInput()
    {
        Stick.SetActive(false);
        SwitchKinematick(false);
    }


    void SwitchKinematick(bool a)
    {
        foreach (GameObject obj in DominoPlits)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = a;
            }
        }
    }
}
