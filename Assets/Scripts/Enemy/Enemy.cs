using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*敵キャラのモーション*/
    [SerializeField] GameObject runObject;
    [SerializeField] GameObject idleObject;

    [SerializeField] float DisappearPositionX; //敵キャラが消えるX座標
    [SerializeField] Player player; //追いかける対象
    [SerializeField] float speed; //スピード

    [SerializeField] PlaneManager planeManager; //地面を管理するManager

    [SerializeField] Ending ending; //endingクラス

    [SerializeField] Se stepSound;

    private bool isHoming; //プレイヤーをホーミングしても良いかどうか
    public bool isRightMove; //右側に動いても良いか
    public bool isLeftMove; //左側に動いても良いか
    public Vector3 thisPosition; //このオブジェクトの現在の座標

    private bool isRunStepSound; //走る時音を出しても良いか

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
            if (isRunStepSound)
            {
                ending.isMethod = true;
                StartCoroutine(RunStepSound());
            }
        }
        else if (isLeftMove)
        {
            SetMotion("leftRun");
            if (isRunStepSound)
            {
                ending.isMethod = true;
                StartCoroutine(RunStepSound());
            }

            if (thisPosition.x <= DisappearPositionX)
            {
                ending.isMethod = false;
                ending.InputZkey(); //次のイベントに移る
            }
        }
        else
        {
            SetMotion("idle");
            if (!isRunStepSound)
            {
                StopCoroutine(RunStepSound()); //もし待機モーション時であればRun用のSEを止める
            }
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

    public void Rotation(string direction)
    {
        if (direction == "left")
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }else if(direction == "right")
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            Debug.Log("存在しない方角です");
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

    public IEnumerator RunStepSound()
    {
        isRunStepSound = false; //再生し終えるまで再生許可は与えない
        yield return StartCoroutine(stepSound.Start_SE());
        yield return new WaitForSeconds(0.3f); //少し補完を入れる
        isRunStepSound = true; //再生し終えたので再度再生許可を与える
    }
}
