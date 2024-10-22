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
using Amazon.EBS;
using Amazon.EBS.Model;

namespace Amazon.PowerShell.Cmdlets.EBS
{
    /// <summary>
    /// Seals and completes the snapshot after all of the required blocks of data have been
    /// written to it. Completing the snapshot changes the status to <c>completed</c>. You
    /// cannot write new blocks to a snapshot after it has been completed.
    /// 
    ///  <note><para>
    /// You should always retry requests that receive server (<c>5xx</c>) error responses,
    /// and <c>ThrottlingException</c> and <c>RequestThrottledException</c> client error responses.
    /// For more information see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/error-retries.html">Error
    /// retries</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Complete", "EBSSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EBS.Status")]
    [AWSCmdlet("Calls the Amazon EBS CompleteSnapshot API operation.", Operation = new[] {"CompleteSnapshot"}, SelectReturnType = typeof(Amazon.EBS.Model.CompleteSnapshotResponse))]
    [AWSCmdletOutput("Amazon.EBS.Status or Amazon.EBS.Model.CompleteSnapshotResponse",
        "This cmdlet returns an Amazon.EBS.Status object.",
        "The service call response (type Amazon.EBS.Model.CompleteSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CompleteEBSSnapshotCmdlet : AmazonEBSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangedBlocksCount
        /// <summary>
        /// <para>
        /// <para>The number of blocks that were written to the snapshot.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ChangedBlocksCount { get; set; }
        #endregion
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// <para>An aggregated Base-64 SHA256 checksum based on the checksums of each written block.</para><para>To generate the aggregated checksum using the linear aggregation method, arrange the
        /// checksums for each written block in ascending order of their block index, concatenate
        /// them to form a single string, and then generate the checksum on the entire string
        /// using the SHA256 algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter ChecksumAggregationMethod
        /// <summary>
        /// <para>
        /// <para>The aggregation method used to generate the checksum. Currently, the only supported
        /// aggregation method is <c>LINEAR</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EBS.ChecksumAggregationMethod")]
        public Amazon.EBS.ChecksumAggregationMethod ChecksumAggregationMethod { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm used to generate the checksum. Currently, the only supported algorithm
        /// is <c>SHA256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EBS.ChecksumAlgorithm")]
        public Amazon.EBS.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot.</para>
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
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EBS.Model.CompleteSnapshotResponse).
        /// Specifying the name of a property of type Amazon.EBS.Model.CompleteSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-EBSSnapshot (CompleteSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EBS.Model.CompleteSnapshotResponse, CompleteEBSSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChangedBlocksCount = this.ChangedBlocksCount;
            #if MODULAR
            if (this.ChangedBlocksCount == null && ParameterWasBound(nameof(this.ChangedBlocksCount)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangedBlocksCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Checksum = this.Checksum;
            context.ChecksumAggregationMethod = this.ChecksumAggregationMethod;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EBS.Model.CompleteSnapshotRequest();
            
            if (cmdletContext.ChangedBlocksCount != null)
            {
                request.ChangedBlocksCount = cmdletContext.ChangedBlocksCount.Value;
            }
            if (cmdletContext.Checksum != null)
            {
                request.Checksum = cmdletContext.Checksum;
            }
            if (cmdletContext.ChecksumAggregationMethod != null)
            {
                request.ChecksumAggregationMethod = cmdletContext.ChecksumAggregationMethod;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
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
        
        private Amazon.EBS.Model.CompleteSnapshotResponse CallAWSServiceOperation(IAmazonEBS client, Amazon.EBS.Model.CompleteSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EBS", "CompleteSnapshot");
            try
            {
                #if DESKTOP
                return client.CompleteSnapshot(request);
                #elif CORECLR
                return client.CompleteSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ChangedBlocksCount { get; set; }
            public System.String Checksum { get; set; }
            public Amazon.EBS.ChecksumAggregationMethod ChecksumAggregationMethod { get; set; }
            public Amazon.EBS.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String SnapshotId { get; set; }
            public System.Func<Amazon.EBS.Model.CompleteSnapshotResponse, CompleteEBSSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
