using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************************************/
// This class is used to set the player data into the game
/*******************************************************************************************************/
public class PlayerEventInput : MonoBehaviour
{
    public PlayerOrder playerOrder;     // Used to set which player is which in the inspector

    /*******************************************************************************************************/
    // Use this for initialization
    /*******************************************************************************************************/
    void Start ()
    {
		
	}
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Update is called once per frame
    /*******************************************************************************************************/
    void Update ()
    {
        SetSelectControl();

    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to set the controller mapping to the StandaloneInputModule component for the correct player in
    // control.
    /*******************************************************************************************************/
    private void SetSelectControl()
    {
        if (GetAnyButton())
        {
            ControllerManager.Instance.SetInputModule(playerOrder);
        }
    }
    /*******************************************************************************************************/

    /*******************************************************************************************************/
    // Used to get every possible input from the controller.
    /*******************************************************************************************************/
    public bool GetAnyButton()
    {
        if (ControllerManager.Instance.GetAButtonDown(playerOrder) || ControllerManager.Instance.GetBButtonDown(playerOrder) || ControllerManager.Instance.GetXButtonDown(playerOrder) ||
            ControllerManager.Instance.GetYButtonDown(playerOrder) || ControllerManager.Instance.GetStartButtonDown(playerOrder) || ControllerManager.Instance.GetBackButtonDown(playerOrder) ||
            ControllerManager.Instance.GetLBButtonDown(playerOrder) || ControllerManager.Instance.GetRBButtonDown(playerOrder) || ControllerManager.Instance.GetLeftTrigger(playerOrder) > 0.0f ||
            ControllerManager.Instance.GetRightTrigger(playerOrder) > 0.0f || ControllerManager.Instance.GetLSButton(playerOrder) || ControllerManager.Instance.GetRSButton(playerOrder) ||
            ControllerManager.Instance.GetDPad(playerOrder).x < 0.0f || ControllerManager.Instance.GetDPad(playerOrder).x > 0.0f || ControllerManager.Instance.GetDPad(playerOrder).y < 0.0f ||
            ControllerManager.Instance.GetDPad(playerOrder).y > 0.0f || ControllerManager.Instance.GetLeftStick(playerOrder).x < 0.0f || ControllerManager.Instance.GetLeftStick(playerOrder).x > 0.0f ||
            ControllerManager.Instance.GetLeftStick(playerOrder).y < 0.0f || ControllerManager.Instance.GetLeftStick(playerOrder).y > 0.0f || ControllerManager.Instance.GetRightStick(playerOrder).x < 0.0f ||
            ControllerManager.Instance.GetRightStick(playerOrder).x > 0.0f || ControllerManager.Instance.GetRightStick(playerOrder).y < 0.0f || ControllerManager.Instance.GetRightStick(playerOrder).y > 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /*******************************************************************************************************/
}
/*******************************************************************************************************/
