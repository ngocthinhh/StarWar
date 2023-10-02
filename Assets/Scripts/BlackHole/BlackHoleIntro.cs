using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleIntro : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject round1;

    [SerializeField] private Animator animator;

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
        player.SetActive(true);

        yield return new WaitForSeconds(2f);
        round1.SetActive(true);
    }
}
