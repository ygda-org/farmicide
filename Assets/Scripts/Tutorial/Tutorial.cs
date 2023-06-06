/* TODO
make IEnumerators for the other tasks we want to do in the tutorial
make the player able to choose if they want to play the tutorial as the left player or the right player
*/

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEditor;



class TutorialText : MonoBehaviour
{
    string _text;
    Vector2 _position;
    GameObject _tutorialTextPrefab;
    GameObject _parent;

    GameObject _textBox;

    public TutorialText(string text_, Vector2 position_, GameObject textPrefab_, GameObject parent_)
    {
        _text = text_;
        _position = position_;

        _tutorialTextPrefab = textPrefab_;
        _parent = parent_;
    }

    public void DisplayText()
    {
        _textBox = Instantiate(_tutorialTextPrefab, _position + (Vector2)_tutorialTextPrefab.transform.position, Quaternion.identity);

        // _textBox.transform.SetParent(_parent.transform);
    }

    public void RemoveText()
    {
        if (_textBox)
            Destroy(_textBox);
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
        Place_Plant = 3,
        Harvest_Plant = 4,
        Buy_Turret = 5,
        Place_Turret = 6
    };

    public GameObject tutorialTextCanvas;
    public GameObject tutorialTextPrefab;
    bool _isWaiting = false;

    public Player playerScript;

    void Start()
    {
        tutorialTextCanvas = GameObject.FindGameObjectWithTag("TutorialTextCanvas");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    IEnumerator Wait(int waitFrames)
    {
        print("started");
        _isWaiting = true;
        for (int current_frame = 0; current_frame < waitFrames; current_frame++)
            yield return new WaitForEndOfFrame();

        _isWaiting = false;
        print("done");
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

    IEnumerator WaitUntilPlayerCompletesBasicMovementAndDestroyText(TutorialText text) {
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

        print("finished");
        _isWaiting = false;
        text.RemoveText();
        yield return null;
    }

    

    void Update()
    {
        print(_isWaiting);
        if (_isWaiting) return;

        switch (currentTutorialState)
        {
            case TutorialState.Basic_Movement:
                TutorialText text = new("Press W, A, S, and D to move around the field", new Vector2(0, 2), tutorialTextPrefab, tutorialTextPrefab);
                text.DisplayText();
                StartCoroutine(WaitUntilPlayerCompletesBasicMovementAndDestroyText(text));
                currentTutorialState++;
                break;

            case TutorialState.Walk_to_Plant_Shop:
                print(currentTutorialState);
                break;

            case TutorialState.Buy_Plant:
                print(currentTutorialState);
                break;

            case TutorialState.Place_Plant:
                print(currentTutorialState);
                break;

            case TutorialState.Harvest_Plant:
                print(currentTutorialState);
                break;

            case TutorialState.Buy_Turret:
                print(currentTutorialState);
                break;

            case TutorialState.Place_Turret:
                print(currentTutorialState);
                break;
        }
    }
}
