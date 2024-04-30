using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;

public class UnityAuthentication : MonoBehaviour{
    public string access_token = "";
    private async void Awake(){
        await UnityServices.InitializeAsync();
        if(UnityServices.State == ServicesInitializationState.Initialized){
            PlayerAccountService.Instance.SignedIn += SignedIn;
        }
    }

    private async void SignedIn(){
        try{
            await SignInWithUnityAsync(PlayerAccountService.Instance.AccessToken);
        } catch (Exception ex){
            Debug.LogException(ex);
        }
        
    }

    private async Task SignInWithUnityAsync(string access_token){
        try{
            await AuthenticationService.Instance.SignInWithUnityAsync(access_token);
            this.access_token = access_token;
            Debug.Log("SignIn is successful.");
        } catch (Exception ex){
            Debug.LogException(ex);
        }
    }

    public async Task InitSignIn(){
        await PlayerAccountService.Instance.StartSignInAsync();
    }
}