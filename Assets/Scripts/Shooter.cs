using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] bulletsResources;    // ’e‚Ì”z—ñ
    public float shotForce;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Shot();

            // U“®
            OVRInput.SetControllerVibration(0f, 0.5f, OVRInput.Controller.RTouch);
        }
    }
    // bulletsResources‚©‚çƒ‰ƒ“ƒ_ƒ€‚Éˆê‚Â‘I‚Ô
    GameObject SampleBullet()
    {
        int index = Random.Range(0, bulletsResources.Length);
        return bulletsResources[index];
    }

    public void Shot()
    {
        // bulletsResources‚©‚çbullet‚ğ¶¬
        GameObject bullet = Instantiate(
            SampleBullet(),
            transform.position,
            Quaternion.identity
            );

        // bullet‚ğ”­Ë
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * shotForce);
    }
}
