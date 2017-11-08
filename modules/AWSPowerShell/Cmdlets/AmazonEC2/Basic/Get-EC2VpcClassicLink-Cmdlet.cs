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
    /// Describes the ClassicLink status of one or more VPCs.
    /// </summary>
    [Cmdlet("Get", "EC2VpcClassicLink")]
    [OutputType("Amazon.EC2.Model.VpcClassicLink")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeVpcClassicLink API operation.", Operation = new[] {"DescribeVpcClassicLink"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcClassicLink",
        "This cmdlet returns a collection of VpcClassicLink objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVpcClassicLinkResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2VpcClassicLinkCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>is-classic-link-enabled</code> - Whether the VPC is enabled for ClassicLink
        /// (<code>true</code> | <code>false</code>).</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource. Specify the key of the tag in the filter name and the value of the
        /// tag in the filter value. For example, for the tag Purpose=X, specify <code>tag:Purpose</code>
        /// for the filter name and <code>X</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is
        /// independent of the <code>tag-value</code> filter. For example, if you use both the
        /// filter "tag-key=Purpose" and the filter "tag-value=X", you get any resources assigned
        /// both the tag key Purpose (regardless of what the tag's value is), and the tag value
        /// X (regardless of what the tag's key is). If you want to list only resources where
        /// Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i> filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>One or more VPCs for which you want to describe the ClassicLink status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VpcIds")]
        public System.String[] VpcId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.VpcId != null)
            {
                context.VpcIds = new List<System.String>(this.VpcId);
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
            var request = new Amazon.EC2.Model.DescribeVpcClassicLinkRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.VpcIds != null)
            {
                request.VpcIds = cmdletContext.VpcIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Vpcs;
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
        
        private Amazon.EC2.Model.DescribeVpcClassicLinkResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVpcClassicLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeVpcClassicLink");
            try
            {
                #if DESKTOP
                return client.DescribeVpcClassicLink(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVpcClassicLinkAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> VpcIds { get; set; }
        }
        
    }
}
