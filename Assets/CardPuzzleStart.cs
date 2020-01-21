using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPuzzleStart : MonoBehaviour
{
    private GameObject go_Player;
    public GameObject[] GO_Cards;
    private GameObject[] GO_CardPlaceholders;
    private List<GameObject> goList_Cards=new List<GameObject>();
    private Camera cm_CardCamera, cm_PlayerCamera;
    private bool bl_PlayerInRange = false, bl_InPuzzle=false;
    // Start is called before the first frame update
    void Start()
    {
        go_Player = GameObject.Find("Player");
        cm_CardCamera = GetComponentInChildren<Camera>();
        cm_PlayerCamera = GameObject.Find("PlayerCamera").GetComponentInChildren<Camera>();
        GO_CardPlaceholders = GameObject.FindGameObjectsWithTag("Card");
        ShuffleCards();
        Debug.Log(cm_CardCamera + "\n" + cm_PlayerCamera);
    }

    // Update is called once per frame
    void Update()
    {
        //Enter puzzle
        if (Input.GetKeyDown(KeyCode.E) && bl_PlayerInRange && !bl_InPuzzle)
        {
            Debug.Log("Enter puzzle");
            go_Player.SetActive(false);
            cm_CardCamera.enabled = true;
            bl_InPuzzle = true;
            StartCoroutine(FlipCards());
        }
        //Leave puzzle
        else if(Input.GetKeyDown(KeyCode.E) && bl_InPuzzle)
        {
            Debug.Log("Leave puzzle");
            cm_CardCamera.enabled = false;
            go_Player.SetActive(true);
            bl_InPuzzle = false;
            StartCoroutine(FlipCards());
        }

        if(bl_InPuzzle)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player in range");
            bl_PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player not in range");
            bl_PlayerInRange = false;
        }
    }

    private void ShuffleCards()
    {
        //Add cards to list
        foreach (GameObject card in GO_Cards)
        {
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
            goList_Cards.Add(card);
        }
        Debug.Log(goList_Cards.Count);
        //Replace placeholders with cards
        foreach(GameObject placeholder in GO_CardPlaceholders)
        {
            GameObject go_CardToSpawn = goList_Cards[Random.Range(0, goList_Cards.Count)];
            Debug.Log(go_CardToSpawn);
            GameObject.Instantiate(go_CardToSpawn, placeholder.transform).transform.SetParent(GameObject.Find("Cards").transform);
            GameObject.Destroy(placeholder);
            goList_Cards.Remove(go_CardToSpawn);
        }
    }

    private IEnumerator FlipCards()
    {
        GO_CardPlaceholders = GameObject.FindGameObjectsWithTag("Card");
        if (bl_InPuzzle)
        {
            foreach (GameObject card in GO_CardPlaceholders)
            {
                card.transform.Rotate(180, 0, 180);
            }

            yield return new WaitForSeconds(3);

            foreach (GameObject card in GO_CardPlaceholders)
            {
                card.transform.Rotate(-180, 0, -180);
            }

            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}