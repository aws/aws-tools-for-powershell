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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Provides a detailed description of a specified operation that was performed on an
    /// enhanced snapshot. To see a list of the operations of a snapshot, use <c>ListSnapshotOperations</c>.
    /// 
    ///  
    /// <para>
    /// Snapshot operations are available for 90 days after they are created.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINA2SnapshotOperationDetail")]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.SnapshotOperationInfoDetails")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 DescribeSnapshotOperation API operation.", Operation = new[] {"DescribeSnapshotOperation"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.SnapshotOperationInfoDetails or Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.SnapshotOperationInfoDetails object.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINA2SnapshotOperationDetailCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the enhanced snapshot.</para>
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
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotOperationId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot operation. You can retrieve this value using <c>ListSnapshotOperations</c>.</para>
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
        public System.String SnapshotOperationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapshotOperationInfoDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapshotOperationInfoDetails";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse, GetKINA2SnapshotOperationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SnapshotName = this.SnapshotName;
            #if MODULAR
            if (this.SnapshotName == null && ParameterWasBound(nameof(this.SnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotOperationId = this.SnapshotOperationId;
            #if MODULAR
            if (this.SnapshotOperationId == null && ParameterWasBound(nameof(this.SnapshotOperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotOperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationRequest();
            
            if (cmdletContext.SnapshotName != null)
            {
                request.SnapshotName = cmdletContext.SnapshotName;
            }
            if (cmdletContext.SnapshotOperationId != null)
            {
                request.SnapshotOperationId = cmdletContext.SnapshotOperationId;
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
        
        private Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "DescribeSnapshotOperation");
            try
            {
                return client.DescribeSnapshotOperationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SnapshotName { get; set; }
            public System.String SnapshotOperationId { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.DescribeSnapshotOperationResponse, GetKINA2SnapshotOperationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapshotOperationInfoDetails;
        }
        
    }
}
