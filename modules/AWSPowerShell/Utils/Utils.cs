/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Net;
using System.Reflection;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Util.Internal;
#if CORECLR
using System.Runtime.InteropServices;
#endif

namespace Amazon.PowerShell.Utils
{
    public static class Common
    {

        public static void PopulateConfig(PSCmdlet cmdlet, ClientConfig clientConfig)
        {
            var proxySettings = ProxySettings.GetSettings(cmdlet);
            var proxy = proxySettings.GetWebProxy();
            if (proxy != null)
            {
                clientConfig.SetWebProxy(proxy);
            }
        }

        public static void SetAWSPowerShellUserAgent(System.Version hostVersion)
        {
#if DESKTOP
            var moduleName = "AWSPowerShell";
            var platform = "WindowsPowerShell";
#elif MODULAR
            var moduleName = "AWSPowerShell.Common";
            var platform = "PowerShellCore";
#else
            var moduleName = "AWSPowerShell.NetCore";
            var platform = "PowerShellCore";
#endif

            InternalSDKUtils.SetUserAgent(moduleName,
                                          typeof(BaseCmdlet).Assembly.GetName().Version.ToString(),
                                          string.Format("md/{0}/{1}.{2}", platform, hostVersion.Major, hostVersion.MajorRevision));
        }

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

        /// <summary>
        /// Outputs a verbose mode message stating the url or region we are about to call
        /// for a given service operation.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="clientConfig"></param>
        /// <param name="serviceName"></param>
        /// <param name="operationName"></param>
        public static void WriteVerboseEndpointMessage(Cmdlet cmdlet, IClientConfig clientConfig, string serviceName, string operationName)
        {
            WriteVerboseEndpointMessage(cmdlet, clientConfig, string.Format("{0} operation '{1}'", serviceName, operationName));
        }

        /// <summary>
        /// Outputs a verbose mode message stating the url or region we are about to call for a pre-formatted operation
        /// message.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="clientConfig"></param>
        /// <param name="operationMessage"></param>
        public static void WriteVerboseEndpointMessage(Cmdlet cmdlet, IClientConfig clientConfig, string operationMessage)
        {
            var serviceUrl = clientConfig.ServiceURL;
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                cmdlet.WriteVerbose(string.Format("Invoking {0} on endpoint '{1}'", operationMessage, serviceUrl));
            }
            else
            {
                var serviceRegion = clientConfig.RegionEndpoint;
                cmdlet.WriteVerbose(serviceRegion != null
                    ? string.Format("Invoking {0} in region '{1}'", operationMessage, serviceRegion.SystemName)
                    : string.Format("Invoking {0} against undetermined endpoint or region.", operationMessage));
            }
        }

        public static string FormatNameResolutionFailureMessage(IClientConfig clientConfig, string exceptionMessage)
        {
            return FormatNameResolutionFailureMessage(clientConfig.RegionEndpoint, clientConfig.ServiceURL, exceptionMessage);
        }

        public static string FormatNameResolutionFailureMessage(RegionEndpoint region, string serviceUrl, string exceptionMessage)
        {
            if (!string.IsNullOrEmpty(serviceUrl))
            {
                return string.Format("Name resolution failure attempting to reach service endpoint {0}.\n"
                                     + "Possible causes:\n"
                                     + "\t- The endpoint may be incorrect.\n"
                                     + "\t- The service may not be available at that endpoint.\n"
                                     + "\t- No network connectivity.\n"
                                     + "See https://docs.aws.amazon.com/general/latest/gr/rande.html for the latest service availability across the AWS regions.",
                                     serviceUrl);
            }

            if (region != null)
            {
                return string.Format(
                    "Name resolution failure attempting to reach service in region {0} (as supplied to the -Region parameter or from configured shell default).\n"
                    + "{1}.\n"
                    + "Possible causes:\n"
                    + "\t- The region may be incorrectly specified (did you specify an availability zone?).\n"
                    + "\t- The service may not be available in the region.\n"
                    + "\t- No network connectivity.\n"
                    + "See https://docs.aws.amazon.com/general/latest/gr/rande.html for the latest service availability across the AWS regions.",
                    region.SystemName,
                    exceptionMessage);
            }

            return string.Format("Name resolution failure attempting to reach service.\n{0}.", exceptionMessage);
        }

        public static string ConvertToBase64(string source)
        {
            return ConvertToBase64(System.Text.Encoding.UTF8.GetBytes(source));
        }

        public static string ConvertToBase64(byte[] source)
        {
            return System.Convert.ToBase64String(source);
        }
    }
}
