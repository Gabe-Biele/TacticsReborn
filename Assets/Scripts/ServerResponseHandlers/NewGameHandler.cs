using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.ButtonEventHandlers;

namespace Assets.Scripts.ServerResponseHandlers
{
    class NewGameHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            //Create Unit GameObject and Set it's parent
            ourGLM.getGameManager().drawHexGrid(12);
        }
    }
}
