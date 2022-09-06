namespace DefaultNamespace
{
    public class PlayerAnimationController : AnimationController
    {
        bool collisionEnemy = false;
        
        public override void AnimateMove(float xMove, float yMove)
        {
            if (xMove > 0 && yMove < 0.5)
            {
                _animator.SetBool("Right", true);
                _animator.SetBool("Idle", false);
                _animator.SetBool("Back", false);
                _animator.SetBool("Forward", false);
            }


            if (xMove == 0 && yMove == 0 && !collisionEnemy)
            {
                SetIdle();
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

        public override void Hit()
        {
            _animator.SetBool("Hit", true);
            _animator.SetBool("Back", false);
            _animator.SetBool("Forward", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Left",false);
            _animator.SetBool("Right", false);
        }

        public override void SetIdle()
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Forward", false);
            _animator.SetBool("Right", false);
            _animator.SetBool("Left", false);
        }

        public void SetCollisionEnemy(bool collision)
        {
            collisionEnemy = collision;
        }
    }
}