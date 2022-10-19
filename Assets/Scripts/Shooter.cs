using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] bulletsResources;    // �e�̔z��
    public float shotForce;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Shot();

            // �U��
            OVRInput.SetControllerVibration(0f, 0.5f, OVRInput.Controller.RTouch);
        }
    }
    // bulletsResources���烉���_���Ɉ�I��
    GameObject SampleBullet()
    {
        int index = Random.Range(0, bulletsResources.Length);
        return bulletsResources[index];
    }

    public void Shot()
    {
        // bulletsResources����bullet�𐶐�
        GameObject bullet = Instantiate(
            SampleBullet(),
            transform.position,
            Quaternion.identity
            );

        // bullet�𔭎�
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * shotForce);
    }
}
