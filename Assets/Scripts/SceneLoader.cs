using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

public void LoadScene(int sceneNumber)
{

SceneManager.LoadScene(sceneNumber);

}

}
