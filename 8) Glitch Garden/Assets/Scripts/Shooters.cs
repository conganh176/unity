using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    [SerializeField] GameObject bullet, gun;
    AttackersSpawner myLaneSpawner;
    Animator animator;
    GameObject bulletParent;
    const string BULLET_PARENT_NAME = "bullets";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateBulletParent();
    }

    private void CreateBulletParent()
    {
        bulletParent = GameObject.Find(BULLET_PARENT_NAME);

        if (!bulletParent)
        {
            bulletParent = new GameObject(BULLET_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackersSpawner[] spawners = FindObjectsOfType<AttackersSpawner>();

        foreach (AttackersSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, gun.transform.position, gun.transform.rotation) as GameObject;
        newBullet.transform.parent = bulletParent.transform;
    }
}
