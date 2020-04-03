using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.81f;
    [Header("Gun")]
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _hitMarkerPrefab;
    [SerializeField] private GameObject _hitMarkerParent;
    [SerializeField] private AudioSource _shootingAudio;
    private int _currentAmmo;
    [SerializeField] private int _maxAmmo = 100;
    private bool _isReloading = false;
    private bool _cursorVisible;
    private UIManager _uIManager;
    [Header("Pickup Logic")]
    public bool _hasCoin;
    private bool _hasWeapon = false;
    //private Vector3 centerScreen;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        //hide mouse cursor
        InvisibleCursor();
        _cursorVisible = false;
        //centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        _currentAmmo = _maxAmmo;
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uIManager.UpdateAmmo(_currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasWeapon)
        {
            Shoot();
            if (Input.GetKeyDown(KeyCode.R) && _currentAmmo < _maxAmmo && _isReloading == false || _currentAmmo == 0 && _isReloading == false)
            {
                StartCoroutine(Reload());
            }
        }
        DisplayCursor();
        CalculateMovement();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            _currentAmmo--;
            _uIManager.UpdateAmmo(_currentAmmo);
            _muzzleFlash.SetActive(true);
            if (_shootingAudio.isPlaying == false)
            {
                _shootingAudio.Play();
            }
            //Ray rayOrigin = Camera.main.ScreenPointToRay(centerScreen);
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.transform.name);
                GameObject hitmarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
                hitmarker.transform.parent = _hitMarkerParent.transform;
                Destroy(hitmarker, 0.1f);

                Destructible crate = hitInfo.transform.GetComponent<Destructible>();
                if (crate != null)
                {
                    crate.DestroyCrate();
                }
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _shootingAudio.Stop();
        }
    }

    IEnumerator Reload()
    {
        _isReloading = true;
           yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uIManager.UpdateAmmo(_currentAmmo);
        _isReloading = false;
    }

    private void DisplayCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _cursorVisible == false)
        {
            VisibleCursor();
            _cursorVisible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _cursorVisible == true)
        {
            InvisibleCursor();
            _cursorVisible = false;
        }
    }

    private static void VisibleCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private static void InvisibleCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;     //Apply gravity

        velocity = transform.transform.TransformDirection(velocity);
        _characterController.Move(velocity * Time.deltaTime);
    }

    public void EnableWeapon()
    {
        _weapon.SetActive(true);
        _hasWeapon = true;
    }
}
