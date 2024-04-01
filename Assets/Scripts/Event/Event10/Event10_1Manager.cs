using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event10_1Manager : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] FadeIn image_Event10_1;
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(image_Event10_1.Fade()); //フェードイン実行
        //ドアを開閉する
        door.OpenTheDoor();
        yield return new WaitForSeconds(2.0f);
    }

    public void Starting2()
    {
        player.gameObject.SetActive(true);
        door.CloseTheDoor();
    }
}
