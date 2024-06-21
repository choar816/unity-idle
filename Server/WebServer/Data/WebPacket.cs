[Serializable]
public class TestPacketReq
{
    public string userId { get; set; }
    public string token { get; set; }
}

[Serializable]
public class TestPacketRes
{
    public bool success { get; set; }
}
