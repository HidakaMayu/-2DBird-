using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSclipt : MonoBehaviour
{
    [SerializeField]
    float Jump = 50f;  //ジャンプ  
    
    Rigidbody2D rb2;

    [SerializeField]
    private Sprite sp;　//ぶつかったときの絵
    private bool stay;

    Animator anim;
    SpriteRenderer rend; //重くなるので移動
    public static bool flagDead = false; 

    void Start()
    {
        flagDead = false;
        rb2 = GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<SpriteRenderer>(); //重くなるので移動
        anim = GetComponent<Animator>();
        Debug.Log("2");
    }
    

    void Update()
    {
        TouchManager.Began += (info) =>
        {
            if(!flagDead)
            {
                rb2.velocity = Vector2.zero;//落下速度をリセットする
                rb2.AddForce(transform.up * Jump, ForceMode2D.Impulse);//上方向に力を入れる​
                Debug.Log('3');
            }
        };
    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HUkkatsu());
    }

    IEnumerator HUkkatsu()
    {
        flagDead = true; //死んだ
        anim.enabled = true;
        SpriteRenderer renderer = rend;
        renderer.sprite = sp;
        Destroy(GetComponent<Animator>());
        Destroy(anim);
        
        yield return new WaitForSeconds(1.0f);　//死んでる時間

        flagDead = false; //時間経過で生き返った
        anim.enabled = false;
        //画像を戻したい
    }
}