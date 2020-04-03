﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    //SFX
    [SerializeField] AudioClip eating;

    /*private void Awake()
    {
        FindObjectOfType<LevelController>().attackerSpawned();
    }*/

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.attackerDestroyed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void playSound()
    {
        AudioSource.PlayClipAtPoint(eating, Camera.main.transform.position, PlayerPrefbController.GetMasterVolume());
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.dealDamage(damage);
        }
    }
}
