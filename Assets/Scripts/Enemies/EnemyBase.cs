using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }

    [SerializeField] private GameObject nextRound;
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        if (transform.childCount.Equals(0))
        {
            player.GetComponent<PlayerController>().round += 1;
            arrow.SetActive(true);
            Camera.main.GetComponent<CameraController>().moveSlow = true;
            nextRound.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
