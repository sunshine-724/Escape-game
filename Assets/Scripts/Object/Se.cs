using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*音を出すのにオブジェクトにアタッチする*/
public class Se : MonoBehaviour
{
    AudioSource audioSource; //AudioSourceコンポーネント(動的に取得する)

    //ここから下は必要な音源ファイルをインスペクターから指定する
    [SerializeField] AudioClip typing;


    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>(); //アタッチしたオブジェクトのコンポーネントを取得する
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*タイピングの音を出す*/
    public void Typing()
    {
        if (audioSource == null)
        {
           
            Debug.Log("AudioSourceの取得に失敗しました");
        }
        else
        {
            audioSource.PlayOneShot(typing);
        }
        
    }

}
