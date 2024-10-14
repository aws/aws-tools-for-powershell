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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Provides descriptions of the schemas discovered by your Fleet Advisor collectors.
    /// </summary>
    [Cmdlet("Get", "DMSFleetAdvisorSchemaObjectSummary")]
    [OutputType("Amazon.DatabaseMigrationService.Model.FleetAdvisorSchemaObjectResponse")]
    [AWSCmdlet("Calls the AWS Database Migration Service DescribeFleetAdvisorSchemaObjectSummary API operation.", Operation = new[] {"DescribeFleetAdvisorSchemaObjectSummary"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.FleetAdvisorSchemaObjectResponse or Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse",
        "This cmdlet returns a collection of Amazon.DatabaseMigrationService.Model.FleetAdvisorSchemaObjectResponse objects.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDMSFleetAdvisorSchemaObjectSummaryCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> If you specify any of the following filters, the output includes information for
        /// only those schema objects that meet the filter criteria:</para><ul><li><para><c>schema-id</c> – The ID of the schema, for example <c>d4610ac5-e323-4ad9-bc50-eaf7249dfe9d</c>.</para></li></ul><para>Example: <c>describe-fleet-advisor-schema-object-summary --filter Name="schema-id",Values="50"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.DatabaseMigrationService.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of records returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If <c>NextToken</c> is returned by a previous response, there are more results available.
        /// The value of <c>NextToken</c> is a unique pagination token for each page. Make the
        /// call again using the returned token to retrieve the next page. Keep all other arguments
        /// unchanged. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FleetAdvisorSchemaObjects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FleetAdvisorSchemaObjects";
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
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse, GetDMSFleetAdvisorSchemaObjectSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.DatabaseMigrationService.Model.Filter>(this.Filter);
            }
            context.MaxRecord = this.MaxRecord;
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
            var request = new Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "DescribeFleetAdvisorSchemaObjectSummary");
            try
            {
                #if DESKTOP
                return client.DescribeFleetAdvisorSchemaObjectSummary(request);
                #elif CORECLR
                return client.DescribeFleetAdvisorSchemaObjectSummaryAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DatabaseMigrationService.Model.Filter> Filter { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.DescribeFleetAdvisorSchemaObjectSummaryResponse, GetDMSFleetAdvisorSchemaObjectSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetAdvisorSchemaObjects;
        }
        
    }
}
