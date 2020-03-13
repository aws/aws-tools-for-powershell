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
using Amazon.CodeGuruProfiler;
using Amazon.CodeGuruProfiler.Model;

namespace Amazon.PowerShell.Cmdlets.CGP
{
    /// <summary>
    /// Provides permission to the principals. This overwrites the existing permissions, and
    /// is not additive.
    /// </summary>
    [Cmdlet("Write", "CGPPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruProfiler.Model.PutPermissionResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Profiler PutPermission API operation.", Operation = new[] {"PutPermission"}, SelectReturnType = typeof(Amazon.CodeGuruProfiler.Model.PutPermissionResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruProfiler.Model.PutPermissionResponse",
        "This cmdlet returns an Amazon.CodeGuruProfiler.Model.PutPermissionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCGPPermissionCmdlet : AmazonCodeGuruProfilerClientCmdlet, IExecutor
    {
        
        #region Parameter ActionGroup
        /// <summary>
        /// <para>
        /// <para>The list of actions that the users and roles can perform on the profiling group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeGuruProfiler.ActionGroup")]
        public Amazon.CodeGuruProfiler.ActionGroup ActionGroup { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The list of role and user ARNs or the accountId that needs access (wildcards are not
        /// allowed).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Principals")]
        public System.String[] Principal { get; set; }
        #endregion
        
        #region Parameter ProfilingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the profiling group.</para>
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
        public System.String ProfilingGroupName { get; set; }
        #endregion
        
        #region Parameter RevisionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the current revision of the policy. This is required, if a
        /// policy exists for the profiling group. This is not required when creating the policy
        /// for the first time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruProfiler.Model.PutPermissionResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruProfiler.Model.PutPermissionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProfilingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProfilingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProfilingGroupName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfilingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CGPPermission (PutPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruProfiler.Model.PutPermissionResponse, WriteCGPPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProfilingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActionGroup = this.ActionGroup;
            #if MODULAR
            if (this.ActionGroup == null && ParameterWasBound(nameof(this.ActionGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Principal != null)
            {
                context.Principal = new List<System.String>(this.Principal);
            }
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfilingGroupName = this.ProfilingGroupName;
            #if MODULAR
            if (this.ProfilingGroupName == null && ParameterWasBound(nameof(this.ProfilingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfilingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevisionId = this.RevisionId;
            
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
            var request = new Amazon.CodeGuruProfiler.Model.PutPermissionRequest();
            
            if (cmdletContext.ActionGroup != null)
            {
                request.ActionGroup = cmdletContext.ActionGroup;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
            }
            if (cmdletContext.ProfilingGroupName != null)
            {
                request.ProfilingGroupName = cmdletContext.ProfilingGroupName;
            }
            if (cmdletContext.RevisionId != null)
            {
                request.RevisionId = cmdletContext.RevisionId;
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
        
        private Amazon.CodeGuruProfiler.Model.PutPermissionResponse CallAWSServiceOperation(IAmazonCodeGuruProfiler client, Amazon.CodeGuruProfiler.Model.PutPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Profiler", "PutPermission");
            try
            {
                #if DESKTOP
                return client.PutPermission(request);
                #elif CORECLR
                return client.PutPermissionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeGuruProfiler.ActionGroup ActionGroup { get; set; }
            public List<System.String> Principal { get; set; }
            public System.String ProfilingGroupName { get; set; }
            public System.String RevisionId { get; set; }
            public System.Func<Amazon.CodeGuruProfiler.Model.PutPermissionResponse, WriteCGPPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
