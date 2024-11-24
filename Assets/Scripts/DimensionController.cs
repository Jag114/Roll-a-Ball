using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class DimensionController : MonoBehaviour
{
    enum Dimension
    {
        Dark = 6,
        Light = 7
    };

    private GameObject[] allObjects;
    private Dimension currDimension = Dimension.Light;

    public Material LightSkybox;
    public Material DarkSkybox;

    void Start()
    {
        allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        RenderDimension((int)currDimension);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            currDimension = Dimension.Dark;
            RenderDimension(6);
            RenderSettings.skybox = DarkSkybox;

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            currDimension = Dimension.Light;
            RenderDimension(7);
            RenderSettings.skybox = LightSkybox;
        }
    }

    void RenderDimension(int dimensionID)
    {
        foreach (GameObject obj in allObjects)
        {
            if(obj.layer > 5 && obj.layer < 8)
            {
                if (obj.layer != dimensionID)
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
