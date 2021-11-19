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
    /// To deregister a consumer, provide its ARN. Alternatively, you can provide the ARN
    /// of the data stream and the name you gave the consumer when you registered it. You
    /// may also provide all three parameters, as long as they don't conflict with each other.
    /// If you don't know the name or ARN of the consumer that you want to deregister, you
    /// can use the <a>ListStreamConsumers</a> operation to get a list of the descriptions
    /// of all the consumers that are currently registered with a given data stream. The description
    /// of a consumer contains its name and ARN.
    /// 
    ///  
    /// <para>
    /// This operation has a limit of five transactions per second per stream.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "KINStreamConsumer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis DeregisterStreamConsumer API operation.", Operation = new[] {"DeregisterStreamConsumer"}, SelectReturnType = typeof(Amazon.Kinesis.Model.DeregisterStreamConsumerResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.DeregisterStreamConsumerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.DeregisterStreamConsumerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterKINStreamConsumerCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ConsumerARN
        /// <summary>
        /// <para>
        /// <para>The ARN returned by Kinesis Data Streams when you registered the consumer. If you
        /// don't know the ARN of the consumer that you want to deregister, you can use the ListStreamConsumers
        /// operation to get a list of the descriptions of all the consumers that are currently
        /// registered with a given data stream. The description of a consumer contains its ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConsumerARN { get; set; }
        #endregion
        
        #region Parameter ConsumerName
        /// <summary>
        /// <para>
        /// <para>The name that you gave to the consumer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsumerName { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Kinesis data stream that the consumer is registered with. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.DeregisterStreamConsumerResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConsumerARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConsumerARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConsumerARN' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-KINStreamConsumer (DeregisterStreamConsumer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.DeregisterStreamConsumerResponse, UnregisterKINStreamConsumerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConsumerARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConsumerARN = this.ConsumerARN;
            context.ConsumerName = this.ConsumerName;
            context.StreamARN = this.StreamARN;
            
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
            var request = new Amazon.Kinesis.Model.DeregisterStreamConsumerRequest();
            
            if (cmdletContext.ConsumerARN != null)
            {
                request.ConsumerARN = cmdletContext.ConsumerARN;
            }
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
        
        private Amazon.Kinesis.Model.DeregisterStreamConsumerResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DeregisterStreamConsumerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DeregisterStreamConsumer");
            try
            {
                #if DESKTOP
                return client.DeregisterStreamConsumer(request);
                #elif CORECLR
                return client.DeregisterStreamConsumerAsync(request).GetAwaiter().GetResult();
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
            public System.String ConsumerARN { get; set; }
            public System.String ConsumerName { get; set; }
            public System.String StreamARN { get; set; }
            public System.Func<Amazon.Kinesis.Model.DeregisterStreamConsumerResponse, UnregisterKINStreamConsumerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
