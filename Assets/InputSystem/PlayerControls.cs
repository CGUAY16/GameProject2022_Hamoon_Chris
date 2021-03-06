//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Base Controls"",
            ""id"": ""e57fd274-1932-43b1-ac17-7c0fca38a843"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c7dbd55a-5e1e-4288-93fe-afa42fca474d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38a3e141-4877-4f9c-9d5e-38b49d046709"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""b425e522-3cb6-4901-8f95-4284ee183fbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""02f77a5b-0a38-4a68-9ebd-f09e97ee4541"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActivateSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""07270a3e-6447-4820-9b69-9fd6ac0b0095"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a56b52d2-2f2c-42c0-9fc1-5f31669d9657"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""ActivateSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66d40dde-e828-43d4-b153-7b87ce474411"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ActivateSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""a2dd6a0b-baf4-4a30-80ee-d240871c59a9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""391739a0-b25e-40ec-ac92-30b476c01dbd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""f2134369-98b5-4527-b675-80b5a137382a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""732594a2-de45-4cd2-9a37-aa341788a20e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""95f7b0ba-7c1f-410c-9ecd-222482bae7d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""9c2e5b02-0d60-40c4-820d-3a9eab8a847c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee980e18-e17d-4e2d-b853-edc8cb71eafa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27a86774-bb92-48ff-942e-11d595664006"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0afe487-f5d0-424c-8bfc-c730fe151980"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d61be04-476a-4a07-8808-a2aac9772b9f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""415751aa-70f0-4356-8d79-0f54b1133133"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard & Mouse"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34b0764c-933d-4b59-8b5f-da3db51724a9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard & Mouse"",
            ""bindingGroup"": ""KeyBoard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Base Controls
        m_PlayerBaseControls = asset.FindActionMap("Player Base Controls", throwIfNotFound: true);
        m_PlayerBaseControls_Movement = m_PlayerBaseControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerBaseControls_Jump = m_PlayerBaseControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerBaseControls_Attack = m_PlayerBaseControls.FindAction("Attack", throwIfNotFound: true);
        m_PlayerBaseControls_Grapple = m_PlayerBaseControls.FindAction("Grapple", throwIfNotFound: true);
        m_PlayerBaseControls_ActivateSwitch = m_PlayerBaseControls.FindAction("ActivateSwitch", throwIfNotFound: true);
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

    // Player Base Controls
    private readonly InputActionMap m_PlayerBaseControls;
    private IPlayerBaseControlsActions m_PlayerBaseControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerBaseControls_Movement;
    private readonly InputAction m_PlayerBaseControls_Jump;
    private readonly InputAction m_PlayerBaseControls_Attack;
    private readonly InputAction m_PlayerBaseControls_Grapple;
    private readonly InputAction m_PlayerBaseControls_ActivateSwitch;
    public struct PlayerBaseControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerBaseControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerBaseControls_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerBaseControls_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerBaseControls_Attack;
        public InputAction @Grapple => m_Wrapper.m_PlayerBaseControls_Grapple;
        public InputAction @ActivateSwitch => m_Wrapper.m_PlayerBaseControls_ActivateSwitch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBaseControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBaseControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBaseControlsActions instance)
        {
            if (m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnAttack;
                @Grapple.started -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnGrapple;
                @ActivateSwitch.started -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnActivateSwitch;
                @ActivateSwitch.performed -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnActivateSwitch;
                @ActivateSwitch.canceled -= m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface.OnActivateSwitch;
            }
            m_Wrapper.m_PlayerBaseControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
                @ActivateSwitch.started += instance.OnActivateSwitch;
                @ActivateSwitch.performed += instance.OnActivateSwitch;
                @ActivateSwitch.canceled += instance.OnActivateSwitch;
            }
        }
    }
    public PlayerBaseControlsActions @PlayerBaseControls => new PlayerBaseControlsActions(this);
    private int m_KeyBoardMouseSchemeIndex = -1;
    public InputControlScheme KeyBoardMouseScheme
    {
        get
        {
            if (m_KeyBoardMouseSchemeIndex == -1) m_KeyBoardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoard & Mouse");
            return asset.controlSchemes[m_KeyBoardMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPlayerBaseControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
        void OnActivateSwitch(InputAction.CallbackContext context);
    }
}
