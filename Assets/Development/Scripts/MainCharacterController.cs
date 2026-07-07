using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Animator _animator;

    private Rigidbody _rb;

    private float _desiredXPosition;

    private int _health = 3;

    private bool _isInterpolating;
    private bool _isGrounded;
    private bool _isPushing;
    private bool _isGameStarted = false;
    public bool IsGameStarted
    {
        get { return _isGameStarted; }
        set { _isGameStarted = value; }
    }

    private UIManager _uiManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        AudioManager.Instance.PlayGameMusic();
        _uiManager = FindAnyObjectByType<UIManager>();

    }

    void FixedUpdate()
    {
        if (!IsGameStarted)
        {
            return;
        }
        MoveCharacter();
        LeftRightMovement();
    }

    public void MoveCharacter()
    {
        
        if (!_isPushing)
        {
            _rb.linearVelocity = (transform.forward * moveSpeed) + (Vector3.up * _rb.linearVelocity.y);
        }
    }

    public void SetRunning(bool value)
    {
        _animator.SetBool("IsRunning", value);
    }

    private void LeftRightMovement()
    {
        if (_isInterpolating)
        {
            Vector3 desiredPosition = new Vector3(_desiredXPosition, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, 7 * Time.deltaTime);

            if (transform.position == desiredPosition)
            {
                _isInterpolating = false;
            }
        }
    }

    

    public void ChangePosition(bool isRight)
    {
        if (isRight)
        {
            if (_desiredXPosition >= 2)
            {
                return;
            }
            _desiredXPosition = _desiredXPosition + 2;
        }
        else
        {
            if (_desiredXPosition <= -2) 
            {
                return;
            }
            _desiredXPosition = _desiredXPosition - 2;
        }

        _isInterpolating = true;
    }

    public void JumpCharacter()
    {
        if (!IsGameStarted)
        {
            return;
        }
        if (_isGrounded) 
        {
            _rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            _animator.SetTrigger("Jump");
            AudioManager.Instance.PlayJumpSound(); 

        }
    }

    public void OnHitObstacle()
    {
        _health--;

        _uiManager.UpdateHealth(_health);

        if (_health <= 0)
        {
            AudioManager.Instance.PlayDeathSound();
            _rb.linearVelocity = Vector3.zero;
            _animator.SetTrigger("Death");
            _uiManager.HandleCharacterDeath();
            IsGameStarted = false;
            StartCoroutine(EndGame());
        }
        else
        {
            StartCoroutine(PushCharacter());
        }
    }
    public IEnumerator PushCharacter()
    {
        _isPushing = true;
        AudioManager.Instance.PlayObstacleSound();
        _rb.AddForce(transform.forward * -2.5f, ForceMode.Impulse);
        _animator.SetTrigger("Back");
        yield return new WaitForSeconds(1.5f);
        _isPushing = false;
    }

    public IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(50);
        if(moveSpeed < 25)
        {
            moveSpeed += 0.25f;
            StartCoroutine(IncreaseSpeed());
        }
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("S_GameScene");
    }

    public void RightFootStepSfx()
    {
            AudioManager.Instance.PlayStepRightFootSound();
    }

    public void LeftFootStepSfx()
    {
            AudioManager.Instance.PlayStepLeftFootSound();
    }


    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
