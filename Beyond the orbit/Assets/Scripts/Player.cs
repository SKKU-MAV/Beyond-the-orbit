using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int starGauge = 0;
    public int health = 100;
    public bool jetPackOn = false;
    [SerializeField] float jetPackTime;

    float lastJetPackT;

    // Start is called before the first frame update
    void Start()
    {
        lastJetPackT = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(jetPackOn && Time.time >= lastJetPackT + jetPackTime)
        {
            JetPackOff();
        }
    }

    public void JetPackOn()
    {
        jetPackOn = true;
    }

    void JetPackOff()
    {
        jetPackOn = false;
    }
    public void AddStarDust(int amount)
    {
        starGauge += amount;
        if(starGauge >= 100)
        {
            AddConstellation();
            starGauge = 0;
        }
    }

    private void AddConstellation()
    {
        
    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        if(health >= 100)
        {
            health = 100;
        }
    }
}
