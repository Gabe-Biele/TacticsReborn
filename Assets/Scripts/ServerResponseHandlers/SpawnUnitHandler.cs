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
    class SpawnUnitHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            //Create Unit GameObject and Set it's parent
            GameObject aUnit = ourGLM.createObject("Units/" + anObjectIn.GetUtfString("UnitID"));
            aUnit.transform.SetParent(GameObject.Find("Units").transform);

            //Set its position
            aUnit.transform.localPosition = ourGLM.getGameManager().getLocation(anObjectIn.GetInt("xLoc"), anObjectIn.GetInt("yLoc"));

            //Determine if it needs to be rotated
            if(anObjectIn.GetInt("yLoc") > 6)
            {
                aUnit.transform.Rotate(0, 180, 0);
            }

        }
    }
}
