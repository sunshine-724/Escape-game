using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField] int shakePerms; //上下するのにどのくらい分割させるのか(つまり上限と下限）
    [SerializeField] float slope; //一回の上がり下がり具合でどのくらい変化するのか
    float initializeYPosition; //初期のY座標
    int positionNumber; //今どの位置にオブジェクトがあるか
    bool UpOrDown; //今上がっているのか下がっているのか
    bool isMethod; //コルーチンを重複させないためのフラグ

    private void Awake()
    {
        initializeYPosition = this.transform.position.y;
        isMethod = false;
        positionNumber = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isMethod)
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        isMethod = true;
        Vector3 pos = this.transform.position; //座標を格納する


        if (UpOrDown)
        {
            positionNumber++;
        }
        else
        {
            positionNumber--;
        }

        if(positionNumber == shakePerms/4)
        {
            UpOrDown = false; //下げる
        }else if(positionNumber == -shakePerms/4)
        {
            UpOrDown = true; //上げる
        }

        pos.y = initializeYPosition + slope * positionNumber;

        this.transform.position = pos;
        yield return new WaitForSeconds(0.001f);
        isMethod = false;
    }
}
