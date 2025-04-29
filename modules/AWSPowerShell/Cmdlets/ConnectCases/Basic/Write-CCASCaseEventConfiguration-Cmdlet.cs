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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Adds case event publishing configuration. For a complete list of fields you can add
    /// to the event message, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/case-fields.html">Create
    /// case fields</a> in the <i>Amazon Connect Administrator Guide</i>
    /// </summary>
    [Cmdlet("Write", "CCASCaseEventConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Cases PutCaseEventConfiguration API operation.", Operation = new[] {"PutCaseEventConfiguration"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCCASCaseEventConfigurationCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter EventBridge_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the to broadcast case event data to the customer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? EventBridge_Enabled { get; set; }
        #endregion
        
        #region Parameter CaseData_Field
        /// <summary>
        /// <para>
        /// <para>List of field identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventBridge_IncludedData_CaseData_Fields")]
        public Amazon.ConnectCases.Model.FieldIdentifier[] CaseData_Field { get; set; }
        #endregion
        
        #region Parameter RelatedItemData_IncludeContent
        /// <summary>
        /// <para>
        /// <para>Details of what related item data is published through the case event stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventBridge_IncludedData_RelatedItemData_IncludeContent")]
        public System.Boolean? RelatedItemData_IncludeContent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CCASCaseEventConfiguration (PutCaseEventConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse, WriteCCASCaseEventConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventBridge_Enabled = this.EventBridge_Enabled;
            #if MODULAR
            if (this.EventBridge_Enabled == null && ParameterWasBound(nameof(this.EventBridge_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter EventBridge_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CaseData_Field != null)
            {
                context.CaseData_Field = new List<Amazon.ConnectCases.Model.FieldIdentifier>(this.CaseData_Field);
            }
            context.RelatedItemData_IncludeContent = this.RelatedItemData_IncludeContent;
            
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
            var request = new Amazon.ConnectCases.Model.PutCaseEventConfigurationRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate EventBridge
            var requestEventBridgeIsNull = true;
            request.EventBridge = new Amazon.ConnectCases.Model.EventBridgeConfiguration();
            System.Boolean? requestEventBridge_eventBridge_Enabled = null;
            if (cmdletContext.EventBridge_Enabled != null)
            {
                requestEventBridge_eventBridge_Enabled = cmdletContext.EventBridge_Enabled.Value;
            }
            if (requestEventBridge_eventBridge_Enabled != null)
            {
                request.EventBridge.Enabled = requestEventBridge_eventBridge_Enabled.Value;
                requestEventBridgeIsNull = false;
            }
            Amazon.ConnectCases.Model.EventIncludedData requestEventBridge_eventBridge_IncludedData = null;
            
             // populate IncludedData
            var requestEventBridge_eventBridge_IncludedDataIsNull = true;
            requestEventBridge_eventBridge_IncludedData = new Amazon.ConnectCases.Model.EventIncludedData();
            Amazon.ConnectCases.Model.CaseEventIncludedData requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData = null;
            
             // populate CaseData
            var requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseDataIsNull = true;
            requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData = new Amazon.ConnectCases.Model.CaseEventIncludedData();
            List<Amazon.ConnectCases.Model.FieldIdentifier> requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData_caseData_Field = null;
            if (cmdletContext.CaseData_Field != null)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData_caseData_Field = cmdletContext.CaseData_Field;
            }
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData_caseData_Field != null)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData.Fields = requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData_caseData_Field;
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseDataIsNull = false;
            }
             // determine if requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData should be set to null
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseDataIsNull)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData = null;
            }
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData != null)
            {
                requestEventBridge_eventBridge_IncludedData.CaseData = requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_CaseData;
                requestEventBridge_eventBridge_IncludedDataIsNull = false;
            }
            Amazon.ConnectCases.Model.RelatedItemEventIncludedData requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData = null;
            
             // populate RelatedItemData
            var requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemDataIsNull = true;
            requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData = new Amazon.ConnectCases.Model.RelatedItemEventIncludedData();
            System.Boolean? requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData_relatedItemData_IncludeContent = null;
            if (cmdletContext.RelatedItemData_IncludeContent != null)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData_relatedItemData_IncludeContent = cmdletContext.RelatedItemData_IncludeContent.Value;
            }
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData_relatedItemData_IncludeContent != null)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData.IncludeContent = requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData_relatedItemData_IncludeContent.Value;
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemDataIsNull = false;
            }
             // determine if requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData should be set to null
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemDataIsNull)
            {
                requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData = null;
            }
            if (requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData != null)
            {
                requestEventBridge_eventBridge_IncludedData.RelatedItemData = requestEventBridge_eventBridge_IncludedData_eventBridge_IncludedData_RelatedItemData;
                requestEventBridge_eventBridge_IncludedDataIsNull = false;
            }
             // determine if requestEventBridge_eventBridge_IncludedData should be set to null
            if (requestEventBridge_eventBridge_IncludedDataIsNull)
            {
                requestEventBridge_eventBridge_IncludedData = null;
            }
            if (requestEventBridge_eventBridge_IncludedData != null)
            {
                request.EventBridge.IncludedData = requestEventBridge_eventBridge_IncludedData;
                requestEventBridgeIsNull = false;
            }
             // determine if request.EventBridge should be set to null
            if (requestEventBridgeIsNull)
            {
                request.EventBridge = null;
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
        
        private Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.PutCaseEventConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "PutCaseEventConfiguration");
            try
            {
                return client.PutCaseEventConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.Boolean? EventBridge_Enabled { get; set; }
            public List<Amazon.ConnectCases.Model.FieldIdentifier> CaseData_Field { get; set; }
            public System.Boolean? RelatedItemData_IncludeContent { get; set; }
            public System.Func<Amazon.ConnectCases.Model.PutCaseEventConfigurationResponse, WriteCCASCaseEventConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
