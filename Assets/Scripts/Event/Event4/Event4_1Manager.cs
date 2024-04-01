using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event4_1Manager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image_ClearWipe_FromLeftToRight image_Event4_1;
    [SerializeField] FadeOut image_Event4_2;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Starting1()
    {
        image_Event4_1.gameObject.SetActive(true); //ワイプ実行
    }

    public IEnumerator Starting2()
    {
        image_Event4_2.gameObject.SetActive(true);
        yield return StartCoroutine(image_Event4_2.Fade()); //フェードアウト実行
        gameManager.Notification(1); //シーンチェンジ
    }
}
