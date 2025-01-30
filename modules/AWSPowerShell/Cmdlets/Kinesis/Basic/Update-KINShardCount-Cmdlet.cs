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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Updates the shard count of the specified stream to the specified number of shards.
    /// This API is only supported for the data streams with the provisioned capacity mode.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// Updating the shard count is an asynchronous operation. Upon receiving the request,
    /// Kinesis Data Streams returns immediately and sets the status of the stream to <c>UPDATING</c>.
    /// After the update is complete, Kinesis Data Streams sets the status of the stream back
    /// to <c>ACTIVE</c>. Depending on the size of the stream, the scaling action could take
    /// a few minutes to complete. You can continue to read and write data to your stream
    /// while its status is <c>UPDATING</c>.
    /// </para><para>
    /// To update the shard count, Kinesis Data Streams performs splits or merges on individual
    /// shards. This can cause short-lived shards to be created, in addition to the final
    /// shards. These short-lived shards count towards your total shard limit for your account
    /// in the Region.
    /// </para><para>
    /// When using this operation, we recommend that you specify a target shard count that
    /// is a multiple of 25% (25%, 50%, 75%, 100%). You can specify any target value within
    /// your shard limit. However, if you specify a target that isn't a multiple of 25%, the
    /// scaling action might take longer to complete. 
    /// </para><para>
    /// This operation has the following default limits. By default, you cannot do the following:
    /// </para><ul><li><para>
    /// Scale more than ten times per rolling 24-hour period per stream
    /// </para></li><li><para>
    /// Scale up to more than double your current shard count for a stream
    /// </para></li><li><para>
    /// Scale down below half your current shard count for a stream
    /// </para></li><li><para>
    /// Scale up to more than 10000 shards in a stream
    /// </para></li><li><para>
    /// Scale a stream with more than 10000 shards down unless the result is less than 10000
    /// shards
    /// </para></li><li><para>
    /// Scale up to more than the shard limit for your account
    /// </para></li><li><para>
    /// Make over 10 TPS. TPS over 10 will trigger the LimitExceededException
    /// </para></li></ul><para>
    /// For the default limits for an Amazon Web Services account, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Streams
    /// Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>. To request an
    /// increase in the call rate limit, the shard limit for this API, or your overall shard
    /// limit, use the <a href="https://console.aws.amazon.com/support/v1#/case/create?issueType=service-limit-increase&amp;limitType=service-code-kinesis">limits
    /// form</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINShardCount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.UpdateShardCountResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateShardCount API operation.", Operation = new[] {"UpdateShardCount"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateShardCountResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.UpdateShardCountResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.UpdateShardCountResponse object containing multiple properties."
    )]
    public partial class UpdateKINShardCountCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScalingType
        /// <summary>
        /// <para>
        /// <para>The scaling type. Uniform scaling creates shards of equal size.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kinesis.ScalingType")]
        public Amazon.Kinesis.ScalingType ScalingType { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter TargetShardCount
        /// <summary>
        /// <para>
        /// <para>The new number of shards. This value has the following default limits. By default,
        /// you cannot do the following: </para><ul><li><para>Set this value to more than double your current shard count for a stream.</para></li><li><para>Set this value below half your current shard count for a stream.</para></li><li><para>Set this value to more than 10000 shards in a stream (the default limit for shard
        /// count per stream is 10000 per account per region), unless you request a limit increase.</para></li><li><para>Scale a stream with more than 10000 shards down unless you set this value to less
        /// than 10000 shards.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TargetShardCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateShardCountResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.UpdateShardCountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINShardCount (UpdateShardCount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateShardCountResponse, UpdateKINShardCountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ScalingType = this.ScalingType;
            #if MODULAR
            if (this.ScalingType == null && ParameterWasBound(nameof(this.ScalingType)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            context.TargetShardCount = this.TargetShardCount;
            #if MODULAR
            if (this.TargetShardCount == null && ParameterWasBound(nameof(this.TargetShardCount)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetShardCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.UpdateShardCountRequest();
            
            if (cmdletContext.ScalingType != null)
            {
                request.ScalingType = cmdletContext.ScalingType;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            if (cmdletContext.TargetShardCount != null)
            {
                request.TargetShardCount = cmdletContext.TargetShardCount.Value;
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
        
        private Amazon.Kinesis.Model.UpdateShardCountResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateShardCountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateShardCount");
            try
            {
                #if DESKTOP
                return client.UpdateShardCount(request);
                #elif CORECLR
                return client.UpdateShardCountAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kinesis.ScalingType ScalingType { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Int32? TargetShardCount { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateShardCountResponse, UpdateKINShardCountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
