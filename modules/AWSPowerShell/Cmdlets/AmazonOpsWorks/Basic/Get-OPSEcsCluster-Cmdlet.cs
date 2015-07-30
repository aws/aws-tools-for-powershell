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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describes Amazon ECS clusters that are registered with a stack. If you specify only
    /// a stack ID, you can use the <code>MaxResults</code> and <code>NextToken</code> parameters
    /// to paginate the response. However, AWS OpsWorks currently supports only one cluster
    /// per layer, so the result set has a maximum of one element.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Show, Deploy,
    /// or Manage permissions level for the stack or an attached policy that explicitly grants
    /// permission. For more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OPSEcsCluster")]
    [OutputType("Amazon.OpsWorks.Model.EcsCluster")]
    [AWSCmdlet("Invokes the DescribeEcsClusters operation against AWS OpsWorks.", Operation = new[] {"DescribeEcsClusters"})]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.EcsCluster",
        "This cmdlet returns a collection of EcsCluster objects.",
        "The service call response (type DescribeEcsClustersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetOPSEcsClusterCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of ARNs, one for each cluster to be described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EcsClusterArns")]
        public System.String[] EcsClusterArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A stack ID. <code>DescribeEcsClusters</code> returns a description of the cluster
        /// that is registered with the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>To receive a paginated response, use this parameter to specify the maximum number
        /// of results to be returned with a single call. If the number of available results exceeds
        /// this maximum, the response includes a <code>NextToken</code> value that you can assign
        /// to the <code>NextToken</code> request parameter to get the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public Int32 MaxResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If the previous paginated request did not return all of the remaining results, the
        /// response object's<code>NextToken</code> parameter value is set to a token. To retrieve
        /// the next set of results, call <code>DescribeEcsClusters</code> again and assign that
        /// token to the request object's <code>NextToken</code> parameter. If there are no remaining
        /// results, the previous response object's <code>NextToken</code> parameter is set to
        /// <code>null</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.EcsClusterArn != null)
            {
                context.EcsClusterArns = new List<String>(this.EcsClusterArn);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StackId = this.StackId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeEcsClustersRequest();
            
            if (cmdletContext.EcsClusterArns != null)
            {
                request.EcsClusterArns = cmdletContext.EcsClusterArns;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeEcsClusters(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EcsClusters;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> EcsClusterArns { get; set; }
            public Int32? MaxResults { get; set; }
            public String NextToken { get; set; }
            public String StackId { get; set; }
        }
        
    }
}
