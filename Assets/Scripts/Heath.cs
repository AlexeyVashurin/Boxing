using System;
using System.Collections;
using DefaultNamespace;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Heath : MonoBehaviour
{
    public int healthCount = 100;
    private string enemyTag = "Enemy";
    private string playerTag = "Player";

    public AnimationController animationController;
    

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            other.GetComponent<Heath>().Damage();
            
        }

        if (other.gameObject.CompareTag(playerTag))
        {
            other.GetComponent<Heath>().Damage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag) || other.gameObject.CompareTag(playerTag))
        {
            other.GetComponent<Heath>().StopAllCoroutines();
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
    }


    void Death()
    {
        
        GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        GetComponent<RotationController>().enabled = false;
        
    }
}