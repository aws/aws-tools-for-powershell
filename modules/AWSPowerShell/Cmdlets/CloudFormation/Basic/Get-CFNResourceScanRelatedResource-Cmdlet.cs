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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Lists the related resources for a list of resources from a resource scan. The response
    /// indicates whether each returned resource is already managed by CloudFormation.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFNResourceScanRelatedResource")]
    [OutputType("Amazon.CloudFormation.Model.ScannedResource")]
    [AWSCmdlet("Calls the AWS CloudFormation ListResourceScanRelatedResources API operation.", Operation = new[] {"ListResourceScanRelatedResources"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.ScannedResource or Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse",
        "This cmdlet returns a collection of Amazon.CloudFormation.Model.ScannedResource objects.",
        "The service call response (type Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFNResourceScanRelatedResourceCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The list of resources for which you want to get the related resources. Up to 100 resources
        /// can be provided.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Resources")]
        public Amazon.CloudFormation.Model.ScannedResourceIdentifier[] Resource { get; set; }
        #endregion
        
        #region Parameter ResourceScanId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource scan.</para>
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
        public System.String ResourceScanId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> If the number of available results exceeds this maximum, the response includes a
        /// <c>NextToken</c> value that you can use for the <c>NextToken</c> parameter to get
        /// the next set of results. By default the <c>ListResourceScanRelatedResources</c> API
        /// action will return up to 100 results in each response. The maximum value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A string that identifies the next page of resource scan results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelatedResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelatedResources";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceScanId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceScanId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceScanId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse, GetCFNResourceScanRelatedResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceScanId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Resource != null)
            {
                context.Resource = new List<Amazon.CloudFormation.Model.ScannedResourceIdentifier>(this.Resource);
            }
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceScanId = this.ResourceScanId;
            #if MODULAR
            if (this.ResourceScanId == null && ParameterWasBound(nameof(this.ResourceScanId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceScanId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            if (cmdletContext.ResourceScanId != null)
            {
                request.ResourceScanId = cmdletContext.ResourceScanId;
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
        
        private Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ListResourceScanRelatedResources");
            try
            {
                #if DESKTOP
                return client.ListResourceScanRelatedResources(request);
                #elif CORECLR
                return client.ListResourceScanRelatedResourcesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudFormation.Model.ScannedResourceIdentifier> Resource { get; set; }
            public System.String ResourceScanId { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ListResourceScanRelatedResourcesResponse, GetCFNResourceScanRelatedResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelatedResources;
        }
        
    }
}
