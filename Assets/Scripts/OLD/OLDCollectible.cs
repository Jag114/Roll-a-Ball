using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OLDCollectible : MonoBehaviour
{
    private Rigidbody m_rb;
    int direction;
    float timeToBop;
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        direction = 1;
        timeToBop = 0;
        sound = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5f * Time.deltaTime, 0);
        if (timeToBop > 30)
        {
            UpAndDown();
            timeToBop = 0;
        }
        else
        {
            timeToBop += 0.1f;
        }
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        //otherObject.gameObject.GetComponent<MovementController>().score += 1;
        otherObject.gameObject.GetComponent<OLDMovementController>().CollectScore();
        sound.Play();

        Vector3 ballPos = otherObject.gameObject.transform.position;
        float x = Random.Range(-8, 8);
        float z = Random.Range(-8, 8);
        while (x == ballPos.x)
        {
            x = Random.Range(-8,8);
        }
        while (z == ballPos.z)
        {
            z = Random.Range(-8, 8);
        }
        Vector3 vector3 = new Vector3(x, 0.9f, z);
        Instantiate(gameObject, vector3, Quaternion.identity);

        gameObject.SetActive(false);
    }

    void UpAndDown()
    {
        Vector3 vector3 = new Vector3(0.0f, 0.1f, 0.0f);
        vector3[1] = vector3[1] * direction;
        transform.Translate(vector3);
        direction = direction * -1;
    }
}
