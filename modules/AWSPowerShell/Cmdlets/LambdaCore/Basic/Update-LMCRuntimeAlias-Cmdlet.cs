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
    /// Updates an existing runtime alias to point to a different runtime version or to change
    /// its description or lifecycle information.
    /// </summary>
    [Cmdlet("Update", "LMCRuntimeAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse")]
    [AWSCmdlet("Calls the AWS Lambda Core UpdateRuntimeAlias API operation.", Operation = new[] {"UpdateRuntimeAlias"}, SelectReturnType = typeof(Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse))]
    [AWSCmdletOutput("Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse",
        "This cmdlet returns an Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse object containing multiple properties."
    )]
    public partial class UpdateLMCRuntimeAliasCmdlet : AmazonLambdaCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReleaseLifecycle_DeprecationDate
        /// <summary>
        /// <para>
        /// The date (UTC) on which the runtime or
        /// alias becomes deprecated.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseLifecycle_DeprecationDate { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description of the runtime alias.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ReleaseLifecycle_FunctionCreateBlockDate
        /// <summary>
        /// <para>
        /// The date (UTC) on which creating
        /// new functions that use this runtime or alias is blocked.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseLifecycle_FunctionCreateBlockDate { get; set; }
        #endregion
        
        #region Parameter ReleaseLifecycle_FunctionUpdateBlockDate
        /// <summary>
        /// <para>
        /// The date (UTC) on which updating
        /// existing functions that use this runtime or alias is blocked.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseLifecycle_FunctionUpdateBlockDate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the runtime alias to update.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReleaseLifecycle_ReleaseState
        /// <summary>
        /// <para>
        /// Optional, with no default applied. DEPRECATED
        /// requires a DeprecationDate on or before today (UTC); PREVIEW and GA require a later
        /// one, or none. Reads report DEPRECATED once DeprecationDate is reached.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaCore.RuntimeReleaseState")]
        public Amazon.LambdaCore.RuntimeReleaseState ReleaseLifecycle_ReleaseState { get; set; }
        #endregion
        
        #region Parameter RuntimeName
        /// <summary>
        /// <para>
        /// The name or ARN of the runtime.
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
        public System.String RuntimeName { get; set; }
        #endregion
        
        #region Parameter RuntimeVersion
        /// <summary>
        /// <para>
        /// The name of the runtime version the alias
        /// should point to.
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
        public System.String RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse).
        /// Specifying the name of a property of type Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.RuntimeName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMCRuntimeAlias (UpdateRuntimeAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse, UpdateLMCRuntimeAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReleaseLifecycle_DeprecationDate = this.ReleaseLifecycle_DeprecationDate;
            context.ReleaseLifecycle_FunctionCreateBlockDate = this.ReleaseLifecycle_FunctionCreateBlockDate;
            context.ReleaseLifecycle_FunctionUpdateBlockDate = this.ReleaseLifecycle_FunctionUpdateBlockDate;
            context.ReleaseLifecycle_ReleaseState = this.ReleaseLifecycle_ReleaseState;
            context.RuntimeName = this.RuntimeName;
            #if MODULAR
            if (this.RuntimeName == null && ParameterWasBound(nameof(this.RuntimeName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeVersion = this.RuntimeVersion;
            #if MODULAR
            if (this.RuntimeVersion == null && ParameterWasBound(nameof(this.RuntimeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LambdaCore.Model.UpdateRuntimeAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ReleaseLifecycle
            var requestReleaseLifecycleIsNull = true;
            request.ReleaseLifecycle = new Amazon.LambdaCore.Model.RuntimeReleaseLifecycle();
            System.String requestReleaseLifecycle_releaseLifecycle_DeprecationDate = null;
            if (cmdletContext.ReleaseLifecycle_DeprecationDate != null)
            {
                requestReleaseLifecycle_releaseLifecycle_DeprecationDate = cmdletContext.ReleaseLifecycle_DeprecationDate;
            }
            if (requestReleaseLifecycle_releaseLifecycle_DeprecationDate != null)
            {
                request.ReleaseLifecycle.DeprecationDate = requestReleaseLifecycle_releaseLifecycle_DeprecationDate;
                requestReleaseLifecycleIsNull = false;
            }
            System.String requestReleaseLifecycle_releaseLifecycle_FunctionCreateBlockDate = null;
            if (cmdletContext.ReleaseLifecycle_FunctionCreateBlockDate != null)
            {
                requestReleaseLifecycle_releaseLifecycle_FunctionCreateBlockDate = cmdletContext.ReleaseLifecycle_FunctionCreateBlockDate;
            }
            if (requestReleaseLifecycle_releaseLifecycle_FunctionCreateBlockDate != null)
            {
                request.ReleaseLifecycle.FunctionCreateBlockDate = requestReleaseLifecycle_releaseLifecycle_FunctionCreateBlockDate;
                requestReleaseLifecycleIsNull = false;
            }
            System.String requestReleaseLifecycle_releaseLifecycle_FunctionUpdateBlockDate = null;
            if (cmdletContext.ReleaseLifecycle_FunctionUpdateBlockDate != null)
            {
                requestReleaseLifecycle_releaseLifecycle_FunctionUpdateBlockDate = cmdletContext.ReleaseLifecycle_FunctionUpdateBlockDate;
            }
            if (requestReleaseLifecycle_releaseLifecycle_FunctionUpdateBlockDate != null)
            {
                request.ReleaseLifecycle.FunctionUpdateBlockDate = requestReleaseLifecycle_releaseLifecycle_FunctionUpdateBlockDate;
                requestReleaseLifecycleIsNull = false;
            }
            Amazon.LambdaCore.RuntimeReleaseState requestReleaseLifecycle_releaseLifecycle_ReleaseState = null;
            if (cmdletContext.ReleaseLifecycle_ReleaseState != null)
            {
                requestReleaseLifecycle_releaseLifecycle_ReleaseState = cmdletContext.ReleaseLifecycle_ReleaseState;
            }
            if (requestReleaseLifecycle_releaseLifecycle_ReleaseState != null)
            {
                request.ReleaseLifecycle.ReleaseState = requestReleaseLifecycle_releaseLifecycle_ReleaseState;
                requestReleaseLifecycleIsNull = false;
            }
             // determine if request.ReleaseLifecycle should be set to null
            if (requestReleaseLifecycleIsNull)
            {
                request.ReleaseLifecycle = null;
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
        
        private Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse CallAWSServiceOperation(IAmazonLambdaCore client, Amazon.LambdaCore.Model.UpdateRuntimeAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda Core", "UpdateRuntimeAlias");
            try
            {
                return client.UpdateRuntimeAliasAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String ReleaseLifecycle_DeprecationDate { get; set; }
            public System.String ReleaseLifecycle_FunctionCreateBlockDate { get; set; }
            public System.String ReleaseLifecycle_FunctionUpdateBlockDate { get; set; }
            public Amazon.LambdaCore.RuntimeReleaseState ReleaseLifecycle_ReleaseState { get; set; }
            public System.String RuntimeName { get; set; }
            public System.String RuntimeVersion { get; set; }
            public System.Func<Amazon.LambdaCore.Model.UpdateRuntimeAliasResponse, UpdateLMCRuntimeAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
