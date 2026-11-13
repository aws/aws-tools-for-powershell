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
using Amazon.LambdaCore;
using Amazon.LambdaCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMC
{
    /// <summary>
    /// Cancels a pending scheduled deletion, returning the resource to the ACTIVE state.
    /// Scope is determined by the RuntimeName path parameter plus an optional, mutually exclusive
    /// RuntimeVersion or RuntimeAlias query parameter: with neither, the runtime itself is
    /// restored; with RuntimeVersion, the named runtime version; with RuntimeAlias, the named
    /// runtime alias. Restoring a resource that is already ACTIVE is a no-op success. Restore
    /// only works while the target is PENDING_DELETION; once the scheduled deletion has begun
    /// executing (DELETING) or has completed, the call fails.
    /// </summary>
    [Cmdlet("Restore", "LMCRuntime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaCore.Model.RestoreRuntimeResponse")]
    [AWSCmdlet("Calls the AWS Lambda Core RestoreRuntime API operation.", Operation = new[] {"RestoreRuntime"}, SelectReturnType = typeof(Amazon.LambdaCore.Model.RestoreRuntimeResponse))]
    [AWSCmdletOutput("Amazon.LambdaCore.Model.RestoreRuntimeResponse",
        "This cmdlet returns an Amazon.LambdaCore.Model.RestoreRuntimeResponse object containing multiple properties."
    )]
    public partial class RestoreLMCRuntimeCmdlet : AmazonLambdaCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RuntimeAlias
        /// <summary>
        /// <para>
        /// Optional. Restores the named RuntimeAlias
        /// under RuntimeName. Mutually exclusive with RuntimeVersion; supplying both is rejected
        /// with InvalidParameterValueException.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeAlias { get; set; }
        #endregion
        
        #region Parameter RuntimeName
        /// <summary>
        /// <para>
        /// The name or ARN of the runtime to restore.
        /// When RuntimeVersion or RuntimeAlias is specified, the runtime that owns the runtime
        /// version or runtime alias to restore.
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
        public System.String RuntimeName { get; set; }
        #endregion
        
        #region Parameter RuntimeVersion
        /// <summary>
        /// <para>
        /// Optional. Restores the named RuntimeVersion
        /// under RuntimeName. Mutually exclusive with RuntimeAlias; supplying both is rejected
        /// with InvalidParameterValueException.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaCore.Model.RestoreRuntimeResponse).
        /// Specifying the name of a property of type Amazon.LambdaCore.Model.RestoreRuntimeResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuntimeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-LMCRuntime (RestoreRuntime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaCore.Model.RestoreRuntimeResponse, RestoreLMCRuntimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RuntimeAlias = this.RuntimeAlias;
            context.RuntimeName = this.RuntimeName;
            #if MODULAR
            if (this.RuntimeName == null && ParameterWasBound(nameof(this.RuntimeName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeVersion = this.RuntimeVersion;
            
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
            var request = new Amazon.LambdaCore.Model.RestoreRuntimeRequest();
            
            if (cmdletContext.RuntimeAlias != null)
            {
                request.RuntimeAlias = cmdletContext.RuntimeAlias;
            }
            if (cmdletContext.RuntimeName != null)
            {
                request.RuntimeName = cmdletContext.RuntimeName;
            }
            if (cmdletContext.RuntimeVersion != null)
            {
                request.RuntimeVersion = cmdletContext.RuntimeVersion;
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
        
        private Amazon.LambdaCore.Model.RestoreRuntimeResponse CallAWSServiceOperation(IAmazonLambdaCore client, Amazon.LambdaCore.Model.RestoreRuntimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda Core", "RestoreRuntime");
            try
            {
                return client.RestoreRuntimeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RuntimeAlias { get; set; }
            public System.String RuntimeName { get; set; }
            public System.String RuntimeVersion { get; set; }
            public System.Func<Amazon.LambdaCore.Model.RestoreRuntimeResponse, RestoreLMCRuntimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
