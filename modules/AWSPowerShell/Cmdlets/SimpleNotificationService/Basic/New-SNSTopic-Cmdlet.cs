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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Creates a topic to which notifications can be published. Users can create at most
    /// 100,000 standard topics (at most 1,000 FIFO topics). For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-create-topic.html">Creating an
    /// Amazon SNS topic</a> in the <i>Amazon SNS Developer Guide</i>. This action is idempotent,
    /// so if the requester already owns a topic with the specified name, that topic's ARN
    /// is returned without creating a new topic.
    /// </summary>
    [Cmdlet("New", "SNSTopic", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) CreateTopic API operation.", Operation = new[] {"CreateTopic"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.CreateTopicResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleNotificationService.Model.CreateTopicResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.CreateTopicResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSNSTopicCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <code>CreateTopic</code> action uses:</para><ul><li><para><code>DeliveryPolicy</code> – The policy that defines how Amazon SNS retries failed
        /// deliveries to HTTP/S endpoints.</para></li><li><para><code>DisplayName</code> – The display name to use for a topic with SMS subscriptions.</para></li><li><para><code>FifoTopic</code> – Set to true to create a FIFO topic.</para></li><li><para><code>Policy</code> – The policy that defines who can access your topic. By default,
        /// only the topic owner can publish or subscribe to the topic.</para></li></ul><para>The following attribute applies only to <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-server-side-encryption.html">server-side
        /// encryption</a>:</para><ul><li><para><code>KmsMasterKeyId</code> – The ID of an Amazon Web Services managed customer master
        /// key (CMK) for Amazon SNS or a custom CMK. For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-server-side-encryption.html#sse-key-terms">Key
        /// Terms</a>. For more examples, see <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">KeyId</a>
        /// in the <i>Key Management Service API Reference</i>. </para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-fifo-topics.html">FIFO
        /// topics</a>:</para><ul><li><para><code>FifoTopic</code> – When this is set to <code>true</code>, a FIFO topic is created.</para></li><li><para><code>ContentBasedDeduplication</code> – Enables content-based deduplication for
        /// FIFO topics.</para><ul><li><para>By default, <code>ContentBasedDeduplication</code> is set to <code>false</code>. If
        /// you create a FIFO topic and this attribute is <code>false</code>, you must specify
        /// a value for the <code>MessageDeduplicationId</code> parameter for the <a href="https://docs.aws.amazon.com/sns/latest/api/API_Publish.html">Publish</a>
        /// action. </para></li><li><para>When you set <code>ContentBasedDeduplication</code> to <code>true</code>, Amazon SNS
        /// uses a SHA-256 hash to generate the <code>MessageDeduplicationId</code> using the
        /// body of the message (but not the attributes of the message).</para><para>(Optional) To override the generated value, you can specify a value for the <code>MessageDeduplicationId</code>
        /// parameter for the <code>Publish</code> action.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter DataProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>The body of the policy document you want to use for this topic.</para><para>You can only add one policy per topic.</para><para>The policy must be in JSON string format.</para><para>Length Constraints: Maximum length of 30,720.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the topic you want to create.</para><para>Constraints: Topic names must be made up of only uppercase and lowercase ASCII letters,
        /// numbers, underscores, and hyphens, and must be between 1 and 256 characters long.</para><para>For a FIFO (first-in-first-out) topic, the name must end with the <code>.fifo</code>
        /// suffix. </para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags to add to a new topic.</para><note><para>To be able to tag a topic on creation, you must have the <code>sns:CreateTopic</code>
        /// and <code>sns:TagResource</code> permissions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleNotificationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TopicArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.CreateTopicResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.CreateTopicResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TopicArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNSTopic (CreateTopic)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.CreateTopicResponse, NewSNSTopicCmdlet>(Select) ??
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
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.DataProtectionPolicy = this.DataProtectionPolicy;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleNotificationService.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleNotificationService.Model.CreateTopicRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.DataProtectionPolicy != null)
            {
                request.DataProtectionPolicy = cmdletContext.DataProtectionPolicy;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SimpleNotificationService.Model.CreateTopicResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.CreateTopicRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "CreateTopic");
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String DataProtectionPolicy { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SimpleNotificationService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.CreateTopicResponse, NewSNSTopicCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TopicArn;
        }
        
    }
}
