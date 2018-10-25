using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//**********************************************************************************************************************//
// This class is used to set the Input for each player using the desired controller
//**********************************************************************************************************************//
public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;   // Static variable that can be used to call public variables and functions from other classes

    public string[] controllers;    //  Used to find the controllers connected

    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    void Awake()
    {
        Instance = this;    // Sets instance of the static variable before scenes loads
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Use this for initialization
    //**********************************************************************************************************************//
    void Start ()
    {
		
	}
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Update is called once per frame
    //**********************************************************************************************************************//
    void Update ()
    {
        ControllerListSetup();      // Finds a array of controllers that are currently connected

        SetInputModule();
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Finds a array of controllers that are currently connected
    // Note: This can be buggy if there is a faulty USB connection. If that's the case, then an element in the array will be
    // blank meaning that there is another controller connected, but it cannot be recognized as one.
    // Fix: Restart Unity/Game if that happens.
    //**********************************************************************************************************************//
    private void ControllerListSetup()
    {
        controllers = Input.GetJoystickNames();
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Finds the event system with the StandaloneInputModule component and updates navigation input for UI based on which
    // controller is connected
    //**********************************************************************************************************************//
    private void SetInputModule()
    {
        if (EventSystem.current)
        {
            StandaloneInputModule inputModule = EventSystem.current.gameObject.GetComponent<StandaloneInputModule>();

            for (int count = 0; count < controllers.Length; count++)
            {
                if (controllers[count] == "Wireless Controller")
                {
                    inputModule.submitButton = "PSInput_Cross (Controller " + (count + 1) + ")";
                }
                else
                {
                    inputModule.submitButton = "XInput_A (Controller " + (count + 1) + ")";
                }
            }
        }
    }
    //**********************************************************************************************************************//

    //**********************************************************************************************************************//
    // Return functions for X-Input
    // Note: Functions with the word "Down" at the end means that they will run for one frame everytime the button is pressed,
    // Otherwise, it runs every frame for when the button is held.
    // Also, Wireless Controller refers to ps4 controller plugged in via usb. Input is different for most keys.
    //**********************************************************************************************************************//
    public bool GetAButtonDown(PlayerOrder playerOrder)
    {
        switch(playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Cross (Controller 1)") : Input.GetButtonDown("XInput_A (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Cross (Controller 2)") : Input.GetButtonDown("XInput_A (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Cross (Controller 3)") : Input.GetButtonDown("XInput_A (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Cross (Controller 4)") : Input.GetButtonDown("XInput_A (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetAButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButton("PSInput_Cross (Controller 1)") : Input.GetButton("XInput_A (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButton("PSInput_Cross (Controller 2)") : Input.GetButton("XInput_A (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButton("PSInput_Cross (Controller 3)") : Input.GetButton("XInput_A (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButton("PSInput_Cross (Controller 4)") : Input.GetButton("XInput_A (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetBButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Circle (Controller 1)") : Input.GetButtonDown("XInput_B (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Circle (Controller 2)") : Input.GetButtonDown("XInput_B (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Circle (Controller 3)") : Input.GetButtonDown("XInput_B (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Circle (Controller 4)") : Input.GetButtonDown("XInput_B (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetBButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButton("PSInput_Circle (Controller 1)") : Input.GetButton("XInput_B (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButton("PSInput_Circle (Controller 2)") : Input.GetButton("XInput_B (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButton("PSInput_Circle (Controller 3)") : Input.GetButton("XInput_B (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButton("PSInput_Circle (Controller 4)") : Input.GetButton("XInput_B (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetXButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Square (Controller 1)") : Input.GetButtonDown("XInput_X (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Square (Controller 2)") : Input.GetButtonDown("XInput_X (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Square (Controller 3)") : Input.GetButtonDown("XInput_X (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Square (Controller 4)") : Input.GetButtonDown("XInput_X (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetXButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButton("PSInput_Square (Controller 1)") : Input.GetButton("XInput_X (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButton("PSInput_Square (Controller 2)") : Input.GetButton("XInput_X (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButton("PSInput_Square (Controller 3)") : Input.GetButton("XInput_X (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButton("PSInput_Square (Controller 4)") : Input.GetButton("XInput_X (Controller 4)");
                }
                break;
        }

        return false;
    }

    // Same
    public bool GetYButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButtonDown("XInput_Y (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButtonDown("XInput_Y (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButtonDown("XInput_Y (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButtonDown("XInput_Y (Controller 4)");
        }

        return false;
    }

    // Same
    public bool GetYButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButton("XInput_Y (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButton("XInput_Y (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButton("XInput_Y (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButton("XInput_Y (Controller 4)");
        }

        return false;
    }

    public bool GetStartButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Start (Controller 1)") : Input.GetButtonDown("XInput_Start (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Start (Controller 2)") : Input.GetButtonDown("XInput_Start (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Start (Controller 3)") : Input.GetButtonDown("XInput_Start (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Start (Controller 4)") : Input.GetButtonDown("XInput_Start (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetBackButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Select (Controller 1)") : Input.GetButtonDown("XInput_Back (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Select (Controller 2)") : Input.GetButtonDown("XInput_Back (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Select (Controller 3)") : Input.GetButtonDown("XInput_Back (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_Select (Controller 4)") : Input.GetButtonDown("XInput_Back (Controller 4)");
                }
                break;
        }

        return false;
    }

    // Same
    public bool GetLBButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButtonDown("XInput_LB (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButtonDown("XInput_LB (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButtonDown("XInput_LB (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButtonDown("XInput_LB (Controller 4)");
        }

        return false;
    }

    // Same
    public bool GetLBButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButton("XInput_LB (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButton("XInput_LB (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButton("XInput_LB (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButton("XInput_LB (Controller 4)");
        }

        return false;
    }

    // Same
    public bool GetRBButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButtonDown("XInput_RB (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButtonDown("XInput_RB (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButtonDown("XInput_RB (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButtonDown("XInput_RB (Controller 4)");
        }

        return false;
    }

    // Same
    public bool GetRBButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return Input.GetButton("XInput_RB (Controller 1)");
            case PlayerOrder.PLAYER_2:
                return Input.GetButton("XInput_RB (Controller 2)");
            case PlayerOrder.PLAYER_3:
                return Input.GetButton("XInput_RB (Controller 3)");
            case PlayerOrder.PLAYER_4:
                return Input.GetButton("XInput_RB (Controller 4)");
        }

        return false;
    }

    public bool GetLSButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_L3 (Controller 1)") : Input.GetButtonDown("XInput_LS_Press (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_L3 (Controller 2)") : Input.GetButtonDown("XInput_LS_Press (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_L3 (Controller 3)") : Input.GetButtonDown("XInput_LS_Press (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_L3 (Controller 4)") : Input.GetButtonDown("XInput_LS_Press (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetLSButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButton("PSInput_L3 (Controller 1)") : Input.GetButton("XInput_LS_Press (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButton("PSInput_L3 (Controller 2)") : Input.GetButton("XInput_LS_Press (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButton("PSInput_L3 (Controller 3)") : Input.GetButton("XInput_LS_Press (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButton("PSInput_L3 (Controller 4)") : Input.GetButton("XInput_LS_Press (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetRSButtonDown(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButtonDown("PSInput_R3 (Controller 1)") : Input.GetButtonDown("XInput_RS_Press (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButtonDown("PSInput_R3 (Controller 2)") : Input.GetButtonDown("XInput_RS_Press (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButtonDown("PSInput_R3 (Controller 3)") : Input.GetButtonDown("XInput_RS_Press (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButtonDown("PSInput_R3 (Controller 4)") : Input.GetButtonDown("XInput_RS_Press (Controller 4)");
                }
                break;
        }

        return false;
    }

    public bool GetRSButton(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetButton("PSInput_R3 (Controller 1)") : Input.GetButton("XInput_RS_Press (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetButton("PSInput_R3 (Controller 2)") : Input.GetButton("XInput_RS_Press (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetButton("PSInput_R3 (Controller 3)") : Input.GetButton("XInput_RS_Press (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetButton("PSInput_R3 (Controller 4)") : Input.GetButton("XInput_RS_Press (Controller 4)");
                }
                break;
        }

        return false;
    }

    // Same
    public Vector2 GetLeftStick(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                return new Vector2(Input.GetAxis("XInput_LS_Horizontal (Controller 1)"), Input.GetAxis("XInput_LS_Vertical (Controller 1)"));
            case PlayerOrder.PLAYER_2:
                return new Vector2(Input.GetAxis("XInput_LS_Horizontal (Controller 2)"), Input.GetAxis("XInput_LS_Vertical (Controller 2)"));
            case PlayerOrder.PLAYER_3:
                return new Vector2(Input.GetAxis("XInput_LS_Horizontal (Controller 3)"), Input.GetAxis("XInput_LS_Vertical (Controller 3)"));
            case PlayerOrder.PLAYER_4:
                return new Vector2(Input.GetAxis("XInput_LS_Horizontal (Controller 4)"), Input.GetAxis("XInput_LS_Vertical (Controller 4)"));
        }

        return new Vector2(0 , 0);
    }

    public Vector2 GetRightStick(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? new Vector2 (Input.GetAxis("PSInput_RS_Horizontal (Controller 1)"), Input.GetAxis("PSInput_RS_Vertical (Controller 1)")) : 
                        new Vector2(Input.GetAxis("XInput_RS_Horizontal (Controller 1)"), Input.GetAxis("XInput_RS_Vertical (Controller 1)"));
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_RS_Horizontal (Controller 2)"), Input.GetAxis("PSInput_RS_Vertical (Controller 2)")) :
                        new Vector2(Input.GetAxis("XInput_RS_Horizontal (Controller 2)"), Input.GetAxis("XInput_RS_Vertical (Controller 2)"));
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_RS_Horizontal (Controller 3)"), Input.GetAxis("PSInput_RS_Vertical (Controller 3)")) :
                        new Vector2(Input.GetAxis("XInput_RS_Horizontal (Controller 3)"), Input.GetAxis("XInput_RS_Vertical (Controller 3)"));
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_RS_Horizontal (Controller 4)"), Input.GetAxis("PSInput_RS_Vertical (Controller 4)")) :
                        new Vector2(Input.GetAxis("XInput_RS_Horizontal (Controller 4)"), Input.GetAxis("XInput_RS_Vertical (Controller 4)"));
                }
                break;
        }

        return new Vector2(0, 0);
    }

    public Vector2 GetDPad(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_DPad_Horizontal (Controller 1)"), Input.GetAxis("PSInput_DPad_Vertical (Controller 1)")) :
                        new Vector2(Input.GetAxis("XInput_DPad_Horizontal (Controller 1)"), Input.GetAxis("XInput_DPad_Vertical (Controller 1)"));
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_DPad_Horizontal (Controller 2)"), Input.GetAxis("PSInput_DPad_Vertical (Controller 2)")) :
                        new Vector2(Input.GetAxis("XInput_DPad_Horizontal (Controller 2)"), Input.GetAxis("XInput_DPad_Vertical (Controller 2)"));
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_DPad_Horizontal (Controller 3)"), Input.GetAxis("PSInput_DPad_Vertical (Controller 3)")) :
                        new Vector2(Input.GetAxis("XInput_DPad_Horizontal (Controller 3)"), Input.GetAxis("XInput_DPad_Vertical (Controller 3)"));
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? new Vector2(Input.GetAxis("PSInput_DPad_Horizontal (Controller 4)"), Input.GetAxis("PSInput_DPad_Vertical (Controller 4)")) :
                        new Vector2(Input.GetAxis("XInput_DPad_Horizontal (Controller 4)"), Input.GetAxis("XInput_DPad_Vertical (Controller 4)"));
                }
                break;
        }

        return new Vector2(0, 0);
    }

    public float GetLeftTrigger(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetAxis("PSInput_L2 (Controller 1)") : Input.GetAxis("XInput_LeftTrigger (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetAxis("PSInput_L2 (Controller 2)") : Input.GetAxis("XInput_LeftTrigger (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetAxis("PSInput_L2 (Controller 3)") : Input.GetAxis("XInput_LeftTrigger (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetAxis("PSInput_L2 (Controller 4)") : Input.GetAxis("XInput_LeftTrigger (Controller 4)");
                }
                break;
        }

        return 0.0f;
    }

    public float GetRightTrigger(PlayerOrder playerOrder)
    {
        switch (playerOrder)
        {
            case PlayerOrder.PLAYER_1:
                if (controllers.Length >= 1)
                {
                    return controllers[0] == "Wireless Controller" ? Input.GetAxis("PSInput_R2 (Controller 1)") : Input.GetAxis("XInput_RightTrigger (Controller 1)");
                }
                break;
            case PlayerOrder.PLAYER_2:
                if (controllers.Length >= 2)
                {
                    return controllers[1] == "Wireless Controller" ? Input.GetAxis("PSInput_R2 (Controller 2)") : Input.GetAxis("XInput_RightTrigger (Controller 2)");
                }
                break;
            case PlayerOrder.PLAYER_3:
                if (controllers.Length >= 3)
                {
                    return controllers[2] == "Wireless Controller" ? Input.GetAxis("PSInput_R2 (Controller 3)") : Input.GetAxis("XInput_RightTrigger (Controller 3)");
                }
                break;
            case PlayerOrder.PLAYER_4:
                if (controllers.Length >= 4)
                {
                    return controllers[3] == "Wireless Controller" ? Input.GetAxis("PSInput_R2 (Controller 4)") : Input.GetAxis("XInput_RightTrigger (Controller 4)");
                }
                break;
        }

        return 0.0f;
    }
    //**********************************************************************************************************************//
}
//**********************************************************************************************************************//