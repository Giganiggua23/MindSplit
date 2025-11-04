using UnityEngine;

public class Movement : PlayerStateManager
{
    public CharacterController controller;

    [SerializeField] private float speed = 8f;
    private float _gravity = -19.62f;
    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //SFX

    [SerializeField] private LayerMask groundMaskStone;
    bool isGroundedStone;
    [SerializeField] private LayerMask groundMaskWood;
    bool isGroundedWood;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] StoneWalkSoundsClips;
    [SerializeField] AudioClip[] WoodWalkSoundsClips;

    float stepTimer = 0;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isGroundedStone = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskStone);
        isGroundedWood = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskWood);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        AWalk((Mathf.Abs(x) > 0.4f || Mathf.Abs(z) > 0.4f));


        if (x == 1 && Input.GetKey(KeyCode.LeftShift) || z == 1 && Input.GetKey(KeyCode.LeftShift) || x == -1 && Input.GetKey(KeyCode.LeftShift) && !_IsUse)
        {
            
            if (isGrounded)
            {
                speed = 10f;


                _isRunning = true;
            }
            else
            {
                speed = 6f;
            }


        }
        else
        {
            if (isGrounded)
            {
                speed = 8f;
            }
            else
            {
                speed = 5f;
            }
            _isRunning = false;

        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && _aWalk)
        {
            speed = speed / 1.3f ;
        }

        if (_IsUse)
        {
            speed = 0;
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded && !_IsUse)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity);

        }

        velocity.y += _gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (_aWalk && isGrounded)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= 0.45f && isGroundedStone)
            {
                PlayStoneFootstep();
                stepTimer = 0; 

            }
            if (stepTimer >= 0.5f && isGroundedWood)
            {
                PlayWoodFootstep();
                stepTimer = 0;

            }
        }
    }

    // SFX

    void PlayStoneFootstep()
    {
        if (StoneWalkSoundsClips.Length > 0)
        {
            AudioClip randomClip = StoneWalkSoundsClips[Random.Range(0, StoneWalkSoundsClips.Length)];
            audioSource.PlayOneShot(randomClip, 0.3f);
        }
    }

    void PlayWoodFootstep()
    {
        if (WoodWalkSoundsClips.Length > 0)
        {
            AudioClip randomClip = WoodWalkSoundsClips[Random.Range(0, WoodWalkSoundsClips.Length)];
            audioSource.PlayOneShot(randomClip, 0.35f);
        }
    }
}
