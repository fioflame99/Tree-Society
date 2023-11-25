using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARFoundation;

public class TreeGenerator : MonoBehaviour
{
    /*public GameObject flower;
    public GameObject flower1;*/

    public GameObject treePrefab;
    public GameObject treePrefab2;
    public GameObject treePrefab3;
    public GameObject treePrefab4;
    public GameObject treePrefab5;
    public GameObject treePrefab6;
    public GameObject treePrefab7;
    public GameObject treePrefab8;
    public GameObject treePrefab9;
    public GameObject treePrefab10;
    public GameObject treePrefab11;
    public GameObject treePrefab12;

    public Texture treeTexture;
    public float growthRate;
    public float growthDuration;

    //public float curTime;
    public int select_tree;
    public bool tree1;
    public bool tree2 = false;
    public bool tree3 = false;

    private float startTime;
    private float endTime;
    private bool isGrowing;
    /*public float[,] positions = new float[,] { { 0, 0, 2 }, { 4.4f, 0, 2 }, { 0, 0, 5.4f }, { 4.4f, 0, 5.4f } };*/
    public float[,] positions = new float[,] { { 0, 0, 2 }, { 5, 0, 2 }, { 0, 0, 7 }, { 5, 0, 7 } };

    private GameObject rootNode;
    private GameObject rootNode2;
    private GameObject rootNode3;

    public int count = 0;

    public void Start()
    {

        // GenerateTree2();
    }

    public void GenerateTree2()
    {
        // Define tree structure using a class or struct
        /*GameObject flowerNode = null;
        GameObject flowerNode2 = null;*/
        
        select_tree = PlayerPrefs.GetInt("tree");
        
        //Debug.Log(select_tree0);
        tree1 = true;
        Debug.Log(tree2);
        int index = PlayerPrefs.GetInt("PlayerIndex");
        Vector3 position = new Vector3((float)(positions[index, 0] + count * 1.5), positions[index, 1], positions[index, 2]);
        Debug.Log(index);
        Debug.Log(position);


        // Create root node at base of tree
        if (tree1 & !tree2 & !tree3)
        {
            /*flowerNode = Instantiate(flower);
            flowerNode.transform.parent = transform;
            flowerNode.transform.localPosition = new Vector3(positions[index, 0] + count * 5 + 2, positions[index, 1], positions[index, 2]);
            flowerNode.transform.localRotation = Quaternion.identity;

            flowerNode2 = Instantiate(flower);
            flowerNode2.transform.parent = transform;
            flowerNode2.transform.localPosition = new Vector3(positions[index, 0] + count * 5 - 2, positions[index, 1], positions[index, 2]);
            flowerNode2.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 0)
            {
                Debug.Log(position);
                rootNode = PhotonNetwork.Instantiate(treePrefab.name, position, Quaternion.identity); //Instantiate(treePrefab);
                /*rootNode.tag = "Tree";*/
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
                //PhotonNetwork.Instantiate(gardenPrefab.name, position, Quaternion.identity);
                /*playerObject = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);*/
            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode = PhotonNetwork.Instantiate(treePrefab4.name, position, Quaternion.identity);
                /*rootNode.tag = "Tree";*/
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode = PhotonNetwork.Instantiate(treePrefab7.name, position, Quaternion.identity);
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
            }
            if (select_tree == 3)
            {
                rootNode = PhotonNetwork.Instantiate(treePrefab10.name, position, Quaternion.identity);
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
            }
        }

        if (tree1 & tree2 & !tree3)
        {
            Object.Destroy(rootNode);
            if (select_tree == 0)
            {
                //Destroy(rootNode);


                rootNode2 = PhotonNetwork.Instantiate(treePrefab2.name, position, Quaternion.identity);
                /*rootNode2.tag = "Tree";*/
                /*rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;*/


            }

            if (select_tree == 1)
            {
                //Object.Destroy(transform.GetChild(0));
                

                rootNode2 = PhotonNetwork.Instantiate(treePrefab5.name, position, Quaternion.identity);
                /*rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;*/
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode2 = PhotonNetwork.Instantiate(treePrefab8.name, position, Quaternion.identity);
                /*rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;*/
            }
            if (select_tree == 3)
            {
                rootNode2 = PhotonNetwork.Instantiate(treePrefab11.name, position, Quaternion.identity);
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
            }
        }

        if (tree1 & tree2 & tree3)
        {
            Object.Destroy(rootNode2);
            Debug.Log("Hm");
            if (select_tree == 0)
            {
                Debug.Log("Hi");

                rootNode3 = PhotonNetwork.Instantiate(treePrefab3.name, position, Quaternion.identity);
                /*rootNode3.tag = "Tree";*/
                /*Color newColor = new Color(0.74f, 0.33f, 0.61f);
                rootNode3.GetComponent<Renderer>().material.color = newColor; */
                /*rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;*/

            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode3 = PhotonNetwork.Instantiate(treePrefab6.name, position, Quaternion.identity);
                /*rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;*/
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode3 = PhotonNetwork.Instantiate(treePrefab9.name, position, Quaternion.identity);
                /*rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;*/
            }
            if (select_tree == 3)
            {
                rootNode3 = PhotonNetwork.Instantiate(treePrefab12.name, position, Quaternion.identity);
                /*rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;*/
            }
        }


        // Start growing tree
        startTime = Time.time;
        endTime = startTime + growthDuration;
        isGrowing = true;

    }

    public void Update()
    {
        // Check if tree is currently growing
        if (isGrowing)
        {
            // Calculate how much time has passed since growth started
            float elapsed = Time.time - startTime;

            // Calculate how much the tree should have grown by now
            float growth = Time.time / growthDuration;
            //Debug.Log(elapsed);


            // Stop growing the tree if it has reached its final size
            /*if (growth >= 1.0f)
            {
                isGrowing = false;
                PlayerPrefs.SetInt("tree", 0);
                count += 1;
                tree2 = false;
                tree3 = false;
                return;
            }*/

            /*if (tree1 & tree2) // put & tree 3
            {
                isGrowing = false;
                return;
            }*/


            if (elapsed >= growthDuration / 3)
            {
                if (tree3 == true)
                {
                    isGrowing = false;

                    PlayerPrefs.SetInt("tree", 0);
                    count += 1;
                    tree2 = false;
                    tree3 = false;
                    return;
                }

                if (tree2 == true)
                {
                    isGrowing = false;
                    tree3 = true;
                    GenerateTree2();

                }

                if (tree1 == true && tree2 != true)
                {
                    //DestroyImmediate(treePrefab,true);
                    isGrowing = false;
                    tree2 = true;
                    GenerateTree2();

                }


            }

            if (tree1 == true && tree2 != true)
            {
                float scaleFactor = growthRate * Time.deltaTime;
                rootNode.transform.localScale += Vector3.one * scaleFactor;
            }

            if (tree2 == true)
            {
                float scaleFactor = growthRate * Time.deltaTime;
                rootNode2.transform.localScale += Vector3.one * scaleFactor;
            }

            if (tree3 == true)
            {
                float scaleFactor = growthRate * Time.deltaTime;
                rootNode3.transform.localScale += Vector3.one * scaleFactor;
            }


            /*// Grow the tree by scaling it up
            float scaleFactor = growthRate * Time.deltaTime;
            transform.GetChild(count).localScale += Vector3.one * scaleFactor;*/
        }


    }
}













