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
using Amazon.IAMToolbox;
using Amazon.IAMToolbox.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAMTB
{
    /// <summary>
    /// Retrieves the authorization details for a specific access denied request. The details
    /// include the request context, the evaluations performed, and the policies that were
    /// evaluated.
    /// 
    ///  
    /// <para>
    /// Use this operation to understand why a request was denied. Supported services include
    /// an authorization ID in the access denied error message. Pass that ID to this operation
    /// to retrieve the details.
    /// </para><para>
    /// Authorization details are available for at least 24 hours after the denial.
    /// </para><para>
    /// To use this operation, you must have the <c>iam:GetRequestAuthorizationDetails</c>
    /// permission.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IAMTBRequestAuthorizationDetail")]
    [OutputType("Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse")]
    [AWSCmdlet("Calls the IAM Toolbox (Preview) GetRequestAuthorizationDetails API operation.", Operation = new[] {"GetRequestAuthorizationDetails"}, SelectReturnType = typeof(Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse))]
    [AWSCmdletOutput("Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse",
        "This cmdlet returns an Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse object containing multiple properties."
    )]
    public partial class GetIAMTBRequestAuthorizationDetailCmdlet : AmazonIAMToolboxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthorizationId
        /// <summary>
        /// <para>
        /// <para>The authorization ID received in the access denied error message. This ID identifies
        /// the specific request to retrieve details for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AuthorizationId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from a previous call, used to retrieve the next page of evaluations.
        /// Omit this value on the first call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse).
        /// Specifying the name of a property of type Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse, GetIAMTBRequestAuthorizationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizationId = this.AuthorizationId;
            #if MODULAR
            if (this.AuthorizationId == null && ParameterWasBound(nameof(this.AuthorizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsRequest();
            
            if (cmdletContext.AuthorizationId != null)
            {
                request.AuthorizationId = cmdletContext.AuthorizationId;
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
        
        private Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse CallAWSServiceOperation(IAmazonIAMToolbox client, Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Toolbox (Preview)", "GetRequestAuthorizationDetails");
            try
            {
                return client.GetRequestAuthorizationDetailsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuthorizationId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IAMToolbox.Model.GetRequestAuthorizationDetailsResponse, GetIAMTBRequestAuthorizationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
