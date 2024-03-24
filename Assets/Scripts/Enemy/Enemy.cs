using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*敵キャラのモーション*/
    [SerializeField] GameObject runObject;
    [SerializeField] GameObject idleObject;

    [SerializeField] Player player; //追いかける対象
    [SerializeField] float speed; //スピード

    [SerializeField] PlaneManager planeManager; //地面を管理するManager

    [SerializeField] Ending ending; //endingクラス

    private bool isHoming; //プレイヤーをホーミングしても良いかどうか
    public bool isRightMove; //右側に動いても良いか
    public bool isLeftMove; //左側に動いても良いか
    public Vector3 thisPosition; //このオブジェクトの現在の座標

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisPosition.x = this.transform.position.x;

        //もし追跡許可が出ていたら
        if (isHoming)
        {
            if (thisPosition.x <= player.pos.x -5.0f)
            {
                isRightMove = true;
                isLeftMove = false;
            }
            else
            {
                IsMove(false);
                isHoming = false;
                ending.isMethod = false;
            }
        }

        //移動後の座標を変数に格納する
        if (isRightMove)
        {
            SetMotion("rightRun");
        }else if (isLeftMove)
        {
            SetMotion("leftRun");
            if(thisPosition.x <= 40)
            {
                player.IsMove(true);
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            SetMotion("idle");
        }

        if(isRightMove || isLeftMove)
        {
            this.transform.position = thisPosition; //座標を更新する
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //床の衝突判定
        if (planeManager != null)
        {
            for (int k = 0; k < planeManager.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planeManager.plane[k]) 
                {
                    IsMove(true);
                    isHoming = true;
                    thisPosition.y = this.transform.position.y;
                    break; //地面は一つしか接しないのでこれ以上検索をかける必要がない
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        for (int k = 0; k < planeManager.childPlaneNumbers; k++)
        {
            if (collision.gameObject == planeManager.plane[k])
            {
                isHoming = false;
                break; //地面は一つしか接しないのでこれ以上検索をかける必要がない
            }
        }
    }

    //指定された名前によってモーションを設定する
    void SetMotion(string motionName)
    {
        if(motionName == "rightRun")
        {
            idleObject.SetActive(false);
            runObject.SetActive(true);
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            thisPosition.x += speed;
        }
        else if(motionName == "leftRun")
        {
            idleObject.SetActive(false);
            runObject.SetActive(true);
            this.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f); //反転
            thisPosition.x -= speed;
        }
        else if(motionName == "idle")
        {
            idleObject.SetActive(true);
            runObject.SetActive(false);
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            Debug.Log("存在しないモーションです");
        }
    }

    public void IsMove(bool status)
    {
        if (status)
        {
            isRightMove = true;
            isLeftMove = true;
        }
        else
        {
            isRightMove = false;
            isLeftMove = false;
        }
    }
}
