/* TODO
make IEnumerators for the other tasks we want to do in the tutorial
*/
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEditor;
using TMPro;

/*
This is a modularly designed tutorial system that uses IEnumerators and flags (_isWaiting) to wait for player interactions
If you want to add a part to the tutorial, then add a value to the TutorialState enum at the relative time you want the tutorial part to play
Then, create an IEnumerator that doesn't "yield return null" until the task is finished (if you don't know what this is then just search up Coroutines for unity online they are pretty common)
Then just pretty much follow the outline established by the other cases in the giant switch case statement
*/

class TutorialText : MonoBehaviour
{
    string _text;
    Vector2 _position;
    GameObject _tutorialTextPrefab;
    GameObject _textBox;

    public TutorialText(string text_, Vector2 position_, GameObject textPrefab_)
    {
        _text = text_;
        _position = position_;

        _tutorialTextPrefab = textPrefab_;
    }

    public void DisplayText()
    {
        _textBox = Instantiate(_tutorialTextPrefab, _position + (Vector2)_tutorialTextPrefab.transform.position, Quaternion.identity);
        _textBox.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = _text;
        // _textBox.transform.SetParent(_parent.transform);
    }

    public void RemoveText()
    {
        if (_textBox) Destroy(_textBox);
    }
}

public class Tutorial : MonoBehaviour
{

    Dictionary<string, string> leftPlayerControls = new()
    {
        {"up", "W"},
        {"down", "S"},
        {"left", "A"},
        {"right", "D"},
        {"interact", "Press A and D at the Same Time!"}
    };

    Dictionary<string, string> rightPlayerControls = new()
    {
        {"up", "Up Arrow"},
        {"down", "Down Arrow"},
        {"left", "Left Arrow"},
        {"right", "Right Arrow"},
        {"interact", "Press Left Arrow and Right Arrow at the Same Time!"}
    };

    TutorialState currentTutorialState = TutorialState.Basic_Movement;
    enum TutorialState
    {
        Basic_Movement = 0,
        Walk_to_Plant_Shop = 1,
        Buy_Plant = 2,
        Interact_Instruction = 3,
        Place_Plant = 4,
        Harvest_Plant = 5,
        Finished1 = 6,
        Finished2 = 7,
        Finished3 = 8
    };
    
    public GameObject tutorialTextPrefab;
    public Player playerScript;

    private GameObject _plantVendor;
    public GameObject plantPrefab;
    public GameObject turretPrefab;
    // private Territory _territoryScript;

