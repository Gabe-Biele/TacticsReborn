using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sfs2X.Entities.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ServerResponseHandlers
{
    class EditFormationHandler : ServerResponseHandler
    {
        public void HandleResponse(ISFSObject anObjectIn, GameLobbyManager ourGLM)
        {
            //Define variables
            GameObject formationsPanel = ourGLM.createObject("UI/FormationsPanel");
            formationsPanel.transform.SetParent(GameObject.Find("Canvas").transform);
            formationsPanel.transform.localPosition = new Vector3();

            if(anObjectIn.GetInt("NumberOfFormations") > 0)
            {
                string[] formationButtonNames = anObjectIn.GetUtfStringArray("FormationNames");
                for(int i = 0; i < formationButtonNames.Length; i++)
                {
                    formationsPanel.transform.FindChild("New 1v1 Formation").GetComponentInChildren<Text>().text = formationButtonNames[i];
                    formationsPanel.transform.FindChild("New 1v1 Formation").name = formationButtonNames[i];
                }
            }
        }
    }
}
