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
    /// Describes one or more of the Reserved Instances that you purchased.
    /// 
    ///  
    /// <para>
    /// For more information about Reserved Instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/concepts-on-demand-reserved-instances.html">Reserved
    /// Instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstance")]
    [OutputType("Amazon.EC2.Model.ReservedInstances")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeReservedInstances API operation.", Operation = new[] {"DescribeReservedInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeReservedInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstances or Amazon.EC2.Model.DescribeReservedInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ReservedInstances objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2ReservedInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>availability-zone</c> - The Availability Zone where the Reserved Instance can
        /// be used.</para></li><li><para><c>duration</c> - The duration of the Reserved Instance (one year or three years),
        /// in seconds (<c>31536000</c> | <c>94608000</c>).</para></li><li><para><c>end</c> - The time when the Reserved Instance expires (for example, 2015-08-07T11:54:42.000Z).</para></li><li><para><c>fixed-price</c> - The purchase price of the Reserved Instance (for example, 9800.0).</para></li><li><para><c>instance-type</c> - The instance type that is covered by the reservation.</para></li><li><para><c>scope</c> - The scope of the Reserved Instance (<c>Region</c> or <c>Availability
        /// Zone</c>).</para></li><li><para><c>product-description</c> - The Reserved Instance product platform description (<c>Linux/UNIX</c>
        /// | <c>Linux with SQL Server Standard</c> | <c>Linux with SQL Server Web</c> | <c>Linux
        /// with SQL Server Enterprise</c> | <c>SUSE Linux</c> | <c>Red Hat Enterprise Linux</c>
        /// | <c>Red Hat Enterprise Linux with HA</c> | <c>Windows</c> | <c>Windows with SQL Server
        /// Standard</c> | <c>Windows with SQL Server Web</c> | <c>Windows with SQL Server Enterprise</c>).</para></li><li><para><c>reserved-instances-id</c> - The ID of the Reserved Instance.</para></li><li><para><c>start</c> - The time at which the Reserved Instance purchase request was placed
        /// (for example, 2014-08-07T11:54:42.000Z).</para></li><li><para><c>state</c> - The state of the Reserved Instance (<c>payment-pending</c> | <c>active</c>
        /// | <c>payment-failed</c> | <c>retired</c>).</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>usage-price</c> - The usage price of the Reserved Instance, per hour (for example,
        /// 0.84).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter OfferingClass
        /// <summary>
        /// <para>
        /// <para>Describes whether the Reserved Instance is Standard or Convertible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OfferingClassType")]
        public Amazon.EC2.OfferingClassType OfferingClass { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The Reserved Instance offering type. If you are using tools that predate the 2011-11-01
        /// API version, you only have access to the <c>Medium Utilization</c> Reserved Instance
        /// offering type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OfferingTypeValues")]
        public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesId
        /// <summary>
        /// <para>
        /// <para>One or more Reserved Instance IDs.</para><para>Default: Describes all your Reserved Instances, or only those otherwise specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ReservedInstancesIds")]
        public System.String[] ReservedInstancesId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeReservedInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeReservedInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstances";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeReservedInstancesResponse, GetEC2ReservedInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.OfferingClass = this.OfferingClass;
            context.OfferingType = this.OfferingType;
            if (this.ReservedInstancesId != null)
            {
                context.ReservedInstancesId = new List<System.String>(this.ReservedInstancesId);
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
            var request = new Amazon.EC2.Model.DescribeReservedInstancesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.OfferingClass != null)
            {
                request.OfferingClass = cmdletContext.OfferingClass;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ReservedInstancesId != null)
            {
                request.ReservedInstancesIds = cmdletContext.ReservedInstancesId;
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
        
        private Amazon.EC2.Model.DescribeReservedInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeReservedInstances");
            try
            {
                #if DESKTOP
                return client.DescribeReservedInstances(request);
                #elif CORECLR
                return client.DescribeReservedInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public Amazon.EC2.OfferingClassType OfferingClass { get; set; }
            public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
            public List<System.String> ReservedInstancesId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeReservedInstancesResponse, GetEC2ReservedInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstances;
        }
        
    }
}
