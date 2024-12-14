using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;

public class ParallaxBg : MonoBehaviour
{
    public Camera cam;
    public Transform subject;
    Vector2 startPosition;
    float startZ;
    Transform subj;
    Transform[] childs;
    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
        SetupBg();
        Transform[] childs = GetComponentsInChildren<Transform>();
    }
    public void Update()
    {        
        Vector2 newpos = transform.position = startPosition + Travel() * parallaxFactor();
        transform.position = new Vector3(newpos.x, newpos.y, startZ);
    }
    public void SetupBg()
    {

    }
    public Vector2 Travel(){
        return (Vector2)cam.transform.position -startPosition;
    }
    public float distanceFromSubj(){
        return transform.position.z - subject.position.z;
    }
    public float clippingplane (){
        return cam.transform.position.z +(distanceFromSubj()>0 ? cam.farClipPlane :cam.nearClipPlane);
    }
    public float parallaxFactor (){
        return Mathf.Abs(distanceFromSubj()) / clippingplane();
    }
}
