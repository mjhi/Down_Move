using Assets.Scriptsd;
using UnityEngine;
using AnimationState = Assets.Scriptsd.MainAnimationState;

namespace Assets.Scriptsd
{
    public class Monster : MonoBehaviour
    {
        public Character Character;
        SpriteRenderer rend;
        public float RunSpeed = 1f;
        public float dir;
        [SerializeField]private Rigidbody2D rigid;
        

        
        
        public void Start()
        {
            rend=gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            if(Random.value > 0.5f)
            {
                dir=1.0f;
            }
            else{
                dir=-1.0f;
                rend.flipX=true;
            }
            
            rigid = GetComponent<Rigidbody2D>();
           
        }

        public void Update()
        {
            if(GameManager.instance.isPlay)
            {
                Character.SetState(AnimationState.Running);
                // rigid.AddForce(new Vector2(RunSpeed,0), ForceMode2D.Force);
                transform.Translate(new Vector3(RunSpeed*dir*Time.deltaTime,0,0));
                
                if(transform.position.x<=-2.5f&&rend.flipX)
                {
                    Change();
                }
                else if(transform.position.x>=2.5f&&!rend.flipX)
                {
                    Change();
                }
                if(transform.position.y-GameManager.instance.Player.transform.position.y>=4.5)
                {
                    Destroy(gameObject);
                }
            }
            else{
                Character.SetState(AnimationState.Idle);
            }
            
            
            
        }
        
        void Change()
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
    }
    
        
}
