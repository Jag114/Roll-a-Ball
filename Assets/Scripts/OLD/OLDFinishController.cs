using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OLDFinishController : MonoBehaviour
{
    public Text finish_text;
    private bool finished = false;

    private void Update()
    {
        if (finished)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(++index, LoadSceneMode.Single);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;
        finish_text.gameObject.SetActive(true);
        finished = true;
    }



}
