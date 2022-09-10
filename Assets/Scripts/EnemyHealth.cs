using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] protected int healthCount = 100;
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private EnemyAnimationController enemyAnimationController;
        private string enemyTag = "Player";
        private Collider lastCollisionCollider;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                other.GetComponent<PlayerHealth>().Damage();
                enemyAnimationController.SetCollisionEnemy(true);
                lastCollisionCollider = other;

            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(enemyTag))
            {
                //playerAnimationController.SetCollisionEnemy(true);
                enemyAnimationController.Hit();
            }
        
        }
        
        private void OnTriggerExit(Collider other)
        {
           
            if (other.gameObject.CompareTag(enemyTag))
            {
                //lastCollisionCollider.GetComponent<Health>().StopAllCoroutines();
                enemyAnimationController.SetCollisionEnemy(false);
                enemyAnimationController.SetIdle();
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
        }


        void Death()
        {
            capsuleCollider.center = new Vector3(100, 100, 100);
            gameObject.GetComponent<Animator>().enabled = false;
            GetComponent<RotationController>().enabled = false;
            lastCollisionCollider.GetComponent<PlayerHealth>().Win();
            StopAllCoroutines();
            
            
        }
        
    }
}