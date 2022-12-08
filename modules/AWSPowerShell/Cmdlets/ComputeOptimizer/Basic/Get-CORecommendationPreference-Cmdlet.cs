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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Returns existing recommendation preferences, such as enhanced infrastructure metrics.
    /// 
    ///  
    /// <para>
    /// Use the <code>scope</code> parameter to specify which preferences to return. You can
    /// specify to return preferences for an organization, a specific account ID, or a specific
    /// EC2 instance or Auto Scaling group Amazon Resource Name (ARN).
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/enhanced-infrastructure-metrics.html">Activating
    /// enhanced infrastructure metrics</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CORecommendationPreference")]
    [OutputType("Amazon.ComputeOptimizer.Model.RecommendationPreferencesDetail")]
    [AWSCmdlet("Calls the AWS Compute Optimizer GetRecommendationPreferences API operation.", Operation = new[] {"GetRecommendationPreferences"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.RecommendationPreferencesDetail or Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse",
        "This cmdlet returns a collection of Amazon.ComputeOptimizer.Model.RecommendationPreferencesDetail objects.",
        "The service call response (type Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCORecommendationPreferenceCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        #region Parameter Scope_Name
        /// <summary>
        /// <para>
        /// <para>The name of the scope.</para><para>The following scopes are possible:</para><ul><li><para><code>Organization</code> - Specifies that the recommendation preference applies
        /// at the organization level, for all member accounts of an organization.</para></li><li><para><code>AccountId</code> - Specifies that the recommendation preference applies at
        /// the account level, for all resources of a given resource type in an account.</para></li><li><para><code>ResourceArn</code> - Specifies that the recommendation preference applies at
        /// the individual resource level.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ScopeName")]
        public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The target resource type of the recommendation preference for which to return preferences.</para><para>The <code>Ec2Instance</code> option encompasses standalone instances and instances
        /// that are part of Auto Scaling groups. The <code>AutoScalingGroup</code> option encompasses
        /// only instances that are part of an Auto Scaling group.</para><note><para>The valid values for this parameter are <code>Ec2Instance</code> and <code>AutoScalingGroup</code>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.ResourceType")]
        public Amazon.ComputeOptimizer.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Scope_Value
        /// <summary>
        /// <para>
        /// <para>The value of the scope.</para><para>If you specified the <code>name</code> of the scope as:</para><ul><li><para><code>Organization</code> - The <code>value</code> must be <code>ALL_ACCOUNTS</code>.</para></li><li><para><code>AccountId</code> - The <code>value</code> must be a 12-digit Amazon Web Services
        /// account ID.</para></li><li><para><code>ResourceArn</code> - The <code>value</code> must be the Amazon Resource Name
        /// (ARN) of an EC2 instance or an Auto Scaling group.</para></li></ul><para>Only EC2 instance and Auto Scaling group ARNs are currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendation preferences to return with a single request.</para><para>To retrieve the remaining results, make another request with the returned <code>nextToken</code>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of recommendation preferences.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendationPreferencesDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendationPreferencesDetails";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse, GetCORecommendationPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope_Name = this.Scope_Name;
            context.Scope_Value = this.Scope_Value;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.ComputeOptimizer.Model.Scope();
            Amazon.ComputeOptimizer.ScopeName requestScope_scope_Name = null;
            if (cmdletContext.Scope_Name != null)
            {
                requestScope_scope_Name = cmdletContext.Scope_Name;
            }
            if (requestScope_scope_Name != null)
            {
                request.Scope.Name = requestScope_scope_Name;
                requestScopeIsNull = false;
            }
            System.String requestScope_scope_Value = null;
            if (cmdletContext.Scope_Value != null)
            {
                requestScope_scope_Value = cmdletContext.Scope_Value;
            }
            if (requestScope_scope_Value != null)
            {
                request.Scope.Value = requestScope_scope_Value;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
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
        
        private Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "GetRecommendationPreferences");
            try
            {
                #if DESKTOP
                return client.GetRecommendationPreferences(request);
                #elif CORECLR
                return client.GetRecommendationPreferencesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ComputeOptimizer.ResourceType ResourceType { get; set; }
            public Amazon.ComputeOptimizer.ScopeName Scope_Name { get; set; }
            public System.String Scope_Value { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.GetRecommendationPreferencesResponse, GetCORecommendationPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendationPreferencesDetails;
        }
        
    }
}
