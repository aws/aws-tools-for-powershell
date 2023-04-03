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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Notifies the result of the provisioning engine execution.
    /// </summary>
    [Cmdlet("Start", "SCProvisionProductEngineWorkflowResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Catalog NotifyProvisionProductEngineWorkflowResult API operation.", Operation = new[] {"NotifyProvisionProductEngineWorkflowResult"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSCProvisionProductEngineWorkflowResultCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter FailureReason
        /// <summary>
        /// <para>
        /// <para> The reason why the provisioning engine execution failed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FailureReason { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para> The idempotency token that identifies the provisioning engine execution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter UniqueTag_Key
        /// <summary>
        /// <para>
        /// <para> A unique key that's attached to a resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_UniqueTag_Key")]
        public System.String UniqueTag_Key { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para> The output of the provisioning engine execution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.ServiceCatalog.Model.RecordOutput[] Output { get; set; }
        #endregion
        
        #region Parameter RecordId
        /// <summary>
        /// <para>
        /// <para> The identifier of the record. </para>
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
        public System.String RecordId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para> The status of the provisioning engine execution. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.EngineWorkflowStatus")]
        public Amazon.ServiceCatalog.EngineWorkflowStatus Status { get; set; }
        #endregion
        
        #region Parameter UniqueTag_Value
        /// <summary>
        /// <para>
        /// <para> A unique value that's attached to a resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_UniqueTag_Value")]
        public System.String UniqueTag_Value { get; set; }
        #endregion
        
        #region Parameter WorkflowToken
        /// <summary>
        /// <para>
        /// <para> The encrypted contents of the provisioning engine execution payload that Service
        /// Catalog sends after the Terraform product provisioning workflow starts. </para>
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
        public System.String WorkflowToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecordId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SCProvisionProductEngineWorkflowResult (NotifyProvisionProductEngineWorkflowResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse, StartSCProvisionProductEngineWorkflowResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FailureReason = this.FailureReason;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.Output != null)
            {
                context.Output = new List<Amazon.ServiceCatalog.Model.RecordOutput>(this.Output);
            }
            context.RecordId = this.RecordId;
            #if MODULAR
            if (this.RecordId == null && ParameterWasBound(nameof(this.RecordId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UniqueTag_Key = this.UniqueTag_Key;
            context.UniqueTag_Value = this.UniqueTag_Value;
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowToken = this.WorkflowToken;
            #if MODULAR
            if (this.WorkflowToken == null && ParameterWasBound(nameof(this.WorkflowToken)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultRequest();
            
            if (cmdletContext.FailureReason != null)
            {
                request.FailureReason = cmdletContext.FailureReason;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.RecordId != null)
            {
                request.RecordId = cmdletContext.RecordId;
            }
            
             // populate ResourceIdentifier
            var requestResourceIdentifierIsNull = true;
            request.ResourceIdentifier = new Amazon.ServiceCatalog.Model.EngineWorkflowResourceIdentifier();
            Amazon.ServiceCatalog.Model.UniqueTagResourceIdentifier requestResourceIdentifier_resourceIdentifier_UniqueTag = null;
            
             // populate UniqueTag
            var requestResourceIdentifier_resourceIdentifier_UniqueTagIsNull = true;
            requestResourceIdentifier_resourceIdentifier_UniqueTag = new Amazon.ServiceCatalog.Model.UniqueTagResourceIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Key = null;
            if (cmdletContext.UniqueTag_Key != null)
            {
                requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Key = cmdletContext.UniqueTag_Key;
            }
            if (requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Key != null)
            {
                requestResourceIdentifier_resourceIdentifier_UniqueTag.Key = requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Key;
                requestResourceIdentifier_resourceIdentifier_UniqueTagIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Value = null;
            if (cmdletContext.UniqueTag_Value != null)
            {
                requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Value = cmdletContext.UniqueTag_Value;
            }
            if (requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Value != null)
            {
                requestResourceIdentifier_resourceIdentifier_UniqueTag.Value = requestResourceIdentifier_resourceIdentifier_UniqueTag_uniqueTag_Value;
                requestResourceIdentifier_resourceIdentifier_UniqueTagIsNull = false;
            }
             // determine if requestResourceIdentifier_resourceIdentifier_UniqueTag should be set to null
            if (requestResourceIdentifier_resourceIdentifier_UniqueTagIsNull)
            {
                requestResourceIdentifier_resourceIdentifier_UniqueTag = null;
            }
            if (requestResourceIdentifier_resourceIdentifier_UniqueTag != null)
            {
                request.ResourceIdentifier.UniqueTag = requestResourceIdentifier_resourceIdentifier_UniqueTag;
                requestResourceIdentifierIsNull = false;
            }
             // determine if request.ResourceIdentifier should be set to null
            if (requestResourceIdentifierIsNull)
            {
                request.ResourceIdentifier = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.WorkflowToken != null)
            {
                request.WorkflowToken = cmdletContext.WorkflowToken;
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
        
        private Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "NotifyProvisionProductEngineWorkflowResult");
            try
            {
                #if DESKTOP
                return client.NotifyProvisionProductEngineWorkflowResult(request);
                #elif CORECLR
                return client.NotifyProvisionProductEngineWorkflowResultAsync(request).GetAwaiter().GetResult();
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
            public System.String FailureReason { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<Amazon.ServiceCatalog.Model.RecordOutput> Output { get; set; }
            public System.String RecordId { get; set; }
            public System.String UniqueTag_Key { get; set; }
            public System.String UniqueTag_Value { get; set; }
            public Amazon.ServiceCatalog.EngineWorkflowStatus Status { get; set; }
            public System.String WorkflowToken { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.NotifyProvisionProductEngineWorkflowResultResponse, StartSCProvisionProductEngineWorkflowResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
