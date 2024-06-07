using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorClose;

    Animator anim; //このオブジェクトのアニメーション
    int kindOfAnimation; //どのドアのアニメーションが実行されたか 0:何も起きていない 1:Open 2:Close

    private void Awake()
    {
        kindOfAnimation = 0;
        anim = this.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheDoor()
    {
        kindOfAnimation = 1;
        doorClose.SetActive(false);
        anim.SetBool("DoorOpen", true); //ドアを開ける
    }

    public void CloseTheDoor()
    {
        kindOfAnimation = 2;
        doorOpen.SetActive(false);
        anim.SetBool("DoorClose", true); //ドアを閉める
    }

    //アニメーション終了後直接呼び出される
    public void ChangeDoorObjects()
    {
        if(kindOfAnimation == 1)
        {
            doorClose.SetActive(false);
            doorOpen.SetActive(true);
            anim.SetBool("DoorOpen", false); //連続してアニメーションが再生されないようにする
            EndAnimation(); //アニメーションが終了したことを通知する
        }
        else if(kindOfAnimation == 2)
        {
            doorOpen.SetActive(false);
            doorClose.SetActive(true);
            anim.SetBool("DoorClose", false); //連続してアニメーションが再生されないようにする
            EndAnimation(); //アニメーションが終了したことを通知する
        }
        else
        {
            Debug.Log("エラー");
        }
    }

    private void EndAnimation()
    {
        //今のイベント内容によって通知するところを変える
        switch (gameManager.EventNumber)
        {
            case 4:
                gameManager.Notification(0); //ドアの操作が終わったことを通知で伝える
                break;

            case 10:
                if(kindOfAnimation == 1)
                {
                    gameManager.Notification(2);
                }
                break;

            default:
                Debug.Log("存在しないイベントナンバーです");
                break;
        }
    }
}
