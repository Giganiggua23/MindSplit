using UnityEngine;

public class FlashBranch : MonoBehaviour
{
    public StartAnimation _startAnimation;

    [SerializeField] private bool IsEnd;
    private bool IsEnter = false;

   public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsEnd)
        {
            _startAnimation.SwitchCamera(true);
        }

        if (other.CompareTag("Player") && IsEnd && !IsEnter)
        {
            _startAnimation.StartCameraSequence();
            IsEnter = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !IsEnd)
        {
           
            _startAnimation.SwitchCamera(false);
        }
    }
}
