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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Retrieves the results of the specified lifecycle policy preview request.
    /// </summary>
    [Cmdlet("Get", "ECRLifecyclePolicyPreview")]
    [OutputType("Amazon.ECR.Model.GetLifecyclePolicyPreviewResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry GetLifecyclePolicyPreview API operation.", Operation = new[] {"GetLifecyclePolicyPreview"})]
    [AWSCmdletOutput("Amazon.ECR.Model.GetLifecyclePolicyPreviewResponse",
        "This cmdlet returns a Amazon.ECR.Model.GetLifecyclePolicyPreviewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECRLifecyclePolicyPreviewCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The list of imageIDs to be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ImageIds")]
        public Amazon.ECR.Model.ImageIdentifier[] ImageId { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID associated with the registry that contains the repository. If you
        /// do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository with the policy to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Filter_TagStatus
        /// <summary>
        /// <para>
        /// <para>The tag status of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECR.TagStatus")]
        public Amazon.ECR.TagStatus Filter_TagStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of repository results returned by <code>GetLifecyclePolicyPreviewRequest</code>
        /// in  paginated output. When this parameter is used, <code>GetLifecyclePolicyPreviewRequest</code>
        /// only returns  <code>maxResults</code> results in a single page along with a
        /// <code>nextToken</code>  response element. The remaining results of the initial
        /// request can be seen by sending  another <code>GetLifecyclePolicyPreviewRequest</code>
        /// request with the returned <code>nextToken</code>  value. This value can be between
        /// 1 and 100. If this  parameter is not used, then <code>GetLifecyclePolicyPreviewRequest</code>
        /// returns up to  100 results and a <code>nextToken</code> value, if  applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> value returned from a previous paginated  <code>GetLifecyclePolicyPreviewRequest</code>
        /// request where <code>maxResults</code> was used and the  results exceeded the
        /// value of that parameter. Pagination continues from the end of the  previous
        /// results that returned the <code>nextToken</code> value. This value is  <code>null</code>
        /// when there are no more results to return.</para>
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
            
            context.Filter_TagStatus = this.Filter_TagStatus;
            if (this.ImageId != null)
            {
                context.ImageIds = new List<Amazon.ECR.Model.ImageIdentifier>(this.ImageId);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            
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
            var request = new Amazon.ECR.Model.GetLifecyclePolicyPreviewRequest();
            
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.ECR.Model.LifecyclePolicyPreviewFilter();
            Amazon.ECR.TagStatus requestFilter_filter_TagStatus = null;
            if (cmdletContext.Filter_TagStatus != null)
            {
                requestFilter_filter_TagStatus = cmdletContext.Filter_TagStatus;
            }
            if (requestFilter_filter_TagStatus != null)
            {
                request.Filter.TagStatus = requestFilter_filter_TagStatus;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.ImageIds != null)
            {
                request.ImageIds = cmdletContext.ImageIds;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.ECR.Model.GetLifecyclePolicyPreviewResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.GetLifecyclePolicyPreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "GetLifecyclePolicyPreview");
            try
            {
                #if DESKTOP
                return client.GetLifecyclePolicyPreview(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetLifecyclePolicyPreviewAsync(request);
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
            public Amazon.ECR.TagStatus Filter_TagStatus { get; set; }
            public List<Amazon.ECR.Model.ImageIdentifier> ImageIds { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
