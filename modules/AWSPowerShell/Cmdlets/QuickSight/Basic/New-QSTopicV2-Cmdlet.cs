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
    [Cmdlet("New", "QSTopicV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateTopicV2Response")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateTopicV2 API operation.", Operation = new[] {"CreateTopicV2"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateTopicV2Response))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateTopicV2Response",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateTopicV2Response object containing multiple properties."
    )]
    public partial class NewQSTopicV2Cmdlet : AmazonQuickSightClientCmdlet, IExecutor
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
        
        #region Parameter CustomInstructions_CustomInstructionsString
        /// <summary>
        /// <para>
        /// <para>A text field for providing additional guidance or context for response generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomInstructions_CustomInstructionsString { get; set; }
        #endregion
        
        #region Parameter Topic_DataSetRelation
        /// <summary>
        /// <para>
        /// <para>The relations between the data sets that the topic is associated with.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Topic_DataSetRelations")]
        public Amazon.QuickSight.Model.TopicV2DataSetRelation[] Topic_DataSetRelation { get; set; }
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
        public Amazon.QuickSight.Model.TopicV2DataSetReference[] Topic_DataSet { get; set; }
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
        /// <para>The Amazon Resource Names (ARNs) of the folders that you want the topic to reside
        /// in.</para><para />
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Topic_Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags that are assigned
        /// to the topic.</para><para />
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TopicId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateTopicV2Response).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateTopicV2Response will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AwsAccountId),
                nameof(this.TopicId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSTopicV2 (CreateTopicV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateTopicV2Response, NewQSTopicV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomInstructions_CustomInstructionsString = this.CustomInstructions_CustomInstructionsString;
            if (this.FolderArn != null)
            {
                context.FolderArn = new List<System.String>(this.FolderArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            if (this.Topic_DataSetRelation != null)
            {
                context.Topic_DataSetRelation = new List<Amazon.QuickSight.Model.TopicV2DataSetRelation>(this.Topic_DataSetRelation);
            }
            if (this.Topic_DataSet != null)
            {
                context.Topic_DataSet = new List<Amazon.QuickSight.Model.TopicV2DataSetReference>(this.Topic_DataSet);
            }
            context.Topic_Description = this.Topic_Description;
            context.Topic_Name = this.Topic_Name;
            #if MODULAR
            if (this.Topic_Name == null && ParameterWasBound(nameof(this.Topic_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Topic_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.QuickSight.Model.CreateTopicV2Request();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate CustomInstructions
            var requestCustomInstructionsIsNull = true;
            request.CustomInstructions = new Amazon.QuickSight.Model.CustomInstructions();
            System.String requestCustomInstructions_customInstructions_CustomInstructionsString = null;
            if (cmdletContext.CustomInstructions_CustomInstructionsString != null)
            {
                requestCustomInstructions_customInstructions_CustomInstructionsString = cmdletContext.CustomInstructions_CustomInstructionsString;
            }
            if (requestCustomInstructions_customInstructions_CustomInstructionsString != null)
            {
                request.CustomInstructions.CustomInstructionsString = requestCustomInstructions_customInstructions_CustomInstructionsString;
                requestCustomInstructionsIsNull = false;
            }
             // determine if request.CustomInstructions should be set to null
            if (requestCustomInstructionsIsNull)
            {
                request.CustomInstructions = null;
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
            request.Topic = new Amazon.QuickSight.Model.TopicV2Details();
            List<Amazon.QuickSight.Model.TopicV2DataSetRelation> requestTopic_topic_DataSetRelation = null;
            if (cmdletContext.Topic_DataSetRelation != null)
            {
                requestTopic_topic_DataSetRelation = cmdletContext.Topic_DataSetRelation;
            }
            if (requestTopic_topic_DataSetRelation != null)
            {
                request.Topic.DataSetRelations = requestTopic_topic_DataSetRelation;
                requestTopicIsNull = false;
            }
            List<Amazon.QuickSight.Model.TopicV2DataSetReference> requestTopic_topic_DataSet = null;
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
        
        private Amazon.QuickSight.Model.CreateTopicV2Response CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateTopicV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateTopicV2");
            try
            {
                return client.CreateTopicV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomInstructions_CustomInstructionsString { get; set; }
            public List<System.String> FolderArn { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public List<Amazon.QuickSight.Model.TopicV2DataSetRelation> Topic_DataSetRelation { get; set; }
            public List<Amazon.QuickSight.Model.TopicV2DataSetReference> Topic_DataSet { get; set; }
            public System.String Topic_Description { get; set; }
            public System.String Topic_Name { get; set; }
            public System.String TopicId { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateTopicV2Response, NewQSTopicV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
