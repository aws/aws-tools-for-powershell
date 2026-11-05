using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.SimpleSystemsManagement.Model;
using System.Text.Json;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    public partial class StartSSMSessionCmdlet
    {
        private const int fileNotFoundErrCode = 2;

        private const string pluginDocumentationMsg = "Please refer to SessionManager Documentation here: " +
                    "http://docs.aws.amazon.com/console/systems-manager/session-manager-plugin-not-found";

        private const string pluginNotFoundErrMsg = "SessionManagerPlugin is not found. " + pluginDocumentationMsg;

        private const string pluginVersionNotSupportedErrMsg = "SessionManagerPlugin version {0} is not supported. " +
                    "Upgrade to a version newer than {1} or use -DisablePluginInvocation. " + pluginDocumentationMsg;

        private const string pluginVersionUnknownErrMsg = "Could not determine the SessionManagerPlugin version from '{0} --version'. " +
                    pluginDocumentationMsg;

        private const string sessionResponseEnvironmentVariable = "AWS_SSM_START_SESSION_RESPONSE";

        private const int pluginVersionTimeoutMs = 30000;

        private static readonly Version lastPluginVersionWithoutEnvironmentVariable = new Version(1, 2, 497, 0);

        private static readonly bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        #region Parameter DisablePluginInvocation
        /// <summary>
        /// <para>
        /// <para>If set, reverts to legacy behavior and returns session metadata including a URL and token that can be used to open 
        // a WebSocket connection to send input and receive outputs, rather than opening an interactive terminal.</para>
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter DisablePluginInvocation { get; set; }
        #endregion
        
        protected override void ProcessOutput(CmdletOutput output)
        {
            var serviceResponse = output.ServiceResponse as StartSessionResponse;

            if (this.DisablePluginInvocation.IsPresent)
            {
                base.ProcessOutput(output);
            }
            else
            {
                var pluginStarted = false;
                try
                {
                    /// Check if there was an error getting session metadata in API response.
                    if (output.ErrorResponse != null)
                    {
                        ThrowExecutionError(output.ErrorResponse.Message, this, output.ErrorResponse);
                    }

                    var pluginPath = FindPlugin(out var pluginVersion) ?? throw new Exception(pluginNotFoundErrMsg);
                    if (pluginVersion == null)
                    {
                        throw new Exception(string.Format(pluginVersionUnknownErrMsg, pluginPath));
                    }
                    if (pluginVersion <= lastPluginVersionWithoutEnvironmentVariable)
                    {
                        throw new Exception(string.Format(pluginVersionNotSupportedErrMsg,
                            pluginVersion, lastPluginVersionWithoutEnvironmentVariable));
                    }

                    var sessionParameters = JsonSerializer.Serialize(new
                        {
                            SessionId = serviceResponse.SessionId,
                            TokenValue = serviceResponse.TokenValue,
                            StreamUrl = serviceResponse.StreamUrl
                        });
                    var startSessionParameters = JsonSerializer.Serialize(new { Target = this.Target });

                    using (var process = new Process())
                    {
                        process.StartInfo.FileName = pluginPath;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.Environment[sessionResponseEnvironmentVariable] = sessionParameters;
                        process.StartInfo.Arguments = string.Join(" ", new[]
                            {
                                sessionResponseEnvironmentVariable,
                                this._RegionEndpoint.SystemName,
                                "StartSession",
                                this.ProfileName,
                                startSessionParameters,
                                this.EndpointUrl
                            }.Select(QuoteArgument));

                        process.Start();
                        pluginStarted = true;
                        process.WaitForExit();
                    }

                }
                catch (Exception e)
                {
                    /// Start-SSMSession api call returns response and starts the 
                    /// session on ssm-agent and response is forwarded to
                    /// session-manager-plugin. If the plugin is not started, the session
                    /// is terminated to avoid zombie session active 
                    /// on ssm-agent for default self terminate time
                    if (!pluginStarted && serviceResponse?.SessionId != null)
                    {
                        TerminateSession(serviceResponse.SessionId);
                    }

                    /// If Process.Start() system call errors, check error code and display 
                    /// plugin not found error message if appropriate.
                    if (e is Win32Exception win32Exception && win32Exception.NativeErrorCode == fileNotFoundErrCode)
                    {
                        throw new Exception(pluginNotFoundErrMsg);
                    }
                    throw;
                }
            }
        }

        private void TerminateSession(string sessionId)
        {
            try
            {
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                client.TerminateSessionAsync(new TerminateSessionRequest { SessionId = sessionId }).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                WriteWarning($"Failed to stop SSM session: {e.Message}");
            }
        }

        private static string FindPlugin(out Version version)
        {
            foreach (var candidate in FindPluginCandidates())
            {
                try
                {
                    version = GetPluginVersion(candidate);
                    return candidate;
                }
                catch (Win32Exception)
                {
                }
            }
            version = null;
            return null;
        }

        private static IEnumerable<string> FindPluginCandidates()
        {
            var fileName = isWindows ? "session-manager-plugin.exe" : "session-manager-plugin";
            var pathEntries = (Environment.GetEnvironmentVariable("PATH") ?? string.Empty).Split(Path.PathSeparator);
            foreach (var entry in pathEntries)
            {
                var directory = isWindows ? entry.Trim().Trim('"') : entry;
                if (!IsAbsoluteDirectory(directory) || directory.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    continue;
                }

                var candidate = Path.Combine(directory, fileName);
                if (File.Exists(candidate))
                {
                    yield return candidate;
                }
            }
        }

        private static bool IsAbsoluteDirectory(string directory)
        {
            if (!isWindows)
            {
                return directory.StartsWith("/", StringComparison.Ordinal);
            }

            return directory.StartsWith(@"\\", StringComparison.Ordinal) ||
                   (directory.Length >= 3 && char.IsLetter(directory[0]) && directory[1] == ':' &&
                    (directory[2] == '\\' || directory[2] == '/'));
        }

        private static Version GetPluginVersion(string pluginPath)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = pluginPath;
                process.StartInfo.Arguments = "--version";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                var timer = Stopwatch.StartNew();
                process.Start();

                var versionOutput = process.StandardOutput.ReadToEndAsync();
                if (!versionOutput.Wait(pluginVersionTimeoutMs) ||
                    !process.WaitForExit(Math.Max(0, pluginVersionTimeoutMs - (int)timer.ElapsedMilliseconds)))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (InvalidOperationException)
                    {
                    }
                    return null;
                }

                return Version.TryParse(versionOutput.Result.Trim(), out var version) ? version : null;
            }
        }

        private static string QuoteArgument(string value)
        {
            var quoted = new StringBuilder("\"");
            var backslashes = 0;
            foreach (var c in value ?? string.Empty)
            {
                if (c == '\\')
                {
                    backslashes++;
                    continue;
                }

                quoted.Append('\\', c == '"' ? backslashes * 2 + 1 : backslashes);
                backslashes = 0;
                quoted.Append(c);
            }
            return quoted.Append('\\', backslashes * 2).Append('"').ToString();
        }
    }
}