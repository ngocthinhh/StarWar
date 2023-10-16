using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float strength;

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

    public void SetStrength(float num)
    {
        strength = num;
    }

    public float GetStrength()
    {
        return strength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Boss") && !collision.CompareTag("HealthSafe")
            && !collision.CompareTag("BulletPlayer") && !collision.CompareTag("BulletOrange") && !collision.CompareTag("BulletGreen")
            && !collision.CompareTag("BulletWhite") && !collision.CompareTag("BulletPurple") && !collision.CompareTag("BulletGolden"))
        {
            Destroy(gameObject);
        }
    }
}
