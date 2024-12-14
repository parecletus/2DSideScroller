using System.Collections.Generic;
using UnityEngine;

public class Manager_ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform Subj;
    public Transform[] childs;
    public List<Vector2> childsstart;

    float indFactor;
    void Start()
    {
        List<float> childz = new List<float>();
        childs = GetComponentsInChildren<Transform>();
        foreach (Transform t in childs)
        {
            if (t != transform)
            {
                float a = clippingplane(distanceFromSubj(t));
                childz.Add(Mathf.Abs(distanceFromSubj(t)) / a);
            }
        }
        for (int i = 0; i < childs.Length; i++)
        {
            childsstart.Add(childs[i].position);
        }
    }

    void Update()
    {
        // Vector2 newpos = transform.position = startPosition + ((Vector2)cam.transform.position -startPosition) * parallaxFactor();
        // transform.position = new Vector3(newpos.x, newpos.y, startZ);
    }

    public float distanceFromSubj(Transform t)
    {
        return t.localPosition.z - Subj.localPosition.z;
    }
    public float clippingplane(float d)
    {
        return cam.transform.position.z + (d > 0 ? cam.farClipPlane : cam.nearClipPlane);
    }

}
