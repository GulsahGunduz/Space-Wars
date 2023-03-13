using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crushEffect;


    private void OnTriggerEnter(Collider other)
    {
        StartCrush();
    }

    void StartCrush()
    {
        crushEffect.Play();
        GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Collider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;

        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindex);
    }
}
