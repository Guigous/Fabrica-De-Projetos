using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovaCena : MonoBehaviour
{

   public void Loadscene(string sceneName)
    {
        Debug.Log("???");

        SceneManager.LoadScene(sceneName);
    }
}
