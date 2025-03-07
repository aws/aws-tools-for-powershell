using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.SimpleSystemsManagement.Model;
using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    public partial class StartSSMSessionCmdlet
    {
        private const int fileNotFoundErrCode = 2;

        private const string pluginNotFoundErrMsg = "SessionManagerPlugin is not found. " +
                    "Please refer to SessionManager Documentation here: " +
                    "http://docs.aws.amazon.com/console/systems-manager/session-manager-plugin-not-found";

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
                try
                {
                    /// Check if there was an error getting session metadata in API response.
                    if (output.ErrorResponse != null)
                    {
                        ThrowExecutionError(output.ErrorResponse.Message, this, output.ErrorResponse);
                    }

                    var operationName = "StartSession";
                    var profileName = (this.ProfileName != null) ? this.ProfileName : null;
                    var parameters = (this.Parameter != null) ? JsonSerializer.Serialize(this.Parameter) : null; 
                    var region = this._RegionEndpoint.SystemName;
                    var endpointName = (this.EndpointUrl != null) ? this.EndpointUrl : null;
                    var sessionParameters = JsonSerializer.Serialize(new
                        {
                            SessionId = serviceResponse.SessionId,
                            TokenValue = serviceResponse.TokenValue,
                            StreamUrl = serviceResponse.StreamUrl
                        });
                    /// Replace each quotation mark with triple-escape quotation marks
                    /// to explicitly include quotations around each JSON field and value. 
                    /// See documentation for ProcessStartInfo.Arguments for more info:
                    /// https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo.arguments?view=net-8.0
                    var sb = new StringBuilder(sessionParameters);
                    sb.Replace("\"", "\"\"\"");

                    var process = new System.Diagnostics.Process();

                    /// Configure StartInfo for session manager plugin invocation.
                    process.StartInfo.FileName = "session-manager-plugin";

                    // The JSON expression must be wrapped in an additional set of double quotes when passed as ProcessStartInfo.Arguments.   
                    var argumentList = new List<string>();
                    argumentList.Add("\"" + sb.ToString() + "\"");
                    argumentList.Add(region);
                    argumentList.Add(operationName);
                    argumentList.Add(profileName);
                    argumentList.Add(parameters);
                    argumentList.Add(endpointName);

                    process.StartInfo.Arguments = string.Join(" ", argumentList.ToArray());

                    process.Start();
                    process.WaitForExit();

                }
                catch (Exception e)
                {
                    /// If Process.Start() system call errors, check error code and display 
                    /// plugin not found error message if appropriate.
                    if (e is System.ComponentModel.Win32Exception)
                    {
                        int errorCode = (e as System.ComponentModel.Win32Exception).NativeErrorCode;
                        if (errorCode == fileNotFoundErrCode)
                        {
                            /// Start-SSMSession api call returns response and starts the 
                            /// session on ssm-agent and response is forwarded to
                            /// session-manager-plugin. If plugin is not present, Stop-SSMSession
                            /// is called to terminate the session to avoid zombie session active 
                            /// on ssm-agent for default self terminate time
                            
                            /// Attempt to stop SSM session but don't let stop failure prevent original error
                            try 
                            {
                                StopSSMSessionCmdlet stopSSMSessionCmdlet = new StopSSMSessionCmdlet();
                                stopSSMSessionCmdlet.SessionId = serviceResponse.SessionId;
                                stopSSMSessionCmdlet.Invoke();
                            }
                            catch (Exception stopSSMError)
                            {
                                WriteWarning($"Failed to stop SSM session: {stopSSMError.Message}");
                            }
                            
                            throw new Exception(pluginNotFoundErrMsg);
                        }
                    }
                    throw;
                }
            }
        }
    }
}