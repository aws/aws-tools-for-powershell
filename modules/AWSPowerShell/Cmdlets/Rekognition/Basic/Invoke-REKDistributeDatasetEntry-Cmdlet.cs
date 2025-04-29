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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    /// Distributes the entries (images) in a training dataset across the training dataset
    /// and the test dataset for a project. <c>DistributeDatasetEntries</c> moves 20% of the
    /// training dataset images to the test dataset. An entry is a JSON Line that describes
    /// an image. 
    /// </para><para>
    /// You supply the Amazon Resource Names (ARN) of a project's training dataset and test
    /// dataset. The training dataset must contain the images that you want to split. The
    /// test dataset must be empty. The datasets must belong to the same project. To create
    /// training and test datasets for a project, call <a>CreateDataset</a>.
    /// </para><para>
    /// Distributing a dataset takes a while to complete. To check the status call <c>DescribeDataset</c>.
    /// The operation is complete when the <c>Status</c> field for the training dataset and
    /// the test dataset is <c>UPDATE_COMPLETE</c>. If the dataset split fails, the value
    /// of <c>Status</c> is <c>UPDATE_FAILED</c>.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:DistributeDatasetEntries</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "REKDistributeDatasetEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Rekognition DistributeDatasetEntries API operation.", Operation = new[] {"DistributeDatasetEntries"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DistributeDatasetEntriesResponse))]
    [AWSCmdletOutput("None or Amazon.Rekognition.Model.DistributeDatasetEntriesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Rekognition.Model.DistributeDatasetEntriesResponse) be returned by specifying '-Select *'."
    )]
    public partial class InvokeREKDistributeDatasetEntryCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Dataset
        /// <summary>
        /// <para>
        /// <para>The ARNS for the training dataset and test dataset that you want to use. The datasets
        /// must belong to the same project. The test dataset must be empty. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Datasets")]
        public Amazon.Rekognition.Model.DistributeDataset[] Dataset { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DistributeDatasetEntriesResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Dataset), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-REKDistributeDatasetEntry (DistributeDatasetEntries)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DistributeDatasetEntriesResponse, InvokeREKDistributeDatasetEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Dataset != null)
            {
                context.Dataset = new List<Amazon.Rekognition.Model.DistributeDataset>(this.Dataset);
            }
            #if MODULAR
            if (this.Dataset == null && ParameterWasBound(nameof(this.Dataset)))
            {
                WriteWarning("You are passing $null as a value for parameter Dataset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Rekognition.Model.DistributeDatasetEntriesRequest();
            
            if (cmdletContext.Dataset != null)
            {
                request.Datasets = cmdletContext.Dataset;
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
        
        private Amazon.Rekognition.Model.DistributeDatasetEntriesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DistributeDatasetEntriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DistributeDatasetEntries");
            try
            {
                return client.DistributeDatasetEntriesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Rekognition.Model.DistributeDataset> Dataset { get; set; }
            public System.Func<Amazon.Rekognition.Model.DistributeDatasetEntriesResponse, InvokeREKDistributeDatasetEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
