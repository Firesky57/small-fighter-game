using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

   

    public static Vector2 lastCheckPointPos = new Vector2(-3,0);
    public GameObject[] playerPrefabs;
    private Sprite playersprite;
    int characterIndex;
    // Start is called before the first frame update
    void Start()
    {
        characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        

      
        
    }

    
}
