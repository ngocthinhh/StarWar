using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private void Update()
    {
        Move();

        DestroyWhenOutMap();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10f);
    }

    private void DestroyWhenOutMap()
    {
        if (transform.position.x < -23 || transform.position.x > 23)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -23 || transform.position.y > 23)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
