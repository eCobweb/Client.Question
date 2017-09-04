using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace QuestionClient
{
    public class FileCompress
    {
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[1024];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            };
            output.Flush();
        }

        private static string GetFilePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;

            var pathString = Path.GetTempPath(); // ConfigurationHelper.DocumentTempRoot; !! this ends with a trailing backslash.
            return string.Format(@"{0}{1}", pathString, fileName);
        }

        public static byte[] GetDocument(string fileName)
        {
            var readFilePath = string.IsNullOrEmpty(fileName) ? null : GetFilePath(fileName);
            if (string.IsNullOrEmpty(readFilePath)) return null;

            if (File.Exists(readFilePath))
            {
                byte[] outputBytes = System.IO.File.ReadAllBytes(readFilePath);

                return outputBytes.ToArray();
            }

            return null;
        }

        #region PDF Queue only       


        // Adds an ACL entry on the specified file for the specified account.
        public static void AddFileUserSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
        {
            try
            {
                // Get a FileSecurity object that represents the current security settings.
                var fSecurity = File.GetAccessControl(fileName);

                // Add the FileSystemAccessRule to the security settings.
                fSecurity.AddAccessRule(new FileSystemAccessRule(account,
                    rights, controlType));

                // Set the new access settings.
                File.SetAccessControl(fileName, fSecurity);
            }
            catch (Exception ex)
            {
                //toodo
            }
        }

        public static bool IsFileUserSecurity(string fileName, string account, FileSystemRights rights)
        {
            try
            {
                var fSecurity = File.GetAccessControl(fileName);

                foreach (FileSystemAccessRule fsRule in fSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {
                    var accessType = fsRule.AccessControlType;
                    string acct = fsRule.IdentityReference.Value.ToLower();

                    if (accessType == AccessControlType.Allow && acct == OSHelper.MsmqUser)
                    {
                        return fsRule.FileSystemRights == rights;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                //todo
                return false;
            }
        }
        #endregion

       
        private static string CleanUpInvalidChar(string value)
        {
            foreach (Char c in Path.GetInvalidFileNameChars())
                if (value.Contains(c.ToString()))
                    value = value.Replace(c, ' ');

            return value;
        }
    }
}
