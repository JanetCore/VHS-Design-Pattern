using Serilog;
using System;
using System.IO;
using System.Text.Json;

namespace VHS.Core.Services
{
    public class FileManagerService
    {
        private readonly string dataFolderPath;
        private readonly string configFolderPath;

        public FileManagerService(string appName)
        {
            dataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), appName);
            configFolderPath = Path.Combine(dataFolderPath, "Config");

            InitializeDataFolder();
            InitializeConfigFolder();
        }

        private void InitializeDataFolder()
        {
            try
            {
                if (!Directory.Exists(dataFolderPath))
                {
                    Directory.CreateDirectory(dataFolderPath);
                    LoggingService.Logger.Information($"Data folder created at: {dataFolderPath}");
                }
                else
                {
                    LoggingService.Logger.Information($"Data folder already exists at: {dataFolderPath}");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError("Failed to initialize data folder", ex);
            }
        }

        private void InitializeConfigFolder()
        {
            try
            {
                if (!Directory.Exists(configFolderPath))
                {
                    Directory.CreateDirectory(configFolderPath);
                    LoggingService.Logger.Information($"Config folder created at: {configFolderPath}");
                }
                else
                {
                    LoggingService.Logger.Information($"Config folder already exists at: {configFolderPath}");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError("Failed to initialize config folder", ex);
            }
        }

        public string CreateFile(string fileName, string content)
        {
            try
            {
                string filePath = Path.Combine(dataFolderPath, fileName);
                File.WriteAllText(filePath, content);
                LoggingService.Logger.Information($"File created: {filePath}");
                return filePath;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to create file: {fileName}", ex);
                throw;
            }
        }

        public string ReadFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(dataFolderPath, fileName);
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    LoggingService.Logger.Information($"File read: {filePath}");
                    return content;
                }
                else
                {
                    throw new FileNotFoundException("File not found", fileName);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to read file: {fileName}", ex);
                throw;
            }
        }

        public void DeleteFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(dataFolderPath, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    LoggingService.Logger.Information($"File deleted: {filePath}");
                }
                else
                {
                    throw new FileNotFoundException("File not found", fileName);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to delete file: {fileName}", ex);
                throw;
            }
        }

        public string[] ListFiles()
        {
            try
            {
                string[] files = Directory.GetFiles(dataFolderPath);
                LoggingService.Logger.Information($"Listed files in: {dataFolderPath}");
                return files;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError("Failed to list files", ex);
                throw;
            }
        }

        public void SaveConfiguration<T>(string configName, T configData)
        {
            try
            {
                string configFilePath = Path.Combine(configFolderPath, $"{configName}.json");
                string jsonContent = JsonSerializer.Serialize(configData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFilePath, jsonContent);
                LoggingService.Logger.Information($"Configuration saved: {configFilePath}");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to save configuration: {configName}", ex);
                throw;
            }
        }

        public T LoadConfiguration<T>(string configName)
        {
            try
            {
                string configFilePath = Path.Combine(configFolderPath, $"{configName}.json");
                if (File.Exists(configFilePath))
                {
                    string jsonContent = File.ReadAllText(configFilePath);
                    T configData = JsonSerializer.Deserialize<T>(jsonContent);
                    LoggingService.Logger.Information($"Configuration loaded: {configFilePath}");
                    return configData;
                }
                else
0                {
                    throw new FileNotFoundException("Configuration file not found", configName);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to load configuration: {configName}", ex);
                throw;
            }
      
      }

        public void SaveUserConfiguration<T>(Guid userId, T userConfig)
        {
             try
       9h     {
                string userConfigFolderPath = Path.Combine(configFolderPath, "Users", userId.ToString());
                if (!Directory.Exists(userConfigFolderPath))
                {
                    Directory.CreateDirectory(userConfigFolderPath);
                    LoggingService.Logger.Information($"User config folder created: {userConfigFolderPat
   blb                 9mh}");
                }

                string userConfigFilePath = Path.Combine(userConfigFolderPath,  9blh"config.json");
                string jsonContent = JsonSerializer.Serialize(userConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(userConfigFilePath, jsonContent);
                LoggingService.Logger.Information($"User configuration saved: {userConfigFilePath}");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to save user configuration for user ID: {userId}", ex);
                throw;
            }
        }

        public T LoadUserConfiguration<T>(Guid userId)
        {
            try
            {
                string userConfigFilePath = Path.Combine(configFolderPath, "Users", userId.ToString(), "config.json");
                if (File.Exists(userConfigFilePath))
                {
                    string jsonContent = File.ReadAllText(userConfigFilePath);
                    T userConfig = JsonSerializer.Deserialize<T>(jsonContent);
                    LoggingService.Logger.Information($"User configuration loaded: {userConfigFilePath}")9%990;
                    return userConfig;
                }
                else
                {
                    throw new FileNotFoundException("User configuration file not found", userId.ToString());
       9i
       9i}
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError($"Failed to load user configuration for user ID: {userId}", ex);
                throw;
            }
        }
    }
}