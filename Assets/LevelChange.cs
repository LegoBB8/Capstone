using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public SteamVR_LoadLevel loadLevel;
    public string sceneToLoad;
    public GameObject player;




    public void ChangeLevel() { 
            SteamVR_LoadLevel.Begin(sceneToLoad);

            player = GameObject.FindGameObjectWithTag("Player");
            Destroy(player);

           
        }
    }

