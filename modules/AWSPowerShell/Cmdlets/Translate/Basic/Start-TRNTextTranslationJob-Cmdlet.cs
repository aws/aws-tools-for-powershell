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
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Starts an asynchronous batch translation job. Batch translation jobs can be used to
    /// translate large volumes of text across multiple documents at once. For more information,
    /// see <a>async</a>.
    /// 
    ///  
    /// <para>
    /// Batch translation jobs can be described with the <a>DescribeTextTranslationJob</a>
    /// operation, listed with the <a>ListTextTranslationJobs</a> operation, and stopped with
    /// the <a>StopTextTranslationJob</a> operation.
    /// </para><note><para>
    /// Amazon Translate does not support batch translation of multiple source languages at
    /// once.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "TRNTextTranslationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.StartTextTranslationJobResponse")]
    [AWSCmdlet("Calls the Amazon Translate StartTextTranslationJob API operation.", Operation = new[] {"StartTextTranslationJob"}, SelectReturnType = typeof(Amazon.Translate.Model.StartTextTranslationJobResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.StartTextTranslationJobResponse",
        "This cmdlet returns an Amazon.Translate.Model.StartTextTranslationJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartTRNTextTranslationJobCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        #region Parameter InputDataConfig_ContentType
        /// <summary>
        /// <para>
        /// <para>The multipurpose internet mail extension (MIME) type of the input files. Valid values
        /// are <code>text/plain</code> for plaintext files and <code>text/html</code> for HTML
        /// files.</para>
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
        public System.String InputDataConfig_ContentType { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS Identity Access and Management (IAM) role
        /// that grants Amazon Translate read access to your input data. For more nformation,
        /// see <a>identity-and-access-management</a>.</para>
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
        /// <para>The name of the batch translation job to be performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the AWS S3 folder that contains the input file. The folder must be in the
        /// same Region as the API endpoint you are calling.</para>
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
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the S3 folder that contains a translation job's output file. The folder
        /// must be in the same Region as the API endpoint that you are calling.</para>
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
        public System.String OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter SourceLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code of the input language. For a list of language codes, see <a>what-is-languages</a>.</para><para>Amazon Translate does not automatically detect a source language during batch translation
        /// jobs.</para>
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
        public System.String SourceLanguageCode { get; set; }
        #endregion
        
        #region Parameter TargetLanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code of the output language.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TargetLanguageCodes")]
        public System.String[] TargetLanguageCode { get; set; }
        #endregion
        
        #region Parameter TerminologyName
        /// <summary>
        /// <para>
        /// <para>The name of the terminology to use in the batch translation job. For a list of available
        /// terminologies, use the <a>ListTerminologies</a> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerminologyNames")]
        public System.String[] TerminologyName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token of the EC2 instance calling the request. This token is auto-generated
        /// when using the Amazon Translate SDK. Otherwise, use the <a href="docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeInstances.html">DescribeInstances</a>
        /// EC2 operation to retreive an instance's client token. For more information, see <a href="docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html#client-tokens">Client
        /// Tokens</a> in the EC2 User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Translate.Model.StartTextTranslationJobResponse).
        /// Specifying the name of a property of type Amazon.Translate.Model.StartTextTranslationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TRNTextTranslationJob (StartTextTranslationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.StartTextTranslationJobResponse, StartTRNTextTranslationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_ContentType = this.InputDataConfig_ContentType;
            #if MODULAR
            if (this.InputDataConfig_ContentType == null && ParameterWasBound(nameof(this.InputDataConfig_ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            #if MODULAR
            if (this.InputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.InputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            #if MODULAR
            if (this.OutputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceLanguageCode = this.SourceLanguageCode;
            #if MODULAR
            if (this.SourceLanguageCode == null && ParameterWasBound(nameof(this.SourceLanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetLanguageCode != null)
            {
                context.TargetLanguageCode = new List<System.String>(this.TargetLanguageCode);
            }
            #if MODULAR
            if (this.TargetLanguageCode == null && ParameterWasBound(nameof(this.TargetLanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetLanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TerminologyName != null)
            {
                context.TerminologyName = new List<System.String>(this.TerminologyName);
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
            // create request
            var request = new Amazon.Translate.Model.StartTextTranslationJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.Translate.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_ContentType = null;
            if (cmdletContext.InputDataConfig_ContentType != null)
            {
                requestInputDataConfig_inputDataConfig_ContentType = cmdletContext.InputDataConfig_ContentType;
            }
            if (requestInputDataConfig_inputDataConfig_ContentType != null)
            {
                request.InputDataConfig.ContentType = requestInputDataConfig_inputDataConfig_ContentType;
                requestInputDataConfigIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
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
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Translate.Model.OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Uri = cmdletContext.OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Uri != null)
            {
                request.OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3Uri;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.SourceLanguageCode != null)
            {
                request.SourceLanguageCode = cmdletContext.SourceLanguageCode;
            }
            if (cmdletContext.TargetLanguageCode != null)
            {
                request.TargetLanguageCodes = cmdletContext.TargetLanguageCode;
            }
            if (cmdletContext.TerminologyName != null)
            {
                request.TerminologyNames = cmdletContext.TerminologyName;
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
        
        private Amazon.Translate.Model.StartTextTranslationJobResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.StartTextTranslationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "StartTextTranslationJob");
            try
            {
                #if DESKTOP
                return client.StartTextTranslationJob(request);
                #elif CORECLR
                return client.StartTextTranslationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DataAccessRoleArn { get; set; }
            public System.String InputDataConfig_ContentType { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String JobName { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public System.String SourceLanguageCode { get; set; }
            public List<System.String> TargetLanguageCode { get; set; }
            public List<System.String> TerminologyName { get; set; }
            public System.Func<Amazon.Translate.Model.StartTextTranslationJobResponse, StartTRNTextTranslationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
