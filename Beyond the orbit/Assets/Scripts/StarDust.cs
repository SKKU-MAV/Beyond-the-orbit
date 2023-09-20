using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDust : MonoBehaviour, IItem
{
    public int starCharge = 30;
    public void Use(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        if(player != null)
        {
            player.AddStarDust(starCharge);
        }
    }
}
