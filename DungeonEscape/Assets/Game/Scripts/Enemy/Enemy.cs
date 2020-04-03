using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _gems;
    [SerializeField] protected Transform _pointA, _pointB;
    [SerializeField] protected GameObject _gemsPrefab;

    protected Vector3 _currentTarget;
    protected Animator _animator;
    //protected SpriteRenderer _spriteRenderer
    protected Transform _sprite;

    protected bool _isStopMoving = false;
    protected bool _isAlive = true;
    protected Player _player;
    private void Start()
    {
        Inititate();
    }

    public virtual void Inititate()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator not founded in " + gameObject);
        }

        /*_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogError("Animator not founded in " + gameObject);
        }*/

        _sprite = transform.Find("Sprite"); 
        if (_sprite == null)
        {
            Debug.LogError("Sprite GameObject not founded in " + gameObject);
        }

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is not founded");
        }
    }

    public virtual void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _animator.GetBool("InCombat") == false)
        {
            return;
        }
        
        if (_isAlive == true)
        {
            Movement();
            Flip();
            CombatToMovement();
        }
    }

    public virtual void Movement()
    {
        //normal movement
        if (_currentTarget == _pointA.position)
        {
            //_spriteRenderer.flipX = true;
            _sprite.transform.localScale = new Vector3(-1 * (transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            //_spriteRenderer.flipX = false;
            _sprite.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (transform.position == _pointA.position)
        {
            _currentTarget = _pointB.position;
            _animator.SetTrigger("Idle");
        }
        else if (transform.position == _pointB.position)
        {
            _currentTarget = _pointA.position;
            _animator.SetTrigger("Idle");
        }

        if (_isStopMoving == false)
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    public virtual void CombatToMovement()
    {
        //change from in combat to normal movement
        float distance = Vector3.Distance(transform.localPosition, _player.transform.localPosition);

        if (distance > 2f)
        {
            StartMoving();
            _animator.SetBool("InCombat", false);
        }
    }

    public virtual void Flip()
    {
        //When in combat
        Vector3 direction = _player.transform.position - transform.position;

        if (direction.x > 0 && _animator.GetBool("InCombat") == true)
        {
            //_spriteRenderer.flipX = false;
            _sprite.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0 && _animator.GetBool("InCombat") == true)
        {
            _sprite.transform.localScale = new Vector3(-1 * (transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public virtual void StopMoving()
    {
        _isStopMoving = true;
    }
    public virtual void StartMoving()
    {
        _isStopMoving = false;
    }
    public virtual void SpawnDiamond()
    {
        GameObject diamond = Instantiate(_gemsPrefab, transform.position, Quaternion.identity);
        diamond.GetComponent<Diamond>()._gems = _gems;
    }
}
