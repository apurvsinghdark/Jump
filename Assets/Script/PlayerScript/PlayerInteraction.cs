using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private Rigidbody rb;
    private bool playerDied;
    private CameraScript cameraFollow;
    
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.GetComponent<CameraScript>();
    }

    void Update()
    {
        if(!playerDied)
        {
            if(rb.velocity.sqrMagnitude > 60)
            {
                playerDied = true;
                cameraFollow.CanFollow = false;

                SoundManager.instance.GameEndSound();
                GameplayController.instance.Restart();
            }
        }
    }// update


    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Coin")
        {
            target.gameObject.SetActive(false);
            SoundManager.instance.PickedUpCoin(); 
            GameplayController.instance.IncrementScore();
        }

        if (target.tag == "Spike")
        {

            cameraFollow.CanFollow = false;
            gameObject.SetActive(false);

            SoundManager.instance.GameEndSound();
            
            GameplayController.instance.Restart();
        }
    } // trigger

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "EndPlatform")
        {
            SoundManager.instance.GameStartSound();
            GameplayController.instance.Restart();
        }
    }


}// class
