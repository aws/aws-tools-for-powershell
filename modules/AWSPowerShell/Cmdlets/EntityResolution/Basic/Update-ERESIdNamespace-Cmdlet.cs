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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Updates an existing ID namespace.
    /// </summary>
    [Cmdlet("Update", "ERESIdNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.UpdateIdNamespaceResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution UpdateIdNamespace API operation.", Operation = new[] {"UpdateIdNamespace"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.UpdateIdNamespaceResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.UpdateIdNamespaceResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.UpdateIdNamespaceResponse object containing multiple properties."
    )]
    public partial class UpdateERESIdNamespaceCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the ID namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdMappingWorkflowProperty
        /// <summary>
        /// <para>
        /// <para>Determines the properties of <c>IdMappingWorkflow</c> where this <c>IdNamespace</c>
        /// can be used as a <c>Source</c> or a <c>Target</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdMappingWorkflowProperties")]
        public Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties[] IdMappingWorkflowProperty { get; set; }
        #endregion
        
        #region Parameter IdNamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the ID namespace.</para>
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
        public System.String IdNamespaceName { get; set; }
        #endregion
        
        #region Parameter InputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>InputSource</c> objects, which have the fields <c>InputSourceARN</c>
        /// and <c>SchemaName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EntityResolution.Model.IdNamespaceInputSource[] InputSourceConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. Entity Resolution assumes this role
        /// to access the resources defined in this <c>IdNamespace</c> on your behalf as part
        /// of a workflow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.UpdateIdNamespaceResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.UpdateIdNamespaceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdNamespaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ERESIdNamespace (UpdateIdNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.UpdateIdNamespaceResponse, UpdateERESIdNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.IdMappingWorkflowProperty != null)
            {
                context.IdMappingWorkflowProperty = new List<Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties>(this.IdMappingWorkflowProperty);
            }
            context.IdNamespaceName = this.IdNamespaceName;
            #if MODULAR
            if (this.IdNamespaceName == null && ParameterWasBound(nameof(this.IdNamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdNamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputSourceConfig != null)
            {
                context.InputSourceConfig = new List<Amazon.EntityResolution.Model.IdNamespaceInputSource>(this.InputSourceConfig);
            }
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
            var request = new Amazon.EntityResolution.Model.UpdateIdNamespaceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IdMappingWorkflowProperty != null)
            {
                request.IdMappingWorkflowProperties = cmdletContext.IdMappingWorkflowProperty;
            }
            if (cmdletContext.IdNamespaceName != null)
            {
                request.IdNamespaceName = cmdletContext.IdNamespaceName;
            }
            if (cmdletContext.InputSourceConfig != null)
            {
                request.InputSourceConfig = cmdletContext.InputSourceConfig;
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
        
        private Amazon.EntityResolution.Model.UpdateIdNamespaceResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.UpdateIdNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "UpdateIdNamespace");
            try
            {
                return client.UpdateIdNamespaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties> IdMappingWorkflowProperty { get; set; }
            public System.String IdNamespaceName { get; set; }
            public List<Amazon.EntityResolution.Model.IdNamespaceInputSource> InputSourceConfig { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.EntityResolution.Model.UpdateIdNamespaceResponse, UpdateERESIdNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
