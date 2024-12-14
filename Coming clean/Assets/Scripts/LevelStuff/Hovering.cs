using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hovering : MonoBehaviour
{
    public SceneAsset scene;
    public BoxCollider2D col;
    [Header("Prefab to show")]
    public GameObject orj_Prefab;
    private GameObject fake_Prefab;
    [Header("Position of the prefab")]
    public Transform position;
    Vector2 startpos => position.position;
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            fake_Prefab = Instantiate(orj_Prefab, transform);
            fake_Prefab.transform.position = startpos;
        }
    }
    void OnTriggerStay2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && fake_Prefab != null)
            {
                Destroy();
                if (scene != null)
                    SceneManager.LoadScene(scene.name);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collison)
    {
        if (fake_Prefab != null && collison.CompareTag("Player"))
            Destroy();
    }
    void Destroy()
    {
        Destroy(fake_Prefab);
    }


}

