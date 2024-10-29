using UnityEngine;
using UnityEngine.UIElements;

public class CollectibleController : MonoBehaviour
{
    private Rigidbody m_rb;
    private int direction;
    private float timeToBop;
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
        otherObject.gameObject.GetComponent<PlayerController>().IncrementScore();
        sound.Play();

        Respawn(otherObject.gameObject.transform.position);
    }

    private void Respawn(Vector3 ballPos)
    {
        float x = Random.Range(-8, 8);
        float z = Random.Range(-8, 8);
        while (x == ballPos.x)
        {
            x = Random.Range(-8, 8);
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
