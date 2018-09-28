using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager : MonoBehaviour {
	
    public static void LoadNext(int n)
    {
        SceneManager.LoadScene(n,LoadSceneMode.Single);
    }
  
}
