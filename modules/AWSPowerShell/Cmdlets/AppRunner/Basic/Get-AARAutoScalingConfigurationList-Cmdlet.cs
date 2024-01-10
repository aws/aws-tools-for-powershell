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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Returns a list of active App Runner automatic scaling configurations in your Amazon
    /// Web Services account. You can query the revisions for a specific configuration name
    /// or the revisions for all active configurations in your account. You can optionally
    /// query only the latest revision of each requested name.
    /// 
    ///  
    /// <para>
    /// To retrieve a full description of a particular configuration revision, call and provide
    /// one of the ARNs returned by <c>ListAutoScalingConfigurations</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AARAutoScalingConfigurationList")]
    [OutputType("Amazon.AppRunner.Model.AutoScalingConfigurationSummary")]
    [AWSCmdlet("Calls the AWS App Runner ListAutoScalingConfigurations API operation.", Operation = new[] {"ListAutoScalingConfigurations"}, SelectReturnType = typeof(Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.AutoScalingConfigurationSummary or Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.AppRunner.Model.AutoScalingConfigurationSummary objects.",
        "The service call response (type Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAARAutoScalingConfigurationListCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the App Runner auto scaling configuration that you want to list. If specified,
        /// App Runner lists revisions that share this name. If not specified, App Runner returns
        /// revisions of all active configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoScalingConfigurationName { get; set; }
        #endregion
        
        #region Parameter LatestOnly
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to list only the latest revision for each requested configuration
        /// name.</para><para>Set to <c>false</c> to list all revisions for each requested configuration name.</para><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LatestOnly { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to include in each response (result page). It's used
        /// for a paginated request.</para><para>If you don't specify <c>MaxResults</c>, the request retrieves all available results
        /// in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token from a previous result page. It's used for a paginated request. The request
        /// retrieves the next result page. All other parameter values must be identical to the
        /// ones that are specified in the initial request.</para><para>If you don't specify <c>NextToken</c>, the request retrieves the first result page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoScalingConfigurationSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoScalingConfigurationSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse, GetAARAutoScalingConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingConfigurationName = this.AutoScalingConfigurationName;
            context.LatestOnly = this.LatestOnly;
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.AppRunner.Model.ListAutoScalingConfigurationsRequest();
            
            if (cmdletContext.AutoScalingConfigurationName != null)
            {
                request.AutoScalingConfigurationName = cmdletContext.AutoScalingConfigurationName;
            }
            if (cmdletContext.LatestOnly != null)
            {
                request.LatestOnly = cmdletContext.LatestOnly.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.ListAutoScalingConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "ListAutoScalingConfigurations");
            try
            {
                #if DESKTOP
                return client.ListAutoScalingConfigurations(request);
                #elif CORECLR
                return client.ListAutoScalingConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingConfigurationName { get; set; }
            public System.Boolean? LatestOnly { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AppRunner.Model.ListAutoScalingConfigurationsResponse, GetAARAutoScalingConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoScalingConfigurationSummaryList;
        }
        
    }
}
