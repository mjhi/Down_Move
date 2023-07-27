using Assets.Scriptsd;
using UnityEngine;
using AnimationState = Assets.Scriptsd.MainAnimationState;

namespace Assets.Scriptsd
{
    public class Controller : MonoBehaviour
    {
        public Character Character;
        SpriteRenderer rend;
        public float RunSpeed = 1f;
        public float dir;
        [SerializeField]private Rigidbody2D rigid;
        

        
        
        public void Start()
        {
            rend=gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            dir=1.0f;
            rigid = GetComponent<Rigidbody2D>();
            Character.SetState(AnimationState.Idle);
        }

        public void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                dir*=-1;
                if(dir==-1)
                {
                    rend.flipX=true;
                }
                else{
                    rend.flipX=false;
                }
            }
            if(GameManager.instance.isPlay)
            {
                Character.SetState(AnimationState.Running);
                // rigid.AddForce(new Vector2(RunSpeed,0), ForceMode2D.Force);
                transform.Translate(new Vector3(RunSpeed*dir*Time.deltaTime,0,0));
            }
            
            
        }
        void OnCollisionStay2D(Collision2D other)
        {
            if(other.gameObject.tag=="Floor"&&GameManager.instance.isPlay)
            {
                Destroy(other.gameObject);
            }
            
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag=="Enemy"&&GameManager.instance.isPlay)
            {
                Character.SetState(AnimationState.Dead);
                GameManager.instance.GameOver();
            }
            
        }
    }
    
        
}