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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Returns information about the specified dataset. This includes its identifier, Amazon
    /// Resource Name (ARN), and any customer managed Amazon Web Services Key Management Service
    /// (Amazon Web Services KMS) key that is currently associated with it.
    /// 
    ///  
    /// <para>
    /// Only the <c>default</c> dataset is supported. The <c>default</c> dataset is implicit
    /// for every account in every Region — you can call <c>GetDataset</c> for it without
    /// first creating it. If no customer managed KMS key has been associated with the dataset,
    /// the response omits the <c>KmsKeyArn</c> field, indicating that data is encrypted at
    /// rest using an Amazon Web Services owned key managed by Amazon CloudWatch.
    /// </para><para>
    /// To associate a customer managed KMS key with a dataset, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_AssociateDatasetKmsKey.html">AssociateDatasetKmsKey</a>.
    /// To remove the association, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_DisassociateDatasetKmsKey.html">DisassociateDatasetKmsKey</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWDataset")]
    [OutputType("Amazon.CloudWatch.Model.GetDatasetResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetDataset API operation.", Operation = new[] {"GetDataset"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetDatasetResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetDatasetResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.GetDatasetResponse object containing multiple properties."
    )]
    public partial class GetCWDatasetCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of the dataset to retrieve. For the <c>default</c> dataset,
        /// you can specify either <c>default</c> or the full dataset Amazon Resource Name (ARN)
        /// in the format <c>arn:aws:cloudwatch:<i>Region</i>:<i>account-id</i>:dataset/default</c>.</para>
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
        public System.String DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetDatasetResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetDatasetResponse, GetCWDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetIdentifier = this.DatasetIdentifier;
            #if MODULAR
            if (this.DatasetIdentifier == null && ParameterWasBound(nameof(this.DatasetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.GetDatasetRequest();
            
            if (cmdletContext.DatasetIdentifier != null)
            {
                request.DatasetIdentifier = cmdletContext.DatasetIdentifier;
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
        
        private Amazon.CloudWatch.Model.GetDatasetResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetDataset");
            try
            {
                return client.GetDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetIdentifier { get; set; }
            public System.Func<Amazon.CloudWatch.Model.GetDatasetResponse, GetCWDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
