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
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace Amazon.PowerShell.Cmdlets.CMPM
{
    /// <summary>
    /// Starts an asynchronous job to detect medical concepts and link them to the SNOMED-CT
    /// ontology. Use the DescribeSNOMEDCTInferenceJob operation to track the status of a
    /// job.
    /// </summary>
    [Cmdlet("Start", "CMPMSNOMEDCTInferenceJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Comprehend Medical StartSNOMEDCTInferenceJob API operation.", Operation = new[] {"StartSNOMEDCTInferenceJob"}, SelectReturnType = typeof(Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCMPMSNOMEDCTInferenceJobCmdlet : AmazonComprehendMedicalClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request. If you don't set the client request token, Amazon
        /// Comprehend Medical generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that grants Amazon Comprehend Medical read access to your input data. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para> The user generated name the asynchronous InferSNOMEDCT job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para> An AWS Key Management Service key used to encrypt your output files. If you do not
        /// specify a key, the files are written in plain text. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para> The language of the input documents. All documents must be in the same language.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ComprehendMedical.LanguageCode")]
        public Amazon.ComprehendMedical.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The URI of the S3 bucket that contains the input data. The bucket must be in the same
        /// region as the API endpoint that you are calling.</para><para>Each file in the document collection must be less than 40 KB. You can store a maximum
        /// of 30 GB in the bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InputDataConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>When you use the <code>OutputDataConfig</code> object with asynchronous operations,
        /// you specify the Amazon S3 location where you want to write the output data. The URI
        /// must be in the same region as the API endpoint that you are calling. The location
        /// is used as the prefix for the actual location of the output.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OutputDataConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Key
        /// <summary>
        /// <para>
        /// <para>The path to the input data files in the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_S3Key { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Key
        /// <summary>
        /// <para>
        /// <para>The path to the output data files in the S3 bucket. Comprehend Medical; creates an
        /// output directory using the job ID so that the output from one job does not overwrite
        /// the output of another.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_S3Key { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse).
        /// Specifying the name of a property of type Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataAccessRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CMPMSNOMEDCTInferenceJob (StartSNOMEDCTInferenceJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse, StartCMPMSNOMEDCTInferenceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_S3Bucket = this.InputDataConfig_S3Bucket;
            #if MODULAR
            if (this.InputDataConfig_S3Bucket == null && ParameterWasBound(nameof(this.InputDataConfig_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_S3Key = this.InputDataConfig_S3Key;
            context.JobName = this.JobName;
            context.KMSKey = this.KMSKey;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig_S3Bucket = this.OutputDataConfig_S3Bucket;
            #if MODULAR
            if (this.OutputDataConfig_S3Bucket == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig_S3Key = this.OutputDataConfig_S3Key;
            
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
            var request = new Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.ComprehendMedical.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_S3Bucket = null;
            if (cmdletContext.InputDataConfig_S3Bucket != null)
            {
                requestInputDataConfig_inputDataConfig_S3Bucket = cmdletContext.InputDataConfig_S3Bucket;
            }
            if (requestInputDataConfig_inputDataConfig_S3Bucket != null)
            {
                request.InputDataConfig.S3Bucket = requestInputDataConfig_inputDataConfig_S3Bucket;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_S3Key = null;
            if (cmdletContext.InputDataConfig_S3Key != null)
            {
                requestInputDataConfig_inputDataConfig_S3Key = cmdletContext.InputDataConfig_S3Key;
            }
            if (requestInputDataConfig_inputDataConfig_S3Key != null)
            {
                request.InputDataConfig.S3Key = requestInputDataConfig_inputDataConfig_S3Key;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.ComprehendMedical.Model.OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3Bucket = null;
            if (cmdletContext.OutputDataConfig_S3Bucket != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Bucket = cmdletContext.OutputDataConfig_S3Bucket;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Bucket != null)
            {
                request.OutputDataConfig.S3Bucket = requestOutputDataConfig_outputDataConfig_S3Bucket;
                requestOutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3Key = null;
            if (cmdletContext.OutputDataConfig_S3Key != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Key = cmdletContext.OutputDataConfig_S3Key;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Key != null)
            {
                request.OutputDataConfig.S3Key = requestOutputDataConfig_outputDataConfig_S3Key;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
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
        
        private Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse CallAWSServiceOperation(IAmazonComprehendMedical client, Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Comprehend Medical", "StartSNOMEDCTInferenceJob");
            try
            {
                #if DESKTOP
                return client.StartSNOMEDCTInferenceJob(request);
                #elif CORECLR
                return client.StartSNOMEDCTInferenceJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String InputDataConfig_S3Bucket { get; set; }
            public System.String InputDataConfig_S3Key { get; set; }
            public System.String JobName { get; set; }
            public System.String KMSKey { get; set; }
            public Amazon.ComprehendMedical.LanguageCode LanguageCode { get; set; }
            public System.String OutputDataConfig_S3Bucket { get; set; }
            public System.String OutputDataConfig_S3Key { get; set; }
            public System.Func<Amazon.ComprehendMedical.Model.StartSNOMEDCTInferenceJobResponse, StartCMPMSNOMEDCTInferenceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
