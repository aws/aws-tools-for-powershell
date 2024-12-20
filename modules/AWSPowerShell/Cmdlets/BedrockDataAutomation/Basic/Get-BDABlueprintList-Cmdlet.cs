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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Lists all existing Amazon Bedrock Data Automation Blueprints<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BDABlueprintList")]
    [OutputType("Amazon.BedrockDataAutomation.Model.BlueprintSummary")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock ListBlueprints API operation.", Operation = new[] {"ListBlueprints"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.BlueprintSummary or Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse",
        "This cmdlet returns a collection of Amazon.BedrockDataAutomation.Model.BlueprintSummary objects.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDABlueprintListCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlueprintArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BlueprintArn { get; set; }
        #endregion
        
        #region Parameter BlueprintStageFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.BlueprintStageFilter")]
        public Amazon.BedrockDataAutomation.BlueprintStageFilter BlueprintStageFilter { get; set; }
        #endregion
        
        #region Parameter ProjectFilter_ProjectArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectFilter_ProjectArn { get; set; }
        #endregion
        
        #region Parameter ProjectFilter_ProjectStage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DataAutomationProjectStage")]
        public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectFilter_ProjectStage { get; set; }
        #endregion
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.ResourceOwner")]
        public Amazon.BedrockDataAutomation.ResourceOwner ResourceOwner { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Blueprints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Blueprints";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse, GetBDABlueprintListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueprintArn = this.BlueprintArn;
            context.BlueprintStageFilter = this.BlueprintStageFilter;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProjectFilter_ProjectArn = this.ProjectFilter_ProjectArn;
            context.ProjectFilter_ProjectStage = this.ProjectFilter_ProjectStage;
            context.ResourceOwner = this.ResourceOwner;
            
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
            var request = new Amazon.BedrockDataAutomation.Model.ListBlueprintsRequest();
            
            if (cmdletContext.BlueprintArn != null)
            {
                request.BlueprintArn = cmdletContext.BlueprintArn;
            }
            if (cmdletContext.BlueprintStageFilter != null)
            {
                request.BlueprintStageFilter = cmdletContext.BlueprintStageFilter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate ProjectFilter
            var requestProjectFilterIsNull = true;
            request.ProjectFilter = new Amazon.BedrockDataAutomation.Model.DataAutomationProjectFilter();
            System.String requestProjectFilter_projectFilter_ProjectArn = null;
            if (cmdletContext.ProjectFilter_ProjectArn != null)
            {
                requestProjectFilter_projectFilter_ProjectArn = cmdletContext.ProjectFilter_ProjectArn;
            }
            if (requestProjectFilter_projectFilter_ProjectArn != null)
            {
                request.ProjectFilter.ProjectArn = requestProjectFilter_projectFilter_ProjectArn;
                requestProjectFilterIsNull = false;
            }
            Amazon.BedrockDataAutomation.DataAutomationProjectStage requestProjectFilter_projectFilter_ProjectStage = null;
            if (cmdletContext.ProjectFilter_ProjectStage != null)
            {
                requestProjectFilter_projectFilter_ProjectStage = cmdletContext.ProjectFilter_ProjectStage;
            }
            if (requestProjectFilter_projectFilter_ProjectStage != null)
            {
                request.ProjectFilter.ProjectStage = requestProjectFilter_projectFilter_ProjectStage;
                requestProjectFilterIsNull = false;
            }
             // determine if request.ProjectFilter should be set to null
            if (requestProjectFilterIsNull)
            {
                request.ProjectFilter = null;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
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
        
        private Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.ListBlueprintsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "ListBlueprints");
            try
            {
                #if DESKTOP
                return client.ListBlueprints(request);
                #elif CORECLR
                return client.ListBlueprintsAsync(request).GetAwaiter().GetResult();
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
            public System.String BlueprintArn { get; set; }
            public Amazon.BedrockDataAutomation.BlueprintStageFilter BlueprintStageFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProjectFilter_ProjectArn { get; set; }
            public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectFilter_ProjectStage { get; set; }
            public Amazon.BedrockDataAutomation.ResourceOwner ResourceOwner { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.ListBlueprintsResponse, GetBDABlueprintListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Blueprints;
        }
        
    }
}
