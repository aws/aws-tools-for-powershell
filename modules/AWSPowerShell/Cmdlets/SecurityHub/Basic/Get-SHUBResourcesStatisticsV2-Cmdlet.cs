/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Retrieves statistical information about Amazon Web Services resources and their associated
    /// security findings. This API is in private preview and subject to change.
    /// </summary>
    [Cmdlet("Get", "SHUBResourcesStatisticsV2")]
    [OutputType("Amazon.SecurityHub.Model.GroupByResult")]
    [AWSCmdlet("Calls the AWS Security Hub GetResourcesStatisticsV2 API operation.", Operation = new[] {"GetResourcesStatisticsV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.GroupByResult or Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.GroupByResult objects.",
        "The service call response (type Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBResourcesStatisticsV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupByRule
        /// <summary>
        /// <para>
        /// <para>How resource statistics should be aggregated and organized in the response.</para>
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
        [Alias("GroupByRules")]
        public Amazon.SecurityHub.Model.ResourceGroupByRule[] GroupByRule { get; set; }
        #endregion
        
        #region Parameter MaxStatisticResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxStatisticResults")]
        public System.Int32? MaxStatisticResult { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Sorts aggregated statistics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.SortOrder")]
        public Amazon.SecurityHub.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GroupByResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GroupByResults";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response, GetSHUBResourcesStatisticsV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GroupByRule != null)
            {
                context.GroupByRule = new List<Amazon.SecurityHub.Model.ResourceGroupByRule>(this.GroupByRule);
            }
            #if MODULAR
            if (this.GroupByRule == null && ParameterWasBound(nameof(this.GroupByRule)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupByRule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxStatisticResult = this.MaxStatisticResult;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.SecurityHub.Model.GetResourcesStatisticsV2Request();
            
            if (cmdletContext.GroupByRule != null)
            {
                request.GroupByRules = cmdletContext.GroupByRule;
            }
            if (cmdletContext.MaxStatisticResult != null)
            {
                request.MaxStatisticResults = cmdletContext.MaxStatisticResult.Value;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetResourcesStatisticsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetResourcesStatisticsV2");
            try
            {
                #if DESKTOP
                return client.GetResourcesStatisticsV2(request);
                #elif CORECLR
                return client.GetResourcesStatisticsV2Async(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.ResourceGroupByRule> GroupByRule { get; set; }
            public System.Int32? MaxStatisticResult { get; set; }
            public Amazon.SecurityHub.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetResourcesStatisticsV2Response, GetSHUBResourcesStatisticsV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GroupByResults;
        }
        
    }
}
