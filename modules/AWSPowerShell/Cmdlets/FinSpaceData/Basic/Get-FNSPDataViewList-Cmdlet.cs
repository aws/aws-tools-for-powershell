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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// Lists all available Dataviews for a Dataset.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "FNSPDataViewList")]
    [OutputType("Amazon.FinSpaceData.Model.DataViewSummary")]
    [AWSCmdlet("Calls the FinSpace Public API ListDataViews API operation.", Operation = new[] {"ListDataViews"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.ListDataViewsResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.DataViewSummary or Amazon.FinSpaceData.Model.ListDataViewsResponse",
        "This cmdlet returns a collection of Amazon.FinSpaceData.Model.DataViewSummary objects.",
        "The service call response (type Amazon.FinSpaceData.Model.ListDataViewsResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class GetFNSPDataViewListCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Dataset for which to retrieve Dataviews.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates where a results page should begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataViews'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.ListDataViewsResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.ListDataViewsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataViews";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.ListDataViewsResponse, GetFNSPDataViewListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            // create request
            var request = new Amazon.FinSpaceData.Model.ListDataViewsRequest();
            
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.FinSpaceData.Model.ListDataViewsResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.ListDataViewsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "ListDataViews");
            try
            {
                #if DESKTOP
                return client.ListDataViews(request);
                #elif CORECLR
                return client.ListDataViewsAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.ListDataViewsResponse, GetFNSPDataViewListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataViews;
        }
        
    }
}
