using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Player _player;
    Vector3 _direction;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is not founded");
        }

        _direction = _player.transform.position - transform.position;
        Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        if (_direction.x < 0)
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        else if (_direction.x > 0)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.Damage();
            Destroy(gameObject);
        }
    }
}
