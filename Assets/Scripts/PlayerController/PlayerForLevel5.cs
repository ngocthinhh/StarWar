using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForLevel5 : MonoBehaviour
{
    public GameObject enemyBase;
    public GameObject enemyBase1;
    public GameObject enemyBase2;

    public GameObject enemyBaseUsing;

    private PlayerController playerController;

    [SerializeField] private GameObject blackHolePrefab;
    [SerializeField] private GameObject blackHoleEnemies;
    [SerializeField] private GameObject bulletBagEnemy;

    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckRound();

        SetMinMaxOfX();
        SetMinMaxOfY();
    }

    private void CheckRound()
    {
        if (playerController.round == 1)
        {
            enemyBaseUsing = enemyBase;
        }
        else if (playerController.round == 2)
        {
            enemyBaseUsing = enemyBase1;
        }
        else if (playerController.round == 3)
        {
            enemyBaseUsing = enemyBase2;
        }
    }

    private void SetMinMaxOfX()
    {
        float range = 4f;
        if (transform.position.x <= -16f)
        {
            minX = -16f;
            maxX = transform.position.x + range;
        }
        else if (transform.position.x >= 16f)
        {
            minX = transform.position.x - range;
            maxX = 16f;
        }
        else if (transform.position.x - range <= -16f)
        {
            minX = -16f;
            maxX = transform.position.x + range;
        }
        else if (transform.position.x + range >= 16f)
        {
            minX = transform.position.x - range;
            maxX = 16f;
        }
        else
        {
            minX = transform.position.x - range;
            maxX = transform.position.x + range;
        }
    }

    private void SetMinMaxOfY()
    {
        float range = 2.5f;
        if (transform.position.y <= -16f)
        {
            minY = -16f;
            maxY = transform.position.y + range;
        }
        else if (transform.position.y >= 16f)
        {
            minY = transform.position.y - range;
            maxY = 16f;
        }
        else if (transform.position.y - range <= -16f)
        {
            minY = -16f;
            maxY = transform.position.y + range;
        }
        else if (transform.position.y + range >= 16f)
        {
            minY = transform.position.y - range;
            maxY = 16f;
        }
        else
        {
            minY = transform.position.y - range;
            maxY = transform.position.y + range;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPurple"))
        {
            // TAO THEM ENEMY
            GameObject blackHoleEnemy = Instantiate(blackHolePrefab,
                new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f),
                Quaternion.identity, blackHoleEnemies.transform);

            blackHoleEnemy.GetComponent<BlackHoleEnemy>().enemyBase = enemyBaseUsing;
            blackHoleEnemy.GetComponent<BlackHoleEnemy>().bulletBagEnemy = bulletBagEnemy;
            //
        }
    }
}
