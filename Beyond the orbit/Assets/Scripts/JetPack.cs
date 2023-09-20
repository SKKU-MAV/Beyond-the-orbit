using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour, IItem
{
    public void Use(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        if(player != null)
        {
            player.JetPackOn();
        }
        Destroy(gameObject);
    }
}
