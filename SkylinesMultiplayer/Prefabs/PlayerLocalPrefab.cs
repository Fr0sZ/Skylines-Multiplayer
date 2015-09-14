﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ColossalFramework;
using UnityEngine;

namespace SkylinesMultiplayer.Prefabs
{
    class PlayerLocalPrefab
    {
        public static GameObject Create(int id)
        {
            GameObject gameObject = new GameObject("Player Local");
            gameObject.layer = 2;   //Ignore raycast
            var playerComp = gameObject.gameObject.AddComponent<Player>();
            playerComp.m_playerId = id;
            playerComp.m_isMine = true;
            gameObject.tag = "Player";

            Camera.main.GetComponent<CameraController>().enabled = false;
            Camera.main.transform.parent = gameObject.transform;
            Camera.main.transform.localPosition = new Vector3(0, 1.5f, 0);
            Camera.main.transform.rotation = Quaternion.identity;
            Camera.main.nearClipPlane = 0.25f;
            Camera.main.fieldOfView = 90;

            Camera.main.gameObject.AddComponent<FPSCameraController>().axes = FPSCameraController.RotationAxes.MouseY;
            gameObject.AddComponent<FPSCameraController>().axes = FPSCameraController.RotationAxes.MouseX;
            gameObject.AddComponent<PlayerController>();
            gameObject.AddComponent<PlayerCollision>();
            
            var collider = gameObject.AddComponent<CapsuleCollider>();
            collider.height = 2;
            collider.radius = 0.5f;
            var rigidBody = gameObject.AddComponent<Rigidbody>();
            rigidBody.freezeRotation = true;

            return gameObject;
        }
    }
}