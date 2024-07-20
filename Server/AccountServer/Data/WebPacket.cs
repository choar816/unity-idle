﻿using AccountDB;

public class LoginAccountPacketReq
{
    public string userId { get; set; } = string.Empty;
    public string token { get; set; } = string.Empty;
}

public class LoginAccountPacketRes
{
    public ProviderType providerType { get; set; }
    public bool success { get; set; } = false;
    public long accountDbId { get; set; }
    public string jwt { get; set; } = string.Empty;
}

public class UpdateRankingPacketReq
{
    public string jwt { get; set; } = string.Empty; 
    public int score { get; set; }
}

public class UpdateRankingPacketRes
{
    public bool success { get; set; } = false;
}