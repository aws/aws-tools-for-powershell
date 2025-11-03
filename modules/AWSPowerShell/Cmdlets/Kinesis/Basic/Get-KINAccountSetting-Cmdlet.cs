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
    /// Describes the account-level settings for Amazon Kinesis Data Streams. This operation
    /// returns information about the minimum throughput billing commitments and other account-level
    /// configurations.
    /// 
    ///  
    /// <para>
    /// This API has a call limit of 5 transactions per second (TPS) for each Amazon Web Services
    /// account. TPS over 5 will initiate the <c>LimitExceededException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINAccountSetting")]
    [OutputType("Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput")]
    [AWSCmdlet("Calls the Amazon Kinesis DescribeAccountSettings API operation.", Operation = new[] {"DescribeAccountSettings"}, SelectReturnType = typeof(Amazon.Kinesis.Model.DescribeAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput or Amazon.Kinesis.Model.DescribeAccountSettingsResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.MinimumThroughputBillingCommitmentOutput object.",
        "The service call response (type Amazon.Kinesis.Model.DescribeAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINAccountSettingCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MinimumThroughputBillingCommitment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.DescribeAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.DescribeAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MinimumThroughputBillingCommitment";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.DescribeAccountSettingsResponse, GetKINAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Kinesis.Model.DescribeAccountSettingsRequest();
            
            
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
        
        private Amazon.Kinesis.Model.DescribeAccountSettingsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DescribeAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DescribeAccountSettings");
            try
            {
                return client.DescribeAccountSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Kinesis.Model.DescribeAccountSettingsResponse, GetKINAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MinimumThroughputBillingCommitment;
        }
        
    }
}
