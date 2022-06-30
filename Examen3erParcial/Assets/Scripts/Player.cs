using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Chest chest = default;
    private Rigidbody2D _rigidBody2D = default;
    private Animator _animator = default;

    [Header("Configuracion Personaje")]
    [SerializeField] private float playerSpeed = default;
    [SerializeField] private float jumpForce = default;
    [Header("Checador Suelo")]
    [SerializeField] private Vector3 checkGroundPosition = default;
    [SerializeField] private float checkGroudnRadious = default;
    [SerializeField] private bool isGround = default;
    [SerializeField] private LayerMask layerMask = default;
    [Header("Agachado")]
    private bool isDown = false;

    private bool canOpen = false;
    public bool isOpen = false;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isDown == false)
        {
            Vector2 vel = _rigidBody2D.velocity;
            vel.x = Input.GetAxisRaw("Horizontal") * playerSpeed;
            _rigidBody2D.velocity = vel;

            Physics2D.queriesHitTriggers = false;
            isGround = Physics2D.OverlapCircle(transform.position + checkGroundPosition, checkGroudnRadious, layerMask);
            Physics2D.queriesHitTriggers = true;

            _animator.SetInteger("Speed", Mathf.FloorToInt(Mathf.Abs(vel.x)));
            Flip(vel.x);
        }
    }

    void Update()
    {
        _animator.SetBool("isDucking", isDown);
        _animator.SetBool("isGrounded", isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            _rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.S) && isGround)
        {
            isDown = true;
            _rigidBody2D.velocity = Vector2.zero;
        }
        else
        {
            isDown = false;
        }

        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chest.OpenChestAnimation();
                isOpen = true;
                canOpen = false;
            }
        }
    }

    void Flip(float dir)
    {
        Vector3 LocalScale = transform.localScale;
        if (dir > 0)
        {
            LocalScale.x = 1f;
        }
        else if (dir < 0)
        {
            LocalScale.x = -1;
        }

        transform.localScale = LocalScale;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + checkGroundPosition, checkGroudnRadious);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MoveTrigger"))
        {
            CanvasManager.Instance.MoveTutorialOn();
        }

        if (collision.CompareTag("JumpTrigger"))
        {
            CanvasManager.Instance.JumpTutorialOn();
        }

        if (collision.CompareTag("Chest"))
        {
            if (isOpen == false)
            {
                CanvasManager.Instance.OpenChest();
                canOpen = true;
            }
            else
            {
                CanvasManager.Instance.OpenChestOff();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MoveTrigger"))
        {
            CanvasManager.Instance.MoveTutorialOff();
        }

        if (collision.CompareTag("JumpTrigger"))
        {
            CanvasManager.Instance.JumpTutorialOff();
        }

        if (collision.CompareTag("Chest"))
        {
            CanvasManager.Instance.OpenChestOff();
        }
    }
}
