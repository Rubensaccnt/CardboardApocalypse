﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAlpha : MonoBehaviour {

    GameObject player;

    [SerializeField]
    string playerName;

    [SerializeField]
    float moveSpeed = 1;

    [SerializeField]
    public float initialHealth = 10;

    public float health;
    [SerializeField]
    string gameManagerName= "MonsterGameManager";

    [SerializeField]
    GameObject destroyEffect;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            CheckHealth();
        }
    }



	// Use this for initialization
	void Start () {
        player = GameObject.Find(playerName);
        health = initialHealth;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime);

        Vector3 lookRot = (player.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(lookRot);
	}
    
    void CheckHealth()
    {
        if (health <= 0)
        {
            KillMonster();
        }
    }

    public void KillMonster()
    {
        GameObject.Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SpawnMonster();
    }

    void SpawnMonster()
    {
        // call game manager for spawner event
        GameObject.Find(gameManagerName).GetComponent<MonsterGameManager>().Spawn();
    }

}
