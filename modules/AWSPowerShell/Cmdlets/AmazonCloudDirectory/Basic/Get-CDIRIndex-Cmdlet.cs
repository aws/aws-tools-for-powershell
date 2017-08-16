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
    /// Lists objects attached to the specified index.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CDIRIndex")]
    [OutputType("Amazon.CloudDirectory.Model.IndexAttachment")]
    [AWSCmdlet("Invokes the ListIndex operation against AWS Cloud Directory.", Operation = new[] {"ListIndex"})]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.IndexAttachment",
        "This cmdlet returns a collection of IndexAttachment objects.",
        "The service call response (type Amazon.CloudDirectory.Model.ListIndexResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCDIRIndexCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
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
        /// <para>The ARN of the directory that the index exists in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter RangesOnIndexedValue
        /// <summary>
        /// <para>
        /// <para>Specifies the ranges of indexed values that you want to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RangesOnIndexedValues")]
        public Amazon.CloudDirectory.Model.ObjectAttributeRange[] RangesOnIndexedValue { get; set; }
        #endregion
        
        #region Parameter IndexReference_Selector
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
        public System.String IndexReference_Selector { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to retrieve from the index.</para>
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
            context.IndexReference_Selector = this.IndexReference_Selector;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.RangesOnIndexedValue != null)
            {
                context.RangesOnIndexedValues = new List<Amazon.CloudDirectory.Model.ObjectAttributeRange>(this.RangesOnIndexedValue);
            }
            
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
            var request = new Amazon.CloudDirectory.Model.ListIndexRequest();
            
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate IndexReference
            bool requestIndexReferenceIsNull = true;
            request.IndexReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestIndexReference_indexReference_Selector = null;
            if (cmdletContext.IndexReference_Selector != null)
            {
                requestIndexReference_indexReference_Selector = cmdletContext.IndexReference_Selector;
            }
            if (requestIndexReference_indexReference_Selector != null)
            {
                request.IndexReference.Selector = requestIndexReference_indexReference_Selector;
                requestIndexReferenceIsNull = false;
            }
             // determine if request.IndexReference should be set to null
            if (requestIndexReferenceIsNull)
            {
                request.IndexReference = null;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.RangesOnIndexedValues != null)
            {
                request.RangesOnIndexedValues = cmdletContext.RangesOnIndexedValues;
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
                        object pipelineOutput = response.IndexAttachments;
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
                            int _receivedThisCall = response.IndexAttachments.Count;
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
        
        private Amazon.CloudDirectory.Model.ListIndexResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.ListIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "ListIndex");
            try
            {
                #if DESKTOP
                return client.ListIndex(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListIndexAsync(request);
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
            public System.String IndexReference_Selector { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.CloudDirectory.Model.ObjectAttributeRange> RangesOnIndexedValues { get; set; }
        }
        
    }
}
