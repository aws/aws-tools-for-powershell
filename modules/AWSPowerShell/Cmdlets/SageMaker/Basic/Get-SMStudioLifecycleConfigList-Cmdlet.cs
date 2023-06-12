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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Lists the Studio Lifecycle Configurations in your Amazon Web Services Account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMStudioLifecycleConfigList")]
    [OutputType("Amazon.SageMaker.Model.StudioLifecycleConfigDetails")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListStudioLifecycleConfigs API operation.", Operation = new[] {"ListStudioLifecycleConfigs"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.StudioLifecycleConfigDetails or Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.StudioLifecycleConfigDetails objects.",
        "The service call response (type Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMStudioLifecycleConfigListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AppTypeEqual
        /// <summary>
        /// <para>
        /// <para>A parameter to search for the App Type to which the Lifecycle Configuration is attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppTypeEquals")]
        [AWSConstantClassSource("Amazon.SageMaker.StudioLifecycleConfigAppType")]
        public Amazon.SageMaker.StudioLifecycleConfigAppType AppTypeEqual { get; set; }
        #endregion
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only Lifecycle Configurations created on or after the specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only Lifecycle Configurations created on or before the specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter ModifiedTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only Lifecycle Configurations modified after the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ModifiedTimeAfter { get; set; }
        #endregion
        
        #region Parameter ModifiedTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only Lifecycle Configurations modified before the specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ModifiedTimeBefore { get; set; }
        #endregion
        
        #region Parameter NameContain
        /// <summary>
        /// <para>
        /// <para>A string in the Lifecycle Configuration name. This filter returns only Lifecycle Configurations
        /// whose name contains the specified string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NameContains")]
        public System.String NameContain { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The property used to sort results. The default value is CreationTime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.StudioLifecycleConfigSortKey")]
        public Amazon.SageMaker.StudioLifecycleConfigSortKey SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order. The default value is Descending.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortOrder")]
        public Amazon.SageMaker.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The total number of items to return in the response. If the total number of items
        /// available is more than the value specified, a <code>NextToken</code> is provided in
        /// the response. To resume pagination, provide the <code>NextToken</code> value in the
        /// as part of a subsequent call. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous call to ListStudioLifecycleConfigs didn't return the full set of Lifecycle
        /// Configurations, the call returns a token for getting the next set of Lifecycle Configurations.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StudioLifecycleConfigs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StudioLifecycleConfigs";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse, GetSMStudioLifecycleConfigListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppTypeEqual = this.AppTypeEqual;
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.MaxResult = this.MaxResult;
            context.ModifiedTimeAfter = this.ModifiedTimeAfter;
            context.ModifiedTimeBefore = this.ModifiedTimeBefore;
            context.NameContain = this.NameContain;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.SageMaker.Model.ListStudioLifecycleConfigsRequest();
            
            if (cmdletContext.AppTypeEqual != null)
            {
                request.AppTypeEquals = cmdletContext.AppTypeEqual;
            }
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ModifiedTimeAfter != null)
            {
                request.ModifiedTimeAfter = cmdletContext.ModifiedTimeAfter.Value;
            }
            if (cmdletContext.ModifiedTimeBefore != null)
            {
                request.ModifiedTimeBefore = cmdletContext.ModifiedTimeBefore.Value;
            }
            if (cmdletContext.NameContain != null)
            {
                request.NameContains = cmdletContext.NameContain;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListStudioLifecycleConfigsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListStudioLifecycleConfigs");
            try
            {
                #if DESKTOP
                return client.ListStudioLifecycleConfigs(request);
                #elif CORECLR
                return client.ListStudioLifecycleConfigsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.StudioLifecycleConfigAppType AppTypeEqual { get; set; }
            public System.DateTime? CreationTimeAfter { get; set; }
            public System.DateTime? CreationTimeBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.DateTime? ModifiedTimeAfter { get; set; }
            public System.DateTime? ModifiedTimeBefore { get; set; }
            public System.String NameContain { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.StudioLifecycleConfigSortKey SortBy { get; set; }
            public Amazon.SageMaker.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListStudioLifecycleConfigsResponse, GetSMStudioLifecycleConfigListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StudioLifecycleConfigs;
        }
        
    }
}
