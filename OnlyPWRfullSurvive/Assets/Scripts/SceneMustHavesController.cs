using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneMustHavesController : MonoBehaviour
{
    [SerializeField] InputActionMap actionMap;
    [SerializeField] GameObject mapCamera;


    private void Start()
    {
        actionMap["Tab"].started += ctx => mapCamera.SetActive(true);
        actionMap["Tab"].canceled += ctx => mapCamera.SetActive(false);
    }
    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
    }
}
