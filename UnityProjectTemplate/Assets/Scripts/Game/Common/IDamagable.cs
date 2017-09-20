using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IDamagable
    {
        void DoDamage(float damage, GameObject damageSource);
    }
}
