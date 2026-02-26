using UnityEngine;

public class ClosetDomino : MonoBehaviour
{
    [SerializeField] PlayerStateManager _playerStateManager;
    
    public bool DragTrigUse = false;

    private GameObject Test => gameObject;


    bool _isDragCloset = false;

    Vector3 offset;
    private Transform playertrans;

    private Vector3 _velocity = Vector3.zero;

    void Awake()
    {
        if (playertrans == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playertrans = player.transform;
                
                _playerStateManager = player.GetComponent<PlayerStateManager>();
            }

            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && DragTrigUse && _playerStateManager != null)
        {
            _playerStateManager.ClosetUP(false, gameObject);
            offset = transform.position - playertrans.position;
            
            _isDragCloset = !_isDragCloset;
        }


        if (_isDragCloset)
        {
            _playerStateManager.ClosetUP(true, gameObject);

            Vector3 targetPosition = playertrans.position + offset;
            float smoothTime = 0.01f; 
            float maxSpeed = Mathf.Infinity; 

            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref _velocity,
                smoothTime,
                maxSpeed
            );
        }
    }
}
