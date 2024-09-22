using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Modules.Menu;
using VipCoreApi;

namespace VIP_LR_CustomFakeRank
{
    public class VIP_LR_CustomFakeRank : BasePlugin
    {
        private IVipCoreApi? _vipApi;
        private IPlayerRankApi? _playerRankApi;
        private RankFeature? _rankFeature;
        private RankConfig? _config;
        private string _configFilePath;

        public override string ModuleAuthor => "ABKAM";
        public override string ModuleName => "[VIP] [LR] CustomFakeRank";
        public override string ModuleVersion => "v1.0.0";

        private readonly PluginCapability<IVipCoreApi> _vipCoreCapability = new("vipcore:core");
        private readonly PluginCapability<IPlayerRankApi> _playerRankApiCapability = new("PLAYER_RANK_API");

        public override void OnAllPluginsLoaded(bool hotReload)
        {
            _vipApi = _vipCoreCapability.Get();
            _playerRankApi = _playerRankApiCapability.Get();
            
            if (_vipApi == null || _playerRankApi == null) return;

            _configFilePath = Path.Combine(_vipApi.ModulesConfigDirectory, "vip_customfakerank.json");
            _config = LoadConfig();
            _rankFeature = new RankFeature(this, _vipApi, _config, _playerRankApi);
            _vipApi.RegisterFeature(_rankFeature, IVipCoreApi.FeatureType.Selectable);
        }

        public override void Unload(bool hotReload)
        {
            _vipApi?.UnRegisterFeature(_rankFeature);
        }

        private RankConfig LoadConfig()
        {
            if (!File.Exists(_configFilePath)) return CreateDefaultConfig();

            var json = File.ReadAllText(_configFilePath);
            return JsonSerializer.Deserialize<RankConfig>(json) ?? new RankConfig();
        }

        private RankConfig CreateDefaultConfig()
        {
            var config = new RankConfig
            {
                Categories = new List<RankCategory>
                {
                    new RankCategory
                    {
                        Name = "Стандартные звания",
                        Ranks = new List<RankInfo>
                        {
                            new RankInfo { Name = "Серебро I", RankId = 1, RankType = 1 }, 
                            new RankInfo { Name = "Серебро II", RankId = 2, RankType = 1 },
                            new RankInfo { Name = "Серебро III", RankId = 3, RankType = 1 },
                            new RankInfo { Name = "Серебро IV", RankId = 4, RankType = 1 },
                            new RankInfo { Name = "Серебряная Элита", RankId = 5, RankType = 1 },
                            new RankInfo { Name = "Серебряная Элита-Мастер", RankId = 6, RankType = 1 },
                            new RankInfo { Name = "Золотая Звезда I", RankId = 7, RankType = 1 },
                            new RankInfo { Name = "Золотая Звезда II", RankId = 8, RankType = 1 },
                            new RankInfo { Name = "Золотая Звезда III", RankId = 9, RankType = 1 },
                            new RankInfo { Name = "Золотая Звезда-Мастер", RankId = 10, RankType = 1 },
                            new RankInfo { Name = "Магистр-хранитель I", RankId = 11, RankType = 1 },
                            new RankInfo { Name = "Магистр-хранитель II", RankId = 12, RankType = 1 },
                            new RankInfo { Name = "Магистр-хранитель Элита", RankId = 13, RankType = 1 },
                            new RankInfo { Name = "Заслуженный Магистр-хранитель", RankId = 14, RankType = 1 },
                            new RankInfo { Name = "Легендарный Беркут", RankId = 15, RankType = 1 },
                            new RankInfo { Name = "Легендарный Беркут-Мастер", RankId = 16, RankType = 1 },
                            new RankInfo { Name = "Верховный Магистр-Первый Класс", RankId = 17, RankType = 1 },
                            new RankInfo { Name = "Всемирная Элита", RankId = 18, RankType = 1 }
                        }
                    },
                    new RankCategory
                    {
                        Name = "Премьер",
                        Ranks = new List<RankInfo>
                        {
                            new RankInfo { Name = "7000", RankId = 7000, RankType = 3 },
                            new RankInfo { Name = "44444", RankId = 44444, RankType = 3 }
                        }
                    }
                }
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = JsonSerializer.Serialize(config, options);
            File.WriteAllText(_configFilePath, json);

            return config;
        }
    }

    public class RankFeature : VipFeatureBase
    {
        private readonly RankConfig _config;
        private readonly IPlayerRankApi _playerRankApi;

        public override string Feature => "CustomFakeRank";

        public RankFeature(BasePlugin vipRanks, IVipCoreApi api, RankConfig config, IPlayerRankApi playerRankApi) : base(api)
        {
            _config = config;
            _playerRankApi = playerRankApi;
        }

        public override void OnSelectItem(CCSPlayerController player, IVipCoreApi.FeatureState state)
        {
            ShowCategoryMenu(player);
        }

        private void ShowCategoryMenu(CCSPlayerController player)
        {
            var menuTitle = GetTranslatedText("CustomFakeRank.MenuTitle");
            var menu = new ChatMenu(menuTitle);

            foreach (var category in _config.Categories)
            {
                menu.AddMenuOption(category.Name, (controller, option) =>
                {
                    ShowRankMenu(player, category);
                });
            }

            menu.Open(player);
        }

        private void ShowRankMenu(CCSPlayerController player, RankCategory category)
        {
            var menuTitle = category.Name;
            var menu = new ChatMenu(menuTitle);

            menu.AddMenuOption(GetTranslatedText("CustomFakeRank.Disable"), (controller, option) =>
            {
                _playerRankApi.ResetRank(player); 
                PrintToChat(player, GetTranslatedText("CustomFakeRank.ResetMessage"));
                ShowCategoryMenu(player); 
            });

            foreach (var rankInfo in category.Ranks)
            {
                var successMessage = GetTranslatedText("CustomFakeRank.SuccessMessage");
                menu.AddMenuOption(rankInfo.Name, (controller, option) =>
                {
                    int transformedRankType = TransformRankType(rankInfo.RankType); 
                    _playerRankApi.SetCustomRank(player, rankInfo.RankId, transformedRankType); 
                    PrintToChat(player, successMessage);
                    ShowRankMenu(player, category); 
                });
            }

            menu.Open(player);
        }

        private int TransformRankType(int rankType)
        {
            return rankType switch
            {
                1 => 12,
                2 => 7,
                3 => 11,
                _ => 12,
            };
        }
    }

    public class RankConfig
    {
        public List<RankCategory> Categories { get; set; } = new();
    }

    public class RankCategory
    {
        public string Name { get; set; } = string.Empty;
        public List<RankInfo> Ranks { get; set; } = new();
    }

    public class RankInfo
    {
        public string Name { get; set; }
        public int RankId { get; set; }
        public int RankType { get; set; }
    }
}
