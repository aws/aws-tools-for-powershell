/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;

using Amazon.Runtime;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Sets AWS default proxy for the shell.
    /// </summary>
    [Cmdlet("Set", "AWSProxy")]
    [AWSCmdlet("Sets AWS default proxy for the shell. Subsequent AWS cmdlet invocations will use the configured proxy.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class SetProxyCmdlet : PSCmdlet
    {
        /// <summary>
        /// Proxy server host
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Hostname { get; set; }

        /// <summary>
        /// Proxy server port
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int Port { get; set; }

        /// <summary>
        /// Username to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Username { get; set; }

        /// <summary>
        /// Password to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }
        
        /// <summary>
        /// The credentials to submit to the proxy server for authentication
        /// </summary>
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("Credentials")]
        public ICredentials Credential { get; set; }

        /// <summary>
        /// An array of regular expressions that describe URIs that do not use 
        /// the proxy server when accessed.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string[] BypassList { get; set; }

        /// <summary>
        /// If specified, requests to local Internet resources do not use the configured proxy.
        /// </summary>
        /// <remarks>
        /// Local requests are identified by the lack of a period (.) in the URI, as in http://webserver/, 
        /// or access the local server, including http://localhost, http://loopback, or http://127.0.0.1
        /// </remarks>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter BypassOnLocal { get; set; }

        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the proxy configuration to set.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }

        protected override void ProcessRecord()
        {
            var settings = ProxySettings.GetSettings(this);

            settings.Hostname = Hostname;
            settings.Port = Port;

            if (Credential != null)
                settings.Credentials = Credential;
            else if (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Password))
                settings.Credentials = new NetworkCredential(Username, Password ?? String.Empty);
            else
                settings.Credentials = null;

            settings.BypassList = BypassList != null ? new List<string>(BypassList) : null;
            if (BypassOnLocal)
                settings.BypassOnLocal = true;
            else
                settings.BypassOnLocal = null;

            settings.SaveSettings(this, MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope : (VariableScope?)null);
        }
    }

    /// <summary>
    /// Clears AWS default proxy for the shell.
    /// </summary>
    [Cmdlet("Clear", "AWSProxy")]
    [AWSCmdlet("Clears AWS default proxy for the shell. Subsequent AWS cmdlet invocations will not use a proxy.")]
    [OutputType("None")]
    [AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public class ClearProxyCmdlet : PSCmdlet
    {
        /// <summary>
        /// <para>
        /// This parameter allows to specify the scope of the proxy configuration to clear.
        /// For details about variables scopes see https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_scopes.
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public VariableScope Scope { get; set; }

        protected override void ProcessRecord()
        {
            ProxySettings.SaveSettings(this, null, MyInvocation.BoundParameters.ContainsKey("Scope") ? Scope : (VariableScope?)null);
        }
    }

    /// <summary>
    /// Proxy settings for AWS cmdlets
    /// </summary>
    public class ProxySettings
    {
        /// <summary>
        /// Proxy host
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Proxy port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Proxy credentials
        /// </summary>
        public ICredentials Credentials { get; set; }

        /// <summary>
        /// A collection of regular expressions denoting the set of endpoints for
        /// which the configured proxy host will be bypassed.
        /// </summary>
        /// <remarks>
        ///  For more information on bypass lists 
        ///  see https://msdn.microsoft.com/en-us/library/system.net.webproxy.bypasslist%28v=vs.110%29.aspx.
        /// </remarks>
        public List<string> BypassList { get; set;}

        /// <summary>
        /// If set true requests to local addresses bypass the configured proxy.
        /// </summary>
        public bool? BypassOnLocal { get; set; }

        internal bool UseProxy
        {
            get
            {
                return !string.IsNullOrEmpty(Hostname) && Port != 0;
            }
        }

        internal WebProxy GetWebProxy()
        {
            const string httpPrefix = "http://";

            WebProxy proxy = null;
            if (!string.IsNullOrEmpty(Hostname) && Port > 0)
            {
                // WebProxy constructor adds the http:// prefix, but doesn't
                // account for cases where it's already present which leads to
                // malformed addresses
                var host = Hostname.StartsWith(httpPrefix, StringComparison.OrdinalIgnoreCase)
                               ? Hostname.Substring(httpPrefix.Length)
                               : Hostname;
                proxy = new WebProxy(host, Port);

                if (Credentials != null)
                {
                    proxy.Credentials = Credentials;
                }
                if (BypassList != null)
                {
                    proxy.BypassList = BypassList.ToArray();
                }
                if (BypassOnLocal.HasValue)
                    proxy.BypassProxyOnLocal = BypassOnLocal.Value;
            }

            return proxy;
        }

        internal static ProxySettings GetSettings(PSCmdlet cmdlet)
        {
            ProxySettings ps = GetFromSettingsVariable(cmdlet.SessionState);
            if (ps == null)
                ps = new ProxySettings();

            return ps;
        }

        internal static ProxySettings GetFromSettingsVariable(SessionState session)
        {
            ProxySettings ps = null;

            var variable = session.PSVariable.Get(SessionKeys.AWSProxyVariableName);
            if (variable != null && variable.Value != null)
                ps = variable.Value as ProxySettings;

            return ps;
        }

        internal void SaveSettings(PSCmdlet cmdlet, VariableScope? variableScope)
        {
            SaveSettings(cmdlet, this, variableScope);
        }

        internal static void SaveSettings(PSCmdlet cmdlet, ProxySettings settings, VariableScope? variableScope)
        {
            string scope = variableScope.HasValue ? variableScope.Value.ToString() + ":" : "";
            cmdlet.SessionState.PSVariable.Set(scope + SessionKeys.AWSProxyVariableName, settings);
        }
    }
}
