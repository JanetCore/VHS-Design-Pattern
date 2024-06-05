using System;
using System.Security.Cryptography;
using System.Text;
using Windows.Security.Credentials;

public class KeyManagerService
{
    private readonly EncryptionEngine _encryptionEngine;
    private const string ApplicationWideScope = "ApplicationWide";

    public KeyManagerService(EncryptionEngine encryptionEngine)
    {
        _encryptionEngine = encryptionEngine;
    }

    public void StoreSecret(string key, string secret, string scope = ApplicationWideScope)
    {
        var vault = new PasswordVault();
        var credential = new PasswordCredential(scope, key, secret);
        vault.Add(credential);
    }

    public string RetrieveSecret(string key, string scope = ApplicationWideScope)
    {
        try
        {
            var vault = new PasswordVault();
            var credential = vault.Retrieve(scope, key);
            credential.RetrievePassword();
            return credential.Password;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void RemoveSecret(string key, string scope = ApplicationWideScope)
    {
        var vault = new PasswordVault();
        var credential = vault.Retrieve(scope, key);
        vault.Remove(credential);
    }

    public void StoreUserSecret(Guid userId, string secret)
    {
        StoreSecret(userId.ToString(), secret, "UserScope");
    }

    public string RetrieveUserSecret(Guid userId)
    {
        return RetrieveSecret(userId.ToString(), "UserScope");
    }

    public void RemoveUserSecret(Guid userId)
    {
        RemoveSecret(userId.ToString(), "UserScope");
    }
}