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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Indicates whether the specified Config rules are compliant. If a rule is noncompliant,
    /// this operation returns the number of Amazon Web Services resources that do not comply
    /// with the rule.
    /// 
    ///  
    /// <para>
    /// A rule is compliant if all of the evaluated resources comply with it. It is noncompliant
    /// if any of these resources do not comply.
    /// </para><para>
    /// If Config has no current evaluation results for the rule, it returns <c>INSUFFICIENT_DATA</c>.
    /// This result might indicate one of the following conditions:
    /// </para><ul><li><para>
    /// Config has never invoked an evaluation for the rule. To check whether it has, use
    /// the <c>DescribeConfigRuleEvaluationStatus</c> action to get the <c>LastSuccessfulInvocationTime</c>
    /// and <c>LastFailedInvocationTime</c>.
    /// </para></li><li><para>
    /// The rule's Lambda function is failing to send evaluation results to Config. Verify
    /// that the role you assigned to your configuration recorder includes the <c>config:PutEvaluations</c>
    /// permission. If the rule is a custom rule, verify that the Lambda execution role includes
    /// the <c>config:PutEvaluations</c> permission.
    /// </para></li><li><para>
    /// The rule's Lambda function has returned <c>NOT_APPLICABLE</c> for all evaluation results.
    /// This can occur if the resources were deleted or removed from the rule's scope.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceByConfigRule")]
    [OutputType("Amazon.ConfigService.Model.ComplianceByConfigRule")]
    [AWSCmdlet("Calls the AWS Config DescribeComplianceByConfigRule API operation.", Operation = new[] {"DescribeComplianceByConfigRule"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceByConfigRule or Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ComplianceByConfigRule objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGComplianceByConfigRuleCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>Specify one or more Config rule names to filter the results by rule.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> string returned on a previous page that you use to get the next
        /// page of results in a paginated response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComplianceByConfigRules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComplianceByConfigRules";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse, GetCFGComplianceByConfigRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComplianceType != null)
            {
                context.ComplianceType = new List<System.String>(this.ComplianceType);
            }
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleName = new List<System.String>(this.ConfigRuleName);
            }
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
            var request = new Amazon.ConfigService.Model.DescribeComplianceByConfigRuleRequest();
            
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceType;
            }
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleNames = cmdletContext.ConfigRuleName;
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
        
        private Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeComplianceByConfigRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeComplianceByConfigRule");
            try
            {
                return client.DescribeComplianceByConfigRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ConfigRuleName { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeComplianceByConfigRuleResponse, GetCFGComplianceByConfigRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComplianceByConfigRules;
        }
        
    }
}
