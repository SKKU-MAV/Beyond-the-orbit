using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrystal : MonoBehaviour, IItem
{
    public int HPRestore = 30;
    public void Use(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        if (player != null)
        {
            player.RestoreHealth(HPRestore);
        }
        Destroy(gameObject);
    }
}
