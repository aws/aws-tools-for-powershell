/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CodeCatalyst;
using Amazon.CodeCatalyst.Model;

namespace Amazon.PowerShell.Cmdlets.CCAT
{
    /// <summary>
    /// Starts a session for a specified Dev Environment.
    /// </summary>
    [Cmdlet("Start", "CCATDevEnvironmentSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse")]
    [AWSCmdlet("Calls the AWS CodeCatalyst StartDevEnvironmentSession API operation.", Operation = new[] {"StartDevEnvironmentSession"}, SelectReturnType = typeof(Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse))]
    [AWSCmdletOutput("Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse",
        "This cmdlet returns an Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCCATDevEnvironmentSessionCmdlet : AmazonCodeCatalystClientCmdlet, IExecutor
    {
        
        #region Parameter ExecuteCommandSessionConfiguration_Argument
        /// <summary>
        /// <para>
        /// <para>An array of arguments containing arguments and members.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionConfiguration_ExecuteCommandSessionConfiguration_Arguments")]
        public System.String[] ExecuteCommandSessionConfiguration_Argument { get; set; }
        #endregion
        
        #region Parameter ExecuteCommandSessionConfiguration_Command
        /// <summary>
        /// <para>
        /// <para>The command used at the beginning of the SSH session to a Dev Environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionConfiguration_ExecuteCommandSessionConfiguration_Command")]
        public System.String ExecuteCommandSessionConfiguration_Command { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID of the Dev Environment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in the space.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter SessionConfiguration_SessionType
        /// <summary>
        /// <para>
        /// <para>The type of the session.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeCatalyst.DevEnvironmentSessionType")]
        public Amazon.CodeCatalyst.DevEnvironmentSessionType SessionConfiguration_SessionType { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse).
        /// Specifying the name of a property of type Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._ExecuteWithAnonymousCredentials = true;
            this._AWSSignerType = "bearer";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CCATDevEnvironmentSession (StartDevEnvironmentSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse, StartCCATDevEnvironmentSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExecuteCommandSessionConfiguration_Argument != null)
            {
                context.ExecuteCommandSessionConfiguration_Argument = new List<System.String>(this.ExecuteCommandSessionConfiguration_Argument);
            }
            context.ExecuteCommandSessionConfiguration_Command = this.ExecuteCommandSessionConfiguration_Command;
            context.SessionConfiguration_SessionType = this.SessionConfiguration_SessionType;
            #if MODULAR
            if (this.SessionConfiguration_SessionType == null && ParameterWasBound(nameof(this.SessionConfiguration_SessionType)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionConfiguration_SessionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpaceName = this.SpaceName;
            #if MODULAR
            if (this.SpaceName == null && ParameterWasBound(nameof(this.SpaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate SessionConfiguration
            var requestSessionConfigurationIsNull = true;
            request.SessionConfiguration = new Amazon.CodeCatalyst.Model.DevEnvironmentSessionConfiguration();
            Amazon.CodeCatalyst.DevEnvironmentSessionType requestSessionConfiguration_sessionConfiguration_SessionType = null;
            if (cmdletContext.SessionConfiguration_SessionType != null)
            {
                requestSessionConfiguration_sessionConfiguration_SessionType = cmdletContext.SessionConfiguration_SessionType;
            }
            if (requestSessionConfiguration_sessionConfiguration_SessionType != null)
            {
                request.SessionConfiguration.SessionType = requestSessionConfiguration_sessionConfiguration_SessionType;
                requestSessionConfigurationIsNull = false;
            }
            Amazon.CodeCatalyst.Model.ExecuteCommandSessionConfiguration requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration = null;
            
             // populate ExecuteCommandSessionConfiguration
            var requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfigurationIsNull = true;
            requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration = new Amazon.CodeCatalyst.Model.ExecuteCommandSessionConfiguration();
            List<System.String> requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Argument = null;
            if (cmdletContext.ExecuteCommandSessionConfiguration_Argument != null)
            {
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Argument = cmdletContext.ExecuteCommandSessionConfiguration_Argument;
            }
            if (requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Argument != null)
            {
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration.Arguments = requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Argument;
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfigurationIsNull = false;
            }
            System.String requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Command = null;
            if (cmdletContext.ExecuteCommandSessionConfiguration_Command != null)
            {
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Command = cmdletContext.ExecuteCommandSessionConfiguration_Command;
            }
            if (requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Command != null)
            {
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration.Command = requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration_executeCommandSessionConfiguration_Command;
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfigurationIsNull = false;
            }
             // determine if requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration should be set to null
            if (requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfigurationIsNull)
            {
                requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration = null;
            }
            if (requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration != null)
            {
                request.SessionConfiguration.ExecuteCommandSessionConfiguration = requestSessionConfiguration_sessionConfiguration_ExecuteCommandSessionConfiguration;
                requestSessionConfigurationIsNull = false;
            }
             // determine if request.SessionConfiguration should be set to null
            if (requestSessionConfigurationIsNull)
            {
                request.SessionConfiguration = null;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse CallAWSServiceOperation(IAmazonCodeCatalyst client, Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCatalyst", "StartDevEnvironmentSession");
            try
            {
                #if DESKTOP
                return client.StartDevEnvironmentSession(request);
                #elif CORECLR
                return client.StartDevEnvironmentSessionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Id { get; set; }
            public System.String ProjectName { get; set; }
            public List<System.String> ExecuteCommandSessionConfiguration_Argument { get; set; }
            public System.String ExecuteCommandSessionConfiguration_Command { get; set; }
            public Amazon.CodeCatalyst.DevEnvironmentSessionType SessionConfiguration_SessionType { get; set; }
            public System.String SpaceName { get; set; }
            public System.Func<Amazon.CodeCatalyst.Model.StartDevEnvironmentSessionResponse, StartCCATDevEnvironmentSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
