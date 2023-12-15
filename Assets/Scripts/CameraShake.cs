// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Cinemachine;
// using System.Threading;

// public class CameraShake : MonoBehaviour 
// {
//     private CinemachineVirtualCamera cinemachineVirtualCamera;
//     private float shakeIntensity = 1f;
//     private float shakeTime = 0.2f;

//     private float timer;
//     private CinemachineBasicMultiChannelPerlin _cbmcp;

//     private void Awake() {
//         cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
//     }


//     private void Start() {
//         StopShake();
//     }

//     public void ShakeCamera() {
//         CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
//         _cbmcp.m_AmplitudeGain = shakeIntensity;

//         timer = shakeTime;
//     }

//     void StopShake(){
//         CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
//         _cbmcp.m_AmplitudeGain = 0f;
//         timer = 0f;
//     }
//     private void Update() {
//         // shake if witch screams
//         if (Input.GetKey(KeyCode.Space)) {
//             ShakeCamera();
//         }

//         if (timer > 0) {
//             timer -= Time.deltaTime;

//             if (timer <= 0){
//                 StopShake();
//             }
//         }
//     }
// }