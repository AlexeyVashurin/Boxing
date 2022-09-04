using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]private Animator _animator;

        private void Awake()
        {
            
        }

        public void AnimateMove( float xMove, float yMove)
        {
            if (xMove > 0 && yMove < 0.5)
            {
                _animator.SetBool("Right", true);
                _animator.SetBool("Idle", false);
                _animator.SetBool("Back", false);
                _animator.SetBool("Forward", false);
            }

            if (xMove < 0 && yMove < 0.5)
            {
                _animator.SetBool("Left", true);
                _animator.SetBool("Idle", false);
                _animator.SetBool("Back", false);
                _animator.SetBool("Forward", false);
            }

            if (yMove > 0 && xMove > -0.5 && xMove < 0.5)
            {
                _animator.SetBool("Forward", true);
                _animator.SetBool("Hit", false);
                _animator.SetBool("Back", false);
                _animator.SetBool("Idle", false);
                _animator.SetBool("Left", false);
                _animator.SetBool("Right", false);
            }
            else if (yMove < 0)
            {
                _animator.SetBool("Back", true);
                _animator.SetBool("Forward", false);
                _animator.SetBool("Hit", false);
                _animator.SetBool("Idle", false);
                _animator.SetBool("Left", false);
                _animator.SetBool("Right", false);
            }
        }

        public void Hit()
        {
            _animator.SetBool("Hit", true);
            _animator.SetBool("Back", false);
            _animator.SetBool("Forward", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Left",false);
            _animator.SetBool("Right", false);
        }

        public void SetIdle()
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Forward", false);
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", false);
        }
    }
}