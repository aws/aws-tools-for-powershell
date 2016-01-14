/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// For more information about Reserved Instances, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/concepts-on-demand-reserved-instances.html">Reserved
    /// Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstance")]
    [OutputType("Amazon.EC2.Model.ReservedInstances")]
    [AWSCmdlet("Invokes the DescribeReservedInstances operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeReservedInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstances",
        "This cmdlet returns a collection of ReservedInstances objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2ReservedInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone where the Reserved Instance
        /// can be used.</para></li><li><para><code>duration</code> - The duration of the Reserved Instance (one year or three years),
        /// in seconds (<code>31536000</code> | <code>94608000</code>).</para></li><li><para><code>end</code> - The time when the Reserved Instance expires (for example, 2015-08-07T11:54:42.000Z).</para></li><li><para><code>fixed-price</code> - The purchase price of the Reserved Instance (for example,
        /// 9800.0).</para></li><li><para><code>instance-type</code> - The instance type that is covered by the reservation.</para></li><li><para><code>product-description</code> - The Reserved Instance product platform description.
        /// Instances that include <code>(Amazon VPC)</code> in the product platform description
        /// will only be displayed to EC2-Classic account holders and are for use with Amazon
        /// VPC (<code>Linux/UNIX</code> | <code>Linux/UNIX (Amazon VPC)</code> | <code>SUSE Linux</code>
        /// | <code>SUSE Linux (Amazon VPC)</code> | <code>Red Hat Enterprise Linux</code> | <code>Red
        /// Hat Enterprise Linux (Amazon VPC)</code> | <code>Windows</code> | <code>Windows (Amazon
        /// VPC)</code> | <code>Windows with SQL Server Standard</code> | <code>Windows with SQL
        /// Server Standard (Amazon VPC)</code> | <code>Windows with SQL Server Web</code> | <code>Windows
        /// with SQL Server Web (Amazon VPC)</code> | <code>Windows with SQL Server Enterprise</code>
        /// | <code>Windows with SQL Server Enterprise (Amazon VPC)</code>).</para></li><li><para><code>reserved-instances-id</code> - The ID of the Reserved Instance.</para></li><li><para><code>start</code> - The time at which the Reserved Instance purchase request was
        /// placed (for example, 2014-08-07T11:54:42.000Z).</para></li><li><para><code>state</code> - The state of the Reserved Instance (<code>payment-pending</code>
        /// | <code>active</code> | <code>payment-failed</code> | <code>retired</code>).</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>usage-price</code> - The usage price of the Reserved Instance, per hour (for
        /// example, 0.84).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The Reserved Instance offering type. If you are using tools that predate the 2011-11-01
        /// API version, you only have access to the <code>Medium Utilization</code> Reserved
        /// Instance offering type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.OfferingType = this.OfferingType;
            if (this.ReservedInstancesId != null)
            {
                context.ReservedInstancesIds = new List<System.String>(this.ReservedInstancesId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeReservedInstancesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ReservedInstancesIds != null)
            {
                request.ReservedInstancesIds = cmdletContext.ReservedInstancesIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeReservedInstances(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedInstances;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
            public List<System.String> ReservedInstancesIds { get; set; }
        }
        
    }
}
