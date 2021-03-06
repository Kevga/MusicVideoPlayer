﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MusicVideoPlayer.Util
{
    public enum VideoPlacement { BackgroundHigh, BackgroundMid, BackgroundLow, Center, Left, Right, Bottom, Top, Custom };

    public class VideoPlacementSetting
    {   
        public static Vector3 Position(VideoPlacement placement)
        {
            switch (placement)
            {
                case VideoPlacement.BackgroundHigh:
                    return new Vector3(0, 20, 50);
                case VideoPlacement.BackgroundMid:
                    return new Vector3(0, 12, 50);
                case VideoPlacement.BackgroundLow:
                    return new Vector3(0, 4.5f, 50);
                case VideoPlacement.Center:
                    return new Vector3(0, 4.5f, 35);
                case VideoPlacement.Left:
                    return new Vector3(-8, 2, 11);
                case VideoPlacement.Right:
                    return new Vector3(8, 2, 11);
                case VideoPlacement.Top:
                    return new Vector3(0, 5, 10);
                default:
                    return new Vector3(0, -1.5f, 7.35f);
            }
        }

        public static Vector3 Rotation(VideoPlacement placement)
        {
            switch (placement)
            {

                case VideoPlacement.BackgroundHigh:
                    return new Vector3(-12, 0, 0);
                case VideoPlacement.BackgroundMid:
                    return new Vector3(-7, 0, 0);
                case VideoPlacement.BackgroundLow:
                    return new Vector3(0, 0, 0);
                case VideoPlacement.Center:
                    return new Vector3(0, 0, 0);
                case VideoPlacement.Left:
                    return new Vector3(0, -30, 0);
                case VideoPlacement.Right:
                    return new Vector3(0, 30, 0);
                case VideoPlacement.Top:
                    return new Vector3(-15, 0, 0);
                default:
                    return new Vector3(15, 0, 0);
            }
        }

        public static float Scale(VideoPlacement placement)
        {
            switch (placement)
            {
                case VideoPlacement.BackgroundLow:
                case VideoPlacement.BackgroundMid:
                case VideoPlacement.BackgroundHigh:
                    return 30;
                case VideoPlacement.Center:
                    return 8;
                case VideoPlacement.Left:
                    return 4;
                case VideoPlacement.Right:
                    return 4;
                case VideoPlacement.Top:
                    return 3;
                default: 
                    return 2;
            }
        }

        public static float[] Modes()
        {
            return new float[]
            {
                (float)VideoPlacement.BackgroundHigh,
                (float)VideoPlacement.BackgroundMid,
                (float)VideoPlacement.BackgroundLow,
                (float)VideoPlacement.Center,
                (float)VideoPlacement.Left,
                (float)VideoPlacement.Right,
                (float)VideoPlacement.Bottom,
                (float)VideoPlacement.Top,
                (float)VideoPlacement.Custom
            };
        }

        public static string Name(VideoPlacement mode)
        {
            switch (mode)
            {
                case VideoPlacement.BackgroundHigh:
                    return "BackgroundHigh";
                case VideoPlacement.BackgroundMid:
                    return "BackgroundMid";
                case VideoPlacement.BackgroundLow:
                    return "Background Low";
                case VideoPlacement.Center:
                    return "Center";
                case VideoPlacement.Left:
                    return "Left";
                case VideoPlacement.Right:
                    return "Right";
                case VideoPlacement.Bottom:
                    return "Bottom";
                case VideoPlacement.Top:
                    return "Top";
                case VideoPlacement.Custom:
                    return "Custom";
                default:
                    return "?";
            }
        }
    }
}
