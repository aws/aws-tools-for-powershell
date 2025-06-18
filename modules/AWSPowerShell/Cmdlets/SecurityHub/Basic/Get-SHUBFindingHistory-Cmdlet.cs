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
using System.Threading;
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Returns the history of a Security Hub finding for the past 90 days. The history includes
    /// changes made to any fields in the Amazon Web Services Security Finding Format (ASFF)
    /// except top-level timestamp fields, such as the <c>CreatedAt</c> and <c>UpdatedAt</c>
    /// fields. 
    /// 
    ///  
    /// <para>
    /// This operation might return fewer results than the maximum number of results (<c>MaxResults</c>)
    /// specified in a request, even when more results are available. If this occurs, the
    /// response includes a <c>NextToken</c> value, which you should use to retrieve the next
    /// set of results in the response. The presence of a <c>NextToken</c> value in a response
    /// doesn't necessarily indicate that the results are incomplete. However, you should
    /// continue to specify a <c>NextToken</c> value until you receive a response that doesn't
    /// include this value.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBFindingHistory")]
    [OutputType("Amazon.SecurityHub.Model.FindingHistoryRecord")]
    [AWSCmdlet("Calls the AWS Security Hub GetFindingHistory API operation.", Operation = new[] {"GetFindingHistory"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetFindingHistoryResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.FindingHistoryRecord or Amazon.SecurityHub.Model.GetFindingHistoryResponse",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.FindingHistoryRecord objects.",
        "The service call response (type Amazon.SecurityHub.Model.GetFindingHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBFindingHistoryCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para> An ISO 8601-formatted timestamp that indicates the end time of the requested finding
        /// history.</para><para>If you provide values for both <c>StartTime</c> and <c>EndTime</c>, Security Hub returns
        /// finding history for the specified time period. If you provide a value for <c>StartTime</c>
        /// but not for <c>EndTime</c>, Security Hub returns finding history from the <c>StartTime</c>
        /// to the time at which the API is called. If you provide a value for <c>EndTime</c>
        /// but not for <c>StartTime</c>, Security Hub returns finding history from the <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/API_AwsSecurityFindingFilters.html#securityhub-Type-AwsSecurityFindingFilters-CreatedAt">CreatedAt</a>
        /// timestamp of the finding to the <c>EndTime</c>. If you provide neither <c>StartTime</c>
        /// nor <c>EndTime</c>, Security Hub returns finding history from the CreatedAt timestamp
        /// of the finding to the time at which the API is called. In all of these scenarios,
        /// the response is limited to 100 results, and the maximum time period is limited to
        /// 90 days.</para><para>For more information about the validation and formatting of timestamp fields in Security
        /// Hub, see <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/Welcome.html#timestamps">Timestamps</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter FindingIdentifier_Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the finding that was specified by the finding provider.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FindingIdentifier_Id { get; set; }
        #endregion
        
        #region Parameter FindingIdentifier_ProductArn
        /// <summary>
        /// <para>
        /// <para>The ARN generated by Security Hub that uniquely identifies a product that generates
        /// findings. This can be the ARN for a third-party product that is integrated with Security
        /// Hub, or the ARN for a custom integration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FindingIdentifier_ProductArn { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>A timestamp that indicates the start time of the requested finding history.</para><para>If you provide values for both <c>StartTime</c> and <c>EndTime</c>, Security Hub returns
        /// finding history for the specified time period. If you provide a value for <c>StartTime</c>
        /// but not for <c>EndTime</c>, Security Hub returns finding history from the <c>StartTime</c>
        /// to the time at which the API is called. If you provide a value for <c>EndTime</c>
        /// but not for <c>StartTime</c>, Security Hub returns finding history from the <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/API_AwsSecurityFindingFilters.html#securityhub-Type-AwsSecurityFindingFilters-CreatedAt">CreatedAt</a>
        /// timestamp of the finding to the <c>EndTime</c>. If you provide neither <c>StartTime</c>
        /// nor <c>EndTime</c>, Security Hub returns finding history from the CreatedAt timestamp
        /// of the finding to the time at which the API is called. In all of these scenarios,
        /// the response is limited to 100 results, and the maximum time period is limited to
        /// 90 days.</para><para>For more information about the validation and formatting of timestamp fields in Security
        /// Hub, see <a href="https://docs.aws.amazon.com/securityhub/1.0/APIReference/Welcome.html#timestamps">Timestamps</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to be returned. If you don’t provide it, Security Hub
        /// returns up to 100 results of finding history. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A token for pagination purposes. Provide <c>NULL</c> as the initial value. In subsequent
        /// requests, provide the token included in the response to get up to an additional 100
        /// results of finding history. If you don’t provide <c>NextToken</c>, Security Hub returns
        /// up to 100 results of finding history for each request. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Records'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetFindingHistoryResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetFindingHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Records";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetFindingHistoryResponse, GetSHUBFindingHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.FindingIdentifier_Id = this.FindingIdentifier_Id;
            #if MODULAR
            if (this.FindingIdentifier_Id == null && ParameterWasBound(nameof(this.FindingIdentifier_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingIdentifier_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FindingIdentifier_ProductArn = this.FindingIdentifier_ProductArn;
            #if MODULAR
            if (this.FindingIdentifier_ProductArn == null && ParameterWasBound(nameof(this.FindingIdentifier_ProductArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingIdentifier_ProductArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SecurityHub.Model.GetFindingHistoryRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            
             // populate FindingIdentifier
            var requestFindingIdentifierIsNull = true;
            request.FindingIdentifier = new Amazon.SecurityHub.Model.AwsSecurityFindingIdentifier();
            System.String requestFindingIdentifier_findingIdentifier_Id = null;
            if (cmdletContext.FindingIdentifier_Id != null)
            {
                requestFindingIdentifier_findingIdentifier_Id = cmdletContext.FindingIdentifier_Id;
            }
            if (requestFindingIdentifier_findingIdentifier_Id != null)
            {
                request.FindingIdentifier.Id = requestFindingIdentifier_findingIdentifier_Id;
                requestFindingIdentifierIsNull = false;
            }
            System.String requestFindingIdentifier_findingIdentifier_ProductArn = null;
            if (cmdletContext.FindingIdentifier_ProductArn != null)
            {
                requestFindingIdentifier_findingIdentifier_ProductArn = cmdletContext.FindingIdentifier_ProductArn;
            }
            if (requestFindingIdentifier_findingIdentifier_ProductArn != null)
            {
                request.FindingIdentifier.ProductArn = requestFindingIdentifier_findingIdentifier_ProductArn;
                requestFindingIdentifierIsNull = false;
            }
             // determine if request.FindingIdentifier should be set to null
            if (requestFindingIdentifierIsNull)
            {
                request.FindingIdentifier = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecurityHub.Model.GetFindingHistoryResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetFindingHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetFindingHistory");
            try
            {
                return client.GetFindingHistoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String FindingIdentifier_Id { get; set; }
            public System.String FindingIdentifier_ProductArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetFindingHistoryResponse, GetSHUBFindingHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Records;
        }
        
    }
}
