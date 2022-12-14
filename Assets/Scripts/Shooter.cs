using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] bulletsResources;    // 弾の配列
    public float shotForce;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Shot();

            // 振動
            OVRInput.SetControllerVibration(0f, 0.5f, OVRInput.Controller.RTouch);
        }
    }
    // bulletsResourcesからランダムに一つ選ぶ
    GameObject SampleBullet()
    {
        int index = Random.Range(0, bulletsResources.Length);
        return bulletsResources[index];
    }

    public void Shot()
    {
        // bulletsResourcesからbulletを生成
        GameObject bullet = Instantiate(
            SampleBullet(),
            transform.position,
            Quaternion.identity
            );

        // bulletを発射
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * shotForce);
    }
}
