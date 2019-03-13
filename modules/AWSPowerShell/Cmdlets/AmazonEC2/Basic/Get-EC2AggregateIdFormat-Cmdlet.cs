/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes the longer ID format settings for all resource types in a specific region.
    /// This request is useful for performing a quick audit to determine whether a specific
    /// region is fully opted in for longer IDs (17-character IDs).
    /// 
    ///  
    /// <para>
    /// This request only returns information about resource types that support longer IDs.
    /// </para><para>
    /// The following resource types support longer IDs: <code>bundle</code> | <code>conversion-task</code>
    /// | <code>customer-gateway</code> | <code>dhcp-options</code> | <code>elastic-ip-allocation</code>
    /// | <code>elastic-ip-association</code> | <code>export-task</code> | <code>flow-log</code>
    /// | <code>image</code> | <code>import-task</code> | <code>instance</code> | <code>internet-gateway</code>
    /// | <code>network-acl</code> | <code>network-acl-association</code> | <code>network-interface</code>
    /// | <code>network-interface-attachment</code> | <code>prefix-list</code> | <code>reservation</code>
    /// | <code>route-table</code> | <code>route-table-association</code> | <code>security-group</code>
    /// | <code>snapshot</code> | <code>subnet</code> | <code>subnet-cidr-block-association</code>
    /// | <code>volume</code> | <code>vpc</code> | <code>vpc-cidr-block-association</code>
    /// | <code>vpc-endpoint</code> | <code>vpc-peering-connection</code> | <code>vpn-connection</code>
    /// | <code>vpn-gateway</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2AggregateIdFormat")]
    [OutputType("Amazon.EC2.Model.DescribeAggregateIdFormatResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeAggregateIdFormat API operation.", Operation = new[] {"DescribeAggregateIdFormat"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DescribeAggregateIdFormatResponse",
        "This cmdlet returns a Amazon.EC2.Model.DescribeAggregateIdFormatResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AggregateIdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
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
            var request = new Amazon.EC2.Model.DescribeAggregateIdFormatRequest();
            
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.EC2.Model.DescribeAggregateIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAggregateIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeAggregateIdFormat");
            try
            {
                #if DESKTOP
                return client.DescribeAggregateIdFormat(request);
                #elif CORECLR
                return client.DescribeAggregateIdFormatAsync(request).GetAwaiter().GetResult();
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
        }
        
    }
}
