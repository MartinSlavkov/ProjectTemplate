using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public delegate void OnDamage(float damage, GameObject damageSource);
    public event OnDamage OnDamageEvent;

    public void Damage(float damage, GameObject damageSource)
    {
        if (OnDamageEvent != null)
        {
            OnDamageEvent.Invoke(damage, damageSource);
        }
    }
}
