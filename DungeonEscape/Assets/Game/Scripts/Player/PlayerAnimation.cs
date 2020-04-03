using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArcAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArcAnimation = transform.Find("SwordArc").GetComponent<Animator>();
    }
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool isJumping)
    {
        _anim.SetBool("IsJumping", isJumping);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordArcAnimation.SetTrigger("SwordArc");
    }
    public void Dead()
    {
        _anim.SetTrigger("Dead");
    }
}
