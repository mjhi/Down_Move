using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public Sprite[] groundImg;
    public float speed;
    
    SpriteRenderer temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = tiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay){
            for(int i=0; i<tiles.Length; i++){
            if(GameManager.instance.Player.transform.position.y>=tiles[i].transform.position.y)
                {
                    for(int q= 0; q<tiles.Length; q++)
                    {
                        if(temp.transform.position.x<tiles[q].transform.position.x){
                            temp=tiles[q];
                        }
                        
                    }
                    tiles[i].transform.localPosition = new Vector2(temp.transform.localPosition.x+0.48f,0.0f);
                    tiles[i].sprite = groundImg[Random.Range(0,groundImg.Length)];
                }
            }
            
        }
        
    }
}
