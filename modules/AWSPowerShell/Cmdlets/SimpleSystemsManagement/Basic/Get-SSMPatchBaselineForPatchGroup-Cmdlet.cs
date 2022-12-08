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
    /// Retrieves the patch baseline that should be used for the specified patch group.
    /// </summary>
    [Cmdlet("Get", "SSMPatchBaselineForPatchGroup")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetPatchBaselineForPatchGroup API operation.", Operation = new[] {"GetPatchBaselineForPatchGroup"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSSMPatchBaselineForPatchGroupCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter OperatingSystem
        /// <summary>
        /// <para>
        /// <para>Returns the operating system rule specified for patch groups using the patch baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.OperatingSystem")]
        public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
        #endregion
        
        #region Parameter PatchGroup
        /// <summary>
        /// <para>
        /// <para>The name of the patch group whose patch baseline should be retrieved.</para>
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
        public System.String PatchGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse, GetSSMPatchBaselineForPatchGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OperatingSystem = this.OperatingSystem;
            context.PatchGroup = this.PatchGroup;
            #if MODULAR
            if (this.PatchGroup == null && ParameterWasBound(nameof(this.PatchGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter PatchGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupRequest();
            
            if (cmdletContext.OperatingSystem != null)
            {
                request.OperatingSystem = cmdletContext.OperatingSystem;
            }
            if (cmdletContext.PatchGroup != null)
            {
                request.PatchGroup = cmdletContext.PatchGroup;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetPatchBaselineForPatchGroup");
            try
            {
                #if DESKTOP
                return client.GetPatchBaselineForPatchGroup(request);
                #elif CORECLR
                return client.GetPatchBaselineForPatchGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
            public System.String PatchGroup { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetPatchBaselineForPatchGroupResponse, GetSSMPatchBaselineForPatchGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
