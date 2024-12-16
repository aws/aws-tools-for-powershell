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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns a list of entity aggregates for your Organizations that are affected by each
    /// of the specified events.
    /// </summary>
    [Cmdlet("Get", "HLTHEntityAggregatesForOrganization")]
    [OutputType("Amazon.AWSHealth.Model.OrganizationEntityAggregate")]
    [AWSCmdlet("Calls the AWS Health DescribeEntityAggregatesForOrganization API operation.", Operation = new[] {"DescribeEntityAggregatesForOrganization"}, SelectReturnType = typeof(Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.OrganizationEntityAggregate or Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse",
        "This cmdlet returns a collection of Amazon.AWSHealth.Model.OrganizationEntityAggregate objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetHLTHEntityAggregatesForOrganizationCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>A list of 12-digit Amazon Web Services account numbers that contains the affected
        /// entities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsAccountIds")]
        public System.String[] AwsAccountId { get; set; }
        #endregion
        
        #region Parameter EventArn
        /// <summary>
        /// <para>
        /// <para>A list of event ARNs (unique identifiers). For example: <c>"arn:aws:health:us-east-1::event/EC2/EC2_INSTANCE_RETIREMENT_SCHEDULED/EC2_INSTANCE_RETIREMENT_SCHEDULED_ABC123-CDE456",
        /// "arn:aws:health:us-west-1::event/EBS/AWS_EBS_LOST_VOLUME/AWS_EBS_LOST_VOLUME_CHI789_JKL101"</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EventArns")]
        public System.String[] EventArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationEntityAggregates'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationEntityAggregates";
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
                context.Select = CreateSelectDelegate<Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse, GetHLTHEntityAggregatesForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AwsAccountId != null)
            {
                context.AwsAccountId = new List<System.String>(this.AwsAccountId);
            }
            if (this.EventArn != null)
            {
                context.EventArn = new List<System.String>(this.EventArn);
            }
            #if MODULAR
            if (this.EventArn == null && ParameterWasBound(nameof(this.EventArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountIds = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.EventArn != null)
            {
                request.EventArns = cmdletContext.EventArn;
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
        
        private Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEntityAggregatesForOrganization");
            try
            {
                #if DESKTOP
                return client.DescribeEntityAggregatesForOrganization(request);
                #elif CORECLR
                return client.DescribeEntityAggregatesForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AwsAccountId { get; set; }
            public List<System.String> EventArn { get; set; }
            public System.Func<Amazon.AWSHealth.Model.DescribeEntityAggregatesForOrganizationResponse, GetHLTHEntityAggregatesForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationEntityAggregates;
        }
        
    }
}
