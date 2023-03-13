using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 5;

    ScoreBoard scoreBoard;
    GameObject parentObject;

    private void Start()
    {
        parentObject = GameObject.FindWithTag("spawnAt");
        scoreBoard = FindObjectOfType<ScoreBoard>();
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitEffect, transform.position, Quaternion.identity);
        vfx.transform.SetParent(parentObject.transform);
        hitPoints--;
    }

    void KillEnemy()
    {
        scoreBoard.Increasescore(scorePerHit);
        GameObject vfx = Instantiate(deathEffect, transform.position, Quaternion.identity);
        vfx.transform.SetParent(parentObject.transform);
        Destroy(gameObject);
    }
}
