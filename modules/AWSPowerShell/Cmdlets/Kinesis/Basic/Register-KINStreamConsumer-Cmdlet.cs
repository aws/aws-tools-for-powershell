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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Registers a consumer with a Kinesis data stream. When you use this operation, the
    /// consumer you register can then call <a>SubscribeToShard</a> to receive data from the
    /// stream using enhanced fan-out, at a rate of up to 2 MiB per second for every shard
    /// you subscribe to. This rate is unaffected by the total number of consumers that read
    /// from the same stream.
    /// 
    ///  
    /// <para>
    /// You can add tags to the registered consumer when making a <c>RegisterStreamConsumer</c>
    /// request by setting the <c>Tags</c> parameter. If you pass the <c>Tags</c> parameter,
    /// in addition to having the <c>kinesis:RegisterStreamConsumer</c> permission, you must
    /// also have the <c>kinesis:TagResource</c> permission for the consumer that will be
    /// registered. Tags will take effect from the <c>CREATING</c> status of the consumer.
    /// </para><para>
    /// With On-demand Advantage streams, you can register up to 50 consumers per stream to
    /// use Enhanced Fan-out. With On-demand Standard and Provisioned streams, you can register
    /// up to 20 consumers per stream to use Enhanced Fan-out. A given consumer can only be
    /// registered with one stream at a time.
    /// </para><para>
    /// For an example of how to use this operation, see <a href="https://docs.aws.amazon.com/streams/latest/dev/building-enhanced-consumers-api.html">Enhanced
    /// Fan-Out Using the Kinesis Data Streams API</a>.
    /// </para><para>
    /// The use of this operation has a limit of five transactions per second per account.
    /// Also, only 5 consumers can be created simultaneously. In other words, you cannot have
    /// more than 5 consumers in a <c>CREATING</c> status at the same time. Registering a
    /// 6th consumer while there are 5 in a <c>CREATING</c> status results in a <c>LimitExceededException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "KINStreamConsumer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.Consumer")]
    [AWSCmdlet("Calls the Amazon Kinesis RegisterStreamConsumer API operation.", Operation = new[] {"RegisterStreamConsumer"}, SelectReturnType = typeof(Amazon.Kinesis.Model.RegisterStreamConsumerResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.Consumer or Amazon.Kinesis.Model.RegisterStreamConsumerResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.Consumer object.",
        "The service call response (type Amazon.Kinesis.Model.RegisterStreamConsumerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterKINStreamConsumerCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConsumerName
        /// <summary>
        /// <para>
        /// <para>For a given Kinesis data stream, each consumer must have a unique name. However, consumer
        /// names don't have to be unique across data streams.</para>
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
        public System.String ConsumerName { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Kinesis data stream that you want to register the consumer with. For
        /// more info, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para>
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
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of up to 50 key-value pairs. A tag consists of a required key and an optional
        /// value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Consumer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.RegisterStreamConsumerResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.RegisterStreamConsumerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Consumer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConsumerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-KINStreamConsumer (RegisterStreamConsumer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.RegisterStreamConsumerResponse, RegisterKINStreamConsumerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConsumerName = this.ConsumerName;
            #if MODULAR
            if (this.ConsumerName == null && ParameterWasBound(nameof(this.ConsumerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConsumerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            #if MODULAR
            if (this.StreamARN == null && ParameterWasBound(nameof(this.StreamARN)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Kinesis.Model.RegisterStreamConsumerRequest();
            
            if (cmdletContext.ConsumerName != null)
            {
                request.ConsumerName = cmdletContext.ConsumerName;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
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
        
        private Amazon.Kinesis.Model.RegisterStreamConsumerResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.RegisterStreamConsumerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "RegisterStreamConsumer");
            try
            {
                return client.RegisterStreamConsumerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConsumerName { get; set; }
            public System.String StreamARN { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kinesis.Model.RegisterStreamConsumerResponse, RegisterKINStreamConsumerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Consumer;
        }
        
    }
}
