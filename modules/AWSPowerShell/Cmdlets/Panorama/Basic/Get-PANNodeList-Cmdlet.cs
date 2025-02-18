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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Returns a list of nodes.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "PANNodeList")]
    [OutputType("Amazon.Panorama.Model.Node")]
    [AWSCmdlet("Calls the AWS Panorama ListNodes API operation.", Operation = new[] {"ListNodes"}, SelectReturnType = typeof(Amazon.Panorama.Model.ListNodesResponse))]
    [AWSCmdletOutput("Amazon.Panorama.Model.Node or Amazon.Panorama.Model.ListNodesResponse",
        "This cmdlet returns a collection of Amazon.Panorama.Model.Node objects.",
        "The service call response (type Amazon.Panorama.Model.ListNodesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPANNodeListCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>Search for nodes by category.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Panorama.NodeCategory")]
        public Amazon.Panorama.NodeCategory Category { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>Search for nodes by the account ID of the nodes' owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>Search for nodes by name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageName { get; set; }
        #endregion
        
        #region Parameter PackageVersion
        /// <summary>
        /// <para>
        /// <para>Search for nodes by version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageVersion { get; set; }
        #endregion
        
        #region Parameter PatchVersion
        /// <summary>
        /// <para>
        /// <para>Search for nodes by patch version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PatchVersion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes to return in one page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token from a previous request to retrieve the next page of
        /// results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Nodes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.ListNodesResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.ListNodesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Nodes";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.ListNodesResponse, GetPANNodeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Category = this.Category;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OwnerAccount = this.OwnerAccount;
            context.PackageName = this.PackageName;
            context.PackageVersion = this.PackageVersion;
            context.PatchVersion = this.PatchVersion;
            
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
            var request = new Amazon.Panorama.Model.ListNodesRequest();
            
            if (cmdletContext.Category != null)
            {
                request.Category = cmdletContext.Category;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            if (cmdletContext.PackageVersion != null)
            {
                request.PackageVersion = cmdletContext.PackageVersion;
            }
            if (cmdletContext.PatchVersion != null)
            {
                request.PatchVersion = cmdletContext.PatchVersion;
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
        
        private Amazon.Panorama.Model.ListNodesResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.ListNodesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "ListNodes");
            try
            {
                return client.ListNodesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Panorama.NodeCategory Category { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.String PackageName { get; set; }
            public System.String PackageVersion { get; set; }
            public System.String PatchVersion { get; set; }
            public System.Func<Amazon.Panorama.Model.ListNodesResponse, GetPANNodeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Nodes;
        }
        
    }
}
