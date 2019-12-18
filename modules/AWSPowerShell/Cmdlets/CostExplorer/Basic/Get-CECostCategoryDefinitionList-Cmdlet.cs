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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// <important><para><i><b>Cost Category is in preview release for AWS Billing and Cost Management and
    /// is subject to change. Your use of Cost Categories is subject to the Beta Service Participation
    /// terms of the <a href="https://aws.amazon.com/service-terms/">AWS Service Terms</a>
    /// (Section 1.10).</b></i></para></important><para>
    /// Returns the name, ARN and effective dates of all Cost Categories defined in the account.
    /// You have the option to use <code>EffectiveOn</code> to return a list of Cost Categories
    /// that were active on a specific date. If there is no <code>EffectiveOn</code> specified,
    /// you’ll see Cost Categories that are effective on the current date. If Cost Category
    /// is still effective, <code>EffectiveEnd</code> is omitted in the response. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CECostCategoryDefinitionList")]
    [OutputType("Amazon.CostExplorer.Model.CostCategoryReference")]
    [AWSCmdlet("Calls the AWS Cost Explorer ListCostCategoryDefinitions API operation.", Operation = new[] {"ListCostCategoryDefinitions"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CostCategoryReference or Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.CostCategoryReference objects.",
        "The service call response (type Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCECostCategoryDefinitionListCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter EffectiveOn
        /// <summary>
        /// <para>
        /// <para> The date when the Cost Category was effective. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveOn { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.
        /// </para><para>You can use this information to retrieve the full Cost Category information using
        /// <code>DescribeCostCategory</code>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CostCategoryReferences'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CostCategoryReferences";
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse, GetCECostCategoryDefinitionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EffectiveOn = this.EffectiveOn;
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
            var request = new Amazon.CostExplorer.Model.ListCostCategoryDefinitionsRequest();
            
            if (cmdletContext.EffectiveOn != null)
            {
                request.EffectiveOn = cmdletContext.EffectiveOn;
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
        
        private Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.ListCostCategoryDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "ListCostCategoryDefinitions");
            try
            {
                #if DESKTOP
                return client.ListCostCategoryDefinitions(request);
                #elif CORECLR
                return client.ListCostCategoryDefinitionsAsync(request).GetAwaiter().GetResult();
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
            public System.String EffectiveOn { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CostExplorer.Model.ListCostCategoryDefinitionsResponse, GetCECostCategoryDefinitionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CostCategoryReferences;
        }
        
    }
}
