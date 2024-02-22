using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*image_openingにアタッチする*/
public class Image_Opening : MonoBehaviour
{
    /*変数宣言*/
    [SerializeField] FadeIn fadeIn;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public IEnumerator ThisObjectFadeIn()
    {
        yield return  StartCoroutine(fadeIn.Fade()); //フェードインを実行
    }
}
