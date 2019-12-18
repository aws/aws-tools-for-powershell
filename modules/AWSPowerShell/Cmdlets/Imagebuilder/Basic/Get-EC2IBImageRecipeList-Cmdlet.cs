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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Returns a list of image recipes.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2IBImageRecipeList")]
    [OutputType("Amazon.Imagebuilder.Model.ImageRecipeSummary")]
    [AWSCmdlet("Calls the EC2 Image Builder ListImageRecipes API operation.", Operation = new[] {"ListImageRecipes"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.ListImageRecipesResponse))]
    [AWSCmdletOutput("Amazon.Imagebuilder.Model.ImageRecipeSummary or Amazon.Imagebuilder.Model.ListImageRecipesResponse",
        "This cmdlet returns a collection of Amazon.Imagebuilder.Model.ImageRecipeSummary objects.",
        "The service call response (type Amazon.Imagebuilder.Model.ListImageRecipesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2IBImageRecipeListCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.Imagebuilder.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum items to return in a request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A token to specify where to start paginating. This is the NextToken from a previously
        /// truncated response. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para> The owner defines whose image recipes you wish to list. By default this request will
        /// only show image recipes owned by your account. You may use this field to specify if
        /// you wish to view image recipes owned by yourself, Amazon, or those image recipes that
        /// have been shared with you by other customers. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.Ownership")]
        public Amazon.Imagebuilder.Ownership Owner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageRecipeSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.ListImageRecipesResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.ListImageRecipesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageRecipeSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.ListImageRecipesResponse, GetEC2IBImageRecipeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Imagebuilder.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Owner = this.Owner;
            
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
            var request = new Amazon.Imagebuilder.Model.ListImageRecipesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
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
        
        private Amazon.Imagebuilder.Model.ListImageRecipesResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.ListImageRecipesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "ListImageRecipes");
            try
            {
                #if DESKTOP
                return client.ListImageRecipes(request);
                #elif CORECLR
                return client.ListImageRecipesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Imagebuilder.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Imagebuilder.Ownership Owner { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.ListImageRecipesResponse, GetEC2IBImageRecipeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageRecipeSummaryList;
        }
        
    }
}
