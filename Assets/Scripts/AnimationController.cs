using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AnimationController : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        

        public virtual void AnimateMove( float xMove, float yMove)
        {
            
        }

        public virtual void Hit()
        {
            
        }

        public virtual void SetIdle()
        {
            
        }
    }
}