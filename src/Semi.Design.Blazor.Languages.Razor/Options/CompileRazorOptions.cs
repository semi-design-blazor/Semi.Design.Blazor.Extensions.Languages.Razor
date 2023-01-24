﻿namespace Semi.Design.Blazor.Languages.Razor;


public class CompileRazorOptions
{
    /// <summary>
    /// Compiled code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Razor component name
    /// </summary>
    public string ComponentName { get; set; } = "Rendering";

    /// <summary>
    /// Configuration Name 
    /// </summary>
    public string ConfigurationName { get; set; } = "Default";

    /// <summary>
    /// Whether to Build concurrently
    /// （WebAssembly does not support multiple threads using concurrency）
    /// </summary>
    public bool ConcurrentBuild { get; set; } = false;
}