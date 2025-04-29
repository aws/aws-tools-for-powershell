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
using Amazon.PI;
using Amazon.PI.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// Get the attributes of the specified dimension group for a DB instance or data source.
    /// For example, if you specify a SQL ID, <c>GetDimensionKeyDetails</c> retrieves the
    /// full text of the dimension <c>db.sql.statement</c> associated with this ID. This operation
    /// is useful because <c>GetResourceMetrics</c> and <c>DescribeDimensionKeys</c> don't
    /// support retrieval of large SQL statement text, lock snapshots, and execution plans.
    /// </summary>
    [Cmdlet("Get", "PIDimensionKeyDetail")]
    [OutputType("Amazon.PI.Model.GetDimensionKeyDetailsResponse")]
    [AWSCmdlet("Calls the AWS Performance Insights GetDimensionKeyDetails API operation.", Operation = new[] {"GetDimensionKeyDetails"}, SelectReturnType = typeof(Amazon.PI.Model.GetDimensionKeyDetailsResponse))]
    [AWSCmdletOutput("Amazon.PI.Model.GetDimensionKeyDetailsResponse",
        "This cmdlet returns an Amazon.PI.Model.GetDimensionKeyDetailsResponse object containing multiple properties."
    )]
    public partial class GetPIDimensionKeyDetailCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. Performance Insights searches the specified group
        /// for the dimension group ID. The following group name values are valid:</para><ul><li><para><c>db.execution_plan</c> (Amazon RDS and Aurora only)</para></li><li><para><c>db.lock_snapshot</c> (Aurora only)</para></li><li><para><c>db.query</c> (Amazon DocumentDB only)</para></li><li><para><c>db.sql</c> (Amazon RDS and Aurora only)</para></li></ul>
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
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter GroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the dimension group from which to retrieve dimension details. For dimension
        /// group <c>db.sql</c>, the group ID is <c>db.sql.id</c>. The following group ID values
        /// are valid:</para><ul><li><para><c>db.execution_plan.id</c> for dimension group <c>db.execution_plan</c> (Aurora
        /// and RDS only)</para></li><li><para><c>db.sql.id</c> for dimension group <c>db.sql</c> (Aurora and RDS only)</para></li><li><para><c>db.query.id</c> for dimension group <c>db.query</c> (DocumentDB only)</para></li><li><para>For the dimension group <c>db.lock_snapshot</c>, the <c>GroupIdentifier</c> is the
        /// epoch timestamp when Performance Insights captured the snapshot, in seconds. You can
        /// retrieve this value with the <c>GetResourceMetrics</c> operation for a 1 second period.</para></li></ul>
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
        public System.String GroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID for a data source from which to gather dimension data. This ID must be immutable
        /// and unique within an Amazon Web Services Region. When a DB instance is the data source,
        /// specify its <c>DbiResourceId</c> value. For example, specify <c>db-ABCDEFGHIJKLMNOPQRSTU1VW2X</c>.
        /// </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter RequestedDimension
        /// <summary>
        /// <para>
        /// <para>A list of dimensions to retrieve the detail data for within the given dimension group.
        /// If you don't specify this parameter, Performance Insights returns all dimension data
        /// within the specified dimension group. Specify dimension names for the following dimension
        /// groups:</para><ul><li><para><c>db.execution_plan</c> - Specify the dimension name <c>db.execution_plan.raw_plan</c>
        /// or the short dimension name <c>raw_plan</c> (Amazon RDS and Aurora only)</para></li><li><para><c>db.lock_snapshot</c> - Specify the dimension name <c>db.lock_snapshot.lock_trees</c>
        /// or the short dimension name <c>lock_trees</c>. (Aurora only)</para></li><li><para><c>db.sql</c> - Specify either the full dimension name <c>db.sql.statement</c> or
        /// the short dimension name <c>statement</c> (Aurora and RDS only).</para></li><li><para><c>db.query</c> - Specify either the full dimension name <c>db.query.statement</c>
        /// or the short dimension name <c>statement</c> (DocumentDB only).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedDimensions")]
        public System.String[] RequestedDimension { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service for which Performance Insights returns data. The only
        /// valid value is <c>RDS</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PI.Model.GetDimensionKeyDetailsResponse).
        /// Specifying the name of a property of type Amazon.PI.Model.GetDimensionKeyDetailsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.PI.Model.GetDimensionKeyDetailsResponse, GetPIDimensionKeyDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Group = this.Group;
            #if MODULAR
            if (this.Group == null && ParameterWasBound(nameof(this.Group)))
            {
                WriteWarning("You are passing $null as a value for parameter Group which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupIdentifier = this.GroupIdentifier;
            #if MODULAR
            if (this.GroupIdentifier == null && ParameterWasBound(nameof(this.GroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestedDimension != null)
            {
                context.RequestedDimension = new List<System.String>(this.RequestedDimension);
            }
            context.ServiceType = this.ServiceType;
            #if MODULAR
            if (this.ServiceType == null && ParameterWasBound(nameof(this.ServiceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PI.Model.GetDimensionKeyDetailsRequest();
            
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
            }
            if (cmdletContext.GroupIdentifier != null)
            {
                request.GroupIdentifier = cmdletContext.GroupIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.RequestedDimension != null)
            {
                request.RequestedDimensions = cmdletContext.RequestedDimension;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
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
        
        private Amazon.PI.Model.GetDimensionKeyDetailsResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.GetDimensionKeyDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "GetDimensionKeyDetails");
            try
            {
                return client.GetDimensionKeyDetailsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Group { get; set; }
            public System.String GroupIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public List<System.String> RequestedDimension { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.Func<Amazon.PI.Model.GetDimensionKeyDetailsResponse, GetPIDimensionKeyDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
