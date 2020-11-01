using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using HMUI;
using IPA.Logging;
using IPA.Utilities;
using MusicVideoPlayer;

// See https://github.com/pardeike/Harmony/wiki for a full reference on Harmony.
namespace MusicVideoPlayer.HarmonyPatches
{
    //Patch from: https://github.com/Zingabopp/MultiplayerExtensions/blob/4b88e3840b45e33abb9f652940db5d1c0bc76106/MultiplayerExtensions/HarmonyPatches/EnableCustomSongsPatches.cs#L53
    [HarmonyPatch(typeof(MultiplayerLobbyConnectionController), "connectionType", MethodType.Setter)]
    class LobbyJoinPatch
    {
        public static MultiplayerLobbyConnectionController.LobbyConnectionType ConnectionType;

        public static bool IsPrivate { get { return ConnectionType != MultiplayerLobbyConnectionController.LobbyConnectionType.QuickPlay || false; } }
        public static bool IsHost { get { return ConnectionType == MultiplayerLobbyConnectionController.LobbyConnectionType.PartyHost || false; } }
        public static bool IsMultiplayer { get { return ConnectionType != MultiplayerLobbyConnectionController.LobbyConnectionType.None || false; } }

        /// <summary>
        /// Gets the current lobby type.
        /// </summary>
        static void Prefix(MultiplayerLobbyConnectionController __instance)
        {
            ConnectionType = __instance.GetProperty<MultiplayerLobbyConnectionController.LobbyConnectionType, MultiplayerLobbyConnectionController>("connectionType");
            if (IsMultiplayer)
            {
                VideoMenu.instance.RemoveTab();
            }
            else
            {
                VideoMenu.instance.AddTab();
            }
        }
    }
}
