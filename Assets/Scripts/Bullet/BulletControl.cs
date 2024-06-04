using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float damage;
    private float enemyHp;
    

    void Start()
    {
        Destroy(gameObject,5);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            enemyHp = collision.GetComponent<EnemyController>().hp;
            enemyHp -= damage;
            collision.GetComponent<EnemyController>().hp = enemyHp;           
            Destroy(gameObject);
        }
    }
}
