using Sfs2X.Entities.Data;
using Sfs2X.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ButtonEventHandlers
{
    class GetFormationButtonHandler : ButtonEventHandler
    {
        public void performClickAction(GameLobbyManager ourGLM, Button clickedButton)
        {
            string formationName = clickedButton.name.Substring(clickedButton.name.IndexOf("]") + 2);
            Debug.Log(formationName);
            ISFSObject objectOut = new SFSObject();
            objectOut.PutUtfString("FormationName", formationName);
            ourGLM.getSFServer().Send(new ExtensionRequest("GetFormation", objectOut));
        }
    }
}
