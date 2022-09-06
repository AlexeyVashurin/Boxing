using System;
using System.Collections;
using DefaultNamespace;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Heath : MonoBehaviour
{
    [SerializeField] private int healthCount = 100;
    [SerializeField] private PlayerAnimationController playerAnimationController; 
    private string enemyTag = "Enemy";
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            other.GetComponent<Heath>().Damage();
            playerAnimationController.SetCollisionEnemy(true);
            
        }

        if (other.gameObject.CompareTag(playerTag))
        {
            other.GetComponent<Heath>().Damage();
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            
            //playerAnimationController.SetCollisionEnemy(true);
            playerAnimationController.Hit();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag) || other.gameObject.CompareTag(playerTag))
        {
            other.GetComponent<Heath>().StopAllCoroutines();
            playerAnimationController.SetCollisionEnemy(false);
            playerAnimationController.SetIdle();
        }
    }

    private void Update()
    {
        if (healthCount <= 0)
        {
            Death();
        }
    }

    void Damage()
    {
        StartCoroutine(DoDamage());
    }


    IEnumerator DoDamage()
    {
        while (healthCount > 0)
        {
            healthCount -= Random.Range(5, 20);
            //animationController.Hit();
            yield return new WaitForSeconds(1f);
        }
        playerAnimationController.SetIdle();
    }


    void Death()
    {
        //GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<RotationController>().enabled = false;
    }
}