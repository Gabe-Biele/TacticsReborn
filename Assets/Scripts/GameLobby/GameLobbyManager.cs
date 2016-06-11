using Assets.Scripts.GameLobby;
using Assets.Scripts.GameWorld.PlayerActions;
using Assets.Scripts.PlayerActions;
using Assets.Scripts.ServerResponseHandlers;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLobbyManager : MonoBehaviour
{
    private SmartFox SFServer;

    private UIManager ourUserInterface;

    private Dictionary<string, PlayerAction> playerActionDictionary = new Dictionary<string, PlayerAction>();
    private Dictionary<string, ServerResponseHandler> ourSRHDictionary = new Dictionary<string, ServerResponseHandler>();

    void Start()
    {
        //Start up connection
        if(SmartFoxConnection.Connection == null)
        {
            SceneManager.LoadScene("Login");
            return;
        }
        SFServer = SmartFoxConnection.Connection;

        // Setup server event listeners
        SFServer.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
        SFServer.AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnExtensionResponse);


        //Setup sub-managers
        ourUserInterface = new UIManager(this);

        //Setup player actions
        playerActionDictionary.Add("EnterChat", new EnterChatAction());

        //Setup server response handlers
        ourSRHDictionary.Add("EnterChat", new EnterChatHandler());
        ourSRHDictionary.Add("PlayerConnected", new PlayerConnectedHandler());
        ourSRHDictionary.Add("PlayerDisconnected", new PlayerDisconnectedHandler());
        ourSRHDictionary.Add("OnlinePlayers", new OnlinePlayersHandler());

        //Send a request to get the OnlinePlayers
        SFServer.Send(new ExtensionRequest("OnlinePlayers", new SFSObject()));
    }
    void FixedUpdate()
    {
        if(SFServer != null)
        {
            SFServer.ProcessEvents();
        }
    }

    private void OnExtensionResponse(BaseEvent evt)
    {
        try
        {
            String responseType = (string)evt.Params["cmd"];
            Debug.Log("Received Response: " + responseType);
            ISFSObject anObjectIn = (SFSObject)evt.Params["params"];

            ourSRHDictionary[responseType].HandleResponse(anObjectIn, this);
        }
        catch(Exception e)
        {
            Debug.Log("Exception handling response: " + e.Message);
            Debug.Log(e.StackTrace);
        }
    }

    private void OnConnectionLost(BaseEvent evt)
    {
        throw new NotImplementedException();
    }


    public void buttonClicked(Button clickedButton)
    {
        ourUserInterface.getButtonDictionary()[clickedButton].performClickAction(this);
    }


    public SmartFox getSFServer()
    {
        return SFServer;
    }
    public Dictionary<string, PlayerAction> getPlayerActionDictionary()
    {
        return playerActionDictionary;
    }

    public UIManager getUserInterface()
    {
        return ourUserInterface;
    }

    public GameObject createObject(string objectName)
    {
        return (GameObject)Instantiate(Resources.Load(objectName, typeof(GameObject)));
    }
    public void destroyObject(string objectName)
    {
        Destroy(GameObject.Find(objectName));
    }
    public void destroyObject(GameObject o)
    {
        Destroy(o);
    }
}