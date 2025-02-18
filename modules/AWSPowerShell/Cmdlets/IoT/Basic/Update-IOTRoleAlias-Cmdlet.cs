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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a role alias.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateRoleAlias</a>
    /// action.
    /// </para><important><para>
    /// The value of <a href="https://docs.aws.amazon.com/iot/latest/apireference/API_UpdateRoleAlias.html#iot-UpdateRoleAlias-request-credentialDurationSeconds"><c>credentialDurationSeconds</c></a> must be less than or equal to the maximum session
    /// duration of the IAM role that the role alias references. For more information, see
    /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/roles-managingrole-editing-api.html#roles-modify_max-session-duration-api">
    /// Modifying a role maximum session duration (Amazon Web Services API)</a> from the Amazon
    /// Web Services Identity and Access Management User Guide.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "IOTRoleAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateRoleAliasResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateRoleAlias API operation.", Operation = new[] {"UpdateRoleAlias"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateRoleAliasResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateRoleAliasResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateRoleAliasResponse object containing multiple properties."
    )]
    public partial class UpdateIOTRoleAliasCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CredentialDurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds the credential will be valid.</para><para>This value must be less than or equal to the maximum session duration of the IAM role
        /// that the role alias references.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CredentialDurationSeconds")]
        public System.Int32? CredentialDurationSecond { get; set; }
        #endregion
        
        #region Parameter RoleAlias
        /// <summary>
        /// <para>
        /// <para>The role alias to update.</para>
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
        public System.String RoleAlias { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateRoleAliasResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateRoleAliasResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTRoleAlias (UpdateRoleAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateRoleAliasResponse, UpdateIOTRoleAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialDurationSecond = this.CredentialDurationSecond;
            context.RoleAlias = this.RoleAlias;
            #if MODULAR
            if (this.RoleAlias == null && ParameterWasBound(nameof(this.RoleAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.IoT.Model.UpdateRoleAliasRequest();
            
            if (cmdletContext.CredentialDurationSecond != null)
            {
                request.CredentialDurationSeconds = cmdletContext.CredentialDurationSecond.Value;
            }
            if (cmdletContext.RoleAlias != null)
            {
                request.RoleAlias = cmdletContext.RoleAlias;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.IoT.Model.UpdateRoleAliasResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateRoleAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateRoleAlias");
            try
            {
                return client.UpdateRoleAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CredentialDurationSecond { get; set; }
            public System.String RoleAlias { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateRoleAliasResponse, UpdateIOTRoleAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
