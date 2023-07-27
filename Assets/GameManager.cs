using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    #region instance
    public int scoreInt=0;
    public GameObject EndScreen;
    public TMP_Text Score;
    public static GameManager instance;
    public GameObject Player;
    public GameObject prefab;
    public GameObject Last;
    public GameObject[] MonsterPrefab;
    private void Awake()
    {
        
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    // public delegate void OnPlay(bool isplay);
    // public OnPlay onPlay;
    public float gameSpeed = 1;
    
    public bool isPlay = false;
    public GameObject playBtn;
    public void PlayBtnClick()
    {
        scoreInt=0;
        playBtn.SetActive(false);
        isPlay=true;
        StartCoroutine(ScoreGet());
        // onPlay.Invoke(isPlay);
        
    }
    public void CloseBtnClick()
    {
        SceneManager.LoadScene(0);
        
        
    }
    IEnumerator ScoreGet()
    {

        while(isPlay){
            scoreInt+=1;
            yield return new WaitForSeconds(1f);
        }
    }
    public void GameOver()
    {
        
         
         EndScreen.SetActive(true);
        //  playBtn.SetActive(true);
         isPlay=false;
        //  onPlay.Invoke(isPlay);
    }
    public void Update()
    {
        
        if(!isPlay)
        {
            Score.text = "Score : "+scoreInt.ToString();
        }
        
    }
    public void FloorSpawn()
    {

        GameObject qw = Instantiate(prefab,new Vector3(Last.transform.position.x,Last.transform.position.y-1.0f,transform.position.z),Quaternion.identity);
        Instantiate(MonsterPrefab[Random.Range(0,MonsterPrefab.Length)],new Vector3(Random.Range(-3.0f,3.0f),qw.transform.position.y+0.3f,transform.position.z),Quaternion.identity);
        Last=qw;
    }

}