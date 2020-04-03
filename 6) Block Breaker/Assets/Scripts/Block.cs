using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit;          //Debug purposes

    private void Start()
    {
        CountBreakaleBlocks();
    }

    private void CountBreakaleBlocks()
    {
        level = FindObjectOfType<Level>();       //Call method from Level.cs
        if (tag == "Breakable")
        {
            level.CountBlocks();           //Count Blocks
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddScore();      //Call AddScore method from GameStatus.cs
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);      //Play sound at main camera position. PlayClipAtPoint() still play even block destroyed
    }

    private void TriggerVFX()
    {
        GameObject sparkles = Instantiate(blockVFX, transform.position, transform.rotation);        //Instantiate() duplicate a prefab in scene
        Destroy(sparkles, 1f);
    }
}
