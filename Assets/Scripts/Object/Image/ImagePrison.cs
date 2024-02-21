using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Image_Prisonオブジェクトにアタッチ*/
public class ImagePrison : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false); //最初は非アクティブ状態にする
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //引数によってアクティブ状態を切り替える
    public void ObjectSetActive(bool active)
    {
        if (active == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
