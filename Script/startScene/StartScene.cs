using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal.Input;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    UnityEngine.Vector3 temp;

    private void Start()
    {
        temp = transform.localScale;
    }
    private void OnMouseOver()
    {
        transform.localScale = new UnityEngine.Vector3(1.6f, 1.6f, 0);
    }
    private void OnMouseExit()
    {
        transform.localScale = temp;
    }
    void OnMouseDown()
    {
        Debug.Log("game start");
        SceneManager.LoadScene("SampleScene");

    }
  



}
