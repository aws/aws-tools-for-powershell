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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Retrieves information about a specific task running on a specific target.
    /// </summary>
    [Cmdlet("Get", "SSMMaintenanceWindowExecutionTaskInvocation")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetMaintenanceWindowExecutionTaskInvocation API operation.", Operation = new[] {"GetMaintenanceWindowExecutionTaskInvocation"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse object containing multiple properties."
    )]
    public partial class GetSSMMaintenanceWindowExecutionTaskInvocationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvocationId
        /// <summary>
        /// <para>
        /// <para>The invocation ID to retrieve.</para>
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
        public System.String InvocationId { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the specific task in the maintenance window task that should be retrieved.
        /// </para>
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
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter WindowExecutionId
        /// <summary>
        /// <para>
        /// <para>The ID of the maintenance window execution for which the task is a part.</para>
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
        public System.String WindowExecutionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse, GetSSMMaintenanceWindowExecutionTaskInvocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InvocationId = this.InvocationId;
            #if MODULAR
            if (this.InvocationId == null && ParameterWasBound(nameof(this.InvocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskId = this.TaskId;
            #if MODULAR
            if (this.TaskId == null && ParameterWasBound(nameof(this.TaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WindowExecutionId = this.WindowExecutionId;
            #if MODULAR
            if (this.WindowExecutionId == null && ParameterWasBound(nameof(this.WindowExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationRequest();
            
            if (cmdletContext.InvocationId != null)
            {
                request.InvocationId = cmdletContext.InvocationId;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            if (cmdletContext.WindowExecutionId != null)
            {
                request.WindowExecutionId = cmdletContext.WindowExecutionId;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetMaintenanceWindowExecutionTaskInvocation");
            try
            {
                #if DESKTOP
                return client.GetMaintenanceWindowExecutionTaskInvocation(request);
                #elif CORECLR
                return client.GetMaintenanceWindowExecutionTaskInvocationAsync(request).GetAwaiter().GetResult();
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
            public System.String InvocationId { get; set; }
            public System.String TaskId { get; set; }
            public System.String WindowExecutionId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse, GetSSMMaintenanceWindowExecutionTaskInvocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
