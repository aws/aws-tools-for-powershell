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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates the Amazon Q in Connect message template metadata. Note that any modification
    /// to the message template’s name, description and grouping configuration will applied
    /// to the message template pointed by the <c>$LATEST</c> qualifier and all available
    /// versions. Partial update is supported. If any field is not supplied, it will remain
    /// unchanged for the message template.
    /// </summary>
    [Cmdlet("Update", "QCMessageTemplateMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.MessageTemplateData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateMessageTemplateMetadata API operation.", Operation = new[] {"UpdateMessageTemplateMetadata"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.MessageTemplateData or Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse",
        "This cmdlet returns an Amazon.QConnect.Model.MessageTemplateData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCMessageTemplateMetadataCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupingConfiguration_Criterion
        /// <summary>
        /// <para>
        /// <para>The criteria used for grouping Amazon Q in Connect users.</para><para>The following is the list of supported criteria values.</para><ul><li><para><c>RoutingProfileArn</c>: Grouping the users by their <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profile ARN</a>. User should have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_SearchRoutingProfiles.html">SearchRoutingProfile</a>
        /// and <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeRoutingProfile.html">DescribeRoutingProfile</a>
        /// permissions when setting criteria to this value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Criteria")]
        public System.String GroupingConfiguration_Criterion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template. Can be either the ID or the ARN. It cannot
        /// contain any qualifier.</para>
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
        public System.String MessageTemplateId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter GroupingConfiguration_Value
        /// <summary>
        /// <para>
        /// <para>The list of values that define different groups of Amazon Q in Connect users.</para><ul><li><para>When setting <c>criteria</c> to <c>RoutingProfileArn</c>, you need to provide a list
        /// of ARNs of <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profiles</a> as values of this parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Values")]
        public System.String[] GroupingConfiguration_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MessageTemplateId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCMessageTemplateMetadata (UpdateMessageTemplateMetadata)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse, UpdateQCMessageTemplateMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MessageTemplateId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.GroupingConfiguration_Criterion = this.GroupingConfiguration_Criterion;
            if (this.GroupingConfiguration_Value != null)
            {
                context.GroupingConfiguration_Value = new List<System.String>(this.GroupingConfiguration_Value);
            }
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageTemplateId = this.MessageTemplateId;
            #if MODULAR
            if (this.MessageTemplateId == null && ParameterWasBound(nameof(this.MessageTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.QConnect.Model.UpdateMessageTemplateMetadataRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GroupingConfiguration
            var requestGroupingConfigurationIsNull = true;
            request.GroupingConfiguration = new Amazon.QConnect.Model.GroupingConfiguration();
            System.String requestGroupingConfiguration_groupingConfiguration_Criterion = null;
            if (cmdletContext.GroupingConfiguration_Criterion != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Criterion = cmdletContext.GroupingConfiguration_Criterion;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Criterion != null)
            {
                request.GroupingConfiguration.Criteria = requestGroupingConfiguration_groupingConfiguration_Criterion;
                requestGroupingConfigurationIsNull = false;
            }
            List<System.String> requestGroupingConfiguration_groupingConfiguration_Value = null;
            if (cmdletContext.GroupingConfiguration_Value != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Value = cmdletContext.GroupingConfiguration_Value;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Value != null)
            {
                request.GroupingConfiguration.Values = requestGroupingConfiguration_groupingConfiguration_Value;
                requestGroupingConfigurationIsNull = false;
            }
             // determine if request.GroupingConfiguration should be set to null
            if (requestGroupingConfigurationIsNull)
            {
                request.GroupingConfiguration = null;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.MessageTemplateId != null)
            {
                request.MessageTemplateId = cmdletContext.MessageTemplateId;
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
        
        private Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateMessageTemplateMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateMessageTemplateMetadata");
            try
            {
                #if DESKTOP
                return client.UpdateMessageTemplateMetadata(request);
                #elif CORECLR
                return client.UpdateMessageTemplateMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String GroupingConfiguration_Criterion { get; set; }
            public List<System.String> GroupingConfiguration_Value { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String MessageTemplateId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateMessageTemplateMetadataResponse, UpdateQCMessageTemplateMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageTemplate;
        }
        
    }
}
