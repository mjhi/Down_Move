using System;
using UnityEngine;

namespace Assets.Scriptsd
{
    /// <summary>
    /// The main character script.
    /// </summary>
    public class Character : MainCreature
    {
        public Animator Animator;
        
        
        public void SetState(MainAnimationState state)
        {
            foreach (var variable in new[] { "Idle", "Ready", "Walking", "Running", "Crawling", "Jumping", "Climbing", "Blocking", "Dead" })
            {
                Animator.SetBool(variable, false);
            }

            switch (state)
            {
                case MainAnimationState.Idle: Animator.SetBool("Idle", true); break;
                case MainAnimationState.Ready: Animator.SetBool("Ready", true); break;
                case MainAnimationState.Walking: Animator.SetBool("Walking", true); break;
                case MainAnimationState.Running: Animator.SetBool("Running", true); break;
                case MainAnimationState.Crawling: Animator.SetBool("Crawling", true); break;
                case MainAnimationState.Jumping: Animator.SetBool("Jumping", true); break;
                case MainAnimationState.Climbing: Animator.SetBool("Climbing", true); break;
                case MainAnimationState.Blocking: Animator.SetBool("Blocking", true); break;
                case MainAnimationState.Dead: Animator.SetBool("Dead", true); break;
                default: throw new NotSupportedException();
            }

            //Debug.Log("SetState: " + state);
        }

        public MainAnimationState GetState()
        {
            if (Animator.GetBool("Idle")) return MainAnimationState.Idle;
            if (Animator.GetBool("Ready")) return MainAnimationState.Ready;
            if (Animator.GetBool("Walking")) return MainAnimationState.Walking;
            if (Animator.GetBool("Running")) return MainAnimationState.Running;
            if (Animator.GetBool("Crawling")) return MainAnimationState.Crawling;
            if (Animator.GetBool("Jumping")) return MainAnimationState.Jumping;
            if (Animator.GetBool("Climbing")) return MainAnimationState.Climbing;
            if (Animator.GetBool("Blocking")) return MainAnimationState.Blocking;
            if (Animator.GetBool("Dead")) return MainAnimationState.Dead;

            return MainAnimationState.Ready;
        }
    }
}