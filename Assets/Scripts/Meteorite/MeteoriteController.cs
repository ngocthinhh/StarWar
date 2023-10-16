using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    [SerializeField] private float speed;

    private void Start()
    {
        transform.position = startPoint.transform.position;
    }

    private void Update()
    {
        Movemevt();
    }

    private void Movemevt()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, endPoint.transform.position) < 0.5f)
        {
            transform.position = startPoint.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInfo>().DecreaseHealth(100f);
        }
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    collision.gameObject.GetComponent<EnemyInfo>().DecreaseHealth(100f);
        //}
    }
}
