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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Retrieves the status of your service-linked role deletion. After you use <a>DeleteServiceLinkedRole</a>
    /// to submit a service-linked role for deletion, you can use the <c>DeletionTaskId</c>
    /// parameter in <c>GetServiceLinkedRoleDeletionStatus</c> to check the status of the
    /// deletion. If the deletion fails, this operation returns the reason that it failed,
    /// if that information is returned by the service.
    /// </summary>
    [Cmdlet("Get", "IAMServiceLinkedRoleDeletionStatus")]
    [OutputType("Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetServiceLinkedRoleDeletionStatus API operation.", Operation = new[] {"GetServiceLinkedRoleDeletionStatus"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIAMServiceLinkedRoleDeletionStatusCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionTaskId
        /// <summary>
        /// <para>
        /// <para>The deletion task identifier. This identifier is returned by the <a>DeleteServiceLinkedRole</a>
        /// operation in the format <c>task/aws-service-role/&lt;service-principal-name&gt;/&lt;role-name&gt;/&lt;task-uuid&gt;</c>.</para>
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
        public System.String DeletionTaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse, GetIAMServiceLinkedRoleDeletionStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionTaskId = this.DeletionTaskId;
            #if MODULAR
            if (this.DeletionTaskId == null && ParameterWasBound(nameof(this.DeletionTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeletionTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusRequest();
            
            if (cmdletContext.DeletionTaskId != null)
            {
                request.DeletionTaskId = cmdletContext.DeletionTaskId;
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
        
        private Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetServiceLinkedRoleDeletionStatus");
            try
            {
                #if DESKTOP
                return client.GetServiceLinkedRoleDeletionStatus(request);
                #elif CORECLR
                return client.GetServiceLinkedRoleDeletionStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String DeletionTaskId { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse, GetIAMServiceLinkedRoleDeletionStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
