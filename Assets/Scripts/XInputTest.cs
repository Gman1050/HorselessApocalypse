using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XInputTest : MonoBehaviour
{

    //**********************************************************************************************************************//
    // Use this for initialization
    void Start ()
    {
		
	}
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Update is called once per frame
    //**********************************************************************************************************************//
    void Update ()
    {
        XInput();   // Function to Test X-Input

    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Function to check return functions for X-Input
    //**********************************************************************************************************************//
    void XInput()
    {
        if (GetAButtonDown())
        {
            Debug.Log("A:" + GetAButtonDown());
        }

        if (GetBButtonDown())
        {
            Debug.Log("B:" + GetBButtonDown());
        }

        if (GetXButtonDown())
        {
            Debug.Log("X:" + GetXButtonDown());
        }

        if (GetYButtonDown())
        {
            Debug.Log("Y:" + GetYButtonDown());
        }

        if (GetStartButtonDown())
        {
            Debug.Log("Start:" + GetStartButtonDown());
        }

        if (GetBackButtonDown())
        {
            Debug.Log("Back:" + GetBackButtonDown());
        }

        if (GetLBButtonDown())
        {
            Debug.Log("LB:" + GetLBButtonDown());
        }

        if (GetRBButtonDown())
        {
            Debug.Log("RB:" + GetRBButtonDown());
        }

        if (GetLSButtonDown())
        {
            Debug.Log("LS:" + GetLSButtonDown());
        }

        if (GetRSButtonDown())
        {
            Debug.Log("RS:" + GetRSButtonDown());
        }

        if (GetLeftStick().x != 0 || GetLeftStick().y != 0)
        {
            Debug.Log("LS Axis:" + GetLeftStick());
        }

        if (GetRightStick().x != 0 || GetRightStick().y != 0)
        {
            Debug.Log("RS Axis:" + GetRightStick());
        }

        if (GetDPad().x != 0 || GetDPad().y != 0)
        {
            Debug.Log("DPad Axis:" + GetDPad());
        }

        if (GetLeftTrigger() != 0)
        {
            Debug.Log("Left Trigger:" + GetLeftTrigger());
        }

        if (GetRightTrigger() != 0)
        {
            Debug.Log("Right Trigger:" + GetRightTrigger());
        }
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Return functions for X-Input
    //**********************************************************************************************************************//
    bool GetAButtonDown()
    {
        return Input.GetButtonDown("XInput_A");
    }

    bool GetBButtonDown()
    {
        return Input.GetButtonDown("XInput_B");
    }

    bool GetXButtonDown()
    {
        return Input.GetButtonDown("XInput_X");
    }

    bool GetYButtonDown()
    {
        return Input.GetButtonDown("XInput_Y");
    }

    bool GetStartButtonDown()
    {
        return Input.GetButtonDown("XInput_Start");
    }

    bool GetBackButtonDown()
    {
        return Input.GetButtonDown("XInput_Back");
    }

    bool GetLBButtonDown()
    {
        return Input.GetButtonDown("XInput_LB");
    }

    bool GetRBButtonDown()
    {
        return Input.GetButtonDown("XInput_RB");
    }

    bool GetLSButtonDown()
    {
        return Input.GetButtonDown("XInput_LS_Press");
    }

    bool GetRSButtonDown()
    {
        return Input.GetButtonDown("XInput_RS_Press");
    }

    Vector2 GetLeftStick()
    {
        return new Vector2(Input.GetAxis("XInput_LS_Horizontal"), Input.GetAxis("XInput_LS_Vertical"));
    }

    Vector2 GetRightStick()
    {
        return new Vector2(Input.GetAxis("XInput_RS_Horizontal"), Input.GetAxis("XInput_RS_Vertical"));
    }

    Vector2 GetDPad()
    {
        return new Vector2(Input.GetAxis("XInput_DPad_Horizontal"), Input.GetAxis("XInput_Dpad_Vertical"));
    }

    float GetLeftTrigger()
    {
        return Input.GetAxis("XInput_LeftTrigger");
    }

    float GetRightTrigger()
    {
        return Input.GetAxis("XInput_RightTrigger");
    }
    //**********************************************************************************************************************//
}
