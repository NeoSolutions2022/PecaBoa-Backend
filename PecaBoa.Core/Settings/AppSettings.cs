﻿namespace PecaBoa.Core.Settings;

public class AppSettings
{
    public string UrlComum { get; set; } = string.Empty;
    public string UrlGestao { get; set; } = string.Empty;
    public string UrlApi { get; set; } = string.Empty;
    public int FreeUsageDays { get; set; }
    public decimal PlatformValue { get; set; }
}