using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private MainCharacterController mainCharacterController;

    public static InputManager Instance;

    private bool _startGame = false;
    public bool StartGame
    {
        get { return _startGame; }
        set { _startGame = value; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += OnMovePerformed;
        playerInput.actions["Jump"].performed += OnJumpPerformed;
        playerInput.actions["Start"].performed += OnStartGamePerformed;
    }
    private void OnDisable()
    {
        playerInput.actions["Move"].performed -= OnMovePerformed;
        playerInput.actions["Jump"].performed -= OnJumpPerformed;
        playerInput.actions["Start"].performed -= OnStartGamePerformed;

    }

    public void OnStartGamePerformed(InputAction.CallbackContext ctx)
    {      
        if (!StartGame)
        {
            StartGame = true;
            mainCharacterController.IsGameStarted = true;
            mainCharacterController.StartCoroutine(mainCharacterController.IncreaseSpeed());
            UIManager.Instance.StartGame(); 
            mainCharacterController.SetRunning(true);

        }
    }


    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        Vector2 moveVector = ctx.ReadValue<Vector2>();
        if (moveVector.x == 0) return;

        if (moveVector.x > 0)
        {
            mainCharacterController.ChangePosition(true);  // Sadece tam basýldýðýnda saða git
        }
        else if (moveVector.x < 0)
        {
            mainCharacterController.ChangePosition(false); // Sadece tam basýldýðýnda sola git
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        mainCharacterController.JumpCharacter();
    }


}
