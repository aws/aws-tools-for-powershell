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
    /// Describes attributes of your AWS account. The following are the supported account
    /// attributes:
    /// 
    ///  <ul><li><para><code>supported-platforms</code>: Indicates whether your account can launch instances
    /// into EC2-Classic and EC2-VPC, or only into EC2-VPC.
    /// </para></li><li><para><code>default-vpc</code>: The ID of the default VPC for your account, or <code>none</code>.
    /// </para></li><li><para><code>max-instances</code>: The maximum number of On-Demand instances that you can
    /// run.
    /// </para></li><li><para><code>vpc-max-security-groups-per-interface</code>: The maximum number of security
    /// groups that you can assign to a network interface.
    /// </para></li><li><para><code>max-elastic-ips</code>: The maximum number of Elastic IP addresses that you
    /// can allocate for use with EC2-Classic. 
    /// </para></li><li><para><code>vpc-max-elastic-ips</code>: The maximum number of Elastic IP addresses that
    /// you can allocate for use with EC2-VPC.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "EC2AccountAttribute")]
    [OutputType("Amazon.EC2.Model.AccountAttribute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeAccountAttributes API operation.", Operation = new[] {"DescribeAccountAttributes"}, LegacyAlias="Get-EC2AccountAttributes")]
    [AWSCmdletOutput("Amazon.EC2.Model.AccountAttribute",
        "This cmdlet returns a collection of AccountAttribute objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAccountAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AccountAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>One or more account attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("AccountAttributeNames","AttributeNames")]
        public System.String[] AttributeName { get; set; }
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
            
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
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
            var request = new Amazon.EC2.Model.DescribeAccountAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AccountAttributes;
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
        
        private Amazon.EC2.Model.DescribeAccountAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAccountAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeAccountAttributes");
            try
            {
                #if DESKTOP
                return client.DescribeAccountAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAccountAttributesAsync(request);
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
            public List<System.String> AttributeName { get; set; }
        }
        
    }
}
