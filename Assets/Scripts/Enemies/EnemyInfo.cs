using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    //=============== HEALTH ===============
    private float maxHealth;
    private float currentHealth;

    public void SetMaxHealth(float heal)
    {
        maxHealth = heal;
        currentHealth = maxHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(float heal)
    {
        currentHealth += heal;
    }

    public void DecreaseHealth(float heal)
    {
        currentHealth -= heal;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
        }
    }
    //=====================================

    //============= STRENGTH ==============
    private float strength;

    public void SetStrength(float str)
    {
        strength = str;
    }

    public float GetStrength()
    {
        return strength;
    }

    public void IncreaseStrength(float str)
    {
        strength += str;
    }

    public void DecreaseStrength(float str)
    {
        strength -= str;
    }
    //=====================================

    //============= SPEED ==============
    private float speed;

    public void SetSpeed(float sp)
    {
        speed = sp;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void IncreaseSpeed(float sp)
    {
        speed += sp;
    }

    public void DecreaseSpeed(float sp)
    {
        speed -= sp;
    }
    //=====================================
}
