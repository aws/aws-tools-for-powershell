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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.ECR;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Uploads an image layer part to Amazon ECR.
    /// 
    ///  <note><para>
    /// This operation is used by the Amazon ECR proxy, and it is not intended for general
    /// use by customers. Use the <code>docker</code> CLI to pull, tag, and push images.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "ECRLayerPart", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = ParamSet_FromTextBlob)]
    [OutputType("Amazon.ECR.Model.UploadLayerPartResponse")]
    [AWSCmdlet("Invokes the UploadLayerPart operation against Amazon EC2 Container Registry.", Operation = new[] {"UploadLayerPart"})]
    [AWSCmdletOutput("Amazon.ECR.Model.UploadLayerPartResponse",
        "This cmdlet returns a Amazon.ECR.Model.UploadLayerPartResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendECRLayerPartCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        const string ParamSet_FromTextBlob = "FromTextBlob";
        const string ParamSet_FromBytes = "FromBytes";
        const string ParamSet_FromStream = "FromStream";

        #region Parameter LayerPartBlob
        /// <summary>
        /// The layer part payload as text. The supplied value will be encoded as a base-64 string 
        /// by the cmdlet prior to upload.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipeline = true, ParameterSetName = ParamSet_FromTextBlob, Mandatory = true)]
        public System.String LayerPartBlob { get; set; }
        #endregion

        #region Parameter LayerPartBytes
        /// <summary>
        /// The layer part payload as a byte array. The supplied value will be encoded as a base-64 string 
        /// by the cmdlet prior to upload.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipeline = true, ParameterSetName = ParamSet_FromBytes, Mandatory = true)]
        public byte[] LayerPartBytes { get; set; }
        #endregion

        #region Parameter LayerPartStream
        /// <summary>
        /// The base64-encoded layer part payload.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipeline = true, ParameterSetName = ParamSet_FromStream, Mandatory = true)]
        public System.IO.MemoryStream LayerPartStream { get; set; }
        #endregion

        #region Parameter PartFirstByte
        /// <summary>
        /// <para>
        /// <para>The integer value of the first byte of the layer part.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 PartFirstByte { get; set; }
        #endregion
        
        #region Parameter PartLastByte
        /// <summary>
        /// <para>
        /// <para>The integer value of the last byte of the layer part.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 PartLastByte { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID associated with the registry that you are uploading layer parts
        /// to. If you do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that you are uploading layer parts to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The upload ID from a previous <a>InitiateLayerUpload</a> operation to associate with
        /// the layer part upload.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RepositoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-ECRLayerPart (UploadLayerPart)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.LayerPartBlob = this.LayerPartBlob;
            context.LayerPartBytes = this.LayerPartBytes;

            if (ParameterWasBound("PartFirstByte"))
                context.PartFirstByte = this.PartFirstByte;
            if (ParameterWasBound("PartLastByte"))
                context.PartLastByte = this.PartLastByte;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            context.UploadId = this.UploadId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECR.Model.UploadLayerPartRequest();

            System.IO.MemoryStream layerPartStream = null;
            if (ParameterWasBound("LayerPartStream"))
                layerPartStream = cmdletContext.LayerPartStream;
            else
            {
                string base64Blob;
                if (ParameterWasBound("LayerPartBlob"))
                    base64Blob = Convert.ToBase64String(Encoding.UTF8.GetBytes(cmdletContext.LayerPartBlob));
                else
                    base64Blob = Convert.ToBase64String(cmdletContext.LayerPartBytes);

                var asBytes = Encoding.UTF8.GetBytes(base64Blob);
                var ms = new MemoryStream();
                ms.Write(asBytes, 0, asBytes.Length);
                ms.Seek(0, SeekOrigin.Begin);

                layerPartStream = ms;
            }

            request.LayerPartBlob = layerPartStream;

            if (cmdletContext.PartFirstByte != null)
            {
                request.PartFirstByte = cmdletContext.PartFirstByte.Value;
            }
            if (cmdletContext.PartLastByte != null)
            {
                request.PartLastByte = cmdletContext.PartLastByte.Value;
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

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            // issue call
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

        private Amazon.ECR.Model.UploadLayerPartResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.UploadLayerPartRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "UploadLayerPart");

            try
            {
#if DESKTOP
                return client.UploadLayerPart(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UploadLayerPartAsync(request);
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

        internal class CmdletContext : ExecutorContext
        {
            public System.String LayerPartBlob { get; set; }
            public byte[] LayerPartBytes { get; set; }
            public System.IO.MemoryStream LayerPartStream { get; set; }
            public System.Int64? PartFirstByte { get; set; }
            public System.Int64? PartLastByte { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String UploadId { get; set; }
        }
        
    }
}
