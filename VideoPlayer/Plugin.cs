using System;
using IPA;
using UnityEngine.SceneManagement;
using MusicVideoPlayer.Util;
using MusicVideoPlayer.UI;
using MusicVideoPlayer.YT;
using BeatSaberMarkupLanguage.Settings;
using BS_Utils.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Linq;
using System.Reflection;
using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA.Config.Data;


namespace MusicVideoPlayer
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public sealed class Plugin
    {
        public static IPA.Logging.Logger logger;
        
        public const string HarmonyId = "com.github.rie-kumar.MusicVideoPlayer";
        internal static Harmony harmony => new Harmony(HarmonyId);

        [Init]
        public void Init(IPA.Logging.Logger logger)
        {
            Plugin.logger = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Settings.Init();
            SettingsUI.CreateMenu();
            VideoMenu.instance.AddTab();
            BSEvents.OnLoad();
            BSEvents.lateMenuSceneLoadedFresh += OnMenuSceneLoadedFresh;
            // BSEvents.menuSceneLoaded += OnMenuSceneLoaded;
            // BSEvents.menuSceneActive += OnMenuSceneLoaded;
            // BSEvents.gameSceneLoaded += OnMenuSceneLoaded;
            Base64Sprites.ConvertToSprites();
            ApplyHarmonyPatches();
        }
        
        public static void ApplyHarmonyPatches()
        {
            try
            {
                logger.Debug("Applying Harmony patches.");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                logger.Critical("Error applying Harmony patches: " + ex.Message);
                logger.Debug(ex);
            }
        }

        // private void OnMenuSceneLoaded()
        // {
        //     ScreenManager.OnLoad();
        // }

        private static void OnMenuSceneLoadedFresh(ScenesTransitionSetupDataSO scenesTransition)
        {
            YouTubeDownloader.OnLoad();
            ScreenManager.OnLoad();
            VideoLoader.OnLoad();
            VideoMenu.instance.OnLoad();
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            BSEvents.lateMenuSceneLoadedFresh -= OnMenuSceneLoadedFresh;
            // BSEvents.menuSceneLoaded -= OnMenuSceneLoaded;
            // BSEvents.menuSceneActive -= OnMenuSceneLoaded;
            // BSEvents.gameSceneLoaded -= OnMenuSceneLoaded;
            YouTubeDownloader.Instance.OnApplicationQuit();
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }

        public void OnUpdate() { }

        public void OnFixedUpdate() { }
    }
}