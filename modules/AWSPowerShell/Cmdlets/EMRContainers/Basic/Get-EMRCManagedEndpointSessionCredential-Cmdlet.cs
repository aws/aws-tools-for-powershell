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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Generate a session token to connect to a managed endpoint.
    /// </summary>
    [Cmdlet("Get", "EMRCManagedEndpointSessionCredential")]
    [OutputType("Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers GetManagedEndpointSessionCredentials API operation.", Operation = new[] {"GetManagedEndpointSessionCredentials"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse object containing multiple properties."
    )]
    public partial class GetEMRCManagedEndpointSessionCredentialCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CredentialType
        /// <summary>
        /// <para>
        /// <para>Type of the token requested. Currently supported and default value of this field is
        /// “TOKEN.”</para>
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
        public System.String CredentialType { get; set; }
        #endregion
        
        #region Parameter DurationInSecond
        /// <summary>
        /// <para>
        /// <para>Duration in seconds for which the session token is valid. The default duration is
        /// 15 minutes and the maximum is 12 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationInSeconds")]
        public System.Int32? DurationInSecond { get; set; }
        #endregion
        
        #region Parameter EndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the managed endpoint for which the request is submitted. </para>
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
        public System.String EndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM Execution Role ARN that will be used by the job run. </para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter LogContext
        /// <summary>
        /// <para>
        /// <para>String identifier used to separate sections of the execution logs uploaded to S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogContext { get; set; }
        #endregion
        
        #region Parameter VirtualClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the Virtual Cluster which the Managed Endpoint belongs to. </para>
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
        public System.String VirtualClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token of the job run request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse, GetEMRCManagedEndpointSessionCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CredentialType = this.CredentialType;
            #if MODULAR
            if (this.CredentialType == null && ParameterWasBound(nameof(this.CredentialType)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationInSecond = this.DurationInSecond;
            context.EndpointIdentifier = this.EndpointIdentifier;
            #if MODULAR
            if (this.EndpointIdentifier == null && ParameterWasBound(nameof(this.EndpointIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogContext = this.LogContext;
            context.VirtualClusterIdentifier = this.VirtualClusterIdentifier;
            #if MODULAR
            if (this.VirtualClusterIdentifier == null && ParameterWasBound(nameof(this.VirtualClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CredentialType != null)
            {
                request.CredentialType = cmdletContext.CredentialType;
            }
            if (cmdletContext.DurationInSecond != null)
            {
                request.DurationInSeconds = cmdletContext.DurationInSecond.Value;
            }
            if (cmdletContext.EndpointIdentifier != null)
            {
                request.EndpointIdentifier = cmdletContext.EndpointIdentifier;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.LogContext != null)
            {
                request.LogContext = cmdletContext.LogContext;
            }
            if (cmdletContext.VirtualClusterIdentifier != null)
            {
                request.VirtualClusterIdentifier = cmdletContext.VirtualClusterIdentifier;
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
        
        private Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "GetManagedEndpointSessionCredentials");
            try
            {
                return client.GetManagedEndpointSessionCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CredentialType { get; set; }
            public System.Int32? DurationInSecond { get; set; }
            public System.String EndpointIdentifier { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String LogContext { get; set; }
            public System.String VirtualClusterIdentifier { get; set; }
            public System.Func<Amazon.EMRContainers.Model.GetManagedEndpointSessionCredentialsResponse, GetEMRCManagedEndpointSessionCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
