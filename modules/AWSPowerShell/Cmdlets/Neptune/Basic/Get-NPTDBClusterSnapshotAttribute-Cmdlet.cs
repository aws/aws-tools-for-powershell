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
using Amazon.Neptune;
using Amazon.Neptune.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Returns a list of DB cluster snapshot attribute names and values for a manual DB cluster
    /// snapshot.
    /// 
    ///  
    /// <para>
    /// When sharing snapshots with other Amazon accounts, <c>DescribeDBClusterSnapshotAttributes</c>
    /// returns the <c>restore</c> attribute and a list of IDs for the Amazon accounts that
    /// are authorized to copy or restore the manual DB cluster snapshot. If <c>all</c> is
    /// included in the list of values for the <c>restore</c> attribute, then the manual DB
    /// cluster snapshot is public and can be copied or restored by all Amazon accounts.
    /// </para><para>
    /// To add or remove access for an Amazon account to copy or restore a manual DB cluster
    /// snapshot, or to make the manual DB cluster snapshot public or private, use the <a>ModifyDBClusterSnapshotAttribute</a>
    /// API action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NPTDBClusterSnapshotAttribute")]
    [OutputType("Amazon.Neptune.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon Neptune DescribeDBClusterSnapshotAttributes API operation.", Operation = new[] {"DescribeDBClusterSnapshotAttributes"}, SelectReturnType = typeof(Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBClusterSnapshotAttributesResult or Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNPTDBClusterSnapshotAttributeCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB cluster snapshot to describe the attributes for.</para>
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
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshotAttributesResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshotAttributesResult";
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
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse, GetNPTDBClusterSnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.DBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesRequest();
            
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
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
        
        private Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "DescribeDBClusterSnapshotAttributes");
            try
            {
                return client.DescribeDBClusterSnapshotAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public System.Func<Amazon.Neptune.Model.DescribeDBClusterSnapshotAttributesResponse, GetNPTDBClusterSnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshotAttributesResult;
        }
        
    }
}
