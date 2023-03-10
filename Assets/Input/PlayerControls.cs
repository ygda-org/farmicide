//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/PlayerControls.inputactions
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
            ""name"": ""MainGame"",
            ""id"": ""e1856d3b-bc3d-4ed1-a6db-bffc51f4108d"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""98a616fa-8701-46fa-9a87-e4ac104a9246"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""54ac52a8-3e61-4c54-88dc-46e3e9219443"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5d9d9ca8-d116-43ec-b322-4403f9724a95"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""8297273e-04f8-431c-8192-229f65859f54"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AimCounterClockWise"",
                    ""type"": ""Button"",
                    ""id"": ""c02e9f8a-402d-44e4-91b7-b585ee674aca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimClockWise"",
                    ""type"": ""Button"",
                    ""id"": ""1eef1c6f-8971-44e1-9e40-7f965e9dabee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4021ebc3-a848-486f-b1c5-83068ac2d1e6"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5d3cf57-94a5-4810-a5c8-b1190993fb70"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18ded4d5-b6cd-4299-a0ca-6d2066a9bea2"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddaec912-3561-4033-aede-db7ffefcd622"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1011f8e-bab4-4347-9ba2-f893680c8cde"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6ca277a7-cd1a-4cfc-be5f-ca032ac5a1f1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""59a27639-d1d9-4f31-8908-6ae120e47f35"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1191f4e4-fb07-474e-8078-51093abe24e6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4bc4d6a1-0c5b-4f09-af4b-541ecd30cd68"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""53100963-a7cc-42a6-9ead-cfb79eccf69f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fcd75844-b8c5-4d6f-815f-8cb71762b400"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6ab9ab6-12d5-442b-a473-82de00f00a01"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimCounterClockWise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba29f24b-4c9e-495b-8821-d1b1ed2fea58"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AimClockWise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainGame
        m_MainGame = asset.FindActionMap("MainGame", throwIfNotFound: true);
        m_MainGame_Interact = m_MainGame.FindAction("Interact", throwIfNotFound: true);
        m_MainGame_Shoot = m_MainGame.FindAction("Shoot", throwIfNotFound: true);
        m_MainGame_Move = m_MainGame.FindAction("Move", throwIfNotFound: true);
        m_MainGame_Aim = m_MainGame.FindAction("Aim", throwIfNotFound: true);
        m_MainGame_AimCounterClockWise = m_MainGame.FindAction("AimCounterClockWise", throwIfNotFound: true);
        m_MainGame_AimClockWise = m_MainGame.FindAction("AimClockWise", throwIfNotFound: true);
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

    // MainGame
    private readonly InputActionMap m_MainGame;
    private IMainGameActions m_MainGameActionsCallbackInterface;
    private readonly InputAction m_MainGame_Interact;
    private readonly InputAction m_MainGame_Shoot;
    private readonly InputAction m_MainGame_Move;
    private readonly InputAction m_MainGame_Aim;
    private readonly InputAction m_MainGame_AimCounterClockWise;
    private readonly InputAction m_MainGame_AimClockWise;
    public struct MainGameActions
    {
        private @PlayerControls m_Wrapper;
        public MainGameActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_MainGame_Interact;
        public InputAction @Shoot => m_Wrapper.m_MainGame_Shoot;
        public InputAction @Move => m_Wrapper.m_MainGame_Move;
        public InputAction @Aim => m_Wrapper.m_MainGame_Aim;
        public InputAction @AimCounterClockWise => m_Wrapper.m_MainGame_AimCounterClockWise;
        public InputAction @AimClockWise => m_Wrapper.m_MainGame_AimClockWise;
        public InputActionMap Get() { return m_Wrapper.m_MainGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainGameActions set) { return set.Get(); }
        public void SetCallbacks(IMainGameActions instance)
        {
            if (m_Wrapper.m_MainGameActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnInteract;
                @Shoot.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnShoot;
                @Move.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAim;
                @AimCounterClockWise.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimCounterClockWise;
                @AimCounterClockWise.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimCounterClockWise;
                @AimCounterClockWise.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimCounterClockWise;
                @AimClockWise.started -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimClockWise;
                @AimClockWise.performed -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimClockWise;
                @AimClockWise.canceled -= m_Wrapper.m_MainGameActionsCallbackInterface.OnAimClockWise;
            }
            m_Wrapper.m_MainGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @AimCounterClockWise.started += instance.OnAimCounterClockWise;
                @AimCounterClockWise.performed += instance.OnAimCounterClockWise;
                @AimCounterClockWise.canceled += instance.OnAimCounterClockWise;
                @AimClockWise.started += instance.OnAimClockWise;
                @AimClockWise.performed += instance.OnAimClockWise;
                @AimClockWise.canceled += instance.OnAimClockWise;
            }
        }
    }
    public MainGameActions @MainGame => new MainGameActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMainGameActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAimCounterClockWise(InputAction.CallbackContext context);
        void OnAimClockWise(InputAction.CallbackContext context);
    }
}
