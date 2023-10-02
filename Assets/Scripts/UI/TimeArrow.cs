using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeArrow : MonoBehaviour
{
    [SerializeField] private float countTime;

    private void OnEnable()
    {
        countTime = 3f;
    }

    void Update()
    {
        countTime -= Time.deltaTime;

        if (countTime < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
