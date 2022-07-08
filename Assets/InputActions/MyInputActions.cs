//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/MyInputActions.inputactions
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

public partial class @MyInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a351fd63-b51d-4997-83e3-25f6dd14bff7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""55d17957-f30d-4c33-98fc-3948c6c6c7d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""314978ee-2ed6-49f7-9649-7786c8b8525f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""98f93c35-e727-45ef-a573-46923384c5ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon 1"",
                    ""type"": ""Button"",
                    ""id"": ""d07d8123-beb9-4395-a7a4-336a478541e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon 2"",
                    ""type"": ""Button"",
                    ""id"": ""d12ca923-3600-4141-aa0e-6af64fba8f34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon 3"",
                    ""type"": ""Button"",
                    ""id"": ""af39a438-b401-45c3-a180-52da72dacf74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Weapon 4"",
                    ""type"": ""Button"",
                    ""id"": ""cd0c5a9a-d505-4f40-9da7-2d593933e560"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MeleeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""a579d7ea-663f-4168-81b9-47def1ce9745"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeaponWheelButton"",
                    ""type"": ""Button"",
                    ""id"": ""45870136-511a-47c7-82d0-d44638afdd42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grenede"",
                    ""type"": ""Button"",
                    ""id"": ""40906925-974f-443b-906b-e611c269bf09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseCursor"",
                    ""type"": ""Value"",
                    ""id"": ""04ca95fb-10ac-4930-9d0a-906f3fc60d9a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""48e7a081-df9c-4b05-afb2-98e2befa937a"",
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
                    ""id"": ""a7b62ac5-d30e-47c4-945f-9b2aaf083120"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""58886625-45ad-495d-b7f7-b51dbadacfa5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ff5cc26a-8680-47e0-8853-6c37e62a9dfe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f356c2c-d84b-404a-a506-322ec8d8fa87"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f47b3b51-6bf8-47fa-9f25-82fc41608bf2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fd8d32a-a7b7-4043-95cb-274684b5fd34"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9677dded-b6b4-45d0-bbb1-ad31d0dcf55d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Weapon 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4977aee-1f16-4340-bb02-b964b20ff965"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Weapon 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c4f2dc1-a7fe-47cc-bb4b-83260db16a63"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Weapon 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34382980-6d17-450c-bfda-fc2f2ad06d6b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Weapon 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52f6e41a-820f-4804-9068-3c6000687280"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MeleeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d65fbb60-bb31-49d8-a0c9-e81d29517b5d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""WeaponWheelButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3db17987-f2c5-4f7e-a30b-6f48f5ae3b9d"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""Grenede"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f9b71f9-dc39-4402-84cc-a6bf82bee8a5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard/Mouse"",
                    ""action"": ""MouseCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""bindingGroup"": ""Keyboard/Mouse"",
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
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Weapon1 = m_Player.FindAction("Weapon 1", throwIfNotFound: true);
        m_Player_Weapon2 = m_Player.FindAction("Weapon 2", throwIfNotFound: true);
        m_Player_Weapon3 = m_Player.FindAction("Weapon 3", throwIfNotFound: true);
        m_Player_Weapon4 = m_Player.FindAction("Weapon 4", throwIfNotFound: true);
        m_Player_MeleeWeapon = m_Player.FindAction("MeleeWeapon", throwIfNotFound: true);
        m_Player_WeaponWheelButton = m_Player.FindAction("WeaponWheelButton", throwIfNotFound: true);
        m_Player_Grenede = m_Player.FindAction("Grenede", throwIfNotFound: true);
        m_Player_MouseCursor = m_Player.FindAction("MouseCursor", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Weapon1;
    private readonly InputAction m_Player_Weapon2;
    private readonly InputAction m_Player_Weapon3;
    private readonly InputAction m_Player_Weapon4;
    private readonly InputAction m_Player_MeleeWeapon;
    private readonly InputAction m_Player_WeaponWheelButton;
    private readonly InputAction m_Player_Grenede;
    private readonly InputAction m_Player_MouseCursor;
    public struct PlayerActions
    {
        private @MyInputActions m_Wrapper;
        public PlayerActions(@MyInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Weapon1 => m_Wrapper.m_Player_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_Player_Weapon2;
        public InputAction @Weapon3 => m_Wrapper.m_Player_Weapon3;
        public InputAction @Weapon4 => m_Wrapper.m_Player_Weapon4;
        public InputAction @MeleeWeapon => m_Wrapper.m_Player_MeleeWeapon;
        public InputAction @WeaponWheelButton => m_Wrapper.m_Player_WeaponWheelButton;
        public InputAction @Grenede => m_Wrapper.m_Player_Grenede;
        public InputAction @MouseCursor => m_Wrapper.m_Player_MouseCursor;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Weapon1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                @Weapon1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                @Weapon1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                @Weapon2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                @Weapon2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                @Weapon2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                @Weapon3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                @Weapon3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                @Weapon3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                @Weapon4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                @Weapon4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                @Weapon4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                @MeleeWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeWeapon;
                @MeleeWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeWeapon;
                @MeleeWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMeleeWeapon;
                @WeaponWheelButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponWheelButton;
                @WeaponWheelButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponWheelButton;
                @WeaponWheelButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeaponWheelButton;
                @Grenede.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenede;
                @Grenede.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenede;
                @Grenede.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrenede;
                @MouseCursor.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseCursor;
                @MouseCursor.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseCursor;
                @MouseCursor.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseCursor;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Weapon1.started += instance.OnWeapon1;
                @Weapon1.performed += instance.OnWeapon1;
                @Weapon1.canceled += instance.OnWeapon1;
                @Weapon2.started += instance.OnWeapon2;
                @Weapon2.performed += instance.OnWeapon2;
                @Weapon2.canceled += instance.OnWeapon2;
                @Weapon3.started += instance.OnWeapon3;
                @Weapon3.performed += instance.OnWeapon3;
                @Weapon3.canceled += instance.OnWeapon3;
                @Weapon4.started += instance.OnWeapon4;
                @Weapon4.performed += instance.OnWeapon4;
                @Weapon4.canceled += instance.OnWeapon4;
                @MeleeWeapon.started += instance.OnMeleeWeapon;
                @MeleeWeapon.performed += instance.OnMeleeWeapon;
                @MeleeWeapon.canceled += instance.OnMeleeWeapon;
                @WeaponWheelButton.started += instance.OnWeaponWheelButton;
                @WeaponWheelButton.performed += instance.OnWeaponWheelButton;
                @WeaponWheelButton.canceled += instance.OnWeaponWheelButton;
                @Grenede.started += instance.OnGrenede;
                @Grenede.performed += instance.OnGrenede;
                @Grenede.canceled += instance.OnGrenede;
                @MouseCursor.started += instance.OnMouseCursor;
                @MouseCursor.performed += instance.OnMouseCursor;
                @MouseCursor.canceled += instance.OnMouseCursor;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard/Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
        void OnWeapon4(InputAction.CallbackContext context);
        void OnMeleeWeapon(InputAction.CallbackContext context);
        void OnWeaponWheelButton(InputAction.CallbackContext context);
        void OnGrenede(InputAction.CallbackContext context);
        void OnMouseCursor(InputAction.CallbackContext context);
    }
}
