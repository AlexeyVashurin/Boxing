using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] protected int healthCount = 100;
        [SerializeField] private PlayerAnimationController playerAnimationController;
        private string enemyTag = "Enemy";
        private bool win = false;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                other.GetComponent<EnemyHealth>().Damage();
                playerAnimationController.SetCollisionEnemy(true);
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
            if (other.gameObject.CompareTag(enemyTag))
            {
               // other.GetComponent<Health>().StopAllCoroutines();
                playerAnimationController.SetCollisionEnemy(false);
                playerAnimationController.SetIdle();
                StopAllCoroutines();
            }
        }
        
        private void Update()
        {
            if (healthCount <= 0)
            {
                Death();
            }
        }

        public void Damage()
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
            //playerAnimationController.SetIdle();
        }


        void Death()
        {
            gameObject.GetComponent<Animator>().enabled = false;
            GetComponent<RotationController>().enabled = false;
        }

        public void Win()
        {
            playerAnimationController.SetCollisionEnemy(false);
            StopAllCoroutines();
            playerAnimationController.SetIdle();
            
        }
    }
}