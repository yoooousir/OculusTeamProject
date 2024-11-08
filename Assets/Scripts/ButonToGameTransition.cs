using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonToGameTransition : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
}
