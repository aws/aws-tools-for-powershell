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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Returns the current provisioned-capacity limits for your AWS account in a region,
    /// both for the region as a whole and for any one DynamoDB table that you create there.
    /// 
    ///  
    /// <para>
    /// When you establish an AWS account, the account has initial limits on the maximum read
    /// capacity units and write capacity units that you can provision across all of your
    /// DynamoDB tables in a given region. Also, there are per-table limits that apply when
    /// you create a table there. For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Limits.html">Limits</a>
    /// page in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para><para>
    /// Although you can increase these limits by filing a case at <a href="https://console.aws.amazon.com/support/home#/">AWS
    /// Support Center</a>, obtaining the increase is not instantaneous. The <code>DescribeLimits</code>
    /// action lets you write code to compare the capacity you are currently using to those
    /// limits imposed by your account so that you have enough time to apply for an increase
    /// before you hit a limit.
    /// </para><para>
    /// For example, you could use one of the AWS SDKs to do the following:
    /// </para><ol><li><para>
    /// Call <code>DescribeLimits</code> for a particular region to obtain your current account
    /// limits on provisioned capacity there.
    /// </para></li><li><para>
    /// Create a variable to hold the aggregate read capacity units provisioned for all your
    /// tables in that region, and one to hold the aggregate write capacity units. Zero them
    /// both.
    /// </para></li><li><para>
    /// Call <code>ListTables</code> to obtain a list of all your DynamoDB tables.
    /// </para></li><li><para>
    /// For each table name listed by <code>ListTables</code>, do the following:
    /// </para><ul><li><para>
    /// Call <code>DescribeTable</code> with the table name.
    /// </para></li><li><para>
    /// Use the data returned by <code>DescribeTable</code> to add the read capacity units
    /// and write capacity units provisioned for the table itself to your variables.
    /// </para></li><li><para>
    /// If the table has one or more global secondary indexes (GSIs), loop over these GSIs
    /// and add their provisioned capacity values to your variables as well.
    /// </para></li></ul></li><li><para>
    /// Report the account limits for that region returned by <code>DescribeLimits</code>,
    /// along with the total current provisioned capacity levels you have calculated.
    /// </para></li></ol><para>
    /// This will let you see whether you are getting close to your account-level limits.
    /// </para><para>
    /// The per-table limits apply only when you are creating a new table. They restrict the
    /// sum of the provisioned capacity of the new table itself and all its global secondary
    /// indexes.
    /// </para><para>
    /// For existing tables and their GSIs, DynamoDB will not let you increase provisioned
    /// capacity extremely rapidly, but the only upper limit that applies is that the aggregate
    /// provisioned capacity over all your tables and GSIs cannot exceed either of the per-account
    /// limits.
    /// </para><note><para><code>DescribeLimits</code> should only be called periodically. You can expect throttling
    /// errors if you call it more than once in a minute.
    /// </para></note><para>
    /// The <code>DescribeLimits</code> Request element has no content.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBProvisionLimit")]
    [OutputType("Amazon.DynamoDBv2.Model.DescribeLimitsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeLimits API operation.", Operation = new[] {"DescribeLimits"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.DescribeLimitsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.DescribeLimitsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBProvisionLimitCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
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
            var request = new Amazon.DynamoDBv2.Model.DescribeLimitsRequest();
            
            
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
        
        private Amazon.DynamoDBv2.Model.DescribeLimitsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeLimits");
            try
            {
                #if DESKTOP
                return client.DescribeLimits(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeLimitsAsync(request);
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
        }
        
    }
}
