using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WebPacket
{
    [Serializable]
    public class TestPacketReq
    {
        public string userId;
        public string token;
    }

    [Serializable]
    public class TestPacketRes
    {
        public bool success;
    }
}
