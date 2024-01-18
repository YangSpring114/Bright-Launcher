using System;
using System.Threading.Tasks;
using Bright_Launcher.Services.Launch;
using MinecraftLaunch;
using MinecraftLaunch.Classes.Models.Event;
using MinecraftLaunch.Components.Installer;

namespace Bright_Launcher.Services;

public class InstallService {
    private readonly GameService _gameService;

    /// <summary>
    /// 安装进度改变事件
    /// </summary>
    public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
    
    public InstallService(GameService gameService) {
        _gameService = gameService;
    }
    
    /// <summary>
    /// 游戏安装方法
    /// </summary>
    /// <param name="mcVersion">Minecraft版本名，如'1.12.2'</param>
    /// <returns>游戏是否安装成功</returns>
    public ValueTask<bool> InstallGame(string mcVersion) {
        VanlliaInstaller installer = new(_gameService.GameResolver, mcVersion, MirrorDownloadManager.Mcbbs);
        installer.ProgressChanged += (_, args) => {
            ProgressChanged?.Invoke(_, args);
        };
        
        return installer.InstallAsync();
    }
}