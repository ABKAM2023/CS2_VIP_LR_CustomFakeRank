# EN
To ensure the proper functioning of the plugin, please update [LR FakeRank](https://github.com/ABKAM2023/CS2-LR-FakeRank/releases) to the latest version.

**[VIP(CSSharp)] [LR] CustomFakeRank** - adds the ability for VIP players to select custom fake ranks.

# In vip.json
```json
  "CustomFakeRank": true
```

# Translations:
```json
  "CustomFakeRank": "Select custom rank",
  "CustomFakeRank.MenuTitle": "Custom rank selection",
  "CustomFakeRank.Disable": "{red}Disable custom rank",
  "CustomFakeRank.ResetMessage": "Custom rank has been successfully disabled",
  "CustomFakeRank.SuccessMessage": "Custom rank has been successfully set!"
```

# Configuration file (vip_customfakerank.json)
```json
{
  "Categories": [
    {
      "Name": "Standard Ranks",
      "Ranks": [
        {
          "Name": "Silver I",
          "RankId": 1,
          "RankType": 1
        },
        {
          "Name": "Silver II",
          "RankId": 2,
          "RankType": 1
        },
        {
          "Name": "Silver III",
          "RankId": 3,
          "RankType": 1
        },
        {
          "Name": "Silver IV",
          "RankId": 4,
          "RankType": 1
        },
        {
          "Name": "Silver Elite",
          "RankId": 5,
          "RankType": 1
        },
        {
          "Name": "Silver Elite Master",
          "RankId": 6,
          "RankType": 1
        },
        {
          "Name": "Gold Nova I",
          "RankId": 7,
          "RankType": 1
        },
        {
          "Name": "Gold Nova II",
          "RankId": 8,
          "RankType": 1
        },
        {
          "Name": "Gold Nova III",
          "RankId": 9,
          "RankType": 1
        },
        {
          "Name": "Gold Nova Master",
          "RankId": 10,
          "RankType": 1
        },
        {
          "Name": "Master Guardian I",
          "RankId": 11,
          "RankType": 1
        },
        {
          "Name": "Master Guardian II",
          "RankId": 12,
          "RankType": 1
        },
        {
          "Name": "Master Guardian Elite",
          "RankId": 13,
          "RankType": 1
        },
        {
          "Name": "Distinguished Master Guardian",
          "RankId": 14,
          "RankType": 1
        },
        {
          "Name": "Legendary Eagle",
          "RankId": 15,
          "RankType": 1
        },
        {
          "Name": "Legendary Eagle Master",
          "RankId": 16,
          "RankType": 1
        },
        {
          "Name": "Supreme Master First Class",
          "RankId": 17,
          "RankType": 1
        },
        {
          "Name": "Global Elite",
          "RankId": 18,
          "RankType": 1
        }
      ]
    },
    {
      "Name": "Premier",
      "Ranks": [
        {
          "Name": "7000",
          "RankId": 7000,
          "RankType": 3
        },
        {
          "Name": "44444",
          "RankId": 44444,
          "RankType": 3
        }
      ]
    }
  ]
}
```

# Installation:
1. Install [LR FakeRank](https://github.com/ABKAM2023/CS2-LR-FakeRank/releases) and [C# VIPCore](https://github.com/partiusfabaa/cs2-VIPCore).
2. Extract the plugin archive to the server.
3. Configure the `vip_customfakerank.json` file.
4. Add the necessary translations to the translation file.
5. Set up the access for VIP groups in the `vip.json` file.
6. Restart the server.

# RU
Для корректной работы плагина необходимо обновить [LR FakeRank](https://github.com/ABKAM2023/CS2-LR-FakeRank/releases) до последней версии.

**[VIP(CSSharp)] [LR] CustomFakeRank** - добавляет возможность VIP-игрокам выбирать кастомные фейковые ранги.

# В vip.json
```json
  "CustomFakeRank": true
```

# Переводы:
```json
	"CustomFakeRank": "Выбрать кастомное звание",
	"CustomFakeRank.MenuTitle": "Выбор кастомного звания",
	"CustomFakeRank.Disable": "{red}Отключить кастомное звание",
	"CustomFakeRank.ResetMessage": "Кастомное звание успешно отключено",
	"CustomFakeRank.SuccessMessage": "Кастомное звание успешно установлено!"
```

# Конфигурационный файл (vip_customfakerank.json)
```json
{
  "Categories": [
    {
      "Name": "Стандартные звания",
      "Ranks": [
        {
          "Name": "Серебро I",
          "RankId": 1,
          "RankType": 1
        },
        {
          "Name": "Серебро II",
          "RankId": 2,
          "RankType": 1
        },
        {
          "Name": "Серебро III",
          "RankId": 3,
          "RankType": 1
        },
        {
          "Name": "Серебро IV",
          "RankId": 4,
          "RankType": 1
        },
        {
          "Name": "Серебряная Элита",
          "RankId": 5,
          "RankType": 1
        },
        {
          "Name": "Серебряная Элита-Мастер",
          "RankId": 6,
          "RankType": 1
        },
        {
          "Name": "Золотая Звезда I",
          "RankId": 7,
          "RankType": 1
        },
        {
          "Name": "Золотая Звезда II",
          "RankId": 8,
          "RankType": 1
        },
        {
          "Name": "Золотая Звезда III",
          "RankId": 9,
          "RankType": 1
        },
        {
          "Name": "Золотая Звезда-Мастер",
          "RankId": 10,
          "RankType": 1
        },
        {
          "Name": "Магистр-хранитель I",
          "RankId": 11,
          "RankType": 1
        },
        {
          "Name": "Магистр-хранитель II",
          "RankId": 12,
          "RankType": 1
        },
        {
          "Name": "Магистр-хранитель Элита",
          "RankId": 13,
          "RankType": 1
        },
        {
          "Name": "Заслуженный Магистр-хранитель",
          "RankId": 14,
          "RankType": 1
        },
        {
          "Name": "Легендарный Беркут",
          "RankId": 15,
          "RankType": 1
        },
        {
          "Name": "Легендарный Беркут-Мастер",
          "RankId": 16,
          "RankType": 1
        },
        {
          "Name": "Верховный Магистр-Первый Класс",
          "RankId": 17,
          "RankType": 1
        },
        {
          "Name": "Всемирная Элита",
          "RankId": 18,
          "RankType": 1
        }
      ]
    },
    {
      "Name": "Премьер",
      "Ranks": [
        {
          "Name": "7000",
          "RankId": 7000,
          "RankType": 3
        },
        {
          "Name": "44444",
          "RankId": 44444,
          "RankType": 3
        }
      ]
    }
  ]
}
```

# Установка:
1. Установите [LR FakeRank](https://github.com/ABKAM2023/CS2-LR-FakeRank/releases) и [C# VIPCore](https://github.com/partiusfabaa/cs2-VIPCore)
2. Распакуйте архив с плагином на сервер.
3. Настройте конфигурационный файл `vip_customfakerank.json`.
4. Введите необходимые переводы в файл переводов.
5. Укажите доступ для VIP-групп в файле `vip.json`.
6. Перезагрузите сервер.
