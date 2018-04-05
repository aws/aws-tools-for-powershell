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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the number of compliant and noncompliant rules for one or more accounts and
    /// regions in an aggregator.
    /// 
    ///  <note><para>
    /// The results can return an empty result page, but if you have a nextToken, the results
    /// are displayed on the next page.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateConfigRuleComplianceSummary")]
    [OutputType("Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryResponse")]
    [AWSCmdlet("Calls the AWS Config GetAggregateConfigRuleComplianceSummary API operation.", Operation = new[] {"GetAggregateConfigRuleComplianceSummary"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryResponse",
        "This cmdlet returns a Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateConfigRuleComplianceSummaryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the source account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source region where the data is aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_AwsRegion { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter GroupByKey
        /// <summary>
        /// <para>
        /// <para>Groups the result based on ACCOUNT_ID or AWS_REGION.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ConfigRuleComplianceSummaryGroupKey")]
        public Amazon.ConfigService.ConfigRuleComplianceSummaryGroupKey GroupByKey { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. The default is 1000.
        /// You cannot specify a number greater than 1000. If you specify 0, AWS Config uses the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string returned on a previous page that you use to get the next page
        /// of results in a paginated response.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_AwsRegion = this.Filters_AwsRegion;
            context.GroupByKey = this.GroupByKey;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ConfigRuleComplianceSummaryFilters();
            System.String requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountId = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_AwsRegion = null;
            if (cmdletContext.Filters_AwsRegion != null)
            {
                requestFilters_filters_AwsRegion = cmdletContext.Filters_AwsRegion;
            }
            if (requestFilters_filters_AwsRegion != null)
            {
                request.Filters.AwsRegion = requestFilters_filters_AwsRegion;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.GroupByKey != null)
            {
                request.GroupByKey = cmdletContext.GroupByKey;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
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
        
        private Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetAggregateConfigRuleComplianceSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetAggregateConfigRuleComplianceSummary");
            try
            {
                #if DESKTOP
                return client.GetAggregateConfigRuleComplianceSummary(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetAggregateConfigRuleComplianceSummaryAsync(request);
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
            public System.String ConfigurationAggregatorName { get; set; }
            public System.String Filters_AccountId { get; set; }
            public System.String Filters_AwsRegion { get; set; }
            public Amazon.ConfigService.ConfigRuleComplianceSummaryGroupKey GroupByKey { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
