using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

public class UnityAuthentication : MonoBehaviour
{
    public string access_token = "";
    [SerializeField]
    private Image _sync_button;
    [SerializeField]
    private GameObject _settings_group;
    [SerializeField]
    private GameObject _login_button;
    private async void Awake()
    {
        await UnityServices.InitializeAsync();
        if (UnityServices.State == ServicesInitializationState.Initialized)
        {
            PlayerAccountService.Instance.SignedIn += SignedIn;
        }
    }

    private async void SignedIn()
    {
        try
        {
            await SignInWithUnityAsync(PlayerAccountService.Instance.AccessToken);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }

    }

    private async Task SignInWithUnityAsync(string access_token)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUnityAsync(access_token);
            this.access_token = access_token;
            _settings_group.SetActive(false);
            _login_button.SetActive(false);
            _sync_button.color = Color.black;
            _sync_button.transform.GetComponent<Button>().interactable = true;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public async Task InitSignIn()
    {
        await PlayerAccountService.Instance.StartSignInAsync();
    }

    public Boolean IsSignedIn()
    {
        return AuthenticationService.Instance.IsSignedIn;
    }
}