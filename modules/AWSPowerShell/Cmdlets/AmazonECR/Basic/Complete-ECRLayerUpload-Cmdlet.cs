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
    /// Inform Amazon ECR that the image layer upload for a specified registry, repository
    /// name, and upload ID, has completed. You can optionally provide a <code>sha256</code>
    /// digest of the image layer for data validation purposes.
    /// 
    ///  <note><para>
    /// This operation is used by the Amazon ECR proxy, and it is not intended for general
    /// use by customers for pulling and pushing images. In most cases, you should use the
    /// <code>docker</code> CLI to pull, tag, and push images.
    /// </para></note>
    /// </summary>
    [Cmdlet("Complete", "ECRLayerUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.CompleteLayerUploadResponse")]
    [AWSCmdlet("Invokes the CompleteLayerUpload operation against Amazon EC2 Container Registry.", Operation = new[] {"CompleteLayerUpload"})]
    [AWSCmdletOutput("Amazon.ECR.Model.CompleteLayerUploadResponse",
        "This cmdlet returns a Amazon.ECR.Model.CompleteLayerUploadResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CompleteECRLayerUploadCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter LayerDigest
        /// <summary>
        /// <para>
        /// <para>The <code>sha256</code> digest of the image layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("LayerDigests")]
        public System.String[] LayerDigest { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID associated with the registry to which to upload layers. If you
        /// do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository to associate with the image layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The upload ID from a previous <a>InitiateLayerUpload</a> operation to associate with
        /// the image layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UploadId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-ECRLayerUpload (CompleteLayerUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.LayerDigest != null)
            {
                context.LayerDigests = new List<System.String>(this.LayerDigest);
            }
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            context.UploadId = this.UploadId;
            
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
            var request = new Amazon.ECR.Model.CompleteLayerUploadRequest();
            
            if (cmdletContext.LayerDigests != null)
            {
                request.LayerDigests = cmdletContext.LayerDigests;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.UploadId != null)
            {
                request.UploadId = cmdletContext.UploadId;
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
        
        private static Amazon.ECR.Model.CompleteLayerUploadResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.CompleteLayerUploadRequest request)
        {
            #if DESKTOP
            return client.CompleteLayerUpload(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CompleteLayerUploadAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> LayerDigests { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String UploadId { get; set; }
        }
        
    }
}
