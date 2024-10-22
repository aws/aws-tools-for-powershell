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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Updates replication info of a replicator.
    /// </summary>
    [Cmdlet("Update", "MSKReplicationInfo", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateReplicationInfoResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateReplicationInfo API operation.", Operation = new[] {"UpdateReplicationInfo"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateReplicationInfoResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateReplicationInfoResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateReplicationInfoResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMSKReplicationInfoCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConsumerGroupReplication_ConsumerGroupsToExclude
        /// <summary>
        /// <para>
        /// <para>List of regular expression patterns indicating the consumer groups that should not
        /// be replicated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ConsumerGroupReplication_ConsumerGroupsToExclude { get; set; }
        #endregion
        
        #region Parameter ConsumerGroupReplication_ConsumerGroupsToReplicate
        /// <summary>
        /// <para>
        /// <para>List of regular expression patterns indicating the consumer groups to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ConsumerGroupReplication_ConsumerGroupsToReplicate { get; set; }
        #endregion
        
        #region Parameter TopicReplication_CopyAccessControlListsForTopic
        /// <summary>
        /// <para>
        /// <para>Whether to periodically configure remote topic ACLs to match their corresponding upstream
        /// topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicReplication_CopyAccessControlListsForTopics")]
        public System.Boolean? TopicReplication_CopyAccessControlListsForTopic { get; set; }
        #endregion
        
        #region Parameter TopicReplication_CopyTopicConfiguration
        /// <summary>
        /// <para>
        /// <para>Whether to periodically configure remote topics to match their corresponding upstream
        /// topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicReplication_CopyTopicConfigurations")]
        public System.Boolean? TopicReplication_CopyTopicConfiguration { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>Current replicator version.</para>
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
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter ConsumerGroupReplication_DetectAndCopyNewConsumerGroup
        /// <summary>
        /// <para>
        /// <para>Enables synchronization of consumer groups to target cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConsumerGroupReplication_DetectAndCopyNewConsumerGroups")]
        public System.Boolean? ConsumerGroupReplication_DetectAndCopyNewConsumerGroup { get; set; }
        #endregion
        
        #region Parameter TopicReplication_DetectAndCopyNewTopic
        /// <summary>
        /// <para>
        /// <para>Whether to periodically check for new topics and partitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicReplication_DetectAndCopyNewTopics")]
        public System.Boolean? TopicReplication_DetectAndCopyNewTopic { get; set; }
        #endregion
        
        #region Parameter ReplicatorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replicator to be updated.</para>
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
        public System.String ReplicatorArn { get; set; }
        #endregion
        
        #region Parameter SourceKafkaClusterArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the source Kafka cluster.</para>
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
        public System.String SourceKafkaClusterArn { get; set; }
        #endregion
        
        #region Parameter ConsumerGroupReplication_SynchroniseConsumerGroupOffset
        /// <summary>
        /// <para>
        /// <para>Enables synchronization of consumer group offsets to target cluster. The translated
        /// offsets will be written to topic __consumer_offsets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConsumerGroupReplication_SynchroniseConsumerGroupOffsets")]
        public System.Boolean? ConsumerGroupReplication_SynchroniseConsumerGroupOffset { get; set; }
        #endregion
        
        #region Parameter TargetKafkaClusterArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the target Kafka cluster.</para>
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
        public System.String TargetKafkaClusterArn { get; set; }
        #endregion
        
        #region Parameter TopicReplication_TopicsToExclude
        /// <summary>
        /// <para>
        /// <para>List of regular expression patterns indicating the topics that should not be replicated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TopicReplication_TopicsToExclude { get; set; }
        #endregion
        
        #region Parameter TopicReplication_TopicsToReplicate
        /// <summary>
        /// <para>
        /// <para>List of regular expression patterns indicating the topics to copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TopicReplication_TopicsToReplicate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateReplicationInfoResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateReplicationInfoResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicatorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKReplicationInfo (UpdateReplicationInfo)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateReplicationInfoResponse, UpdateMSKReplicationInfoCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConsumerGroupReplication_ConsumerGroupsToExclude != null)
            {
                context.ConsumerGroupReplication_ConsumerGroupsToExclude = new List<System.String>(this.ConsumerGroupReplication_ConsumerGroupsToExclude);
            }
            if (this.ConsumerGroupReplication_ConsumerGroupsToReplicate != null)
            {
                context.ConsumerGroupReplication_ConsumerGroupsToReplicate = new List<System.String>(this.ConsumerGroupReplication_ConsumerGroupsToReplicate);
            }
            context.ConsumerGroupReplication_DetectAndCopyNewConsumerGroup = this.ConsumerGroupReplication_DetectAndCopyNewConsumerGroup;
            context.ConsumerGroupReplication_SynchroniseConsumerGroupOffset = this.ConsumerGroupReplication_SynchroniseConsumerGroupOffset;
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicatorArn = this.ReplicatorArn;
            #if MODULAR
            if (this.ReplicatorArn == null && ParameterWasBound(nameof(this.ReplicatorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicatorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceKafkaClusterArn = this.SourceKafkaClusterArn;
            #if MODULAR
            if (this.SourceKafkaClusterArn == null && ParameterWasBound(nameof(this.SourceKafkaClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceKafkaClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetKafkaClusterArn = this.TargetKafkaClusterArn;
            #if MODULAR
            if (this.TargetKafkaClusterArn == null && ParameterWasBound(nameof(this.TargetKafkaClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetKafkaClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TopicReplication_CopyAccessControlListsForTopic = this.TopicReplication_CopyAccessControlListsForTopic;
            context.TopicReplication_CopyTopicConfiguration = this.TopicReplication_CopyTopicConfiguration;
            context.TopicReplication_DetectAndCopyNewTopic = this.TopicReplication_DetectAndCopyNewTopic;
            if (this.TopicReplication_TopicsToExclude != null)
            {
                context.TopicReplication_TopicsToExclude = new List<System.String>(this.TopicReplication_TopicsToExclude);
            }
            if (this.TopicReplication_TopicsToReplicate != null)
            {
                context.TopicReplication_TopicsToReplicate = new List<System.String>(this.TopicReplication_TopicsToReplicate);
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
            var request = new Amazon.Kafka.Model.UpdateReplicationInfoRequest();
            
            
             // populate ConsumerGroupReplication
            var requestConsumerGroupReplicationIsNull = true;
            request.ConsumerGroupReplication = new Amazon.Kafka.Model.ConsumerGroupReplicationUpdate();
            List<System.String> requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToExclude = null;
            if (cmdletContext.ConsumerGroupReplication_ConsumerGroupsToExclude != null)
            {
                requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToExclude = cmdletContext.ConsumerGroupReplication_ConsumerGroupsToExclude;
            }
            if (requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToExclude != null)
            {
                request.ConsumerGroupReplication.ConsumerGroupsToExclude = requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToExclude;
                requestConsumerGroupReplicationIsNull = false;
            }
            List<System.String> requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToReplicate = null;
            if (cmdletContext.ConsumerGroupReplication_ConsumerGroupsToReplicate != null)
            {
                requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToReplicate = cmdletContext.ConsumerGroupReplication_ConsumerGroupsToReplicate;
            }
            if (requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToReplicate != null)
            {
                request.ConsumerGroupReplication.ConsumerGroupsToReplicate = requestConsumerGroupReplication_consumerGroupReplication_ConsumerGroupsToReplicate;
                requestConsumerGroupReplicationIsNull = false;
            }
            System.Boolean? requestConsumerGroupReplication_consumerGroupReplication_DetectAndCopyNewConsumerGroup = null;
            if (cmdletContext.ConsumerGroupReplication_DetectAndCopyNewConsumerGroup != null)
            {
                requestConsumerGroupReplication_consumerGroupReplication_DetectAndCopyNewConsumerGroup = cmdletContext.ConsumerGroupReplication_DetectAndCopyNewConsumerGroup.Value;
            }
            if (requestConsumerGroupReplication_consumerGroupReplication_DetectAndCopyNewConsumerGroup != null)
            {
                request.ConsumerGroupReplication.DetectAndCopyNewConsumerGroups = requestConsumerGroupReplication_consumerGroupReplication_DetectAndCopyNewConsumerGroup.Value;
                requestConsumerGroupReplicationIsNull = false;
            }
            System.Boolean? requestConsumerGroupReplication_consumerGroupReplication_SynchroniseConsumerGroupOffset = null;
            if (cmdletContext.ConsumerGroupReplication_SynchroniseConsumerGroupOffset != null)
            {
                requestConsumerGroupReplication_consumerGroupReplication_SynchroniseConsumerGroupOffset = cmdletContext.ConsumerGroupReplication_SynchroniseConsumerGroupOffset.Value;
            }
            if (requestConsumerGroupReplication_consumerGroupReplication_SynchroniseConsumerGroupOffset != null)
            {
                request.ConsumerGroupReplication.SynchroniseConsumerGroupOffsets = requestConsumerGroupReplication_consumerGroupReplication_SynchroniseConsumerGroupOffset.Value;
                requestConsumerGroupReplicationIsNull = false;
            }
             // determine if request.ConsumerGroupReplication should be set to null
            if (requestConsumerGroupReplicationIsNull)
            {
                request.ConsumerGroupReplication = null;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
            }
            if (cmdletContext.ReplicatorArn != null)
            {
                request.ReplicatorArn = cmdletContext.ReplicatorArn;
            }
            if (cmdletContext.SourceKafkaClusterArn != null)
            {
                request.SourceKafkaClusterArn = cmdletContext.SourceKafkaClusterArn;
            }
            if (cmdletContext.TargetKafkaClusterArn != null)
            {
                request.TargetKafkaClusterArn = cmdletContext.TargetKafkaClusterArn;
            }
            
             // populate TopicReplication
            var requestTopicReplicationIsNull = true;
            request.TopicReplication = new Amazon.Kafka.Model.TopicReplicationUpdate();
            System.Boolean? requestTopicReplication_topicReplication_CopyAccessControlListsForTopic = null;
            if (cmdletContext.TopicReplication_CopyAccessControlListsForTopic != null)
            {
                requestTopicReplication_topicReplication_CopyAccessControlListsForTopic = cmdletContext.TopicReplication_CopyAccessControlListsForTopic.Value;
            }
            if (requestTopicReplication_topicReplication_CopyAccessControlListsForTopic != null)
            {
                request.TopicReplication.CopyAccessControlListsForTopics = requestTopicReplication_topicReplication_CopyAccessControlListsForTopic.Value;
                requestTopicReplicationIsNull = false;
            }
            System.Boolean? requestTopicReplication_topicReplication_CopyTopicConfiguration = null;
            if (cmdletContext.TopicReplication_CopyTopicConfiguration != null)
            {
                requestTopicReplication_topicReplication_CopyTopicConfiguration = cmdletContext.TopicReplication_CopyTopicConfiguration.Value;
            }
            if (requestTopicReplication_topicReplication_CopyTopicConfiguration != null)
            {
                request.TopicReplication.CopyTopicConfigurations = requestTopicReplication_topicReplication_CopyTopicConfiguration.Value;
                requestTopicReplicationIsNull = false;
            }
            System.Boolean? requestTopicReplication_topicReplication_DetectAndCopyNewTopic = null;
            if (cmdletContext.TopicReplication_DetectAndCopyNewTopic != null)
            {
                requestTopicReplication_topicReplication_DetectAndCopyNewTopic = cmdletContext.TopicReplication_DetectAndCopyNewTopic.Value;
            }
            if (requestTopicReplication_topicReplication_DetectAndCopyNewTopic != null)
            {
                request.TopicReplication.DetectAndCopyNewTopics = requestTopicReplication_topicReplication_DetectAndCopyNewTopic.Value;
                requestTopicReplicationIsNull = false;
            }
            List<System.String> requestTopicReplication_topicReplication_TopicsToExclude = null;
            if (cmdletContext.TopicReplication_TopicsToExclude != null)
            {
                requestTopicReplication_topicReplication_TopicsToExclude = cmdletContext.TopicReplication_TopicsToExclude;
            }
            if (requestTopicReplication_topicReplication_TopicsToExclude != null)
            {
                request.TopicReplication.TopicsToExclude = requestTopicReplication_topicReplication_TopicsToExclude;
                requestTopicReplicationIsNull = false;
            }
            List<System.String> requestTopicReplication_topicReplication_TopicsToReplicate = null;
            if (cmdletContext.TopicReplication_TopicsToReplicate != null)
            {
                requestTopicReplication_topicReplication_TopicsToReplicate = cmdletContext.TopicReplication_TopicsToReplicate;
            }
            if (requestTopicReplication_topicReplication_TopicsToReplicate != null)
            {
                request.TopicReplication.TopicsToReplicate = requestTopicReplication_topicReplication_TopicsToReplicate;
                requestTopicReplicationIsNull = false;
            }
             // determine if request.TopicReplication should be set to null
            if (requestTopicReplicationIsNull)
            {
                request.TopicReplication = null;
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
        
        private Amazon.Kafka.Model.UpdateReplicationInfoResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateReplicationInfoRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateReplicationInfo");
            try
            {
                #if DESKTOP
                return client.UpdateReplicationInfo(request);
                #elif CORECLR
                return client.UpdateReplicationInfoAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConsumerGroupReplication_ConsumerGroupsToExclude { get; set; }
            public List<System.String> ConsumerGroupReplication_ConsumerGroupsToReplicate { get; set; }
            public System.Boolean? ConsumerGroupReplication_DetectAndCopyNewConsumerGroup { get; set; }
            public System.Boolean? ConsumerGroupReplication_SynchroniseConsumerGroupOffset { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.String ReplicatorArn { get; set; }
            public System.String SourceKafkaClusterArn { get; set; }
            public System.String TargetKafkaClusterArn { get; set; }
            public System.Boolean? TopicReplication_CopyAccessControlListsForTopic { get; set; }
            public System.Boolean? TopicReplication_CopyTopicConfiguration { get; set; }
            public System.Boolean? TopicReplication_DetectAndCopyNewTopic { get; set; }
            public List<System.String> TopicReplication_TopicsToExclude { get; set; }
            public List<System.String> TopicReplication_TopicsToReplicate { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateReplicationInfoResponse, UpdateMSKReplicationInfoCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
