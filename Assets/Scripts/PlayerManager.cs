using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb; //リジッドボディを取得するための変数
    public float upForce = 200f; //上方向にかける力
    public float speed = 1.0f;  // 移動速度の度合
    bool isGround; //着地しているかどうかの判定

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        TransViewPoint();
    }

    // 移動
    void Move()
    {
        //右ジョイスティックの情報取得
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        //プレイヤーの移動
        this.transform.position += this.transform.forward * stickL.y * speed * Time.deltaTime;
        //プレイヤーの横移動
        this.transform.position += this.transform.right * stickL.x * speed * Time.deltaTime;
    }

        // 視点切り替え
        void TransViewPoint()
    {
        //右ジョイスティックの情報取得
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        if (stickR.x > 0)
        {
            transform.Rotate(new Vector3(0, 1.0f, 0));
        }
        else if (stickR.x < 0)
        {
            transform.Rotate(new Vector3(0, -1.0f, 0));
        }
    }

    // ジャンプ
    void Jump()
    {
        if ((OVRInput.Get(OVRInput.RawButton.B)))
        {
            if (isGround == true)//着地しているとき
            {
                isGround = false;//  isGroundをfalseにする
                rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
        }
    }
}