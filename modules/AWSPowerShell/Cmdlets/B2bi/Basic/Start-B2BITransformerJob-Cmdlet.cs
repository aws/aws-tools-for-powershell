/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Runs a job, using a transformer, to parse input EDI (electronic data interchange)
    /// file into the output structures used by Amazon Web Services B2B Data Interchange.
    /// 
    ///  
    /// <para>
    /// If you only want to transform EDI (electronic data interchange) documents, you don't
    /// need to create profiles, partnerships or capabilities. Just create and configure a
    /// transformer, and then run the <c>StartTransformerJob</c> API to process your files.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "B2BITransformerJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange StartTransformerJob API operation.", Operation = new[] {"StartTransformerJob"}, SelectReturnType = typeof(Amazon.B2bi.Model.StartTransformerJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.B2bi.Model.StartTransformerJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.B2bi.Model.StartTransformerJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartB2BITransformerJobCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputFile_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputFile_BucketName { get; set; }
        #endregion
        
        #region Parameter OutputLocation_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation_BucketName { get; set; }
        #endregion
        
        #region Parameter InputFile_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputFile_Key { get; set; }
        #endregion
        
        #region Parameter OutputLocation_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation_Key { get; set; }
        #endregion
        
        #region Parameter TransformerId
        /// <summary>
        /// <para>
        /// <para>Specifies the system-assigned unique identifier for the transformer.</para>
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
        public System.String TransformerId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransformerJobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.StartTransformerJobResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.StartTransformerJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransformerJobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransformerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransformerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransformerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransformerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-B2BITransformerJob (StartTransformerJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.StartTransformerJobResponse, StartB2BITransformerJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransformerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.InputFile_BucketName = this.InputFile_BucketName;
            context.InputFile_Key = this.InputFile_Key;
            context.OutputLocation_BucketName = this.OutputLocation_BucketName;
            context.OutputLocation_Key = this.OutputLocation_Key;
            context.TransformerId = this.TransformerId;
            #if MODULAR
            if (this.TransformerId == null && ParameterWasBound(nameof(this.TransformerId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.B2bi.Model.StartTransformerJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate InputFile
            var requestInputFileIsNull = true;
            request.InputFile = new Amazon.B2bi.Model.S3Location();
            System.String requestInputFile_inputFile_BucketName = null;
            if (cmdletContext.InputFile_BucketName != null)
            {
                requestInputFile_inputFile_BucketName = cmdletContext.InputFile_BucketName;
            }
            if (requestInputFile_inputFile_BucketName != null)
            {
                request.InputFile.BucketName = requestInputFile_inputFile_BucketName;
                requestInputFileIsNull = false;
            }
            System.String requestInputFile_inputFile_Key = null;
            if (cmdletContext.InputFile_Key != null)
            {
                requestInputFile_inputFile_Key = cmdletContext.InputFile_Key;
            }
            if (requestInputFile_inputFile_Key != null)
            {
                request.InputFile.Key = requestInputFile_inputFile_Key;
                requestInputFileIsNull = false;
            }
             // determine if request.InputFile should be set to null
            if (requestInputFileIsNull)
            {
                request.InputFile = null;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.B2bi.Model.S3Location();
            System.String requestOutputLocation_outputLocation_BucketName = null;
            if (cmdletContext.OutputLocation_BucketName != null)
            {
                requestOutputLocation_outputLocation_BucketName = cmdletContext.OutputLocation_BucketName;
            }
            if (requestOutputLocation_outputLocation_BucketName != null)
            {
                request.OutputLocation.BucketName = requestOutputLocation_outputLocation_BucketName;
                requestOutputLocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_Key = null;
            if (cmdletContext.OutputLocation_Key != null)
            {
                requestOutputLocation_outputLocation_Key = cmdletContext.OutputLocation_Key;
            }
            if (requestOutputLocation_outputLocation_Key != null)
            {
                request.OutputLocation.Key = requestOutputLocation_outputLocation_Key;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.TransformerId != null)
            {
                request.TransformerId = cmdletContext.TransformerId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.B2bi.Model.StartTransformerJobResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.StartTransformerJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "StartTransformerJob");
            try
            {
                #if DESKTOP
                return client.StartTransformerJob(request);
                #elif CORECLR
                return client.StartTransformerJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String InputFile_BucketName { get; set; }
            public System.String InputFile_Key { get; set; }
            public System.String OutputLocation_BucketName { get; set; }
            public System.String OutputLocation_Key { get; set; }
            public System.String TransformerId { get; set; }
            public System.Func<Amazon.B2bi.Model.StartTransformerJobResponse, StartB2BITransformerJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransformerJobId;
        }
        
    }
}
