using System.Diagnostics;

using Microsoft.Data.SqlClient;

namespace Admin.DB
{
    internal static class StringExtension
    {
        public static string TrustedConnectionString(this string connectionString, bool forceTrustServerCertificate = false)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            if (Debugger.IsAttached || forceTrustServerCertificate)
            {
                //to avoid (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)
                builder["TrustServerCertificate"] = true;
            }
            return builder.ConnectionString;
        }
    }
}
