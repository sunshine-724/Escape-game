using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvent1 : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] GameManager gameManager;
    [SerializeField] Event1_1 event1_1;
    [SerializeField] Event1_2 event1_2;
    [SerializeField] Event1_3 event1_3;


    [System.NonSerialized] public bool isStart = false; //このキャンバス内のスクリプトを実行しても良いか(最初はfalse)

    private void Awake()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart == true)
        {
            StartCoroutine(CanvasEvent());
            isStart = false; //連続でテキストを出さないようにする
        }
    }

    private IEnumerator CanvasEvent()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(event1_1.Event1());
    }

    public void EndEvent(int k)
    {
       switch (k+1)
        {
            case 1:
                break;

            case 2:
                event1_1.gameObject.SetActive(false);
                event1_2.gameObject.SetActive(true);
                break;

            case 3:
                event1_3.gameObject.SetActive(true);
                event1_2.gameObject.SetActive(false);

                break;

            default:
                Debug.Log("存在しないイベントです");
                break;
        }
    }
}
