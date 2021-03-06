﻿using System;

namespace KeyVault.Extensions
{
    /// <summary>
    /// Static helper methods for working with Key Vault
    /// </summary>
    public sealed class KeyVaultHelper
    {
        /// <summary>
        /// Build the Key Vault URL from the name
        /// </summary>
        /// <param name="name">Key Vault Name</param>
        /// <returns>URL to Key Vault</returns>
        public static string BuildKeyVaultConnectionString(string name)
        {
            string kvUrl = name?.Trim();

            // name is required
            if (string.IsNullOrEmpty(kvUrl))
            {
                throw new System.ArgumentNullException(nameof(name));
            }

            // build the URL
            if (!kvUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                kvUrl = "https://" + kvUrl;
            }

            if (!kvUrl.EndsWith(".vault.azure.net/", StringComparison.OrdinalIgnoreCase) && !kvUrl.EndsWith(".vault.azure.net", StringComparison.OrdinalIgnoreCase))
            {
                kvUrl += ".vault.azure.net/";
            }

            if (!kvUrl.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                kvUrl += "/";
            }

            return kvUrl;
        }
    }
}
