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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Indicates whether the specified Amazon Web Services resources are compliant. If a
    /// resource is noncompliant, this action returns the number of Config rules that the
    /// resource does not comply with.
    /// 
    ///  
    /// <para>
    /// A resource is compliant if it complies with all the Config rules that evaluate it.
    /// It is noncompliant if it does not comply with one or more of these rules.
    /// </para><para>
    /// If Config has no current evaluation results for the resource, it returns <code>INSUFFICIENT_DATA</code>.
    /// This result might indicate one of the following conditions about the rules that evaluate
    /// the resource:
    /// </para><ul><li><para>
    /// Config has never invoked an evaluation for the rule. To check whether it has, use
    /// the <code>DescribeConfigRuleEvaluationStatus</code> action to get the <code>LastSuccessfulInvocationTime</code>
    /// and <code>LastFailedInvocationTime</code>.
    /// </para></li><li><para>
    /// The rule's Lambda function is failing to send evaluation results to Config. Verify
    /// that the role that you assigned to your configuration recorder includes the <code>config:PutEvaluations</code>
    /// permission. If the rule is a custom rule, verify that the Lambda execution role includes
    /// the <code>config:PutEvaluations</code> permission.
    /// </para></li><li><para>
    /// The rule's Lambda function has returned <code>NOT_APPLICABLE</code> for all evaluation
    /// results. This can occur if the resources were deleted or removed from the rule's scope.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceByResource")]
    [OutputType("Amazon.ConfigService.Model.ComplianceByResource")]
    [AWSCmdlet("Calls the AWS Config DescribeComplianceByResource API operation.", Operation = new[] {"DescribeComplianceByResource"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeComplianceByResourceResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceByResource or Amazon.ConfigService.Model.DescribeComplianceByResourceResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ComplianceByResource objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeComplianceByResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGComplianceByResourceCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource for which you want compliance information.
        /// You can specify only one resource ID. If you specify a resource ID, you must also
        /// specify a type for <code>ResourceType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The types of Amazon Web Services resources for which you want compliance information
        /// (for example, <code>AWS::EC2::Instance</code>). For this action, you can specify that
        /// the resource type is an Amazon Web Services account by specifying <code>AWS::::Account</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. The default is 10.
        /// You cannot specify a number greater than 100. If you specify 0, Config uses the default.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComplianceByResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeComplianceByResourceResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeComplianceByResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComplianceByResources";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeComplianceByResourceResponse, GetCFGComplianceByResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComplianceType != null)
            {
                context.ComplianceType = new List<System.String>(this.ComplianceType);
            }
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.ConfigService.Model.DescribeComplianceByResourceRequest();
            
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceType;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
            var request = new Amazon.ConfigService.Model.DescribeComplianceByResourceRequest();
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceType;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.ComplianceByResources.Count;
                    
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
            
            
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
        
        private Amazon.ConfigService.Model.DescribeComplianceByResourceResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeComplianceByResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeComplianceByResource");
            try
            {
                #if DESKTOP
                return client.DescribeComplianceByResource(request);
                #elif CORECLR
                return client.DescribeComplianceByResourceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ComplianceType { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceType { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeComplianceByResourceResponse, GetCFGComplianceByResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComplianceByResources;
        }
        
    }
}
