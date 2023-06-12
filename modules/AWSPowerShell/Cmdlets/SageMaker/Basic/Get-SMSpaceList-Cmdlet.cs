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
    /// Lists spaces.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMSpaceList")]
    [OutputType("Amazon.SageMaker.Model.SpaceDetails")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListSpaces API operation.", Operation = new[] {"ListSpaces"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListSpacesResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.SpaceDetails or Amazon.SageMaker.Model.ListSpacesResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.SpaceDetails objects.",
        "The service call response (type Amazon.SageMaker.Model.ListSpacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMSpaceListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter DomainIdEqual
        /// <summary>
        /// <para>
        /// <para>A parameter to search for the Domain ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainIdEquals")]
        public System.String DomainIdEqual { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The parameter by which to sort the results. The default is <code>CreationTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SpaceSortKey")]
        public Amazon.SageMaker.SpaceSortKey SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for the results. The default is <code>Ascending</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortOrder")]
        public Amazon.SageMaker.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter SpaceNameContain
        /// <summary>
        /// <para>
        /// <para>A parameter by which to filter the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceNameContains")]
        public System.String SpaceNameContain { get; set; }
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
        /// <para>If the previous response was truncated, you will receive this token. Use it in your
        /// next request to receive the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Spaces'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListSpacesResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListSpacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Spaces";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListSpacesResponse, GetSMSpaceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainIdEqual = this.DomainIdEqual;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.SpaceNameContain = this.SpaceNameContain;
            
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
            var request = new Amazon.SageMaker.Model.ListSpacesRequest();
            
            if (cmdletContext.DomainIdEqual != null)
            {
                request.DomainIdEquals = cmdletContext.DomainIdEqual;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.SpaceNameContain != null)
            {
                request.SpaceNameContains = cmdletContext.SpaceNameContain;
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
        
        private Amazon.SageMaker.Model.ListSpacesResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListSpacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListSpaces");
            try
            {
                #if DESKTOP
                return client.ListSpaces(request);
                #elif CORECLR
                return client.ListSpacesAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainIdEqual { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.SpaceSortKey SortBy { get; set; }
            public Amazon.SageMaker.SortOrder SortOrder { get; set; }
            public System.String SpaceNameContain { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListSpacesResponse, GetSMSpaceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Spaces;
        }
        
    }
}
