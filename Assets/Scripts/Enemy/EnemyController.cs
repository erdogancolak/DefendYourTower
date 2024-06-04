using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Transform> movePoints;
    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    public float hp;
    private int currentPoint;

    void Start()
    {
        currentPoint = 0;
    }
    void Update()
    {
        Move();
        if(hp <= 0)
        {
            Destroy(gameObject);
            GameManager.coin += 10;
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePoints[currentPoint].position) <= 0)
        {
            if (currentPoint == movePoints.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                currentPoint++;
                characterRotation();
            }
        }
    }

    void characterRotation()
    {
        switch (currentPoint)
        {
            case 1:
            case 6:
            case 8:
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;
            case 2:
            case 4:
            case 5:
            case 9:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case 7:
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;
        }
    }
}
