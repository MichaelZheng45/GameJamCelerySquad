using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

    private List<GameObject> activeObjects;
    public GameObject SceneManager;
    private SceneManagementScript sceneManagerScr;

    private void Start()
    {
        activeObjects = new List<GameObject>();
        sceneManagerScr = SceneManager.GetComponent<SceneManagementScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy objects or create obj bool;
        if(collision.tag == "Bird")
        {
            Debug.Log("GIVE ME FREEDOM OR GIVE ME DEATH");
            sceneManagerScr.LoseGame();
        }
        if(collision.gameObject.layer ==  8 && collision.tag != "Metro")
        {
            removeFromActive(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && collision.tag == "Metro")
        {
            removeFromActive(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void addToActive(GameObject newObject)
    {
        activeObjects.Add(newObject);
    }

    public void removeFromActive(GameObject oldObject)
    {
        if (activeObjects.Contains(oldObject))
        {
            activeObjects.Remove(oldObject);
        }
        else
        {
            Debug.Log("CAN'T REMOVE WHAT ISN'T THERE");
        }
    }

    public void deleteAllActive()
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            GameObject temp = activeObjects[i];
            activeObjects.RemoveAt(i);
            Destroy(temp);
        }
    }
}