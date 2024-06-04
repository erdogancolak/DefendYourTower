using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBulletControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject exploseArea;
    [Header("Values")]
    [SerializeField] private float damage;
    private float enemyHp;
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyHp = collision.GetComponent<EnemyController>().hp;
            enemyHp -= damage;
            collision.GetComponent<EnemyController>().hp = enemyHp;           
            Instantiate(exploseArea,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
