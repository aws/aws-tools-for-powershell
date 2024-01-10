/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns the current provisioned-capacity quotas for your Amazon Web Services account
    /// in a Region, both for the Region as a whole and for any one DynamoDB table that you
    /// create there.
    /// 
    ///  
    /// <para>
    /// When you establish an Amazon Web Services account, the account has initial quotas
    /// on the maximum read capacity units and write capacity units that you can provision
    /// across all of your DynamoDB tables in a given Region. Also, there are per-table quotas
    /// that apply when you create a table there. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Limits.html">Service,
    /// Account, and Table Quotas</a> page in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para><para>
    /// Although you can increase these quotas by filing a case at <a href="https://console.aws.amazon.com/support/home#/">Amazon
    /// Web Services Support Center</a>, obtaining the increase is not instantaneous. The
    /// <c>DescribeLimits</c> action lets you write code to compare the capacity you are currently
    /// using to those quotas imposed by your account so that you have enough time to apply
    /// for an increase before you hit a quota.
    /// </para><para>
    /// For example, you could use one of the Amazon Web Services SDKs to do the following:
    /// </para><ol><li><para>
    /// Call <c>DescribeLimits</c> for a particular Region to obtain your current account
    /// quotas on provisioned capacity there.
    /// </para></li><li><para>
    /// Create a variable to hold the aggregate read capacity units provisioned for all your
    /// tables in that Region, and one to hold the aggregate write capacity units. Zero them
    /// both.
    /// </para></li><li><para>
    /// Call <c>ListTables</c> to obtain a list of all your DynamoDB tables.
    /// </para></li><li><para>
    /// For each table name listed by <c>ListTables</c>, do the following:
    /// </para><ul><li><para>
    /// Call <c>DescribeTable</c> with the table name.
    /// </para></li><li><para>
    /// Use the data returned by <c>DescribeTable</c> to add the read capacity units and write
    /// capacity units provisioned for the table itself to your variables.
    /// </para></li><li><para>
    /// If the table has one or more global secondary indexes (GSIs), loop over these GSIs
    /// and add their provisioned capacity values to your variables as well.
    /// </para></li></ul></li><li><para>
    /// Report the account quotas for that Region returned by <c>DescribeLimits</c>, along
    /// with the total current provisioned capacity levels you have calculated.
    /// </para></li></ol><para>
    /// This will let you see whether you are getting close to your account-level quotas.
    /// </para><para>
    /// The per-table quotas apply only when you are creating a new table. They restrict the
    /// sum of the provisioned capacity of the new table itself and all its global secondary
    /// indexes.
    /// </para><para>
    /// For existing tables and their GSIs, DynamoDB doesn't let you increase provisioned
    /// capacity extremely rapidly, but the only quota that applies is that the aggregate
    /// provisioned capacity over all your tables and GSIs cannot exceed either of the per-account
    /// quotas.
    /// </para><note><para><c>DescribeLimits</c> should only be called periodically. You can expect throttling
    /// errors if you call it more than once in a minute.
    /// </para></note><para>
    /// The <c>DescribeLimits</c> Request element has no content.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBProvisionLimit")]
    [OutputType("Amazon.DynamoDBv2.Model.DescribeLimitsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeLimits API operation.", Operation = new[] {"DescribeLimits"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.DescribeLimitsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.DescribeLimitsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.DescribeLimitsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBProvisionLimitCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.DescribeLimitsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.DescribeLimitsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.DescribeLimitsResponse, GetDDBProvisionLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.DynamoDBv2.Model.DescribeLimitsRequest();
            
            
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
        
        private Amazon.DynamoDBv2.Model.DescribeLimitsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeLimits");
            try
            {
                #if DESKTOP
                return client.DescribeLimits(request);
                #elif CORECLR
                return client.DescribeLimitsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.DynamoDBv2.Model.DescribeLimitsResponse, GetDDBProvisionLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
