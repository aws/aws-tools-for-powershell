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
    /// Describes the modifications made to your Reserved Instances. If no parameter is specified,
    /// information about all your Reserved Instances modification requests is returned. If
    /// a modification ID is specified, only information about the specific modification is
    /// returned.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-modifying.html">Modifying
    /// Reserved Instances</a> in the Amazon Elastic Compute Cloud User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesModifications")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesModification")]
    [AWSCmdlet("Invokes the DescribeReservedInstancesModifications operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeReservedInstancesModifications"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesModification",
        "This cmdlet returns a collection of ReservedInstancesModification objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetEC2ReservedInstancesModificationsCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>client-token</code> - The idempotency token for the modification request.</para></li><li><para><code>create-date</code> - The time when the modification request was created.</para></li><li><para><code>effective-date</code> - The time when the modification becomes effective.</para></li><li><para><code>modification-result.reserved-instances-id</code> - The ID for the Reserved Instances
        /// created as part of the modification request. This ID is only available when the status
        /// of the modification is <code>fulfilled</code>.</para></li><li><para><code>modification-result.target-configuration.availability-zone</code> - The Availability
        /// Zone for the new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.instance-count </code> - The number
        /// of new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.instance-type</code> - The instance
        /// type of the new Reserved Instances.</para></li><li><para><code>modification-result.target-configuration.platform</code> - The network platform
        /// of the new Reserved Instances (<code>EC2-Classic</code> | <code>EC2-VPC</code>).</para></li><li><para><code>reserved-instances-id</code> - The ID of the Reserved Instances modified.</para></li><li><para><code>reserved-instances-modification-id</code> - The ID of the modification request.</para></li><li><para><code>status</code> - The status of the Reserved Instances modification request (<code>processing</code>
        /// | <code>fulfilled</code> | <code>failed</code>).</para></li><li><para><code>status-message</code> - The reason for the status.</para></li><li><para><code>update-date</code> - The time when the modification request was last updated.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesModificationId
        /// <summary>
        /// <para>
        /// <para>IDs for the submitted modification request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReservedInstancesModificationIds")]
        public System.String[] ReservedInstancesModificationId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            context.NextToken = this.NextToken;
            if (this.ReservedInstancesModificationId != null)
            {
                context.ReservedInstancesModificationIds = new List<System.String>(this.ReservedInstancesModificationId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeReservedInstancesModificationsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ReservedInstancesModificationIds != null)
            {
                request.ReservedInstancesModificationIds = cmdletContext.ReservedInstancesModificationIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedInstancesModifications;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        #region AWS Service Operation Call
        
        private static Amazon.EC2.Model.DescribeReservedInstancesModificationsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesModificationsRequest request)
        {
            return client.DescribeReservedInstancesModifications(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ReservedInstancesModificationIds { get; set; }
        }
        
    }
}
