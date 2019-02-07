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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists the findings (results) of a Device Defender audit or of the audits performed
    /// during a specified time period. (Findings are retained for 180 days.)<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "IOTAuditFindingList")]
    [OutputType("Amazon.IoT.Model.AuditFinding")]
    [AWSCmdlet("Calls the AWS IoT ListAuditFindings API operation.", Operation = new[] {"ListAuditFindings"})]
    [AWSCmdletOutput("Amazon.IoT.Model.AuditFinding",
        "This cmdlet returns a collection of AuditFinding objects.",
        "The service call response (type Amazon.IoT.Model.ListAuditFindingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetIOTAuditFindingListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceIdentifier_Account
        /// <summary>
        /// <para>
        /// <para>The account with which the resource is associated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_Account { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CaCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the CA certificate used to authorize the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_CaCertificateId { get; set; }
        #endregion
        
        #region Parameter CheckName
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to the findings for the specified audit check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CheckName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_ClientId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_CognitoIdentityPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Cognito Identity Pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier_DeviceCertificateId
        /// <summary>
        /// <para>
        /// <para>The ID of the certificate attached to the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to those found before the specified time. You must specify
        /// either the startTime and endTime or the taskId, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyName")]
        public System.String PolicyVersionIdentifier_PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyVersionIdentifier_PolicyVersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the version of the policy associated with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId")]
        public System.String PolicyVersionIdentifier_PolicyVersionId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to those found after the specified time. You must specify
        /// either the startTime and endTime or the taskId, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>A filter to limit results to the audit with the specified ID. You must specify either
        /// the taskId or the startTime and endTime, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time. The default is 25.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            
            context.CheckName = this.CheckName;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceIdentifier_Account = this.ResourceIdentifier_Account;
            context.ResourceIdentifier_CaCertificateId = this.ResourceIdentifier_CaCertificateId;
            context.ResourceIdentifier_ClientId = this.ResourceIdentifier_ClientId;
            context.ResourceIdentifier_CognitoIdentityPoolId = this.ResourceIdentifier_CognitoIdentityPoolId;
            context.ResourceIdentifier_DeviceCertificateId = this.ResourceIdentifier_DeviceCertificateId;
            context.ResourceIdentifier_PolicyVersionIdentifier_PolicyName = this.PolicyVersionIdentifier_PolicyName;
            context.ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId = this.PolicyVersionIdentifier_PolicyVersionId;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            context.TaskId = this.TaskId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
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
            bool requestResourceIdentifierIsNull = true;
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
            Amazon.IoT.Model.PolicyVersionIdentifier requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = null;
            
             // populate PolicyVersionIdentifier
            bool requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = true;
            requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier = new Amazon.IoT.Model.PolicyVersionIdentifier();
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = null;
            if (cmdletContext.ResourceIdentifier_PolicyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName = cmdletContext.ResourceIdentifier_PolicyVersionIdentifier_PolicyName;
            }
            if (requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier.PolicyName = requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyName;
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifierIsNull = false;
            }
            System.String requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = null;
            if (cmdletContext.ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId != null)
            {
                requestResourceIdentifier_resourceIdentifier_PolicyVersionIdentifier_policyVersionIdentifier_PolicyVersionId = cmdletContext.ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 250;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 250. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 250 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("MaxResult");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxResults))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxResults);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Findings;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Findings.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 250 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListAuditFindingsAsync(request);
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
            public System.String CheckName { get; set; }
            public System.DateTime? EndTime { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceIdentifier_Account { get; set; }
            public System.String ResourceIdentifier_CaCertificateId { get; set; }
            public System.String ResourceIdentifier_ClientId { get; set; }
            public System.String ResourceIdentifier_CognitoIdentityPoolId { get; set; }
            public System.String ResourceIdentifier_DeviceCertificateId { get; set; }
            public System.String ResourceIdentifier_PolicyVersionIdentifier_PolicyName { get; set; }
            public System.String ResourceIdentifier_PolicyVersionIdentifier_PolicyVersionId { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String TaskId { get; set; }
        }
        
    }
}
