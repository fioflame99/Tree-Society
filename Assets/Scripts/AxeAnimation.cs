using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimation : MonoBehaviour
{
    public GameObject axe; 
    GameObject axeNode = null;
    public float[,] positions = new float[,] { { 4, 1, 1 }, { 5, 2, 1 }, { 0, 2, 6 }, { 5, 2, 6 } };
    private float startTime;
    private float Duration = 5.0f;
    /*public float tiltAngle = 90.0f;
    public float rotationSpeed = 10f;
    public float swingRate;*/

    // Start is called before the first frame update
    void Start()
    {

        
        int index = PlayerPrefs.GetInt("PlayerIndex");
        Vector3 position = new Vector3((float)(positions[index, 0]), positions[index, 1], positions[index, 2]);
        axeNode = Instantiate(axe);
        axeNode.transform.parent = transform;
        axeNode.transform.localPosition = position; 
        axeNode.transform.localRotation = Quaternion.identity;

        axe.gameObject.SetActive(false);

        /*startTime = Time.time;
        endTime = startTime + growthDuration;*/

    }
    public void controller()
    {
        startTime = Time.time;
        axeNode.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

        /*float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, axe,  Time.deltaTime * smooth);*/
        /*float swingSpeed = swingRate * Time.deltaTime;
        axeNode.transform.Rotate(0f, rotationSpeed * swingSpeed, 0f);
        if (Time.time == 3.0f) { return; }*/
        /*axe.transform.Rotate(0f, 45f, 0f);*/

        float elapsed = Time.time - startTime;
        if (elapsed >= Duration)
        {
            axeNode.gameObject.SetActive(false);
        }
    }
}
