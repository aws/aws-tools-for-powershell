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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Starts the specified WorkSpaces.
    /// 
    ///  
    /// <para>
    /// You cannot start a WorkSpace unless it has a running mode of <c>AutoStop</c> or <c>Manual</c>
    /// and a state of <c>STOPPED</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "WKSWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="IdFromRequestObject")]
    [OutputType("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest")]
    [AWSCmdlet("Calls the Amazon WorkSpaces StartWorkspaces API operation.", Operation = new[] {"StartWorkspaces"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.StartWorkspacesResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest or Amazon.WorkSpaces.Model.StartWorkspacesResponse",
        "This cmdlet returns a collection of Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest objects.",
        "The service call response (type Amazon.WorkSpaces.Model.StartWorkspacesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartWKSWorkspaceCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Request
        /// <summary>
        /// <para>
        /// <para>The WorkSpaces to start. You can specify up to 25 WorkSpaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true, ParameterSetName = "IdFromRequestObject")]
        [Alias("StartWorkspaceRequest","StartWorkspaceRequests")]
        public Amazon.WorkSpaces.Model.StartRequest[] Request { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedRequests'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.StartWorkspacesResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.StartWorkspacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedRequests";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Request parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Request' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Request' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-WKSWorkspace (StartWorkspaces)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.StartWorkspacesResponse, StartWKSWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Request;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Request != null)
            {
                context.Request = new List<Amazon.WorkSpaces.Model.StartRequest>(this.Request);
            }
            #if MODULAR
            if (this.Request == null && ParameterWasBound(nameof(this.Request)))
            {
                WriteWarning("You are passing $null as a value for parameter Request which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.StartWorkspacesRequest();
            
            if (cmdletContext.Request != null)
            {
                request.StartWorkspaceRequests = cmdletContext.Request;
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
        
        private Amazon.WorkSpaces.Model.StartWorkspacesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.StartWorkspacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "StartWorkspaces");
            try
            {
                #if DESKTOP
                return client.StartWorkspaces(request);
                #elif CORECLR
                return client.StartWorkspacesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.WorkSpaces.Model.StartRequest> Request { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.StartWorkspacesResponse, StartWKSWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedRequests;
        }
        
    }
}
