using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Image_Prisonオブジェクトにアタッチ*/
public class Image_Event1 : MonoBehaviour
{
    [SerializeField] FadeIn fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(false); //最初は非アクティブ状態にする
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ThisObjectFadeIn()
    {
        StartCoroutine(fadeIn.Fade()); //フェードインする
    }
}
