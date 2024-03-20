using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Player player; //追いかける対象
    [SerializeField] float speed;

    [SerializeField] PlaneManager planeManager;

    bool isHoming; //ホーミングを開始しても良いかどうか
    Vector3 thisPosition; //このオブジェクトの現在の座標

    // Start is called before the first frame update
    void Start()
    {
        isHoming = false;
    }

    // Update is called once per frame
    void Update()
    {
        thisPosition.x = this.transform.position.x;
        if (isHoming)
        {
            if (thisPosition.x <= player.pos.x)
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //正転
                thisPosition.x += speed;
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); //反転
                thisPosition.x -= speed;
            }

            this.transform.position = thisPosition; //座標を更新する
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //床の衝突判定
        if (planeManager != null)
        {
            for (int k = 0; k < planeManager.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planeManager.plane[k])
                {
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
}