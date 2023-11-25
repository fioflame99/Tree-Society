using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(45f, 0, 0);
    }
}
