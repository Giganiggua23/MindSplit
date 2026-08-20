using UnityEngine;
using System.Collections;

public class StartCaveAnimRS : MonoBehaviour
{
    [SerializeField] private GameObject CameraReal1;
    [SerializeField] private GameObject CameraReal2;

    [SerializeField] private GameObject CameraGroup1;
    [SerializeField] private GameObject CameraGroup2;
    [SerializeField] private GameObject divide;



    [SerializeField] private GameObject StartMovie;

    private Coroutine cameraCoroutine;



    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    void Start()
    {


    }


    public void SwitchCamera(bool _switch)
    {
        CameraReal1.SetActive(!_switch);
        CameraReal2.SetActive(_switch);

        audioSource.PlayOneShot(audioClip, 0.5f);
    }

    public void EndAnimation()
    {
        CameraGroup1.SetActive(true);
        CameraGroup2.SetActive(false);
        StartMovie.SetActive(false);
        divide.SetActive(true);
    }

    public void StartCameraSequence()
    {
        cameraCoroutine = StartCoroutine(CameraSequence());
    }


    private IEnumerator CameraSequence()
    {
        yield return new WaitForSeconds(0.1f);
        SwitchCamera(true);

        yield return new WaitForSeconds(1f);
        SwitchCamera(false);

        yield return new WaitForSeconds(1f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.8f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.8f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.6f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.6f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.5f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.4f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.45f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.3f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.2f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.1f);
        SwitchCamera(true);

        yield return new WaitForSeconds(0.05f);
        SwitchCamera(false);

        yield return new WaitForSeconds(0.02f);
        SwitchCamera(true);




        yield return new WaitForSeconds(0.01f);
        EndAnimation();
    }
}
