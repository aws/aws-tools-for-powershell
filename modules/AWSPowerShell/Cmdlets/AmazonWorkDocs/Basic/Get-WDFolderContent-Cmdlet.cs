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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Describes the contents of the specified folder, including its documents and subfolders.
    /// 
    ///  
    /// <para>
    /// By default, Amazon WorkDocs returns the first 100 active document and folder metadata
    /// items. If there are more results, the response includes a marker that you can use
    /// to request the next set of results. You can also request initialized documents.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WDFolderContent")]
    [OutputType("Amazon.WorkDocs.Model.DescribeFolderContentsResponse")]
    [AWSCmdlet("Invokes the DescribeFolderContents operation against Amazon WorkDocs.", Operation = new[] {"DescribeFolderContents"})]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.DescribeFolderContentsResponse",
        "This cmdlet returns a Amazon.WorkDocs.Model.DescribeFolderContentsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWDFolderContentCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. This field should not be set when using administrative
        /// API actions, as in accessing the API using AWS credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter FolderId
        /// <summary>
        /// <para>
        /// <para>The ID of the folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FolderId { get; set; }
        #endregion
        
        #region Parameter Include
        /// <summary>
        /// <para>
        /// <para>The contents to include. Specify "INITIALIZED" to include initialized documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Include { get; set; }
        #endregion
        
        #region Parameter Order
        /// <summary>
        /// <para>
        /// <para>The order for the contents of the folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.OrderType")]
        public Amazon.WorkDocs.OrderType Order { get; set; }
        #endregion
        
        #region Parameter Sort
        /// <summary>
        /// <para>
        /// <para>The sorting criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.ResourceSortType")]
        public Amazon.WorkDocs.ResourceSortType Sort { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.FolderContentType")]
        public Amazon.WorkDocs.FolderContentType Type { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return with this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results. This marker was received from a previous call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
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
            
            context.AuthenticationToken = this.AuthenticationToken;
            context.FolderId = this.FolderId;
            context.Include = this.Include;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Marker = this.Marker;
            context.Order = this.Order;
            context.Sort = this.Sort;
            context.Type = this.Type;
            
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
            var request = new Amazon.WorkDocs.Model.DescribeFolderContentsRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            if (cmdletContext.FolderId != null)
            {
                request.FolderId = cmdletContext.FolderId;
            }
            if (cmdletContext.Include != null)
            {
                request.Include = cmdletContext.Include;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.Order != null)
            {
                request.Order = cmdletContext.Order;
            }
            if (cmdletContext.Sort != null)
            {
                request.Sort = cmdletContext.Sort;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.WorkDocs.Model.DescribeFolderContentsResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.DescribeFolderContentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "DescribeFolderContents");
            #if DESKTOP
            return client.DescribeFolderContents(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeFolderContentsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AuthenticationToken { get; set; }
            public System.String FolderId { get; set; }
            public System.String Include { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String Marker { get; set; }
            public Amazon.WorkDocs.OrderType Order { get; set; }
            public Amazon.WorkDocs.ResourceSortType Sort { get; set; }
            public Amazon.WorkDocs.FolderContentType Type { get; set; }
        }
        
    }
}
