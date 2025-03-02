using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Project1.mvvm.viewmodels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Project1.mvvm.models
{
    public class RollRepository : ObservableObject
    {
        public async static Task<IEnumerable<Roll>> GetRolls()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "RollData.json");

            try
            {
                if (!File.Exists(filePath))
                {
                    IEnumerable<Roll> defaultRolls = await GetDefaultRolls();

                    JsonSerializerOptions options = new()
                    {
                        WriteIndented = true,
                    };

                    string defaultRollsJson = JsonSerializer.Serialize(defaultRolls, options);

                    await File.WriteAllTextAsync(filePath, defaultRollsJson);
                    return defaultRolls;
                }
                else
                {
                    using FileStream stream = File.OpenRead(filePath);

                    JsonSerializerOptions options = new()
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    IEnumerable<Roll>? rolls = await JsonSerializer.DeserializeAsync<List<Roll>>(stream, options);
                    return rolls ?? Enumerable.Empty<Roll>();
                }
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public async static Task<IEnumerable<Roll>> GetDefaultRolls()
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("Data.json");

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            IEnumerable<Roll>? rolls = await JsonSerializer.DeserializeAsync<List<Roll>>(stream, options);

            return rolls ?? [];
        }

        public async static Task SaveRolls(ObservableCollection<DetailedRollViewModel> rolls)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(rolls, options);

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "RollData.json");

            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                await writer.WriteAsync(json);
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }

        public async static Task ResetRolls()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "RollData.json");

            IEnumerable<Roll>? rolls = await GetDefaultRolls();

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(rolls, options);

            await File.WriteAllTextAsync(filePath, json);
        }
    }
}