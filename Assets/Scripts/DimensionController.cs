using System;
using System.Drawing;
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
    private ColorGrading colorGrading;
    private float inputDelay;

    public Material LightSkybox;
    public Material DarkSkybox;

    void Start()
    {
        inputDelay = 0;

        allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        PostProcessVolume[] volume = FindObjectsByType<PostProcessVolume>(FindObjectsSortMode.None);
        foreach(var e in volume)
        {
            if (e != null && e.profile != null)
            {
                if (e.profile.TryGetSettings(out colorGrading))
                {
                    Debug.Log("Color Grading found!");
                }
                else
                {
                    Debug.LogWarning("Color Grading effect is not enabled in the volume profile.");
                }
            }
        }
        
        RenderDimension((int)currDimension);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputDelay > .2f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                currDimension = Dimension.Dark;
                RenderDimension(6);
                //RenderSettings.skybox = DarkSkybox;

            }
            if (Input.GetKey(KeyCode.Q))
            {
                currDimension = Dimension.Light;
                RenderDimension(7);
                //RenderSettings.skybox = LightSkybox;
            }
            inputDelay = 0;
        }
        
        inputDelay += Time.deltaTime;
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

        InvertGradingCurves();
    }

    public void InvertGradingCurves()
    {
        //print("Begin inversion");
        colorGrading.masterCurve.overrideState = true;
        //print(colorGrading.masterCurve);//SplineParameter
        //print(colorGrading.masterCurve.value);//Spline
        //print(colorGrading.masterCurve.value.curve[1]);//Keyframe
        //print(colorGrading.masterCurve.value.curve.length);//int
        //for(int i = 0; i < colorGrading.masterCurve.value.curve.length; ++i)
        //{
        //    print(colorGrading.masterCurve.value.curve[i].value);//float
        //}
        Keyframe[] keyFrames = new Keyframe[2];
        if(currDimension == Dimension.Dark)
        {
            keyFrames[0] = new Keyframe(0, 1);
            keyFrames[1] = new Keyframe(1, 0);
        }
        else
        {
            keyFrames[0] = new Keyframe(0, 0);
            keyFrames[1] = new Keyframe(1, 1);
        }
        
        colorGrading.masterCurve.value = new Spline(new AnimationCurve(keyFrames), 0, false, new Vector2(0,255));
        //print("End inversion");
    }
}

