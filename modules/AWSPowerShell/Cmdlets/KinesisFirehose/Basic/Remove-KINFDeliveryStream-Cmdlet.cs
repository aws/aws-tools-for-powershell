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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Deletes a delivery stream and its data.
    /// 
    ///  
    /// <para>
    /// You can delete a delivery stream only if it is in one of the following states: <c>ACTIVE</c>,
    /// <c>DELETING</c>, <c>CREATING_FAILED</c>, or <c>DELETING_FAILED</c>. You can't delete
    /// a delivery stream that is in the <c>CREATING</c> state. To check the state of a delivery
    /// stream, use <a>DescribeDeliveryStream</a>. 
    /// </para><para>
    /// DeleteDeliveryStream is an asynchronous API. When an API request to DeleteDeliveryStream
    /// succeeds, the delivery stream is marked for deletion, and it goes into the <c>DELETING</c>
    /// state.While the delivery stream is in the <c>DELETING</c> state, the service might
    /// continue to accept records, but it doesn't make any guarantees with respect to delivering
    /// the data. Therefore, as a best practice, first stop any applications that are sending
    /// records before you delete a delivery stream.
    /// </para><para>
    /// Removal of a delivery stream that is in the <c>DELETING</c> state is a low priority
    /// operation for the service. A stream may remain in the <c>DELETING</c> state for several
    /// minutes. Therefore, as a best practice, applications should not wait for streams in
    /// the <c>DELETING</c> state to be removed. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "KINFDeliveryStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose DeleteDeliveryStream API operation.", Operation = new[] {"DeleteDeliveryStream"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowForceDelete
        /// <summary>
        /// <para>
        /// <para>Set this to true if you want to delete the delivery stream even if Firehose is unable
        /// to retire the grant for the CMK. Firehose might be unable to retire the grant due
        /// to a customer error, such as when the CMK or the grant are in an invalid state. If
        /// you force deletion, you can then use the <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_RevokeGrant.html">RevokeGrant</a>
        /// operation to revoke the grant you gave to Firehose. If a failure to retire the grant
        /// happens due to an Amazon Web Services KMS issue, Firehose keeps retrying the delete
        /// operation.</para><para>The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowForceDelete { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
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
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeliveryStreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeliveryStreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeliveryStreamName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KINFDeliveryStream (DeleteDeliveryStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse, RemoveKINFDeliveryStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeliveryStreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowForceDelete = this.AllowForceDelete;
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisFirehose.Model.DeleteDeliveryStreamRequest();
            
            if (cmdletContext.AllowForceDelete != null)
            {
                request.AllowForceDelete = cmdletContext.AllowForceDelete.Value;
            }
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
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
        
        private Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.DeleteDeliveryStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "DeleteDeliveryStream");
            try
            {
                #if DESKTOP
                return client.DeleteDeliveryStream(request);
                #elif CORECLR
                return client.DeleteDeliveryStreamAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowForceDelete { get; set; }
            public System.String DeliveryStreamName { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.DeleteDeliveryStreamResponse, RemoveKINFDeliveryStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
