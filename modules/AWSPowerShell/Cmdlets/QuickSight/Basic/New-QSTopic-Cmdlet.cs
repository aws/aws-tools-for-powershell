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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a new Q topic.
    /// </summary>
    [Cmdlet("New", "QSTopic", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateTopicResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateTopic API operation.", Operation = new[] {"CreateTopic"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateTopicResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateTopicResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateTopicResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQSTopicCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
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
        /// <para>The data sets that the topic is associated with.</para>
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
        
        #region Parameter Topic_Name
        /// <summary>
        /// <para>
        /// <para>The name of the topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Topic_Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags that are assigned
        /// to the dataset.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TopicId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TopicId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TopicId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSTopic (CreateTopic)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateTopicResponse, NewQSTopicCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TopicId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            if (this.Topic_DataSet != null)
            {
                context.Topic_DataSet = new List<Amazon.QuickSight.Model.DatasetMetadata>(this.Topic_DataSet);
            }
            context.Topic_Description = this.Topic_Description;
            context.Topic_Name = this.Topic_Name;
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
                #if DESKTOP
                return client.CreateTopic(request);
                #elif CORECLR
                return client.CreateTopicAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public List<Amazon.QuickSight.Model.DatasetMetadata> Topic_DataSet { get; set; }
            public System.String Topic_Description { get; set; }
            public System.String Topic_Name { get; set; }
            public System.String TopicId { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateTopicResponse, NewQSTopicCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
