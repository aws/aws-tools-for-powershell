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
using Amazon.SageMakerRuntime;
using Amazon.SageMakerRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.SMR
{
    /// <summary>
    /// After you deploy a model into production using Amazon SageMaker hosting services,
    /// your client applications use this API to get inferences from the model hosted at the
    /// specified endpoint. 
    /// 
    ///  
    /// <para>
    /// For an overview of Amazon SageMaker, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/how-it-works.html">How
    /// It Works</a>. 
    /// </para><para>
    /// Amazon SageMaker strips all POST headers except those supported by the API. Amazon
    /// SageMaker might add additional headers. You should not rely on the behavior of headers
    /// outside those enumerated in the request syntax. 
    /// </para><para>
    /// Cals to <code>InvokeEndpoint</code> are authenticated by using AWS Signature Version
    /// 4. For information, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sig-v4-authenticating-requests.html">Authenticating
    /// Requests (AWS Signature Version 4)</a> in the <i>Amazon S3 API Reference</i>.
    /// </para><note><para>
    /// Endpoints are scoped to an individual account, and are not public. The URL does not
    /// contain the account ID, but Amazon SageMaker determines the account ID from the authentication
    /// token that is supplied by the caller.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "SMREndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerRuntime.Model.InvokeEndpointResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Runtime InvokeEndpoint API operation.", Operation = new[] {"InvokeEndpoint"})]
    [AWSCmdletOutput("Amazon.SageMakerRuntime.Model.InvokeEndpointResponse",
        "This cmdlet returns a Amazon.SageMakerRuntime.Model.InvokeEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSMREndpointCmdlet : AmazonSageMakerRuntimeClientCmdlet, IExecutor
    {
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The desired MIME type of the inference in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>Provides input data, in the format specified in the <code>ContentType</code> request
        /// header. Amazon SageMaker passes all of the data in the body to the model. </para><para>For information about the format of the request body, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/cdf-inference.html">Common
        /// Data Formats—Inference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Body { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter CustomAttribute
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CustomAttributes")]
        public System.String CustomAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint that you specified when you created the endpoint using the
        /// <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/API_CreateEndpoint.html">CreateEndpoint</a>
        /// API. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String EndpointName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EndpointName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMREndpoint (InvokeEndpoint)"))
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
            
            context.Accept = this.Accept;
            context.Body = this.Body;
            context.ContentType = this.ContentType;
            context.CustomAttributes = this.CustomAttribute;
            context.EndpointName = this.EndpointName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SageMakerRuntime.Model.InvokeEndpointRequest();
                
                if (cmdletContext.Accept != null)
                {
                    request.Accept = cmdletContext.Accept;
                }
                if (cmdletContext.Body != null)
                {
                    _BodyStream = new System.IO.MemoryStream(cmdletContext.Body);
                    request.Body = _BodyStream;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.CustomAttributes != null)
                {
                    request.CustomAttributes = cmdletContext.CustomAttributes;
                }
                if (cmdletContext.EndpointName != null)
                {
                    request.EndpointName = cmdletContext.EndpointName;
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
            finally
            {
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMakerRuntime.Model.InvokeEndpointResponse CallAWSServiceOperation(IAmazonSageMakerRuntime client, Amazon.SageMakerRuntime.Model.InvokeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Runtime", "InvokeEndpoint");
            try
            {
                #if DESKTOP
                return client.InvokeEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.InvokeEndpointAsync(request);
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
            public System.String Accept { get; set; }
            public byte[] Body { get; set; }
            public System.String ContentType { get; set; }
            public System.String CustomAttributes { get; set; }
            public System.String EndpointName { get; set; }
        }
        
    }
}
