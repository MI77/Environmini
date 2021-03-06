//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/InputSystem/GameControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""GridControls"",
            ""id"": ""2784e88e-9626-4686-918c-1ceb5cf48b29"",
            ""actions"": [
                {
                    ""name"": ""MoveSelection"",
                    ""type"": ""Value"",
                    ""id"": ""28c7a2a4-9f28-44b8-9763-7fa2ed4e0e17"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SetTile"",
                    ""type"": ""Button"",
                    ""id"": ""a1f6336e-a985-4c30-8725-9c5598570e29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""64e40684-0245-436d-9036-c1eff43cf06c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5dc71582-fb39-4415-8153-53ecccd7b7e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""14042181-4192-4ea4-9b42-3f7fcd011c8e"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""db686613-68cb-4191-ace5-352c9ab68eeb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bf1e9545-41ca-414a-a45a-780ddd81d4b6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0ccd7d9c-b1f3-46a6-8c75-127bee926efb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e7bdf01-f01b-4fd2-85fa-9093f1850475"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3d290118-0776-47a5-9780-1d49564f4fc8"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetTile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f52f364-db3b-4be7-8dad-d4b5b9929015"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetTile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d96881d8-d87d-4925-8e5f-9877ef678425"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f1feacd-bbc6-4723-afd4-cf38221475bf"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e7d288f-c307-4366-bb4d-72282399c480"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b346690-43e6-4103-ac8e-0bf2c29eb6aa"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2de78220-67f1-4ea0-9bb9-10b8ae76f944"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17a39a8c-0d6e-4c87-8091-9a8283636ff2"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2df00187-0b7f-4f82-b93b-6363f4e1500e"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""586c38ec-dbf5-4571-9d66-65ddf41866aa"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControls"",
            ""id"": ""8ec4e3d6-6154-4628-abc1-017836c8b9ee"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""b7db06b9-9fd6-4bd5-9609-3ac52ab5867c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""fe1d221e-623b-44d8-99b0-1e00f2d75d13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""50c34004-bfcc-4d98-ac35-70a9b2a9e54a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Value"",
                    ""id"": ""46858df0-8c26-4d08-bf72-6eab99cf27a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HideMenu"",
                    ""type"": ""Button"",
                    ""id"": ""3e72c950-9773-4f62-8fe7-50b4404a08af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""70a94133-0d45-490c-8559-f34d6557c2a9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""976198b7-6a48-4200-a857-94f7aedc19a7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b3a0a904-ec4b-4dc1-aa9c-ca0f63d337ea"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b78d1f99-2d74-4c80-87e0-adf9b63bd4d6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3ebe2832-bda9-4058-ac3f-06664dbfb78b"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""241dd78d-fee8-4210-af91-69d861ba93f9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b3ae7ee-79ef-49e0-870d-b36fd14a329a"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f2b96c38-10a5-419d-b58a-a2b7317e99d9"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""514bf747-a3f9-458f-9e24-5bf9da97fb15"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b6c87b3-5829-48ec-b006-a924165e3272"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""55f55fc9-4dce-4d5b-8f2d-98a05342fd1f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f4978088-b8dc-4739-b30f-35b6d73f8448"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ef124a8-5131-4ab8-a25b-b3e6b2196312"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2fd4b6fc-f30e-448b-8846-3cdb426ef2e9"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""76dc09e8-465d-445a-b26e-d5248fff110c"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""335f6676-b753-455a-91c6-97f97e5c8a4c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""18c9b2df-5a78-4448-b9a4-f8be8b8df1d8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4f5a86e-5748-4572-8c85-ca00a2fa93d4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c5d2462c-c7df-4e28-b651-fb6796304f5e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef54dfe0-d0c0-4e06-b9a5-153f13870d6f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""df2a7e96-0425-45f8-9395-70a10714a9a3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""55fa1abe-e6ef-48e8-b207-c371e0b36648"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4e43383-18e7-4b70-a1d6-12e4dbd1cd00"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bca23469-0aff-461b-8d52-01f93abc5e59"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d100d468-fb81-4e47-9921-cca34cd381c2"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b297771-7240-4acd-885a-f7333775d8c6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4761299d-1603-4ebe-941f-83ec56539fbc"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f6faf6b-813e-4016-b009-d82bf0a309f0"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60a8e5d0-11af-411e-8363-3f860de7e10a"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1888d490-84a1-42a4-87e5-0e891780d83e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce563900-9471-485e-9d5d-f9f7814efe76"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee8cdc11-04a1-4110-946f-d594a605d6c6"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbccb4c6-ecfe-49d1-a1f2-296942c1eedb"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HideMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GridControls
        m_GridControls = asset.FindActionMap("GridControls", throwIfNotFound: true);
        m_GridControls_MoveSelection = m_GridControls.FindAction("MoveSelection", throwIfNotFound: true);
        m_GridControls_SetTile = m_GridControls.FindAction("SetTile", throwIfNotFound: true);
        m_GridControls_OpenMenu = m_GridControls.FindAction("OpenMenu", throwIfNotFound: true);
        m_GridControls_Click = m_GridControls.FindAction("Click", throwIfNotFound: true);
        // MenuControls
        m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
        m_MenuControls_Navigate = m_MenuControls.FindAction("Navigate", throwIfNotFound: true);
        m_MenuControls_Submit = m_MenuControls.FindAction("Submit", throwIfNotFound: true);
        m_MenuControls_Click = m_MenuControls.FindAction("Click", throwIfNotFound: true);
        m_MenuControls_Point = m_MenuControls.FindAction("Point", throwIfNotFound: true);
        m_MenuControls_HideMenu = m_MenuControls.FindAction("HideMenu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GridControls
    private readonly InputActionMap m_GridControls;
    private IGridControlsActions m_GridControlsActionsCallbackInterface;
    private readonly InputAction m_GridControls_MoveSelection;
    private readonly InputAction m_GridControls_SetTile;
    private readonly InputAction m_GridControls_OpenMenu;
    private readonly InputAction m_GridControls_Click;
    public struct GridControlsActions
    {
        private @GameControls m_Wrapper;
        public GridControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveSelection => m_Wrapper.m_GridControls_MoveSelection;
        public InputAction @SetTile => m_Wrapper.m_GridControls_SetTile;
        public InputAction @OpenMenu => m_Wrapper.m_GridControls_OpenMenu;
        public InputAction @Click => m_Wrapper.m_GridControls_Click;
        public InputActionMap Get() { return m_Wrapper.m_GridControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GridControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGridControlsActions instance)
        {
            if (m_Wrapper.m_GridControlsActionsCallbackInterface != null)
            {
                @MoveSelection.started -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.performed -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.canceled -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnMoveSelection;
                @SetTile.started -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnSetTile;
                @SetTile.performed -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnSetTile;
                @SetTile.canceled -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnSetTile;
                @OpenMenu.started -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnOpenMenu;
                @Click.started -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GridControlsActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_GridControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveSelection.started += instance.OnMoveSelection;
                @MoveSelection.performed += instance.OnMoveSelection;
                @MoveSelection.canceled += instance.OnMoveSelection;
                @SetTile.started += instance.OnSetTile;
                @SetTile.performed += instance.OnSetTile;
                @SetTile.canceled += instance.OnSetTile;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public GridControlsActions @GridControls => new GridControlsActions(this);

    // MenuControls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_Navigate;
    private readonly InputAction m_MenuControls_Submit;
    private readonly InputAction m_MenuControls_Click;
    private readonly InputAction m_MenuControls_Point;
    private readonly InputAction m_MenuControls_HideMenu;
    public struct MenuControlsActions
    {
        private @GameControls m_Wrapper;
        public MenuControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_MenuControls_Navigate;
        public InputAction @Submit => m_Wrapper.m_MenuControls_Submit;
        public InputAction @Click => m_Wrapper.m_MenuControls_Click;
        public InputAction @Point => m_Wrapper.m_MenuControls_Point;
        public InputAction @HideMenu => m_Wrapper.m_MenuControls_HideMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSubmit;
                @Click.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnClick;
                @Point.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnPoint;
                @HideMenu.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnHideMenu;
                @HideMenu.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnHideMenu;
                @HideMenu.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnHideMenu;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @HideMenu.started += instance.OnHideMenu;
                @HideMenu.performed += instance.OnHideMenu;
                @HideMenu.canceled += instance.OnHideMenu;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    public interface IGridControlsActions
    {
        void OnMoveSelection(InputAction.CallbackContext context);
        void OnSetTile(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IMenuControlsActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnHideMenu(InputAction.CallbackContext context);
    }
}
