using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyArea area;
    public int health;
    

    public void TakeDamage(int amt)
    {
        //Check for shield stuff here, I would assume
        health -= amt;

        if (health <= 0)
            Death();
    }

    public void Death()
    {
        print("YOu win!");
    }
}
