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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Lists the applications to which a specified principal is assigned.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SSOADMNApplicationAssignmentsForPrincipalList")]
    [OutputType("Amazon.SSOAdmin.Model.ApplicationAssignmentForPrincipal")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin ListApplicationAssignmentsForPrincipal API operation.", Operation = new[] {"ListApplicationAssignmentsForPrincipal"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.ApplicationAssignmentForPrincipal or Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse",
        "This cmdlet returns a collection of Amazon.SSOAdmin.Model.ApplicationAssignmentForPrincipal objects.",
        "The service call response (type Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSOADMNApplicationAssignmentsForPrincipalListCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>Specifies the instance of IAM Identity Center that contains principal and applications.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter PrincipalId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique identifier of the principal for which you want to retrieve its
        /// assignments.</para>
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
        public System.String PrincipalId { get; set; }
        #endregion
        
        #region Parameter PrincipalType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the principal for which you want to retrieve its assignments.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.PrincipalType")]
        public Amazon.SSOAdmin.PrincipalType PrincipalType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the total number of results that you want included in each response. If
        /// additional items exist beyond the number you specify, the <c>NextToken</c> response
        /// element is returned with a value (not null). Include the specified value as the <c>NextToken</c>
        /// request parameter in the next call to the operation to get the next set of results.
        /// Note that the service might return fewer results than the maximum even when there
        /// are more results available. You should check <c>NextToken</c> after every operation
        /// to ensure that you receive all of the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to receive the next page of results. Valid only if you received
        /// a <c>NextToken</c> response in the previous request. If you did, it indicates that
        /// more output is available. Set this parameter to the value provided by the previous
        /// call's <c>NextToken</c> response to request the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationAssignments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationAssignments";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse, GetSSOADMNApplicationAssignmentsForPrincipalListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_ApplicationArn = this.Filter_ApplicationArn;
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PrincipalId = this.PrincipalId;
            #if MODULAR
            if (this.PrincipalId == null && ParameterWasBound(nameof(this.PrincipalId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalType = this.PrincipalType;
            #if MODULAR
            if (this.PrincipalType == null && ParameterWasBound(nameof(this.PrincipalType)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.SSOAdmin.Model.ListApplicationAssignmentsFilter();
            System.String requestFilter_filter_ApplicationArn = null;
            if (cmdletContext.Filter_ApplicationArn != null)
            {
                requestFilter_filter_ApplicationArn = cmdletContext.Filter_ApplicationArn;
            }
            if (requestFilter_filter_ApplicationArn != null)
            {
                request.Filter.ApplicationArn = requestFilter_filter_ApplicationArn;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PrincipalId != null)
            {
                request.PrincipalId = cmdletContext.PrincipalId;
            }
            if (cmdletContext.PrincipalType != null)
            {
                request.PrincipalType = cmdletContext.PrincipalType;
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
        
        private Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "ListApplicationAssignmentsForPrincipal");
            try
            {
                return client.ListApplicationAssignmentsForPrincipalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Filter_ApplicationArn { get; set; }
            public System.String InstanceArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PrincipalId { get; set; }
            public Amazon.SSOAdmin.PrincipalType PrincipalType { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.ListApplicationAssignmentsForPrincipalResponse, GetSSOADMNApplicationAssignmentsForPrincipalListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationAssignments;
        }
        
    }
}
