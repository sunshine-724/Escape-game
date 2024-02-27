using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*音を出すのにオブジェクトにアタッチする*/
public class Se : MonoBehaviour
{
    AudioSource audioSource; //AudioSourceコンポーネント(動的に取得する)

    //これは必要な音源ファイルをインスペクターから指定する
    [SerializeField] AudioClip source;
    float sourceLength; //音源の長さ
    

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>(); //アタッチしたオブジェクトのコンポーネントを取得する
        if(audioSource != null)
        {
            sourceLength = source.length; //音源の長さを取得する
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*指定した音を出す*/
    //イベント1のテキストのところ
    public IEnumerator Start_Text()
    {
        if (audioSource == null)
        {
            Debug.Log("AudioSourceの取得に失敗しました");
        }
        else
        {
            audioSource.PlayOneShot(source);
            yield break;
        }
    }


    public IEnumerator Start_SE()
    {
        if (audioSource == null)
        {
            Debug.Log("AudioSourceの取得に失敗しました");
        }
        else
        {
            audioSource.PlayOneShot(source);
            yield return  new WaitForSeconds(sourceLength); //音源の長さの分だけまつ
        }
    }

}
