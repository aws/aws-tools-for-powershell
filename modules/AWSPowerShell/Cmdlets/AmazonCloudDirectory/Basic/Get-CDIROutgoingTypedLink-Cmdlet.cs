/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Returns a paginated list of all the outgoing <a>TypedLinkSpecifier</a> information
    /// for an object. It also supports filtering by typed link facet and identity attributes.
    /// For more information, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/objectsandlinks.html#typedlink">Typed
    /// link</a>.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CDIROutgoingTypedLink")]
    [OutputType("Amazon.CloudDirectory.Model.TypedLinkSpecifier")]
    [AWSCmdlet("Calls the AWS Cloud Directory ListOutgoingTypedLinks API operation.", Operation = new[] {"ListOutgoingTypedLinks"})]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.TypedLinkSpecifier",
        "This cmdlet returns a collection of TypedLinkSpecifier objects.",
        "The service call response (type Amazon.CloudDirectory.Model.ListOutgoingTypedLinksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCDIROutgoingTypedLinkCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter ConsistencyLevel
        /// <summary>
        /// <para>
        /// <para>The consistency level to execute the request at.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudDirectory.ConsistencyLevel")]
        public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the directory where you want to list the typed links.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String FilterTypedLink_SchemaArn { get; set; }
        #endregion
        
        #region Parameter ObjectReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/objectsandlinks.html#accessingobjects">Accessing
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter FilterTypedLink_TypedLinkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterTypedLink_TypedLinkName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConsistencyLevel = this.ConsistencyLevel;
            context.DirectoryArn = this.DirectoryArn;
            if (this.FilterAttributeRange != null)
            {
                context.FilterAttributeRanges = new List<Amazon.CloudDirectory.Model.TypedLinkAttributeRange>(this.FilterAttributeRange);
            }
            context.FilterTypedLink_SchemaArn = this.FilterTypedLink_SchemaArn;
            context.FilterTypedLink_TypedLinkName = this.FilterTypedLink_TypedLinkName;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
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
            
            // create request and set iteration invariants
            var request = new Amazon.CloudDirectory.Model.ListOutgoingTypedLinksRequest();
            
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.FilterAttributeRanges != null)
            {
                request.FilterAttributeRanges = cmdletContext.FilterAttributeRanges;
            }
            
             // populate FilterTypedLink
            bool requestFilterTypedLinkIsNull = true;
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
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            
             // populate ObjectReference
            bool requestObjectReferenceIsNull = true;
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
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.TypedLinkSpecifiers;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.TypedLinkSpecifiers.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudDirectory.Model.ListOutgoingTypedLinksResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.ListOutgoingTypedLinksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "ListOutgoingTypedLinks");
            try
            {
                #if DESKTOP
                return client.ListOutgoingTypedLinks(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListOutgoingTypedLinksAsync(request);
                return task.Result;
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
            public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
            public System.String DirectoryArn { get; set; }
            public List<Amazon.CloudDirectory.Model.TypedLinkAttributeRange> FilterAttributeRanges { get; set; }
            public System.String FilterTypedLink_SchemaArn { get; set; }
            public System.String FilterTypedLink_TypedLinkName { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String ObjectReference_Selector { get; set; }
        }
        
    }
}
