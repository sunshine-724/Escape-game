using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_Background : MonoBehaviour
{
    public Transform imageTransform {get;private set; } //Recttrasformコンポーネント(外部からは読み取り専用)
    private Vector3 thisPosition; //アタッチした中心座標

    private void Awake()
    {
        imageTransform = GetComponent<Transform>(); //コンポーネントを取得する
        thisPosition = this.transform.position; //ワールド座標系を取得する
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
