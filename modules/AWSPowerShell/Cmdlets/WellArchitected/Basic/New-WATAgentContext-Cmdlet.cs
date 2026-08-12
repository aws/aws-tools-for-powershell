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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Creates a context associated with an optimization profile. Contexts provide application
    /// and environment information used during recommendation generation.
    /// </summary>
    [Cmdlet("New", "WATAgentContext", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.ContextSummary")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool CreateAgentContext API operation.", Operation = new[] {"CreateAgentContext"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.CreateAgentContextResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.ContextSummary or Amazon.WellArchitected.Model.CreateAgentContextResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.ContextSummary object.",
        "The service call response (type Amazon.WellArchitected.Model.CreateAgentContextResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWATAgentContextCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Content_AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs associated with this application context.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_AccountIds")]
        public System.String[] Content_AccountId { get; set; }
        #endregion
        
        #region Parameter Content_AdditionalContext
        /// <summary>
        /// <para>
        /// <para>Additional context not captured by other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_AdditionalContext { get; set; }
        #endregion
        
        #region Parameter Content_ApplicationOverview
        /// <summary>
        /// <para>
        /// <para>A free-form overview of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_ApplicationOverview { get; set; }
        #endregion
        
        #region Parameter Content_ApplicationType
        /// <summary>
        /// <para>
        /// <para>The type of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.ApplicationType")]
        public Amazon.WellArchitected.ApplicationType Content_ApplicationType { get; set; }
        #endregion
        
        #region Parameter Content_ArchitectureOverview
        /// <summary>
        /// <para>
        /// <para>A free-form description of the application architecture.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_ArchitectureOverview { get; set; }
        #endregion
        
        #region Parameter Content_AwsService
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services services used by this application.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_AwsServices")]
        public System.String[] Content_AwsService { get; set; }
        #endregion
        
        #region Parameter ContextType
        /// <summary>
        /// <para>
        /// <para>The type of the context.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WellArchitected.ContextType")]
        public Amazon.WellArchitected.ContextType ContextType { get; set; }
        #endregion
        
        #region Parameter Content_Criticality
        /// <summary>
        /// <para>
        /// <para>The business criticality of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.Criticality")]
        public Amazon.WellArchitected.Criticality Content_Criticality { get; set; }
        #endregion
        
        #region Parameter Content_Industry
        /// <summary>
        /// <para>
        /// <para>The industry vertical for this application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Industry { get; set; }
        #endregion
        
        #region Parameter ProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the profile to associate the context with.</para>
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
        public System.String ProfileArn { get; set; }
        #endregion
        
        #region Parameter Content_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Regions where this application operates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Regions")]
        public System.String[] Content_Region { get; set; }
        #endregion
        
        #region Parameter Content_ResourceTag
        /// <summary>
        /// <para>
        /// <para>Resource tags used to scope this application context.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_ResourceTags")]
        public Amazon.WellArchitected.Model.ContextResourceTag[] Content_ResourceTag { get; set; }
        #endregion
        
        #region Parameter Content_ResourceType
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services resource types relevant to this application.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_ResourceTypes")]
        public System.String[] Content_ResourceType { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the context.</para>
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
        public System.String Title { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Context'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.CreateAgentContextResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.CreateAgentContextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Context";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WATAgentContext (CreateAgentContext)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.CreateAgentContextResponse, NewWATAgentContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Content_AccountId != null)
            {
                context.Content_AccountId = new List<System.String>(this.Content_AccountId);
            }
            context.Content_AdditionalContext = this.Content_AdditionalContext;
            context.Content_ApplicationOverview = this.Content_ApplicationOverview;
            context.Content_ApplicationType = this.Content_ApplicationType;
            context.Content_ArchitectureOverview = this.Content_ArchitectureOverview;
            if (this.Content_AwsService != null)
            {
                context.Content_AwsService = new List<System.String>(this.Content_AwsService);
            }
            context.Content_Criticality = this.Content_Criticality;
            context.Content_Industry = this.Content_Industry;
            if (this.Content_Region != null)
            {
                context.Content_Region = new List<System.String>(this.Content_Region);
            }
            if (this.Content_ResourceTag != null)
            {
                context.Content_ResourceTag = new List<Amazon.WellArchitected.Model.ContextResourceTag>(this.Content_ResourceTag);
            }
            if (this.Content_ResourceType != null)
            {
                context.Content_ResourceType = new List<System.String>(this.Content_ResourceType);
            }
            context.ContextType = this.ContextType;
            #if MODULAR
            if (this.ContextType == null && ParameterWasBound(nameof(this.ContextType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfileArn = this.ProfileArn;
            #if MODULAR
            if (this.ProfileArn == null && ParameterWasBound(nameof(this.ProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.CreateAgentContextRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.WellArchitected.Model.ContextContent();
            List<System.String> requestContent_content_AccountId = null;
            if (cmdletContext.Content_AccountId != null)
            {
                requestContent_content_AccountId = cmdletContext.Content_AccountId;
            }
            if (requestContent_content_AccountId != null)
            {
                request.Content.AccountIds = requestContent_content_AccountId;
                requestContentIsNull = false;
            }
            System.String requestContent_content_AdditionalContext = null;
            if (cmdletContext.Content_AdditionalContext != null)
            {
                requestContent_content_AdditionalContext = cmdletContext.Content_AdditionalContext;
            }
            if (requestContent_content_AdditionalContext != null)
            {
                request.Content.AdditionalContext = requestContent_content_AdditionalContext;
                requestContentIsNull = false;
            }
            System.String requestContent_content_ApplicationOverview = null;
            if (cmdletContext.Content_ApplicationOverview != null)
            {
                requestContent_content_ApplicationOverview = cmdletContext.Content_ApplicationOverview;
            }
            if (requestContent_content_ApplicationOverview != null)
            {
                request.Content.ApplicationOverview = requestContent_content_ApplicationOverview;
                requestContentIsNull = false;
            }
            Amazon.WellArchitected.ApplicationType requestContent_content_ApplicationType = null;
            if (cmdletContext.Content_ApplicationType != null)
            {
                requestContent_content_ApplicationType = cmdletContext.Content_ApplicationType;
            }
            if (requestContent_content_ApplicationType != null)
            {
                request.Content.ApplicationType = requestContent_content_ApplicationType;
                requestContentIsNull = false;
            }
            System.String requestContent_content_ArchitectureOverview = null;
            if (cmdletContext.Content_ArchitectureOverview != null)
            {
                requestContent_content_ArchitectureOverview = cmdletContext.Content_ArchitectureOverview;
            }
            if (requestContent_content_ArchitectureOverview != null)
            {
                request.Content.ArchitectureOverview = requestContent_content_ArchitectureOverview;
                requestContentIsNull = false;
            }
            List<System.String> requestContent_content_AwsService = null;
            if (cmdletContext.Content_AwsService != null)
            {
                requestContent_content_AwsService = cmdletContext.Content_AwsService;
            }
            if (requestContent_content_AwsService != null)
            {
                request.Content.AwsServices = requestContent_content_AwsService;
                requestContentIsNull = false;
            }
            Amazon.WellArchitected.Criticality requestContent_content_Criticality = null;
            if (cmdletContext.Content_Criticality != null)
            {
                requestContent_content_Criticality = cmdletContext.Content_Criticality;
            }
            if (requestContent_content_Criticality != null)
            {
                request.Content.Criticality = requestContent_content_Criticality;
                requestContentIsNull = false;
            }
            System.String requestContent_content_Industry = null;
            if (cmdletContext.Content_Industry != null)
            {
                requestContent_content_Industry = cmdletContext.Content_Industry;
            }
            if (requestContent_content_Industry != null)
            {
                request.Content.Industry = requestContent_content_Industry;
                requestContentIsNull = false;
            }
            List<System.String> requestContent_content_Region = null;
            if (cmdletContext.Content_Region != null)
            {
                requestContent_content_Region = cmdletContext.Content_Region;
            }
            if (requestContent_content_Region != null)
            {
                request.Content.Regions = requestContent_content_Region;
                requestContentIsNull = false;
            }
            List<Amazon.WellArchitected.Model.ContextResourceTag> requestContent_content_ResourceTag = null;
            if (cmdletContext.Content_ResourceTag != null)
            {
                requestContent_content_ResourceTag = cmdletContext.Content_ResourceTag;
            }
            if (requestContent_content_ResourceTag != null)
            {
                request.Content.ResourceTags = requestContent_content_ResourceTag;
                requestContentIsNull = false;
            }
            List<System.String> requestContent_content_ResourceType = null;
            if (cmdletContext.Content_ResourceType != null)
            {
                requestContent_content_ResourceType = cmdletContext.Content_ResourceType;
            }
            if (requestContent_content_ResourceType != null)
            {
                request.Content.ResourceTypes = requestContent_content_ResourceType;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.ContextType != null)
            {
                request.ContextType = cmdletContext.ContextType;
            }
            if (cmdletContext.ProfileArn != null)
            {
                request.ProfileArn = cmdletContext.ProfileArn;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.WellArchitected.Model.CreateAgentContextResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.CreateAgentContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "CreateAgentContext");
            try
            {
                return client.CreateAgentContextAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Content_AccountId { get; set; }
            public System.String Content_AdditionalContext { get; set; }
            public System.String Content_ApplicationOverview { get; set; }
            public Amazon.WellArchitected.ApplicationType Content_ApplicationType { get; set; }
            public System.String Content_ArchitectureOverview { get; set; }
            public List<System.String> Content_AwsService { get; set; }
            public Amazon.WellArchitected.Criticality Content_Criticality { get; set; }
            public System.String Content_Industry { get; set; }
            public List<System.String> Content_Region { get; set; }
            public List<Amazon.WellArchitected.Model.ContextResourceTag> Content_ResourceTag { get; set; }
            public List<System.String> Content_ResourceType { get; set; }
            public Amazon.WellArchitected.ContextType ContextType { get; set; }
            public System.String ProfileArn { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.WellArchitected.Model.CreateAgentContextResponse, NewWATAgentContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Context;
        }
        
    }
}
