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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a new Q topic.
    /// </summary>
    [Cmdlet("New", "QSTopic", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateTopicResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateTopic API operation.", Operation = new[] {"CreateTopic"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateTopicResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateTopicResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateTopicResponse object containing multiple properties."
    )]
    public partial class NewQSTopicCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that you want to create a topic in.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Topic_DataSet
        /// <summary>
        /// <para>
        /// <para>The data sets that the topic is associated with.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Topic_DataSets")]
        public Amazon.QuickSight.Model.DatasetMetadata[] Topic_DataSet { get; set; }
        #endregion
        
        #region Parameter Topic_Description
        /// <summary>
        /// <para>
        /// <para>The description of the topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Topic_Description { get; set; }
        #endregion
        
        #region Parameter FolderArn
        /// <summary>
        /// <para>
        /// <para>The Folder ARN of the folder that you want the topic to reside in.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FolderArns")]
        public System.String[] FolderArn { get; set; }
        #endregion
        
        #region Parameter Topic_Name
        /// <summary>
        /// <para>
        /// <para>The name of the topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Topic_Name { get; set; }
        #endregion
        
        #region Parameter ConfigOptions_QBusinessInsightsEnabled
        /// <summary>
        /// <para>
        /// <para>Enables Amazon Q Business Insights for a <c>Topic</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Topic_ConfigOptions_QBusinessInsightsEnabled")]
        public System.Boolean? ConfigOptions_QBusinessInsightsEnabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags that are assigned
        /// to the dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TopicId
        /// <summary>
        /// <para>
        /// <para>The ID for the topic that you want to create. This ID is unique per Amazon Web Services
        /// Region for each Amazon Web Services account.</para>
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
        public System.String TopicId { get; set; }
        #endregion
        
        #region Parameter Topic_UserExperienceVersion
        /// <summary>
        /// <para>
        /// <para>The user experience version of a topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.TopicUserExperienceVersion")]
        public Amazon.QuickSight.TopicUserExperienceVersion Topic_UserExperienceVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateTopicResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateTopicResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSTopic (CreateTopic)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateTopicResponse, NewQSTopicCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FolderArn != null)
            {
                context.FolderArn = new List<System.String>(this.FolderArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.ConfigOptions_QBusinessInsightsEnabled = this.ConfigOptions_QBusinessInsightsEnabled;
            if (this.Topic_DataSet != null)
            {
                context.Topic_DataSet = new List<Amazon.QuickSight.Model.DatasetMetadata>(this.Topic_DataSet);
            }
            context.Topic_Description = this.Topic_Description;
            context.Topic_Name = this.Topic_Name;
            context.Topic_UserExperienceVersion = this.Topic_UserExperienceVersion;
            context.TopicId = this.TopicId;
            #if MODULAR
            if (this.TopicId == null && ParameterWasBound(nameof(this.TopicId)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.CreateTopicRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.FolderArn != null)
            {
                request.FolderArns = cmdletContext.FolderArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Topic
            var requestTopicIsNull = true;
            request.Topic = new Amazon.QuickSight.Model.TopicDetails();
            List<Amazon.QuickSight.Model.DatasetMetadata> requestTopic_topic_DataSet = null;
            if (cmdletContext.Topic_DataSet != null)
            {
                requestTopic_topic_DataSet = cmdletContext.Topic_DataSet;
            }
            if (requestTopic_topic_DataSet != null)
            {
                request.Topic.DataSets = requestTopic_topic_DataSet;
                requestTopicIsNull = false;
            }
            System.String requestTopic_topic_Description = null;
            if (cmdletContext.Topic_Description != null)
            {
                requestTopic_topic_Description = cmdletContext.Topic_Description;
            }
            if (requestTopic_topic_Description != null)
            {
                request.Topic.Description = requestTopic_topic_Description;
                requestTopicIsNull = false;
            }
            System.String requestTopic_topic_Name = null;
            if (cmdletContext.Topic_Name != null)
            {
                requestTopic_topic_Name = cmdletContext.Topic_Name;
            }
            if (requestTopic_topic_Name != null)
            {
                request.Topic.Name = requestTopic_topic_Name;
                requestTopicIsNull = false;
            }
            Amazon.QuickSight.TopicUserExperienceVersion requestTopic_topic_UserExperienceVersion = null;
            if (cmdletContext.Topic_UserExperienceVersion != null)
            {
                requestTopic_topic_UserExperienceVersion = cmdletContext.Topic_UserExperienceVersion;
            }
            if (requestTopic_topic_UserExperienceVersion != null)
            {
                request.Topic.UserExperienceVersion = requestTopic_topic_UserExperienceVersion;
                requestTopicIsNull = false;
            }
            Amazon.QuickSight.Model.TopicConfigOptions requestTopic_topic_ConfigOptions = null;
            
             // populate ConfigOptions
            var requestTopic_topic_ConfigOptionsIsNull = true;
            requestTopic_topic_ConfigOptions = new Amazon.QuickSight.Model.TopicConfigOptions();
            System.Boolean? requestTopic_topic_ConfigOptions_configOptions_QBusinessInsightsEnabled = null;
            if (cmdletContext.ConfigOptions_QBusinessInsightsEnabled != null)
            {
                requestTopic_topic_ConfigOptions_configOptions_QBusinessInsightsEnabled = cmdletContext.ConfigOptions_QBusinessInsightsEnabled.Value;
            }
            if (requestTopic_topic_ConfigOptions_configOptions_QBusinessInsightsEnabled != null)
            {
                requestTopic_topic_ConfigOptions.QBusinessInsightsEnabled = requestTopic_topic_ConfigOptions_configOptions_QBusinessInsightsEnabled.Value;
                requestTopic_topic_ConfigOptionsIsNull = false;
            }
             // determine if requestTopic_topic_ConfigOptions should be set to null
            if (requestTopic_topic_ConfigOptionsIsNull)
            {
                requestTopic_topic_ConfigOptions = null;
            }
            if (requestTopic_topic_ConfigOptions != null)
            {
                request.Topic.ConfigOptions = requestTopic_topic_ConfigOptions;
                requestTopicIsNull = false;
            }
             // determine if request.Topic should be set to null
            if (requestTopicIsNull)
            {
                request.Topic = null;
            }
            if (cmdletContext.TopicId != null)
            {
                request.TopicId = cmdletContext.TopicId;
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
        
        private Amazon.QuickSight.Model.CreateTopicResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateTopicRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateTopic");
            try
            {
                return client.CreateTopicAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public List<System.String> FolderArn { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.Boolean? ConfigOptions_QBusinessInsightsEnabled { get; set; }
            public List<Amazon.QuickSight.Model.DatasetMetadata> Topic_DataSet { get; set; }
            public System.String Topic_Description { get; set; }
            public System.String Topic_Name { get; set; }
            public Amazon.QuickSight.TopicUserExperienceVersion Topic_UserExperienceVersion { get; set; }
            public System.String TopicId { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateTopicResponse, NewQSTopicCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
