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
    /// Retrieves the pre-signed Amazon S3 download URL corresponding to an image layer. You
    /// can only get URLs for image layers that are referenced in an image.
    /// 
    ///  <note><para>
    /// This operation is used by the Amazon ECR proxy, and it is not intended for general
    /// use by customers for pulling and pushing images. In most cases, you should use the
    /// <code>docker</code> CLI to pull, tag, and push images.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ECRDownloadUrlForLayer")]
    [OutputType("Amazon.ECR.Model.GetDownloadUrlForLayerResponse")]
    [AWSCmdlet("Invokes the GetDownloadUrlForLayer operation against Amazon EC2 Container Registry.", Operation = new[] {"GetDownloadUrlForLayer"})]
    [AWSCmdletOutput("Amazon.ECR.Model.GetDownloadUrlForLayerResponse",
        "This cmdlet returns a Amazon.ECR.Model.GetDownloadUrlForLayerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECRDownloadUrlForLayerCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter LayerDigest
        /// <summary>
        /// <para>
        /// <para>The digest of the image layer to download.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LayerDigest { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID associated with the registry that contains the image layer to download.
        /// If you do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that is associated with the image layer to download.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
            
            context.LayerDigest = this.LayerDigest;
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
            var request = new Amazon.ECR.Model.GetDownloadUrlForLayerRequest();
            
            if (cmdletContext.LayerDigest != null)
            {
                request.LayerDigest = cmdletContext.LayerDigest;
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
        
        private Amazon.ECR.Model.GetDownloadUrlForLayerResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.GetDownloadUrlForLayerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "GetDownloadUrlForLayer");
            #if DESKTOP
            return client.GetDownloadUrlForLayer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDownloadUrlForLayerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String LayerDigest { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
