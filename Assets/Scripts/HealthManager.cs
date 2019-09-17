using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(int damage)
    {
        CurrentHP = CurrentHP - damage;
    }

    public void HealPlayer(int healing)
    {
        CurrentHP = CurrentHP + healing;
        if(CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }
}
