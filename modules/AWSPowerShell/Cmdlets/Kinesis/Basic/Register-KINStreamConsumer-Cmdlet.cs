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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

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
    /// You can register up to 20 consumers per stream. A given consumer can only be registered
    /// with one stream at a time.
    /// </para><para>
    /// For an example of how to use this operations, see <a href="/streams/latest/dev/building-enhanced-consumers-api.html">Enhanced
    /// Fan-Out Using the Kinesis Data Streams API</a>.
    /// </para><para>
    /// The use of this operation has a limit of five transactions per second per account.
    /// Also, only 5 consumers can be created simultaneously. In other words, you cannot have
    /// more than 5 consumers in a <code>CREATING</code> status at the same time. Registering
    /// a 6th consumer while there are 5 in a <code>CREATING</code> status results in a <code>LimitExceededException</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "KINStreamConsumer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.Consumer")]
    [AWSCmdlet("Calls the Amazon Kinesis RegisterStreamConsumer API operation.", Operation = new[] {"RegisterStreamConsumer"}, SelectReturnType = typeof(Amazon.Kinesis.Model.RegisterStreamConsumerResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.Consumer or Amazon.Kinesis.Model.RegisterStreamConsumerResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.Consumer object.",
        "The service call response (type Amazon.Kinesis.Model.RegisterStreamConsumerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterKINStreamConsumerCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConsumerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConsumerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConsumerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConsumerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-KINStreamConsumer (RegisterStreamConsumer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.RegisterStreamConsumerResponse, RegisterKINStreamConsumerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConsumerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.RegisterStreamConsumer(request);
                #elif CORECLR
                return client.RegisterStreamConsumerAsync(request).GetAwaiter().GetResult();
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
            public System.String ConsumerName { get; set; }
            public System.String StreamARN { get; set; }
            public System.Func<Amazon.Kinesis.Model.RegisterStreamConsumerResponse, RegisterKINStreamConsumerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Consumer;
        }
        
    }
}
