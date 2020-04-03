using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public int _gems;
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForce = 5f;
    private bool _isGrounded = false;
    private bool _resetJump = false;
    public bool _isAlive;
    [SerializeField] private LayerMask _groundLayer;

    private PlayerAnimation _playerAnimation;
    //private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArcSpriteRenderer;
    private Transform _sprite;

    public int _health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        //_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSpriteRenderer = transform.Find("SwordArc").GetComponent<SpriteRenderer>();
        _sprite = transform.Find("Sprite");
        _isAlive = true;
        _health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive == true)
        {
            Movement();
            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || CrossPlatformInputManager.GetButtonDown("AButton") && IsGrounded() == true)
        {
            _playerAnimation.Attack();
        }
    }

    private void Movement()
    {
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");     //only 0 and 1
        _isGrounded = IsGrounded();

        Flip(move);

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("BButton") && IsGrounded() == true)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnimation.Jump(true);
        }

        _rigidBody.velocity = new Vector2(move * _speed, _rigidBody.velocity.y);

        _playerAnimation.Move(move);
    }

    private void Flip(float move)
    {
        if (move > 0)
        {
            //_spriteRenderer.flipX = false;
            _sprite.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);      //this can flip box collider 2d
            _swordArcSpriteRenderer.flipX = false;
            _swordArcSpriteRenderer.flipY = false;

            Vector3 newPos = _swordArcSpriteRenderer.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSpriteRenderer.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            //_spriteRenderer.flipX = true;
            _sprite.transform.localScale = new Vector3(-1 * (transform.localScale.x), transform.localScale.y, transform.localScale.z);
            _swordArcSpriteRenderer.flipX = true;
            _swordArcSpriteRenderer.flipY = true;
            
            Vector3 newPos = _swordArcSpriteRenderer.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSpriteRenderer.transform.localPosition = newPos;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void AddGems(int amount)
    {
        _gems += amount;
        UIManager.Instance.UpdateGemCount(_gems);
    }
    public void Damage()
    {
        if (_isAlive == false)
        {
            return;
        }
        _health--;
        UIManager.Instance.UpdateLives(_health);

        if (_health <= 0)
        {
            _isAlive = false;
            _playerAnimation.Dead();
        }
    }
}
