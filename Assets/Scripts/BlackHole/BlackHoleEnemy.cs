using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject enemyPrefab;

    public GameObject enemyBase;
    public GameObject bulletBagEnemy;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void Start()
    {
        animator.Play("Intro");

        StartCoroutine(StartAfter());
    }

    IEnumerator StartAfter()
    {
        yield return new WaitForSeconds(1f);
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation, enemyBase.transform);
        enemy.GetComponent<EnemyPlaneController>().SetBulletBag(bulletBagEnemy);

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