    bool _isWaiting = false;


    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _plantVendor = GameObject.FindGameObjectWithTag("PlantVendor");
    }

    IEnumerator Wait(int waitFrames)
    {
        _isWaiting = true;
        for (int current_frame = 0; current_frame < waitFrames; current_frame++)
            yield return new WaitForEndOfFrame();

        _isWaiting = false;
        yield return null;
    }
    IEnumerator WaitAndDestroyText(int waitFrames, TutorialText text)
    {
        _isWaiting = true;
        for (int current_frame = 0; current_frame < waitFrames; current_frame++)
            yield return new WaitForEndOfFrame();

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerCompletesBasicMovementAndDestroyText(TutorialText text) 
    {
        bool hasPressedUp = false, hasPressedLeft = false, hasPressedDown = false, hasPressedRight = false;
        _isWaiting = true;

        while (!hasPressedDown || !hasPressedLeft || !hasPressedRight || !hasPressedUp)
        {
            if (playerScript.turnAction.ReadValue<Vector2>().x > 0) 
                hasPressedRight = true;
            if (playerScript.turnAction.ReadValue<Vector2>().y > 0)
                hasPressedUp = true;
            if (playerScript.turnAction.ReadValue<Vector2>().x < 0)
                hasPressedLeft = true;
            if (playerScript.turnAction.ReadValue<Vector2>().y < 0)
                hasPressedDown = true;

            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerWalksToPlantShopAndDestroyText(TutorialText text) 
    {
        bool hasWalkedToPlantShop = false;
        _isWaiting = true;

        while (!hasWalkedToPlantShop) 
        {
            if (Vector2.Distance(_plantVendor.transform.position, playerScript.gameObject.transform.position) <= 2)
                hasWalkedToPlantShop = true;

            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerBuysPlantAndDestroyText(TutorialText text)
    {
        bool hasBoughtPlant = false;
        _isWaiting = true;

        while (!hasBoughtPlant)
        {
            if (playerScript.bag == plantPrefab)
                hasBoughtPlant = true;
            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }
    
    IEnumerator WaitUntilPlayerPlacesPlantAndDestroyText(TutorialText text)
    {
        bool hasPlacedPlant = false;
        _isWaiting = true;

        while (!hasPlacedPlant)
        {
            if (playerScript.bag == null)
                hasPlacedPlant = true;
            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerHarvestsPlantAndDestroyText(TutorialText text)
    {
        bool hasHarvestedPlant = false;
        _isWaiting = true;

        while (!hasHarvestedPlant)
        {
            if (playerScript.money != 0)
                hasHarvestedPlant = true;
            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerBuysTurretAndDestroyText(TutorialText text)
    {
        bool hasBoughtTurret = false;
        _isWaiting = true;

        while (!hasBoughtTurret)
        {
            if (playerScript.bag == turretPrefab)
                hasBoughtTurret = true;
            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    IEnumerator WaitUntilPlayerPlacesTurretAndDestroyText(TutorialText text)
    {
        bool hasPlacedTurret = false;
        _isWaiting = true;

        while (!hasPlacedTurret)
        {
            if (playerScript.bag == null)
                hasPlacedTurret = true;
            yield return new WaitForEndOfFrame();
        }

        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }


    void Update()
    {
        if (_isWaiting) return;

        switch (currentTutorialState)
        {
            case TutorialState.Basic_Movement:
                playerScript.interactIsDisabled = true;

                TutorialText text = new("Press W, A, S, and D to move around the field", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerCompletesBasicMovementAndDestroyText(text));

                currentTutorialState++;
                break;

            case TutorialState.Walk_to_Plant_Shop:
                text = new("Walk to the green shop to buy a plant", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerWalksToPlantShopAndDestroyText(text));

                currentTutorialState++;
                break;

            case TutorialState.Buy_Plant:
                playerScript.interactIsDisabled = false;

                text = new("Buy the plant by holding left and right at the same time", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerBuysPlantAndDestroyText(text));

                currentTutorialState++;
                break;

            case TutorialState.Interact_Instruction:
                text = new("Holding left and right allows you to interact with things in the game!", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitAndDestroyText(300, text));

                currentTutorialState++;
                break;

            case TutorialState.Place_Plant:
                text = new("Now, walk over to some land and place the plant by holding left and right to interact with the land", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerPlacesPlantAndDestroyText(text));

                currentTutorialState++;
                break;

            case TutorialState.Harvest_Plant:
                text = new("Once the plant grows, interact with it to harvest the plant", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerHarvestsPlantAndDestroyText(text));

                currentTutorialState++;
                break;

            // case TutorialState.Buy_Turret:
            //     text = new("Oh no an enemy appeared! Buy a turret and place it down ", new Vector2(0, 6), tutorialTextPrefab);
            //     text.DisplayText();
            //     break;

            // case TutorialState.Place_Turret:
            //     print(currentTutorialState);
            //     break;

            case TutorialState.Finished1:
                text = new("You now know what you need to become the best farmer round these parts!", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitAndDestroyText(200, text));

                currentTutorialState++;
                break;
            
            case TutorialState.Finished2:
                text = new("You can press escape to leave or stay here to explore strategies", new Vector2(0, 6), tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitAndDestroyText(200, text));

                currentTutorialState++;
                break;
            

        }
    }
}
