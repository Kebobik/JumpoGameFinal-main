using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class CameraShake : MonoBehaviour
{
    public GameObject PostProccesing;
    [SerializeField] CinemachineVirtualCamera vCamera;
  
     public IEnumerator StartShake()
    {
        PostProccesing.SetActive(true);
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 3;
        yield return new WaitForSeconds(10f);
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
        PostProccesing.SetActive(false);
    }
}
