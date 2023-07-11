using Cinemachine;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThirdpersonMovement : NetworkBehaviour
{
    public CharacterController controller;
    public Transform cam;
    [SerializeField] private CinemachineFreeLook vc;
    [SerializeField] private AudioListener listener;

    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private int isJumpingHash;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    public GameObject canvas;

    //////////////////////////////

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;


    private bool isGrounded;
    private Vector3 playerVelocity;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;


    private bool isGM = false;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        controller = GetComponent<CharacterController>();

        animator = GetComponentInChildren<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }



    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (canvas.activeSelf)
            return;

        PlayerThirdPersonMovement();
    }


    private void PlayerThirdPersonMovement()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        isGrounded = controller.isGrounded;


        /////////////////////////////////////////////////////////////////////////////////////////////////
        ///ver New input system
        /////////////////////////////////////////////////////////////////////////////////////////////////
        //Ve quai os input do utilizador
        float hotizotal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hotizotal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Poe os input do utilizador em angulos
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //Vira o personagem para onde a camara esta
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Faz o personagem andar para onde a camara esta virada
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //move do personagem
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool forwardPressesd = Input.GetKey(KeyCode.W);
        bool jumpPressesd = Input.GetKey(KeyCode.Space);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);


        if (!isWalking && forwardPressesd)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressesd)
        {
            animator.SetBool("isWalking", false);
        }


        if (!isRunning && (forwardPressesd && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressesd || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }




        #region Sprint

        //ve se carregou na tecla shift
        if (!isRunning && (forwardPressesd && runPressed))
        {
            animator.SetBool(isRunningHash, true);
            speed = 8f;
        }

        //ve se largou na tecla shift
        if (isRunning && (!forwardPressesd || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
            speed = 6f;
        }

        #endregion

        #region Saltar
        //Ve se carregou na tecla de saltar
        if (jumpPressesd)
        {
            if (isGrounded)
            {
                //Salta
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);

                animator.SetBool(isJumpingHash, true);

            }
        }

        if (!jumpPressesd)
        {
            animator.SetBool(isJumpingHash, false);
        }
        #endregion
    }


    private void FixedUpdate()
    {
        #region Gravidade
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
        #endregion
    }
}
