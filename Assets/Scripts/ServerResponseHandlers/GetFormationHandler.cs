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
    class GetFormationHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            //Remove formationsPanel
            ourGLM.destroyObject("FormationsPanel");

            //Draw Halfboard
            ourGLM.getGameManager().drawHexGrid(5);
        }
    }
}
