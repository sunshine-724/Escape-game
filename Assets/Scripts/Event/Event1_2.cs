using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_2 : MonoBehaviour
{
    /*親オブジェクト*/
    [SerializeField] CanvasEvent1 canvasEvent1;

    /*子オブジェクト*/
    [SerializeField] GameObject image2_EnemyAppear;
    [SerializeField] Event1_2Text Text1_2_1;
    [SerializeField] Event1_2Text Text1_2_2;
    [SerializeField] Event1_2Text Text1_2_3;


    private int nowEvent = 1; //今何番目のメソッドが実行中か(最初は1)
    private bool isZKey; //zキーによるキー操作を受け付けるか
    private bool isMethod = true; //メソッドを実行しても良いか


    // Start is called before the first frame update

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (nowEvent)
            {
                case 0:
                    Debug.Log("現在イベントが進行中です");
                    break;
                case 1:
                    StartCoroutine(Event1());
                    nowEvent = 0;
                    isMethod = false;
                    break;

                case 2:
                    StartCoroutine(Event2());
                    nowEvent = 0;
                    isMethod = false;
                    break;

                case 3:
                    StartCoroutine(Event3());
                    nowEvent = 0;
                    isMethod = false;
                    break;
            }
        }
    }

    private IEnumerator Event1()
    {
        yield return StartCoroutine(Text1_2_1.TextObjectActive());
        isMethod = true;
        nowEvent = 2;
    }

    private IEnumerator Event2()
    {
        yield return StartCoroutine(Text1_2_2.TextObjectActive());
        isMethod = true;
        nowEvent = 3;
    }

    private IEnumerator Event3()
    {
        yield return StartCoroutine(Text1_2_3.TextObjectActive());
        canvasEvent1.EndEvent(2);
    }

    
}
