﻿namespace Semi.Design.Blazor.Languages.Razor;

public class CompileRazorProjectFileSystem : RazorProjectFileSystem
{
    private static ConcurrentBag<string> _globalUsing = new()
    {
        "@using Microsoft.AspNetCore.Components.Web"
    };

    public static string GlobalUsing =>
        string.Join(Environment.NewLine, _globalUsing);

    public static void AddGlobalUsing(params string[] args)
    {
        foreach (var arg in args)
        {
            _globalUsing.Add(arg);
        }
    }

    public static List<string> GetGlobalUsing()
        => _globalUsing.ToList();
    
    public static void RemoveGlobalUsing(params string[] args)
    {
        lock (_globalUsing)
        {
            _globalUsing = new ConcurrentBag<string>(_globalUsing.Except(args));
        }
    }

    public override IEnumerable<RazorProjectItem> EnumerateItems(string basePath)
    {
        throw new NotImplementedException();
    }

    public override RazorProjectItem GetItem(string path)
    {
        throw new NotImplementedException();
    }

    public override RazorProjectItem GetItem(string path, string fileKind)
    {
        if (path == "/_Imports.razor")
            return new CompileRazorProjectItem()
            {
                Name = "_Imports.razor",
                Code = GlobalUsing
            };
        throw new NotImplementedException(fileKind + ":" + path);
    }
}