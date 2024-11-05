using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int StartLife = 10;

    public bool DestroyOnKill = false;

    public int _CurrentLife;

    public bool IsDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        IsDead = false;
        _CurrentLife = StartLife;

    }

    public void Damage(int damage)
    {
        if (IsDead) return;

        _CurrentLife -= damage;

        if(_CurrentLife <= 0)
        {
            Kill();
        }
    }

   private void Kill()
    {
        IsDead = true;

        if(DestroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
