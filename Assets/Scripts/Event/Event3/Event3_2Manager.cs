using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3_2Manager : MonoBehaviour
{
    [SerializeField] Image_BlackWipe_FromLeftToRight image_Event3_2;

    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが一定の座標を超えるとワイプを実行し、終了するまでまたせる
    public IEnumerator Starting1()
    {
        image_Event3_2.gameObject.SetActive(true);

        while (image_Event3_2.isActive)
        {
            yield return null;
        }

        isEnd = true;
    }
}
