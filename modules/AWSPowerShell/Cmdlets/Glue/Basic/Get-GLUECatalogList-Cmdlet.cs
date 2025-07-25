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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieves all catalogs defined in a catalog in the Glue Data Catalog. For a Redshift-federated
    /// catalog use case, this operation returns the list of catalogs mapped to Redshift databases
    /// in the Redshift namespace catalog.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUECatalogList")]
    [OutputType("Amazon.Glue.Model.Catalog")]
    [AWSCmdlet("Calls the AWS Glue GetCatalogs API operation.", Operation = new[] {"GetCatalogs"}, SelectReturnType = typeof(Amazon.Glue.Model.GetCatalogsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.Catalog or Amazon.Glue.Model.GetCatalogsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.Catalog objects.",
        "The service call response (type Amazon.Glue.Model.GetCatalogsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUECatalogListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeRoot
        /// <summary>
        /// <para>
        /// <para>Whether to list the default catalog in the account and region in the response. Defaults
        /// to <c>false</c>. When <c>true</c> and <c>ParentCatalogId = NULL | Amazon Web Services
        /// Account ID</c>, all catalogs and the default catalog are enumerated in the response.</para><para>When the <c>ParentCatalogId</c> is not equal to null, and this attribute is passed
        /// as <c>false</c> or <c>true</c>, an <c>InvalidInputException</c> is thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeRoot { get; set; }
        #endregion
        
        #region Parameter ParentCatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the parent catalog in which the catalog resides. If none is provided, the
        /// Amazon Web Services Account Number is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentCatalogId { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>Whether to list all catalogs across the catalog hierarchy, starting from the <c>ParentCatalogId</c>.
        /// Defaults to <c>false</c> . When <c>true</c>, all catalog objects in the <c>ParentCatalogID</c>
        /// hierarchy are enumerated in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recursive { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of catalogs to return in one response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is a continuation call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CatalogList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetCatalogsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetCatalogsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CatalogList";
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetCatalogsResponse, GetGLUECatalogListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeRoot = this.IncludeRoot;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ParentCatalogId = this.ParentCatalogId;
            context.Recursive = this.Recursive;
            
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
            var request = new Amazon.Glue.Model.GetCatalogsRequest();
            
            if (cmdletContext.IncludeRoot != null)
            {
                request.IncludeRoot = cmdletContext.IncludeRoot.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ParentCatalogId != null)
            {
                request.ParentCatalogId = cmdletContext.ParentCatalogId;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
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
        
        private Amazon.Glue.Model.GetCatalogsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetCatalogsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetCatalogs");
            try
            {
                return client.GetCatalogsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeRoot { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ParentCatalogId { get; set; }
            public System.Boolean? Recursive { get; set; }
            public System.Func<Amazon.Glue.Model.GetCatalogsResponse, GetGLUECatalogListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CatalogList;
        }
        
    }
}
