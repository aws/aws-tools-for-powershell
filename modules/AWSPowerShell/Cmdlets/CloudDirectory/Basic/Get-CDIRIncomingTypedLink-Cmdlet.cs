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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Returns a paginated list of all the incoming <a>TypedLinkSpecifier</a> information
    /// for an object. It also supports filtering by typed link facet and identity attributes.
    /// For more information, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_links.html#directory_objects_links_typedlink">Typed
    /// Links</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CDIRIncomingTypedLink")]
    [OutputType("Amazon.CloudDirectory.Model.TypedLinkSpecifier")]
    [AWSCmdlet("Calls the Amazon Cloud Directory ListIncomingTypedLinks API operation.", Operation = new[] {"ListIncomingTypedLinks"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse))]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.TypedLinkSpecifier or Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse",
        "This cmdlet returns a collection of Amazon.CloudDirectory.Model.TypedLinkSpecifier objects.",
        "The service call response (type Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCDIRIncomingTypedLinkCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConsistencyLevel
        /// <summary>
        /// <para>
        /// <para>The consistency level to execute the request at.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudDirectory.ConsistencyLevel")]
        public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the directory where you want to list the typed links.</para>
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
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter FilterAttributeRange
        /// <summary>
        /// <para>
        /// <para>Provides range filters for multiple attributes. When providing ranges to typed link
        /// selection, any inexact ranges must be specified at the end. Any attributes that do
        /// not have a range specified are presumed to match the entire range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterAttributeRanges")]
        public Amazon.CloudDirectory.Model.TypedLinkAttributeRange[] FilterAttributeRange { get; set; }
        #endregion
        
        #region Parameter FilterTypedLink_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterTypedLink_SchemaArn { get; set; }
        #endregion
        
        #region Parameter ObjectReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_access_objects.html">Access
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier. To identify an object with ObjectIdentifier,
        /// the ObjectIdentifier must be wrapped in double quotes. </para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter FilterTypedLink_TypedLinkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterTypedLink_TypedLinkName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LinkSpecifiers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse).
        /// Specifying the name of a property of type Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LinkSpecifiers";
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
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse, GetCDIRIncomingTypedLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConsistencyLevel = this.ConsistencyLevel;
            context.DirectoryArn = this.DirectoryArn;
            #if MODULAR
            if (this.DirectoryArn == null && ParameterWasBound(nameof(this.DirectoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterAttributeRange != null)
            {
                context.FilterAttributeRange = new List<Amazon.CloudDirectory.Model.TypedLinkAttributeRange>(this.FilterAttributeRange);
            }
            context.FilterTypedLink_SchemaArn = this.FilterTypedLink_SchemaArn;
            context.FilterTypedLink_TypedLinkName = this.FilterTypedLink_TypedLinkName;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ObjectReference_Selector = this.ObjectReference_Selector;
            
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
            var request = new Amazon.CloudDirectory.Model.ListIncomingTypedLinksRequest();
            
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.FilterAttributeRange != null)
            {
                request.FilterAttributeRanges = cmdletContext.FilterAttributeRange;
            }
            
             // populate FilterTypedLink
            var requestFilterTypedLinkIsNull = true;
            request.FilterTypedLink = new Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName();
            System.String requestFilterTypedLink_filterTypedLink_SchemaArn = null;
            if (cmdletContext.FilterTypedLink_SchemaArn != null)
            {
                requestFilterTypedLink_filterTypedLink_SchemaArn = cmdletContext.FilterTypedLink_SchemaArn;
            }
            if (requestFilterTypedLink_filterTypedLink_SchemaArn != null)
            {
                request.FilterTypedLink.SchemaArn = requestFilterTypedLink_filterTypedLink_SchemaArn;
                requestFilterTypedLinkIsNull = false;
            }
            System.String requestFilterTypedLink_filterTypedLink_TypedLinkName = null;
            if (cmdletContext.FilterTypedLink_TypedLinkName != null)
            {
                requestFilterTypedLink_filterTypedLink_TypedLinkName = cmdletContext.FilterTypedLink_TypedLinkName;
            }
            if (requestFilterTypedLink_filterTypedLink_TypedLinkName != null)
            {
                request.FilterTypedLink.TypedLinkName = requestFilterTypedLink_filterTypedLink_TypedLinkName;
                requestFilterTypedLinkIsNull = false;
            }
             // determine if request.FilterTypedLink should be set to null
            if (requestFilterTypedLinkIsNull)
            {
                request.FilterTypedLink = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate ObjectReference
            var requestObjectReferenceIsNull = true;
            request.ObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestObjectReference_objectReference_Selector = null;
            if (cmdletContext.ObjectReference_Selector != null)
            {
                requestObjectReference_objectReference_Selector = cmdletContext.ObjectReference_Selector;
            }
            if (requestObjectReference_objectReference_Selector != null)
            {
                request.ObjectReference.Selector = requestObjectReference_objectReference_Selector;
                requestObjectReferenceIsNull = false;
            }
             // determine if request.ObjectReference should be set to null
            if (requestObjectReferenceIsNull)
            {
                request.ObjectReference = null;
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
        
        private Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.ListIncomingTypedLinksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "ListIncomingTypedLinks");
            try
            {
                return client.ListIncomingTypedLinksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
            public System.String DirectoryArn { get; set; }
            public List<Amazon.CloudDirectory.Model.TypedLinkAttributeRange> FilterAttributeRange { get; set; }
            public System.String FilterTypedLink_SchemaArn { get; set; }
            public System.String FilterTypedLink_TypedLinkName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ObjectReference_Selector { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.ListIncomingTypedLinksResponse, GetCDIRIncomingTypedLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LinkSpecifiers;
        }
        
    }
}
