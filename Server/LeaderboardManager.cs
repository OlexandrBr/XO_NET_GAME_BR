using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{
    public static class LeaderboardManager
    {
        private static readonly string filePath = "leaderboard.json";
        private static Dictionary<string, LeaderboardEntry> leaderboard = new();

        public static void Load()
        {
            if (!File.Exists(filePath))
            {
                leaderboard = new Dictionary<string, LeaderboardEntry>();
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);
                leaderboard = JsonSerializer.Deserialize<Dictionary<string, LeaderboardEntry>>(json)
                              ?? new Dictionary<string, LeaderboardEntry>();
            }
            catch
            {
                leaderboard = new Dictionary<string, LeaderboardEntry>();
            }
        }

        public static void Save()
        {
            string json = JsonSerializer.Serialize(leaderboard, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private static LeaderboardEntry GetOrCreate(string nickname)
        {
            if (!leaderboard.ContainsKey(nickname))
            {
                leaderboard[nickname] = new LeaderboardEntry
                {
                    Nickname = nickname
                };
            }

            return leaderboard[nickname];
        }

        public static void AddWin(string nickname)
        {
            var player = GetOrCreate(nickname);
            player.Wins++;
            Save();
        }

        public static void AddLoss(string nickname)
        {
            var player = GetOrCreate(nickname);
            player.Losses++;
            Save();
        }

        public static void AddDraw(string nickname)
        {
            var player = GetOrCreate(nickname);
            player.Draws++;
            Save();
        }

        public static List<LeaderboardEntry> GetTop()
        {
            return leaderboard.Values
                .OrderByDescending(x => x.Wins)
                .ThenBy(x => x.Losses)
                .ThenByDescending(x => x.Draws)
                .ToList();
        }

        public static string GetLeaderboardText()
        {
            var top = GetTop();

            if (top.Count == 0)
                return "LEADERBOARD|Пока нет результатов";

            var lines = top.Select((x, i) =>
                $"{i + 1}. {x.Nickname}  W:{x.Wins} L:{x.Losses} D:{x.Draws}");

            return "LEADERBOARD|" + string.Join(";", lines);
        }
    }
}
