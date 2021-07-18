using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningMiniGameMapScript : MonoBehaviour
{
    [SerializeField] MiningCard miningCard;
    [SerializeField] PlayerBalance playerBalance;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject upgradebutton;
    [SerializeField] float timer = 10f;
   
    public GameObject ground;
    public GameObject player;
    public GameObject coin;
    private int z = 1;
    private int spawnCoin;
    public void StartGeneration()
    {
        StartCoroutine(GenerateMap());
    }

    private IEnumerator GenerateMap()
    {
        var playerclone = Instantiate(player, new Vector3(-200, 4, 1), player.transform.rotation);
        playerclone.GetComponent<PlayerMovement>().SetPlayerBalance(playerBalance);
        playerclone.GetComponent<PlayerMovement>().SetMiningCard(miningCard);
        startButton.GetComponent<Button>().interactable = false;
        upgradebutton.GetComponent<Button>().interactable = false;
        var instantiatedObjects = new List<GameObject> {playerclone};
        for (int y = -5; y <= 2; y++)
        {
            y++;
            for (int x = -208; x <= -191; x++)
            {
                spawnCoin = Random.Range(0, 20);
                if (spawnCoin >= 10) 
                {
                    var coinclone = Instantiate(coin, new Vector3(x, y, z), coin.transform.rotation);
                    instantiatedObjects.Add(coinclone);
                }

                var groundclone = Instantiate(ground, new Vector3(x, y, z), ground.transform.rotation);
                instantiatedObjects.Add(groundclone);
                x++;
            }
        }
        Debug.Log("here1");
        yield return new WaitForSeconds(timer);
        foreach (var instantiatedObject in instantiatedObjects)
        {
            Destroy(instantiatedObject);
        }
        Debug.Log("here2");
        startButton.GetComponent<Button>().interactable = true;
        upgradebutton.GetComponent<Button>().interactable = true;
        
    }

}