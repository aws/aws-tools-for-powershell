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
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// This API is in preview release for Amazon Connect and is subject to change. To request
    /// access to this API, contact Amazon Web Services Support.
    /// 
    ///  
    /// <para>
    /// Updates the selected authentication profile.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNAuthenticationProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateAuthenticationProfile API operation.", Operation = new[] {"UpdateAuthenticationProfile"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateAuthenticationProfileResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateAuthenticationProfileResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateAuthenticationProfileResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNAuthenticationProfileCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowedIp
        /// <summary>
        /// <para>
        /// <para>A list of IP address range strings that are allowed to access the instance. For more
        /// information on how to configure IP addresses, see<a href="https://docs.aws.amazon.com/connect/latest/adminguide/authentication-profiles.html#configure-session-timeouts">Configure
        /// session timeouts</a> in the <i>Amazon Connect Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedIps")]
        public System.String[] AllowedIp { get; set; }
        #endregion
        
        #region Parameter AuthenticationProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the authentication profile. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AuthenticationProfileId { get; set; }
        #endregion
        
        #region Parameter BlockedIp
        /// <summary>
        /// <para>
        /// <para>A list of IP address range strings that are blocked from accessing the instance. For
        /// more information on how to configure IP addresses, For more information on how to
        /// configure IP addresses, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/authentication-profiles.html#configure-ip-based-ac">Configure
        /// IP-based access control</a> in the <i>Amazon Connect Administrator Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockedIps")]
        public System.String[] BlockedIp { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the authentication profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the authentication profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PeriodicSessionDuration
        /// <summary>
        /// <para>
        /// <para>The short lived session duration configuration for users logged in to Amazon Connect,
        /// in minutes. This value determines the maximum possible time before an agent is authenticated.
        /// For more information, For more information on how to configure IP addresses, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/authentication-profiles.html#configure-session-timeouts">Configure
        /// session timeouts</a> in the <i>Amazon Connect Administrator Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PeriodicSessionDuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateAuthenticationProfileResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthenticationProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNAuthenticationProfile (UpdateAuthenticationProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateAuthenticationProfileResponse, UpdateCONNAuthenticationProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedIp != null)
            {
                context.AllowedIp = new List<System.String>(this.AllowedIp);
            }
            context.AuthenticationProfileId = this.AuthenticationProfileId;
            #if MODULAR
            if (this.AuthenticationProfileId == null && ParameterWasBound(nameof(this.AuthenticationProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BlockedIp != null)
            {
                context.BlockedIp = new List<System.String>(this.BlockedIp);
            }
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.PeriodicSessionDuration = this.PeriodicSessionDuration;
            
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
            var request = new Amazon.Connect.Model.UpdateAuthenticationProfileRequest();
            
            if (cmdletContext.AllowedIp != null)
            {
                request.AllowedIps = cmdletContext.AllowedIp;
            }
            if (cmdletContext.AuthenticationProfileId != null)
            {
                request.AuthenticationProfileId = cmdletContext.AuthenticationProfileId;
            }
            if (cmdletContext.BlockedIp != null)
            {
                request.BlockedIps = cmdletContext.BlockedIp;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PeriodicSessionDuration != null)
            {
                request.PeriodicSessionDuration = cmdletContext.PeriodicSessionDuration.Value;
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
        
        private Amazon.Connect.Model.UpdateAuthenticationProfileResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateAuthenticationProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateAuthenticationProfile");
            try
            {
                return client.UpdateAuthenticationProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllowedIp { get; set; }
            public System.String AuthenticationProfileId { get; set; }
            public List<System.String> BlockedIp { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Int32? PeriodicSessionDuration { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateAuthenticationProfileResponse, UpdateCONNAuthenticationProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
