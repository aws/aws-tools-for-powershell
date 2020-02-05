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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists the findings (results) of a Device Defender audit or of the audits performed
    /// during a specified time period. (Findings are retained for 180 days.)<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTAuditFindingList")]
    [OutputType("Amazon.IoT.Model.AuditFinding")]
    [AWSCmdlet("Calls the AWS IoT ListAuditFindings API operation.", Operation = new[] {"ListAuditFindings"}, SelectReturnType = typeof(Amazon.IoT.Model.ListAuditFindingsResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.AuditFinding or Amazon.IoT.Model.ListAuditFindingsResponse",
        "This cmdlet returns a collection of Amazon.IoT.Model.AuditFinding objects.",
        "The service call response (type Amazon.IoT.Model.ListAuditFindingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTAuditFindingListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceIdentifier_Account
        /// <summary>
        /// <para>
        /// <para>The account with which the resource is associated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_Account { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CaCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the CA certificate used to authorize the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_CaCertificateId { get; set; }
        #endregion
        
        #region Parameter CheckName
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to the findings for the specified audit check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_ClientId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CognitoIdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito identity pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_DeviceCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate attached to the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to those found before the specified time. You must specify
        /// either the startTime and endTime or the taskId, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that has overly permissive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyName")]
        public System.String PolicyVersionIdentifier_PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyVersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the version of the policy associated with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId")]
        public System.String PolicyVersionIdentifier_PolicyVersionId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_RoleAliasArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role alias that has overly permissive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier_RoleAliasArn { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to those found after the specified time. You must specify
        /// either the startTime and endTime or the taskId, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to the audit with the specified ID. You must specify either
        /// the taskId or the startTime and endTime, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time. The default is 25.</para>
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
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Findings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.ListAuditFindingsResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.ListAuditFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Findings";
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.ListAuditFindingsResponse, GetIOTAuditFindingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CheckName = this.CheckName;
            context.EndTime = this.EndTime;
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
            context.ResourceIdentifier_Account = this.ResourceIdentifier_Account;
            context.ResourceIdentifier_CaCertificateId = this.ResourceIdentifier_CaCertificateId;
            context.ResourceIdentifier_ClientId = this.ResourceIdentifier_ClientId;
            context.ResourceIdentifier_CognitoIdentityPoolId = this.ResourceIdentifier_CognitoIdentityPoolId;
            context.ResourceIdentifier_DeviceCertificateId = this.ResourceIdentifier_DeviceCertificateId;
            context.ResourceIdentifier_IamRoleArn = this.ResourceIdentifier_IamRoleArn;
            context.PolicyVersionIdentifier_PolicyName = this.PolicyVersionIdentifier_PolicyName;
            context.PolicyVersionIdentifier_PolicyVersionId = this.PolicyVersionIdentifier_PolicyVersionId;
            context.ResourceIdentifier_RoleAliasArn = this.ResourceIdentifier_RoleAliasArn;
            context.StartTime = this.StartTime;
            context.TaskId = this.TaskId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IoT.Model.ListAuditFindingsRequest();
            
            if (cmdletContext.CheckName != null)
            {
                request.CheckName = cmdletContext.CheckName;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate ResourceIdentifier
            var requestResourceIdentifierIsNull = true;
            request.ResourceIdentifier = new Amazon.IoT.Model.ResourceIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_Account = null;
            if (cmdletContext.ResourceIdentifier_Account != null)
            {
                requestResourceIdentifier_resourceIdentifier_Account = cmdletContext.ResourceIdentifier_Account;
            }
            if (requestResourceIdentifier_resourceIdentifier_Account != null)
            {
                request.ResourceIdentifier.Account = requestResourceIdentifier_resourceIdentifier_Account;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CaCertificateId = null;
            if (cmdletContext.ResourceIdentifier_CaCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CaCertificateId = cmdletContext.ResourceIdentifier_CaCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CaCertificateId != null)
            {
                request.ResourceIdentifier.CaCertificateId = requestResourceIdentifier_resourceIdentifier_CaCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_ClientId = null;
            if (cmdletContext.ResourceIdentifier_ClientId != null)
            {
                requestResourceIdentifier_resourceIdentifier_ClientId = cmdletContext.ResourceIdentifier_ClientId;
            }
            if (requestResourceIdentifier_resourceIdentifier_ClientId != null)
            {
                request.ResourceIdentifier.ClientId = requestResourceIdentifier_resourceIdentifier_ClientId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = null;
            if (cmdletContext.ResourceIdentifier_CognitoIdentityPoolId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = cmdletContext.ResourceIdentifier_CognitoIdentityPoolId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId != null)
            {
                request.ResourceIdentifier.CognitoIdentityPoolId = requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = null;
            if (cmdletContext.ResourceIdentifier_DeviceCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = cmdletContext.ResourceIdentifier_DeviceCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_DeviceCertificateId != null)
            {
                request.ResourceIdentifier.DeviceCertificateId = requestResourceIdentifier_resourceIdentifier_DeviceCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_IamRoleArn = null;
            if (cmdletContext.ResourceIdentifier_IamRoleArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_IamRoleArn = cmdletContext.ResourceIdentifier_IamRoleArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_IamRoleArn != null)
            {
                request.ResourceIdentifier.IamRoleArn = requestResourceIdentifier_resourceIdentifier_IamRoleArn;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_RoleAliasArn = null;
            if (cmdletContext.ResourceIdentifier_RoleAliasArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_RoleAliasArn = cmdletContext.ResourceIdentifier_RoleAliasArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_RoleAliasArn != null)
            {
                request.ResourceIdentifier.RoleAliasArn = requestResourceIdentifier_resourceIdentifier_RoleAliasArn;
                requestResourceIdentifierIsNull = false;
            }
            Amazon.IoT.Model.PolicyVersionIdentifier requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            
             // populate PolicyVersionIdentifier
            var requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = true;
            requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = new Amazon.IoT.Model.PolicyVersionIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = cmdletContext.PolicyVersionIdentifier_PolicyName;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyName = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = cmdletContext.PolicyVersionIdentifier_PolicyVersionId;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyVersionId = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
             // determine if requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier should be set to null
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier != null)
            {
                request.ResourceIdentifier.PolicyVersionIdentifier = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier;
                requestResourceIdentifierIsNull = false;
            }
             // determine if request.ResourceIdentifier should be set to null
            if (requestResourceIdentifierIsNull)
            {
                request.ResourceIdentifier = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IoT.Model.ListAuditFindingsRequest();
            if (cmdletContext.CheckName != null)
            {
                request.CheckName = cmdletContext.CheckName;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            
             // populate ResourceIdentifier
            var requestResourceIdentifierIsNull = true;
            request.ResourceIdentifier = new Amazon.IoT.Model.ResourceIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_Account = null;
            if (cmdletContext.ResourceIdentifier_Account != null)
            {
                requestResourceIdentifier_resourceIdentifier_Account = cmdletContext.ResourceIdentifier_Account;
            }
            if (requestResourceIdentifier_resourceIdentifier_Account != null)
            {
                request.ResourceIdentifier.Account = requestResourceIdentifier_resourceIdentifier_Account;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CaCertificateId = null;
            if (cmdletContext.ResourceIdentifier_CaCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CaCertificateId = cmdletContext.ResourceIdentifier_CaCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CaCertificateId != null)
            {
                request.ResourceIdentifier.CaCertificateId = requestResourceIdentifier_resourceIdentifier_CaCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_ClientId = null;
            if (cmdletContext.ResourceIdentifier_ClientId != null)
            {
                requestResourceIdentifier_resourceIdentifier_ClientId = cmdletContext.ResourceIdentifier_ClientId;
            }
            if (requestResourceIdentifier_resourceIdentifier_ClientId != null)
            {
                request.ResourceIdentifier.ClientId = requestResourceIdentifier_resourceIdentifier_ClientId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = null;
            if (cmdletContext.ResourceIdentifier_CognitoIdentityPoolId != null)
            {
                requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId = cmdletContext.ResourceIdentifier_CognitoIdentityPoolId;
            }
            if (requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId != null)
            {
                request.ResourceIdentifier.CognitoIdentityPoolId = requestResourceIdentifier_resourceIdentifier_CognitoIdentityPoolId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = null;
            if (cmdletContext.ResourceIdentifier_DeviceCertificateId != null)
            {
                requestResourceIdentifier_resourceIdentifier_DeviceCertificateId = cmdletContext.ResourceIdentifier_DeviceCertificateId;
            }
            if (requestResourceIdentifier_resourceIdentifier_DeviceCertificateId != null)
            {
                request.ResourceIdentifier.DeviceCertificateId = requestResourceIdentifier_resourceIdentifier_DeviceCertificateId;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_IamRoleArn = null;
            if (cmdletContext.ResourceIdentifier_IamRoleArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_IamRoleArn = cmdletContext.ResourceIdentifier_IamRoleArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_IamRoleArn != null)
            {
                request.ResourceIdentifier.IamRoleArn = requestResourceIdentifier_resourceIdentifier_IamRoleArn;
                requestResourceIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_RoleAliasArn = null;
            if (cmdletContext.ResourceIdentifier_RoleAliasArn != null)
            {
                requestResourceIdentifier_resourceIdentifier_RoleAliasArn = cmdletContext.ResourceIdentifier_RoleAliasArn;
            }
            if (requestResourceIdentifier_resourceIdentifier_RoleAliasArn != null)
            {
                request.ResourceIdentifier.RoleAliasArn = requestResourceIdentifier_resourceIdentifier_RoleAliasArn;
                requestResourceIdentifierIsNull = false;
            }
            Amazon.IoT.Model.PolicyVersionIdentifier requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            
             // populate PolicyVersionIdentifier
            var requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = true;
            requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = new Amazon.IoT.Model.PolicyVersionIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = cmdletContext.PolicyVersionIdentifier_PolicyName;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyName = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = null;
            if (cmdletContext.PolicyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = cmdletContext.PolicyVersionIdentifier_PolicyVersionId;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyVersionId = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
             // determine if requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier should be set to null
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier != null)
            {
                request.ResourceIdentifier.PolicyVersionIdentifier = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier;
                requestResourceIdentifierIsNull = false;
            }
             // determine if request.ResourceIdentifier should be set to null
            if (requestResourceIdentifierIsNull)
            {
                request.ResourceIdentifier = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 250. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 250 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(250, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.Findings.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoT.Model.ListAuditFindingsResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListAuditFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListAuditFindings");
            try
            {
                #if DESKTOP
                return client.ListAuditFindings(request);
                #elif CORECLR
                return client.ListAuditFindingsAsync(request).GetAwaiter().GetResult();
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
            public System.String CheckName { get; set; }
            public System.DateTime? EndTime { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceIdentifier_Account { get; set; }
            public System.String ResourceIdentifier_CaCertificateId { get; set; }
            public System.String ResourceIdentifier_ClientId { get; set; }
            public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
            public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
            public System.String ResourceIdentifier_IamRoleArn { get; set; }
            public System.String PolicyVersionIdentifier_PolicyName { get; set; }
            public System.String PolicyVersionIdentifier_PolicyVersionId { get; set; }
            public System.String ResourceIdentifier_RoleAliasArn { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String TaskId { get; set; }
            public System.Func<Amazon.IoT.Model.ListAuditFindingsResponse, GetIOTAuditFindingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Findings;
        }
        
    }
}
