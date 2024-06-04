using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float damage;
    private float enemyHp;

    private void Start()
    {
        Destroy(gameObject, .3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.name);
            enemyHp = collision.GetComponent<EnemyController>().hp;
            enemyHp -= damage;
            collision.GetComponent<EnemyController>().hp = enemyHp;

        }
    }
}
