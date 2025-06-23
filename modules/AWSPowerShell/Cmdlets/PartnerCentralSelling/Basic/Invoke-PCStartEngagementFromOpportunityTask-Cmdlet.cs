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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// This action initiates the engagement process from an existing opportunity by accepting
    /// the engagement invitation and creating a corresponding opportunity in the partner’s
    /// system. Similar to <c>StartEngagementByAcceptingInvitationTask</c>, this action is
    /// asynchronous and performs multiple steps before completion.
    /// </summary>
    [Cmdlet("Invoke", "PCStartEngagementFromOpportunityTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Selling API StartEngagementFromOpportunityTask API operation.", Operation = new[] {"StartEngagementFromOpportunityTask"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse object containing multiple properties."
    )]
    public partial class InvokePCStartEngagementFromOpportunityTaskCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog in which the engagement is tracked. Acceptable values include
        /// <c>AWS</c> for production and <c>Sandbox</c> for testing environments.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the opportunity from which the engagement task is to be initiated.
        /// This helps ensure that the task is applied to the correct opportunity.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter AwsSubmission_InvolvementType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of AWS involvement in the opportunity, such as coselling, deal
        /// support, or technical consultation. This helps categorize the nature of AWS participation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.SalesInvolvementType")]
        public Amazon.PartnerCentralSelling.SalesInvolvementType AwsSubmission_InvolvementType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PartnerCentralSelling.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AwsSubmission_Visibility
        /// <summary>
        /// <para>
        /// <para>Determines who can view AWS involvement in the opportunity. Typically, this field
        /// is set to <c>Full</c> for most cases, but it may be restricted based on special program
        /// requirements or confidentiality needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralSelling.Visibility")]
        public Amazon.PartnerCentralSelling.Visibility AwsSubmission_Visibility { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token provided by the client to help ensure the idempotency of the request.
        /// It helps prevent the same task from being performed multiple times.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCStartEngagementFromOpportunityTask (StartEngagementFromOpportunityTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse, InvokePCStartEngagementFromOpportunityTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsSubmission_InvolvementType = this.AwsSubmission_InvolvementType;
            #if MODULAR
            if (this.AwsSubmission_InvolvementType == null && ParameterWasBound(nameof(this.AwsSubmission_InvolvementType)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsSubmission_InvolvementType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsSubmission_Visibility = this.AwsSubmission_Visibility;
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PartnerCentralSelling.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskRequest();
            
            
             // populate AwsSubmission
            var requestAwsSubmissionIsNull = true;
            request.AwsSubmission = new Amazon.PartnerCentralSelling.Model.AwsSubmission();
            Amazon.PartnerCentralSelling.SalesInvolvementType requestAwsSubmission_awsSubmission_InvolvementType = null;
            if (cmdletContext.AwsSubmission_InvolvementType != null)
            {
                requestAwsSubmission_awsSubmission_InvolvementType = cmdletContext.AwsSubmission_InvolvementType;
            }
            if (requestAwsSubmission_awsSubmission_InvolvementType != null)
            {
                request.AwsSubmission.InvolvementType = requestAwsSubmission_awsSubmission_InvolvementType;
                requestAwsSubmissionIsNull = false;
            }
            Amazon.PartnerCentralSelling.Visibility requestAwsSubmission_awsSubmission_Visibility = null;
            if (cmdletContext.AwsSubmission_Visibility != null)
            {
                requestAwsSubmission_awsSubmission_Visibility = cmdletContext.AwsSubmission_Visibility;
            }
            if (requestAwsSubmission_awsSubmission_Visibility != null)
            {
                request.AwsSubmission.Visibility = requestAwsSubmission_awsSubmission_Visibility;
                requestAwsSubmissionIsNull = false;
            }
             // determine if request.AwsSubmission should be set to null
            if (requestAwsSubmissionIsNull)
            {
                request.AwsSubmission = null;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "StartEngagementFromOpportunityTask");
            try
            {
                return client.StartEngagementFromOpportunityTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PartnerCentralSelling.SalesInvolvementType AwsSubmission_InvolvementType { get; set; }
            public Amazon.PartnerCentralSelling.Visibility AwsSubmission_Visibility { get; set; }
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public List<Amazon.PartnerCentralSelling.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.StartEngagementFromOpportunityTaskResponse, InvokePCStartEngagementFromOpportunityTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
