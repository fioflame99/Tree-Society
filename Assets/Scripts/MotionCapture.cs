using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

[DefaultExecutionOrder(100)]
public class MotionCapture : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Animator animator;
    //string jsonString = File.ReadAllText(Application.dataPath + "/test.txt");

   // [SerializeField] private Transform Neck;
    
    //For Body Pose2DLandmarks and Pose3DLandmarks
    [SerializeField] private Transform J_Bip_C_Neck;
    [SerializeField] private Transform J_Bip_C_Hips;
    [SerializeField] private Transform J_Bip_C_Chest;
    [SerializeField] private Transform J_Bip_C_Spine;
    [SerializeField] private Transform J_Bip_R_UpperArm;
    [SerializeField] private Transform J_Bip_R_LowerArm;
    [SerializeField] private Transform J_Bip_L_UpperArm;
    [SerializeField] private Transform J_Bip_L_LowerArm;
    [SerializeField] private Transform J_Bip_R_UpperLeg;
    [SerializeField] private Transform J_Bip_R_LowerLeg;
    [SerializeField] private Transform J_Bip_L_UpperLeg;
    [SerializeField] private Transform J_Bip_L_LowerLeg;
    /*
    //For Left Fingers
     [SerializeField] private Transform LeftHand;
     [SerializeField] private Transform LeftRingProximal;
     [SerializeField] private Transform LeftRingIntermediate;
     [SerializeField] private Transform LeftRingDistal;
     [SerializeField] private Transform LeftIndexProximal;
     [SerializeField] private Transform LeftIndexIntermediate;
     [SerializeField] private Transform LeftIndexDistal;
     [SerializeField] private Transform LeftMiddleProximal;
     [SerializeField] private Transform LeftThumbProximal;
     [SerializeField] private Transform LeftThumbIntermediate;
     [SerializeField] private Transform LeftThumbDistal;
     [SerializeField] private Transform LeftLittleProximal;
     [SerializeField] private Transform LeftLittleIntermediate;
     [SerializeField] private Transform LeftLittleDistal;

    //For Right Fingers
     [SerializeField] private Transform RightHand;
     [SerializeField] private Transform RightRingProximal;
     [SerializeField] private Transform RightRingIntermediate;
     [SerializeField] private Transform RightRingDistal;
     [SerializeField] private Transform RightIndexProximal;
     [SerializeField] private Transform RightIndexIntermediate;
     [SerializeField] private Transform RightIndexDistal;
     [SerializeField] private Transform RightMiddleProximal;
     [SerializeField] private Transform RightThumbProximal;
     [SerializeField] private Transform RightThumbIntermediate;
     [SerializeField] private Transform RightThumbDistal;
     [SerializeField] private Transform RightLittleProximal;
     [SerializeField] private Transform RightLittleIntermediate;
     [SerializeField] private Transform RightLittleDistal;
    */
    int dampener= 1;
    float lerpAmount=1f;
    float lerpAmountRotation=0.3f;

    public void Awake(){
        //Body
       J_Bip_C_Neck = animator.GetBoneTransform(HumanBodyBones.Neck);
        J_Bip_C_Hips = animator.GetBoneTransform(HumanBodyBones.Hips);
        J_Bip_C_Chest= animator.GetBoneTransform(HumanBodyBones.Chest);
        J_Bip_C_Spine=animator.GetBoneTransform(HumanBodyBones.Spine);
    //    J_Bip_R_UpperArm=animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
    //    J_Bip_R_LowerArm=animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
    //    J_Bip_L_UpperArm=animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
    //    J_Bip_L_LowerArm=animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
    //    J_Bip_R_UpperLeg=animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
    //    J_Bip_R_LowerLeg=animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
    //    J_Bip_L_UpperLeg=animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
    //    J_Bip_L_LowerLeg=animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        
    //     //Left Hand
    //    LeftHand=animator.GetBoneTransform(HumanBodyBones.LeftHand);
    //    LeftRingProximal=animator.GetBoneTransform(HumanBodyBones.LeftRingProximal);
    //    LeftRingIntermediate=animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate);
    //    LeftRingDistal=animator.GetBoneTransform(HumanBodyBones.LeftRingDistal);
    //    LeftIndexProximal=animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
    //    LeftIndexIntermediate=animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate);
    //    LeftIndexDistal=animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal);
    //    LeftMiddleProximal=animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal);
    //    LeftThumbProximal=animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
    //    LeftThumbIntermediate=animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
    //    LeftThumbDistal=animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal);
    //    LeftLittleProximal=animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
    //    LeftLittleIntermediate=animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate);
    //    LeftLittleDistal=animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal);

    //     //Right Hand
    //    RightHand=animator.GetBoneTransform(HumanBodyBones.RightHand);
    //    RightRingProximal=animator.GetBoneTransform(HumanBodyBones.RightRingProximal);
    //    RightRingIntermediate=animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
    //    RightRingDistal=animator.GetBoneTransform(HumanBodyBones.RightRingDistal);
    //    RightIndexProximal=animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
    //    RightIndexIntermediate=animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
    //    RightIndexDistal=animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
    //    RightMiddleProximal=animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
    //    RightThumbProximal=animator.GetBoneTransform(HumanBodyBones.RightThumbProximal);
    //    RightThumbIntermediate=animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
    //    RightThumbDistal=animator.GetBoneTransform(HumanBodyBones.RightThumbDistal);
    //    RightLittleProximal=animator.GetBoneTransform(HumanBodyBones.RightLittleProximal);
    //    RightLittleIntermediate=animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
    //    RightLittleDistal=animator.GetBoneTransform(HumanBodyBones.RightLittleDistal);
            
    }

    /*
    public void Update()
    {
        //Debug.Log("UnityRotationsNeck: " + J_Bip_C_Neck + " LeftHand: "+LeftHand+" LeftRingProximal: " +LeftRingProximal+" RightHand: "+ RightHand+" RightLittleProximal: "+ RightLittleProximal+" J_Bip_R_UpperArm: "+J_Bip_R_UpperArm);
        //UpdateRotations(jsonString);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 rotation = new Vector3(3,3,3);
            Quaternion quaternion = Quaternion.Euler(rotation);
            J_Bip_C_Hips.rotation= quaternion;
            // UpdateFaceBlendshapes(jsonString);
            // UpdatePositions(jsonString);
            // UpdateRotations(jsonString);
        }
        //Debug.Log("J_Bip_C_Neck rotation"+animator.GetBoneTransform(HumanBodyBones.Neck).rotation+"J_Bip_C_Chest rotation"+animator.GetBoneTransform(HumanBodyBones.Chest).rotation);
        Debug.Log("J_Bip_C_Neck rotation"+J_Bip_C_Neck.rotation);

    }
    */
    public void UpdateFaceBlendshapes(string BlendshapeValues)
    {
        // Parse the string into a JSONObject
        JSONObject jsonObject = JSON.Parse(BlendshapeValues) as JSONObject;
        skinnedMeshRenderer.SetBlendShapeWeight(0, jsonObject["Neutral"]);
        skinnedMeshRenderer.SetBlendShapeWeight(1, jsonObject["Fun"]);
        skinnedMeshRenderer.SetBlendShapeWeight(2, jsonObject["Sorrow"]);
        skinnedMeshRenderer.SetBlendShapeWeight(3, jsonObject["Angry"]);
        skinnedMeshRenderer.SetBlendShapeWeight(4, jsonObject["Joy"]);
        skinnedMeshRenderer.SetBlendShapeWeight(5, jsonObject["Surprised"]);
        skinnedMeshRenderer.SetBlendShapeWeight(28, jsonObject["A"]);
        skinnedMeshRenderer.SetBlendShapeWeight(29, jsonObject["I"]);
        skinnedMeshRenderer.SetBlendShapeWeight(30, jsonObject["U"]);
        skinnedMeshRenderer.SetBlendShapeWeight(31, jsonObject["E"]);
        skinnedMeshRenderer.SetBlendShapeWeight(32, jsonObject["O"]);
        skinnedMeshRenderer.SetBlendShapeWeight(11, jsonObject["Close"]);
        skinnedMeshRenderer.SetBlendShapeWeight(12, jsonObject["Close_R"]);
        skinnedMeshRenderer.SetBlendShapeWeight(13, jsonObject["Close_L"]);
        // Debug.Log("Blendshapevalue: " + BlendshapeValues + BlendshapeValues.GetType());
        // Debug.Log("Blendshapevalue 28: " + jsonObject["A"]);
        // Debug.Log("skinnedMeshRenderer 28: " + skinnedMeshRenderer.GetBlendShapeWeight(28));
        // Debug.Log("skinnedMeshRenderer 29: " + skinnedMeshRenderer.GetBlendShapeWeight(29));
        // Debug.Log("skinnedMeshRenderer 11: " + skinnedMeshRenderer.GetBlendShapeWeight(11));
    }
   
    public void UpdatePositions(string HipPosition)
    {
        // Parse the string into a JSONObject
        JSONObject jsonObject = JSON.Parse(HipPosition) as JSONObject;
        Vector3 vector= new Vector3(jsonObject["PoseXHips"]*dampener, jsonObject["PoseYHips"]*dampener, jsonObject["PoseZHips"]*dampener);
        // Debug.Log("Vector" + vector);
        // J_Bip_C_Hips.position=Vector3.Lerp(J_Bip_C_Hips.position, vector,lerpAmount);
        J_Bip_C_Hips.position=vector;
        Debug.Log("PositionsUnityUpdate: " + J_Bip_C_Hips);
       // Debug.Log("Position Hips"+ animator.GetBoneTransform(HumanBodyBones.Hips).position);
    }
    
   public void UpdateRotations(string BodyRotations){
       // Parse the string into a JSONObject
       JSONObject jsonObject = JSON.Parse(BodyRotations) as JSONObject;
      //For Body
       RotationQuaternionConversion("J_Bip_C_Neck",J_Bip_C_Neck, HumanBodyBones.Neck,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_C_Hips",J_Bip_C_Hips, HumanBodyBones.Hips,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_C_Chest",J_Bip_C_Chest, HumanBodyBones.Chest,0.25f,jsonObject);
       RotationQuaternionConversion("J_Bip_C_Spine",J_Bip_C_Spine, HumanBodyBones.Spine,0.45f,jsonObject);
       RotationQuaternionConversion("J_Bip_R_UpperArm",J_Bip_R_UpperArm, HumanBodyBones.RightUpperArm,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_R_LowerArm",J_Bip_R_LowerArm, HumanBodyBones.RightLowerArm,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_L_UpperArm",J_Bip_L_UpperArm, HumanBodyBones.LeftUpperArm,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_L_LowerArm",J_Bip_L_LowerArm, HumanBodyBones.LeftLowerArm,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_R_UpperLeg",J_Bip_R_UpperLeg, HumanBodyBones.RightUpperLeg,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_R_LowerLeg",J_Bip_R_LowerLeg, HumanBodyBones.RightLowerLeg,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_L_UpperLeg",J_Bip_L_UpperLeg, HumanBodyBones.LeftUpperLeg,0.7f,jsonObject);
       RotationQuaternionConversion("J_Bip_L_LowerLeg",J_Bip_L_LowerLeg, HumanBodyBones.LeftLowerLeg,0.7f,jsonObject);
        /*
       //For Left Fingers
       RotationQuaternionConversion("LeftHand",LeftHand,HumanBodyBones.LeftHand,1,jsonObject);
       RotationQuaternionConversion("LeftRingProximal",LeftRingProximal, HumanBodyBones.LeftRingProximal,1,jsonObject);
       RotationQuaternionConversion("LeftRingIntermediate",LeftRingIntermediate, HumanBodyBones.LeftRingIntermediate,1,jsonObject);
       RotationQuaternionConversion("LeftRingDistal",LeftRingDistal, HumanBodyBones.LeftRingDistal,1,jsonObject);
       RotationQuaternionConversion("LeftIndexProximal",LeftIndexProximal, HumanBodyBones.LeftIndexProximal,1,jsonObject);
       RotationQuaternionConversion("LeftIndexIntermediate",LeftIndexIntermediate, HumanBodyBones.LeftIndexIntermediate,1,jsonObject);
       RotationQuaternionConversion("LeftIndexDistal",LeftIndexDistal, HumanBodyBones.LeftIndexDistal,1,jsonObject);
       RotationQuaternionConversion("LeftMiddleProximal",LeftMiddleProximal, HumanBodyBones.LeftMiddleProximal,1,jsonObject);
       RotationQuaternionConversion("LeftThumbProximal",LeftThumbProximal, HumanBodyBones.LeftThumbProximal,1,jsonObject);
       RotationQuaternionConversion("LeftThumbIntermediate",LeftThumbIntermediate, HumanBodyBones.LeftThumbIntermediate,1,jsonObject);
       RotationQuaternionConversion("LeftThumbDistal",LeftThumbDistal, HumanBodyBones.LeftThumbDistal,1,jsonObject);
       RotationQuaternionConversion("LeftLittleProximal",LeftLittleProximal, HumanBodyBones.LeftLittleProximal,1,jsonObject);
       RotationQuaternionConversion("LeftLittleIntermediate",LeftLittleIntermediate, HumanBodyBones.LeftLittleIntermediate,1,jsonObject);
       RotationQuaternionConversion("LeftLittleDistal",LeftLittleDistal, HumanBodyBones.LeftLittleDistal,1,jsonObject);

       //For Right Fingers
       RotationQuaternionConversion("RightHand",RightHand,HumanBodyBones.RightHand,1,jsonObject);
       RotationQuaternionConversion("RightRingProximal",RightRingProximal, HumanBodyBones.RightRingProximal,1,jsonObject);
       RotationQuaternionConversion("RightRingIntermediate",RightRingIntermediate, HumanBodyBones.RightRingIntermediate,1,jsonObject);
       RotationQuaternionConversion("RightRingDistal",RightRingDistal, HumanBodyBones.RightRingDistal,1,jsonObject);
       RotationQuaternionConversion("RightIndexProximal",RightIndexProximal, HumanBodyBones.RightIndexProximal,1,jsonObject);
       RotationQuaternionConversion("RightIndexIntermediate",RightIndexIntermediate, HumanBodyBones.RightIndexIntermediate,1,jsonObject);
       RotationQuaternionConversion("RightIndexDistal",RightIndexDistal, HumanBodyBones.RightIndexDistal,1,jsonObject);
       RotationQuaternionConversion("RightMiddleProximal",RightMiddleProximal, HumanBodyBones.RightMiddleProximal,1,jsonObject);
       RotationQuaternionConversion("RightThumbProximal",RightThumbProximal, HumanBodyBones.RightThumbProximal,1,jsonObject);
       RotationQuaternionConversion("RightThumbIntermediate",RightThumbIntermediate, HumanBodyBones.RightThumbIntermediate,1,jsonObject);
       RotationQuaternionConversion("RightThumbDistal",RightThumbDistal, HumanBodyBones.RightThumbDistal,1,jsonObject);
       RotationQuaternionConversion("RightLittleProximal",RightLittleProximal, HumanBodyBones.RightLittleProximal,1,jsonObject);
       RotationQuaternionConversion("RightLittleIntermediate",RightLittleIntermediate, HumanBodyBones.RightLittleIntermediate,1,jsonObject);
       RotationQuaternionConversion("RightLittleDistal",RightLittleDistal, HumanBodyBones.RightLittleDistal,1,jsonObject);
  */
        
        }
  
 public void RotationQuaternionConversion(string jsonName, Transform bodyTransform, HumanBodyBones humanBodyBone, float dampener, JSONObject jsonObject){
       Vector3 rotation = new Vector3(jsonObject[jsonName]["x"] *dampener, jsonObject[jsonName]["y"] *dampener,jsonObject[jsonName]["z"] *dampener);
       Debug.Log("part 1"+jsonName+" " +rotation);
       Quaternion quaternion = Quaternion.Euler(rotation);
       Debug.Log("part 2 quaternion" + quaternion);
       //humanBodyBone.Transform.rotation = Quaternion.Slerp(boneTransform.localRotation, quaternion, lerpAmount);      
       // bodyTransform.rotation = Quaternion.Slerp(bodyTransform.rotation, quaternion, lerpAmount);
       bodyTransform.rotation=quaternion;
       Debug.Log("part 3" +bodyTransform.rotation);
       // Set the new rotation using SetBoneLocalRotation
       //animator.SetBoneLocalRotation(humanBodyBone, newRotation);
      // Debug.Log("animator: rotation "+ animator.GetBoneTransform(humanBodyBone).rotation);
    }

    }
