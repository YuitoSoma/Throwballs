using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb; //���W�b�h�{�f�B���擾���邽�߂̕ϐ�
    public float upForce = 200f; //������ɂ������
    public float speed = 1.0f;  // �ړ����x�̓x��
    bool isGround; //���n���Ă��邩�ǂ����̔���

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

    // �ړ�
    void Move()
    {
        //�E�W���C�X�e�B�b�N�̏��擾
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        //�v���C���[�̈ړ�
        this.transform.position += this.transform.forward * stickL.y * speed * Time.deltaTime;
        //�v���C���[�̉��ړ�
        this.transform.position += this.transform.right * stickL.x * speed * Time.deltaTime;
    }

        // ���_�؂�ւ�
        void TransViewPoint()
    {
        //�E�W���C�X�e�B�b�N�̏��擾
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

    // �W�����v
    void Jump()
    {
        if ((OVRInput.Get(OVRInput.RawButton.B)))
        {
            if (isGround == true)//���n���Ă���Ƃ�
            {
                isGround = false;//  isGround��false�ɂ���
                rb.AddForce(new Vector3(0, upForce, 0)); //��Ɍ������ė͂�������
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") //Ground�^�O�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            isGround = true; //isGround��true�ɂ���
        }
    }
}