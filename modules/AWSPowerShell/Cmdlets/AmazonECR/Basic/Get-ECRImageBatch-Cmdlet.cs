/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets detailed information for specified images within a specified repository. Images
    /// are specified with either <code>imageTag</code> or <code>imageDigest</code>.
    /// </summary>
    [Cmdlet("Get", "ECRImageBatch")]
    [OutputType("Amazon.ECR.Model.BatchGetImageResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry BatchGetImage API operation.", Operation = new[] {"BatchGetImage"})]
    [AWSCmdletOutput("Amazon.ECR.Model.BatchGetImageResponse",
        "This cmdlet returns a Amazon.ECR.Model.BatchGetImageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECRImageBatchCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptedMediaType
        /// <summary>
        /// <para>
        /// <para>The accepted media types for the request.</para><para>Valid values: <code>application/vnd.docker.distribution.manifest.v1+json</code> |
        /// <code>application/vnd.docker.distribution.manifest.v2+json</code> | <code>application/vnd.oci.image.manifest.v1+json</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AcceptedMediaTypes")]
        public System.String[] AcceptedMediaType { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>A list of image ID references that correspond to images to describe. The format of
        /// the <code>imageIds</code> reference is <code>imageTag=tag</code> or <code>imageDigest=digest</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ImageIds")]
        public Amazon.ECR.Model.ImageIdentifier[] ImageId { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID associated with the registry that contains the images to describe.
        /// If you do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The repository that contains the images to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryName { get; set; }
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
            
            if (this.AcceptedMediaType != null)
            {
                context.AcceptedMediaTypes = new List<System.String>(this.AcceptedMediaType);
            }
            if (this.ImageId != null)
            {
                context.ImageIds = new List<Amazon.ECR.Model.ImageIdentifier>(this.ImageId);
            }
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
            var request = new Amazon.ECR.Model.BatchGetImageRequest();
            
            if (cmdletContext.AcceptedMediaTypes != null)
            {
                request.AcceptedMediaTypes = cmdletContext.AcceptedMediaTypes;
            }
            if (cmdletContext.ImageIds != null)
            {
                request.ImageIds = cmdletContext.ImageIds;
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
        
        private Amazon.ECR.Model.BatchGetImageResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.BatchGetImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "BatchGetImage");
            try
            {
                #if DESKTOP
                return client.BatchGetImage(request);
                #elif CORECLR
                return client.BatchGetImageAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AcceptedMediaTypes { get; set; }
            public List<Amazon.ECR.Model.ImageIdentifier> ImageIds { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
