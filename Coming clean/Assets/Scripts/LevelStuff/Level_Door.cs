using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Door : MonoBehaviour
{
    public SceneAsset scene;
    public BoxCollider2D box;


private void OnTriggerEnter2D(Collider2D collison){
    if(collison.CompareTag("Player")){
        SceneManager.LoadScene(scene.name);
    }
}
}
