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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes a tree-based hierarchy that represents the physical host placement of your
    /// pending or active Capacity Reservations within an Availability Zone or Local Zone.
    /// You can use this information to determine the relative proximity of your capacity
    /// within the Amazon Web Services network before it is launched and use this information
    /// to allocate capacity together to support your tightly coupled workloads.
    /// 
    ///  
    /// <para>
    /// Capacity Reservation topology is supported for specific instance types only. For more
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-topology-prerequisites.html">Prerequisites
    /// for Amazon EC2 instance topology</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><note><para>
    /// The Amazon EC2 API follows an eventual consistency model due to the distributed nature
    /// of the system supporting it. As a result, when you call the DescribeCapacityReservationTopology
    /// API command immediately after launching instances, the response might return a <c>null</c>
    /// value for <c>capacityBlockId</c> because the data might not have fully propagated
    /// across all subsystems. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/eventual-consistency.html">Eventual
    /// consistency in the Amazon EC2 API</a> in the <i>Amazon EC2 Developer Guide</i>.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-topology.html">Amazon
    /// EC2 topology</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2CapacityReservationTopology")]
    [OutputType("Amazon.EC2.Model.CapacityReservationTopology")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeCapacityReservationTopology API operation.", Operation = new[] {"DescribeCapacityReservationTopology"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityReservationTopology or Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.CapacityReservationTopology objects.",
        "The service call response (type Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2CapacityReservationTopologyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The Capacity Reservation IDs.</para><para>Default: Describes all your Capacity Reservations.</para><para>Constraints: Maximum 100 explicitly specified Capacity Reservation IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationIds")]
        public System.String[] CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>availability-zone</c> - The name of the Availability Zone (for example, <c>us-west-2a</c>)
        /// or Local Zone (for example, <c>us-west-2-lax-1b</c>) that the Capacity Reservation
        /// is in.</para></li><li><para><c>instance-type</c> - The instance type (for example, <c>p4d.24xlarge</c>) or instance
        /// family (for example, <c>p4d*</c>). You can use the <c>*</c> wildcard to match zero
        /// or more characters, or the <c>?</c> wildcard to match zero or one character.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para><para>You can't specify this parameter and the Capacity Reservation IDs parameter in the
        /// same request.</para><para>Default: <c>10</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityReservations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityReservations";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse, GetEC2CapacityReservationTopologyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityReservationId != null)
            {
                context.CapacityReservationId = new List<System.String>(this.CapacityReservationId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.EC2.Model.DescribeCapacityReservationTopologyRequest();
            
            if (cmdletContext.CapacityReservationId != null)
            {
                request.CapacityReservationIds = cmdletContext.CapacityReservationId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeCapacityReservationTopologyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeCapacityReservationTopology");
            try
            {
                #if DESKTOP
                return client.DescribeCapacityReservationTopology(request);
                #elif CORECLR
                return client.DescribeCapacityReservationTopologyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CapacityReservationId { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeCapacityReservationTopologyResponse, GetEC2CapacityReservationTopologyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityReservations;
        }
        
    }
}
