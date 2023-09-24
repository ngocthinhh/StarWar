using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBagController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }

    public void SetPlayer(GameObject gameObject)
    {
        player = gameObject;
    }
}
