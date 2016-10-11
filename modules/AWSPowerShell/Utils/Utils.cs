/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.Util.Internal;
#if CORECLR
using System.Runtime.InteropServices;
#endif

namespace Amazon.PowerShell.Utils
{
    internal static class Common
    {

        public static void PopulateConfig(PSCmdlet cmdlet, ClientConfig clientConfig)
        {
#if DESKTOP
            var proxySettings = ProxySettings.GetSettings(cmdlet);
            if (proxySettings != null && proxySettings.UseProxy)
            {
                clientConfig.ProxyHost = proxySettings.Hostname;
                clientConfig.ProxyPort = proxySettings.Port;
                clientConfig.ProxyCredentials = proxySettings.Credentials;

                if (proxySettings.BypassList != null)
                    clientConfig.ProxyBypassList = new List<string>(proxySettings.BypassList);
                if (proxySettings.BypassOnLocal.HasValue)
                    clientConfig.ProxyBypassOnLocal = proxySettings.BypassOnLocal.Value;
            }
#endif
        }

        public static void SetAWSPowerShellUserAgent(System.Version hostVersion)
        {
#if DESKTOP
            var moduleName = "AWSPowerShell";
            var platform = "WindowsPowerShell";
#else
            var moduleName = "AWSPowerShell.NetCore";
            var platform = "PowerShellCore";
#endif

            InternalSDKUtils.SetUserAgent(moduleName,
                                          TypeFactory.GetTypeInfo(typeof(BaseCmdlet)).Assembly.GetName().Version.ToString(),
                                          string.Format("{0}/{1}.{2}", platform, hostVersion.Major, hostVersion.MajorRevision));
        }

        public static ServerSideEncryptionMethod Convert(string serverSideEncryption)
        {
            ServerSideEncryptionMethod value = serverSideEncryption;
            if (string.Equals(value.Value, serverSideEncryptionNone.Value, System.StringComparison.OrdinalIgnoreCase))
                value = ServerSideEncryptionMethod.None;
            return value;
        }

        private static readonly ServerSideEncryptionMethod serverSideEncryptionNone = "None";

        public static void CopyStream(Stream source, Stream destination, int bufferSize = 8192)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destination == null)
                throw new ArgumentNullException("destination");
            if (bufferSize <= 0)
                throw new ArgumentOutOfRangeException("bufferSize");

            byte[] array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
            }
        }

        public const string WindowsPlatform = "Windows";
        public const string LinuxPlatform = "Linux";
        public const string OSXPlatform = "OSX";

        /// <summary>
        /// Probes to discover the OS we are running on. Environment.OSVersion is not available
        /// on CoreCLR. We return a string rather than OSPlatform to avoid the need to expose
        /// the nuget package to our AWSPowerShell module (plus we only really need the name 
        /// anyway).
        /// </summary>
        /// <returns></returns>
        public static string QueryOSPlatform()
        {
#if CORECLR
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return LinuxPlatform;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return OSXPlatform;
            }
            catch
            {
            }
#endif

            return WindowsPlatform;
        }

        public static bool IsWindowsPlatform
        {
            get
            {
                return QueryOSPlatform().Equals(WindowsPlatform, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
