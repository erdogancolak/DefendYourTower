using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<GameObject> targetEnemy;
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject Bullet;
    [Header("Values")]
    [SerializeField] private float rotationModifier;
    [SerializeField] private float turretSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;
    private float _timer;
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        Fire();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (targetEnemy.Count > 0)
        {
            WeaponRotation(targetEnemy[0]);
        }
        else
        {
            WeaponRotation(Spawner);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targetEnemy.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targetEnemy.Remove(collision.gameObject);
        }
    }

    private void WeaponRotation(GameObject gameobject)
    {
        Vector3 vectorToTarget = transform.position - gameobject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turretSpeed);
    }

    private void Fire()
    {
        if(_timer >= fireRate && targetEnemy.Count > 0)
        {
            _timer = 0;
            var spawnedBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnedBullet.transform.rotation = transform.rotation;
            Vector2 dir = targetEnemy[0].transform.position - spawnedBullet.transform.position;
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        }
    }


}
