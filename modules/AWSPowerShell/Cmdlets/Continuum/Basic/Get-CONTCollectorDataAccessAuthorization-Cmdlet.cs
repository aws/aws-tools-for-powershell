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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Authorizes an Environment's access to a Collector's data. Continuum calls this operation
    /// with the Environment's Collector data-access role before it reads the Collector's
    /// inventory, so grant continuum:GetCollectorDataAccessAuthorization to that role and,
    /// for a Collector in another account, in the Collector's resource policy. The operation
    /// evaluates the action against the exact Collector ARN and the Collector's current resource
    /// policy using IAM and the caller's authenticated request context, with environmentArn
    /// as the continuum:EnvironmentArn condition key. A successful request returns HTTP 200
    /// with no response members. If access is not granted, the operation returns AccessDeniedException
    /// without disclosing Collector existence, ownership, or the policy layer that denied
    /// access. The service does not reinterpret the policy using only an account ID.
    /// </summary>
    [Cmdlet("Get", "CONTCollectorDataAccessAuthorization")]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Continuum GetCollectorDataAccessAuthorization API operation.", Operation = new[] {"GetCollectorDataAccessAuthorization"}, SelectReturnType = typeof(Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse))]
    [AWSCmdletOutput("None or Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse) be returned by specifying '-Select *'."
    )]
    public partial class GetCONTCollectorDataAccessAuthorizationCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The AWS account that owns the Collector.
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter CollectorId
        /// <summary>
        /// <para>
        /// The unique identifier of the Collector.
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
        public System.String CollectorId { get; set; }
        #endregion
        
        #region Parameter EnvironmentArn
        /// <summary>
        /// <para>
        /// The full ARN of the Environment requesting
        /// the Collector's data. The Environment must be in the caller's account. Continuum supplies
        /// this value as the continuum:EnvironmentArn condition key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse).
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
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse, GetCONTCollectorDataAccessAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CollectorId = this.CollectorId;
            #if MODULAR
            if (this.CollectorId == null && ParameterWasBound(nameof(this.CollectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentArn = this.EnvironmentArn;
            
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
            var request = new Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.CollectorId != null)
            {
                request.CollectorId = cmdletContext.CollectorId;
            }
            if (cmdletContext.EnvironmentArn != null)
            {
                request.EnvironmentArn = cmdletContext.EnvironmentArn;
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
        
        private Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "GetCollectorDataAccessAuthorization");
            try
            {
                return client.GetCollectorDataAccessAuthorizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String CollectorId { get; set; }
            public System.String EnvironmentArn { get; set; }
            public System.Func<Amazon.Continuum.Model.GetCollectorDataAccessAuthorizationResponse, GetCONTCollectorDataAccessAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
