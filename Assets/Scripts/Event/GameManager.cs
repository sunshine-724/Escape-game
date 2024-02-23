using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Event1_1Manager event1_1Manager;
    [SerializeField] Event1_2Manager event1_2Manager;
    [SerializeField] Event1_3Manager event1_3Manager;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(event1_1Manager.Starting1()); //デバッグ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            Debug.Log("Zキーが押されました");
            Debug.Log(!event1_1Manager.isEnd);
            Debug.Log(!event1_1Manager.nowMethod);
            Debug.Log(event1_1Manager.nowEvent);

            if ((!event1_1Manager.isEnd) && (!event1_1Manager.nowMethod))
            {
                switch (event1_1Manager.nowEvent)
                {
                    case 2:
                        StartCoroutine(event1_1Manager.Starting2());
                        break;

                    case 3:
                        StartCoroutine(event1_1Manager.Ending());
                        break;

                    default:
                        Debug.Log("エラー");
                        break;
                }
            }
            else if ((!event1_2Manager.isEnd) && (!event1_2Manager.nowMethod))
            {
                Debug.Log(event1_2Manager.nowEvent + "が実行されます");
                switch (event1_2Manager.nowEvent)
                {
                    case 2:
                        StartCoroutine(event1_2Manager.Starting2());
                        break;

                    case 3:
                        StartCoroutine(event1_2Manager.Starting3());
                        break;

                    case 4:
                        StartCoroutine(event1_2Manager.Ending());
                        break;

                    default:
                        Debug.Log("エラー");
                        break;
                }
            }
            else if ((!event1_3Manager.isEnd) && (!event1_3Manager.nowMethod))
            {
                Debug.Log(event1_3Manager.nowEvent + "が実行されます");
                switch (event1_3Manager.nowEvent)
                {
                    case 2:
                        StartCoroutine(event1_3Manager.Starting2());
                        break;
                    case 3:
                        StartCoroutine(event1_3Manager.Ending());
                        break;

                    default:
                        Debug.Log("エラー");
                        break;
                }
            }
        }

        if ((event1_1Manager.isEnd) && (!event1_1Manager.nowMethod))
        {
            Debug.Log("次のイベントに移ります");
            StartCoroutine(event1_2Manager.Starting1());
            event1_1Manager.nowMethod = true; //このイベントのメソッドをこれ以上実行されないようにする
        }
        else if ((event1_2Manager.isEnd) && (!event1_2Manager.nowMethod))
        {
            StartCoroutine(event1_3Manager.Starting1());
            event1_2Manager.nowMethod = true;

        }
    }
}
