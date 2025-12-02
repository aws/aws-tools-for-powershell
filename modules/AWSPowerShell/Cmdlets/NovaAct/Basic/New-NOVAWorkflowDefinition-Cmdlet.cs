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
using Amazon.NovaAct;
using Amazon.NovaAct.Model;

namespace Amazon.PowerShell.Cmdlets.NOVA
{
    /// <summary>
    /// Creates a new workflow definition template that can be used to execute multiple workflow
    /// runs.
    /// </summary>
    [Cmdlet("New", "NOVAWorkflowDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NovaAct.WorkflowDefinitionStatus")]
    [AWSCmdlet("Calls the Amazon Nova Act CreateWorkflowDefinition API operation.", Operation = new[] {"CreateWorkflowDefinition"}, SelectReturnType = typeof(Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse))]
    [AWSCmdletOutput("Amazon.NovaAct.WorkflowDefinitionStatus or Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse",
        "This cmdlet returns an Amazon.NovaAct.WorkflowDefinitionStatus object.",
        "The service call response (type Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewNOVAWorkflowDefinitionCmdlet : AmazonNovaActClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the workflow definition's purpose and functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the workflow definition. Must be unique within your account and region.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ExportConfig_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon S3 bucket, that Nova Act uses to export your workflow data.
        /// Note that the IAM role used to access Nova Act must also have write permissions to
        /// this bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportConfig_S3BucketName { get; set; }
        #endregion
        
        #region Parameter ExportConfig_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>An optional prefix for Amazon S3 object keys to organize exported data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportConfig_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse).
        /// Specifying the name of a property of type Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NOVAWorkflowDefinition (CreateWorkflowDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse, NewNOVAWorkflowDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ExportConfig_S3BucketName = this.ExportConfig_S3BucketName;
            context.ExportConfig_S3KeyPrefix = this.ExportConfig_S3KeyPrefix;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NovaAct.Model.CreateWorkflowDefinitionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ExportConfig
            var requestExportConfigIsNull = true;
            request.ExportConfig = new Amazon.NovaAct.Model.WorkflowExportConfig();
            System.String requestExportConfig_exportConfig_S3BucketName = null;
            if (cmdletContext.ExportConfig_S3BucketName != null)
            {
                requestExportConfig_exportConfig_S3BucketName = cmdletContext.ExportConfig_S3BucketName;
            }
            if (requestExportConfig_exportConfig_S3BucketName != null)
            {
                request.ExportConfig.S3BucketName = requestExportConfig_exportConfig_S3BucketName;
                requestExportConfigIsNull = false;
            }
            System.String requestExportConfig_exportConfig_S3KeyPrefix = null;
            if (cmdletContext.ExportConfig_S3KeyPrefix != null)
            {
                requestExportConfig_exportConfig_S3KeyPrefix = cmdletContext.ExportConfig_S3KeyPrefix;
            }
            if (requestExportConfig_exportConfig_S3KeyPrefix != null)
            {
                request.ExportConfig.S3KeyPrefix = requestExportConfig_exportConfig_S3KeyPrefix;
                requestExportConfigIsNull = false;
            }
             // determine if request.ExportConfig should be set to null
            if (requestExportConfigIsNull)
            {
                request.ExportConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse CallAWSServiceOperation(IAmazonNovaAct client, Amazon.NovaAct.Model.CreateWorkflowDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nova Act", "CreateWorkflowDefinition");
            try
            {
                #if DESKTOP
                return client.CreateWorkflowDefinition(request);
                #elif CORECLR
                return client.CreateWorkflowDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String ExportConfig_S3BucketName { get; set; }
            public System.String ExportConfig_S3KeyPrefix { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.NovaAct.Model.CreateWorkflowDefinitionResponse, NewNOVAWorkflowDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
