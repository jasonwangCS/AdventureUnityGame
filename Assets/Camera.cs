using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject original = null;

    private void Awake()
    {
        if (original == null)
            original = gameObject;
        if (gameObject != original)
            Destroy(gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
