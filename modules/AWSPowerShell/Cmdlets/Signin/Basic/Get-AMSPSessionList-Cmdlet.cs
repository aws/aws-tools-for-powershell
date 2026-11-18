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
using Amazon.Signin;
using Amazon.Signin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMSP
{
    /// <summary>
    /// Lists sign-in sessions for an IAM identity in your account. If you omit principalArn,
    /// the operation lists the caller's own sessions. Specify a user or role ARN to list
    /// that identity's sessions, or specify arn:aws:iam::{account-id}:* to list all sessions
    /// in the account. Filters are combined with a logical AND.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AMSPSessionList")]
    [OutputType("Amazon.Signin.Model.Session")]
    [AWSCmdlet("Calls the AWS Sign-In Service ListSessions API operation.", Operation = new[] {"ListSessions"}, SelectReturnType = typeof(Amazon.Signin.Model.ListSessionsResponse))]
    [AWSCmdletOutput("Amazon.Signin.Model.Session or Amazon.Signin.Model.ListSessionsResponse",
        "This cmdlet returns a collection of Amazon.Signin.Model.Session objects.",
        "The service call response (type Amazon.Signin.Model.ListSessionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAMSPSessionListCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// Returns only sessions created by this OAuth client
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter IssuedAfter
        /// <summary>
        /// <para>
        /// Returns only sessions created at or after
        /// this time, in Unix epoch seconds
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? IssuedAfter { get; set; }
        #endregion
        
        #region Parameter IssuedBefore
        /// <summary>
        /// <para>
        /// Returns only sessions created before this
        /// time, in Unix epoch seconds
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? IssuedBefore { get; set; }
        #endregion
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// The identity whose sessions to list. Omit
        /// to list the caller's own sessions. Specify arn:aws:iam::{account-id}:* to list all
        /// sessions in the account.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// Returns only sessions with this status
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Signin.SessionStatus")]
        public Amazon.Signin.SessionStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// Maximum number of results to return
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// Token for pagination
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.ListSessionsResponse).
        /// Specifying the name of a property of type Amazon.Signin.Model.ListSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.ListSessionsResponse, GetAMSPSessionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientId = this.ClientId;
            context.IssuedAfter = this.IssuedAfter;
            context.IssuedBefore = this.IssuedBefore;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.PrincipalArn = this.PrincipalArn;
            context.Status = this.Status;
            
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
            var request = new Amazon.Signin.Model.ListSessionsRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.IssuedAfter != null)
            {
                request.IssuedAfter = cmdletContext.IssuedAfter.Value;
            }
            if (cmdletContext.IssuedBefore != null)
            {
                request.IssuedBefore = cmdletContext.IssuedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Signin.Model.ListSessionsResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.ListSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Service", "ListSessions");
            try
            {
                return client.ListSessionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public System.Int64? IssuedAfter { get; set; }
            public System.Int64? IssuedBefore { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PrincipalArn { get; set; }
            public Amazon.Signin.SessionStatus Status { get; set; }
            public System.Func<Amazon.Signin.Model.ListSessionsResponse, GetAMSPSessionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
