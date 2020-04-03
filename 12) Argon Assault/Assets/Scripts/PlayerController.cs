using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In meter per second")] [SerializeField] float controlSpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject jetFX;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-throw based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("FX")]
    [SerializeField] float deadSlowMo = 0.2f;
    [SerializeField] float deadSlowMoDuration = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip deadSFX;
    [SerializeField] [Range(0, 1)] float deadSFX_Volume = 0.5f;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.5f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    public void OnPlayerDeath()
    {
        StartCoroutine(TriggerDead());
    }

    IEnumerator TriggerDead()
    {
        GetComponent<AudioSource>().PlayOneShot(deadSFX, deadSFX_Volume);
        DisableControl();
        Time.timeScale = deadSlowMo;
        DestroyPlayer();

        yield return new WaitForSeconds(deadSlowMoDuration);

        Time.timeScale = 0f;

        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Stop();
        FindObjectOfType<LevelController>().HandleGameOverScene();
    }

    public void DisableControl()
    {
        isControlEnabled = false;
    }

    private void DestroyPlayer()
    {
        GetComponent<MeshRenderer>().enabled = false;
        jetFX.SetActive(false);
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ProcessTranslation()
    {
        //X
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawNewXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawNewXPosition, -xRange, xRange);

        //Y
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawNewYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawNewYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    public void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
