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
    /// Enables server-side encryption (SSE) for the delivery stream. 
    /// 
    ///  
    /// <para>
    /// This operation is asynchronous. It returns immediately. When you invoke it, Firehose
    /// first sets the encryption status of the stream to <c>ENABLING</c>, and then to <c>ENABLED</c>.
    /// The encryption status of a delivery stream is the <c>Status</c> property in <a>DeliveryStreamEncryptionConfiguration</a>.
    /// If the operation fails, the encryption status changes to <c>ENABLING_FAILED</c>. You
    /// can continue to read and write data to your delivery stream while the encryption status
    /// is <c>ENABLING</c>, but the data is not encrypted. It can take up to 5 seconds after
    /// the encryption status changes to <c>ENABLED</c> before all records written to the
    /// delivery stream are encrypted. To find out whether a record or a batch of records
    /// was encrypted, check the response elements <a>PutRecordOutput$Encrypted</a> and <a>PutRecordBatchOutput$Encrypted</a>,
    /// respectively.
    /// </para><para>
    /// To check the encryption status of a delivery stream, use <a>DescribeDeliveryStream</a>.
    /// </para><para>
    /// Even if encryption is currently enabled for a delivery stream, you can still invoke
    /// this operation on it to change the ARN of the CMK or both its type and ARN. If you
    /// invoke this method to change the CMK, and the old CMK is of type <c>CUSTOMER_MANAGED_CMK</c>,
    /// Firehose schedules the grant it had on the old CMK for retirement. If the new CMK
    /// is of type <c>CUSTOMER_MANAGED_CMK</c>, Firehose creates a grant that enables it to
    /// use the new CMK to encrypt and decrypt data and to manage the grant.
    /// </para><para>
    /// For the KMS grant creation to be successful, the Firehose API operations <c>StartDeliveryStreamEncryption</c>
    /// and <c>CreateDeliveryStream</c> should not be called with session credentials that
    /// are more than 6 hours old.
    /// </para><para>
    /// If a delivery stream already has encryption enabled and then you invoke this operation
    /// to change the ARN of the CMK or both its type and ARN and you get <c>ENABLING_FAILED</c>,
    /// this only means that the attempt to change the CMK failed. In this case, encryption
    /// remains enabled with the old CMK.
    /// </para><para>
    /// If the encryption status of your delivery stream is <c>ENABLING_FAILED</c>, you can
    /// invoke this operation again with a valid CMK. The CMK must be enabled and the key
    /// policy mustn't explicitly deny the permission for Firehose to invoke KMS encrypt and
    /// decrypt operations.
    /// </para><para>
    /// You can enable SSE for a delivery stream only if it's a delivery stream that uses
    /// <c>DirectPut</c> as its source. 
    /// </para><para>
    /// The <c>StartDeliveryStreamEncryption</c> and <c>StopDeliveryStreamEncryption</c> operations
    /// have a combined limit of 25 calls per delivery stream per 24 hours. For example, you
    /// reach the limit if you call <c>StartDeliveryStreamEncryption</c> 13 times and <c>StopDeliveryStreamEncryption</c>
    /// 12 times for the same delivery stream in a 24-hour period.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "KINFDeliveryStreamEncryption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose StartDeliveryStreamEncryption API operation.", Operation = new[] {"StartDeliveryStreamEncryption"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartKINFDeliveryStreamEncryptionCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream for which you want to enable server-side encryption
        /// (SSE).</para>
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
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyARN
        /// <summary>
        /// <para>
        /// <para>If you set <c>KeyType</c> to <c>CUSTOMER_MANAGED_CMK</c>, you must specify the Amazon
        /// Resource Name (ARN) of the CMK. If you set <c>KeyType</c> to <c>Amazon Web Services_OWNED_CMK</c>,
        /// Firehose uses a service-account CMK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of customer master key (CMK) to use for encryption. The default
        /// setting is <c>Amazon Web Services_OWNED_CMK</c>. For more information about CMKs,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#master_keys">Customer
        /// Master Keys (CMKs)</a>. When you invoke <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a>
        /// with <c>KeyType</c> set to CUSTOMER_MANAGED_CMK, Firehose invokes the Amazon KMS operation
        /// <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_CreateGrant.html">CreateGrant</a>
        /// to create a grant that allows the Firehose service to use the customer managed CMK
        /// to perform encryption and decryption. Firehose manages that grant. </para><para>When you invoke <a>StartDeliveryStreamEncryption</a> to change the CMK for a delivery
        /// stream that is encrypted with a customer managed CMK, Firehose schedules the grant
        /// it had on the old CMK for retirement.</para><para>You can use a CMK of type CUSTOMER_MANAGED_CMK to encrypt up to 500 delivery streams.
        /// If a <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a> operation
        /// exceeds this limit, Firehose throws a <c>LimitExceededException</c>. </para><important><para>To encrypt your delivery stream, use symmetric CMKs. Firehose doesn't support asymmetric
        /// CMKs. For information about symmetric and asymmetric CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symm-asymm-concepts.html">About
        /// Symmetric and Asymmetric CMKs</a> in the Amazon Web Services Key Management Service
        /// developer guide.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.KeyType")]
        public Amazon.KinesisFirehose.KeyType DeliveryStreamEncryptionConfigurationInput_KeyType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-KINFDeliveryStreamEncryption (StartDeliveryStreamEncryption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse, StartKINFDeliveryStreamEncryptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryStreamEncryptionConfigurationInput_KeyARN = this.DeliveryStreamEncryptionConfigurationInput_KeyARN;
            context.DeliveryStreamEncryptionConfigurationInput_KeyType = this.DeliveryStreamEncryptionConfigurationInput_KeyType;
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
            var request = new Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionRequest();
            
            
             // populate DeliveryStreamEncryptionConfigurationInput
            var requestDeliveryStreamEncryptionConfigurationInputIsNull = true;
            request.DeliveryStreamEncryptionConfigurationInput = new Amazon.KinesisFirehose.Model.DeliveryStreamEncryptionConfigurationInput();
            System.String requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN = null;
            if (cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyARN != null)
            {
                requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN = cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyARN;
            }
            if (requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN != null)
            {
                request.DeliveryStreamEncryptionConfigurationInput.KeyARN = requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN;
                requestDeliveryStreamEncryptionConfigurationInputIsNull = false;
            }
            Amazon.KinesisFirehose.KeyType requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType = null;
            if (cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyType != null)
            {
                requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType = cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyType;
            }
            if (requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType != null)
            {
                request.DeliveryStreamEncryptionConfigurationInput.KeyType = requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType;
                requestDeliveryStreamEncryptionConfigurationInputIsNull = false;
            }
             // determine if request.DeliveryStreamEncryptionConfigurationInput should be set to null
            if (requestDeliveryStreamEncryptionConfigurationInputIsNull)
            {
                request.DeliveryStreamEncryptionConfigurationInput = null;
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
        
        private Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "StartDeliveryStreamEncryption");
            try
            {
                #if DESKTOP
                return client.StartDeliveryStreamEncryption(request);
                #elif CORECLR
                return client.StartDeliveryStreamEncryptionAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
            public Amazon.KinesisFirehose.KeyType DeliveryStreamEncryptionConfigurationInput_KeyType { get; set; }
            public System.String DeliveryStreamName { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.StartDeliveryStreamEncryptionResponse, StartKINFDeliveryStreamEncryptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
